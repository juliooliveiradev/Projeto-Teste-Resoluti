using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CadastroPessoaFisicaBackEnd.Models; // Certifique-se de substituir pelo namespace correto

namespace SeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Usuario model)
        {
            try
            {
                var usuarioExistente = await _userManager.FindByEmailAsync(model.Email);

                if (usuarioExistente != null)
                {
                    return BadRequest(new { message = "Email já existente" });
                }

                var novoUsuario = new Usuario
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Telefones = model.Telefones,
                    ImagePath = model.ImagePath
                };

                var result = await _userManager.CreateAsync(novoUsuario, model.Password);

                if (result.Succeeded)
                {
                    var token = GenerateToken(novoUsuario);
                    return Ok(new
                    {
                        id = novoUsuario.Id,
                        data_criacao = novoUsuario.CreatedAt,
                        data_atualizacao = novoUsuario.UpdatedAt,
                        ultimo_login = novoUsuario.LastLogin,
                        token
                    });
                }

                return BadRequest(new { message = "Erro ao criar usuário", errors = result.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao criar usuário", error = ex.Message });
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] Usuario model)
        {
            try
            {
                var usuarioExistente = await _userManager.FindByEmailAsync(model.Email);

                if (usuarioExistente == null || !await _userManager.CheckPasswordAsync(usuarioExistente, model.Password))
                {
                    return Unauthorized(new { message = "Usuário e/ou senha inválidos" });
                }

                usuarioExistente.LastLogin = DateTime.Now;
                await _userManager.UpdateAsync(usuarioExistente);

                var token = GenerateToken(usuarioExistente);

                return Ok(new
                {
                    id = usuarioExistente.Id,
                    data_criacao = usuarioExistente.CreatedAt,
                    data_atualizacao = usuarioExistente.UpdatedAt,
                    ultimo_login = usuarioExistente.LastLogin,
                    token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao autenticar usuário", error = ex.Message });
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound(new { message = "Usuário não encontrado" });
                }

                var tokenExpiration = user.LastLogin.AddMinutes(30);
                var currentTime = DateTime.Now;

                if (currentTime > tokenExpiration)
                {
                    return Unauthorized(new { message = "Sessão inválida. Token expirado." });
                }

                return Ok(new
                {
                    id = user.Id,
                    data_criacao = user.CreatedAt,
                    data_atualizacao = user.UpdatedAt,
                    ultimo_login = user.LastLogin
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao buscar usuário", error = ex.Message });
            }
        }

        private string GenerateToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
