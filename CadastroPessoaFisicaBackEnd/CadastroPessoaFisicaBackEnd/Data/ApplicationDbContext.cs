using CadastroPessoaFisicaBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaFisicaBackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações para a classe Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Telefone>()
                .HasKey(t => new { t.Numero, t.DDD });

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Telefones)
                .HasForeignKey(t => t.UsuarioId);

            // Configurações para a classe PessoaFisica
            modelBuilder.Entity<PessoaFisica>()
                .HasKey(pf => pf.Id);

            modelBuilder.Entity<PessoaFisica>()
                .HasMany(pf => pf.Enderecos)
                .WithOne()
                .HasForeignKey(e => e.PessoaFisicaId);

            modelBuilder.Entity<PessoaFisica>()
                .HasMany(pf => pf.Contatos)
                .WithOne()
                .HasForeignKey(c => c.PessoaFisicaId);

            // Configurações para a classe Endereco
            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.PessoaFisica)
                .WithMany(pf => pf.Enderecos)
                .HasForeignKey(e => e.PessoaFisicaId);

            // Configurações para a classe Contato
            modelBuilder.Entity<Contato>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Contato>()
                .HasOne(c => c.PessoaFisica)
                .WithMany(pf => pf.Contatos)
                .HasForeignKey(c => c.PessoaFisicaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
