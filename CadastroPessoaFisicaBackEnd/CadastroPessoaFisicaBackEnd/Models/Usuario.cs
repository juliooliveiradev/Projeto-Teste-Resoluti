using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoaFisicaBackEnd.Models
{
    public class Usuario : IdentityUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Telefone> Telefones { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
    }

    public class Telefone
    {
        public string Numero { get; set; }
        public string DDD { get; set; }

        // Adicione a propriedade UsuarioId como chave estrangeira
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
