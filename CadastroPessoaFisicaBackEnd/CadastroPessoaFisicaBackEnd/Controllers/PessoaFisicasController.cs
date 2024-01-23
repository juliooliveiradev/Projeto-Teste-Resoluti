using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroPessoaFisicaBackEnd.Data;
using CadastroPessoaFisicaBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CadastroPessoaFisicaBackEnd.Controllers
{
    [Authorize] // Apenas usuários autenticados podem acessar
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PessoaFisicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint para listar todas as pessoas físicas do usuário logado
        [HttpGet]
        public IActionResult Get()
        {
            // Recuperar o ID do usuário logado
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Buscar todas as pessoas físicas associadas a esse usuário
            var pessoasFisicas = _context.PessoasFisicas.Where(pf => pf.UserId == userId).ToList();

            return Ok(pessoasFisicas);
        }

        // Endpoint para obter detalhes de uma pessoa física específica
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoaFisica = _context.PessoasFisicas.Find(id);

            // Verificar se a pessoa pertence ao usuário logado
            if (pessoaFisica == null || pessoaFisica.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return NotFound("Pessoa física não encontrada");
            }

            return Ok(pessoaFisica);
        }

        // Endpoint para cadastrar uma nova pessoa física
        [HttpPost]
        public IActionResult Post([FromBody] PessoaFisica pessoaFisica)
        {
            // Definir o ID do usuário logado
            pessoaFisica.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _context.PessoasFisicas.Add(pessoaFisica);
            _context.SaveChanges();

            return Ok("Pessoa física cadastrada com sucesso");
        }

        // Endpoint para editar uma pessoa física existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PessoaFisica pessoaFisica)
        {
            var existingPessoaFisica = _context.PessoasFisicas.Find(id);

            // Verificar se a pessoa existe e pertence ao usuário logado
            if (existingPessoaFisica == null || existingPessoaFisica.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return NotFound("Pessoa física não encontrada");
            }

            // Atualizar os campos necessários
            existingPessoaFisica.Nome = pessoaFisica.Nome;
            existingPessoaFisica.Sobrenome = pessoaFisica.Sobrenome;
            existingPessoaFisica.DataNascimento = pessoaFisica.DataNascimento;
            existingPessoaFisica.Email = pessoaFisica.Email;
            existingPessoaFisica.CPF = pessoaFisica.CPF;
            existingPessoaFisica.RG = pessoaFisica.RG;
            existingPessoaFisica.Enderecos = pessoaFisica.Enderecos;
            existingPessoaFisica.Contatos = pessoaFisica.Contatos;
            // Atualizar outros campos conforme necessário

            _context.SaveChanges();

            return Ok("Pessoa física atualizada com sucesso");
        }

        // Endpoint para excluir uma pessoa física
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoaFisica = _context.PessoasFisicas.Find(id);

            // Verificar se a pessoa existe e pertence ao usuário logado
            if (pessoaFisica == null || pessoaFisica.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return NotFound("Pessoa física não encontrada");
            }

            _context.PessoasFisicas.Remove(pessoaFisica);
            _context.SaveChanges();

            return Ok("Pessoa física excluída com sucesso");
        }
    }
}
