namespace CadastroPessoaFisicaBackEnd.Models
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string UserId { get; set; }  
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Contato> Contatos { get; set; }
    }

    // Endereco.cs
    public class Endereco
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    // Contato.cs
    public class Contato
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public TipoContato TipoContato { get; set; }
    }

    public enum TipoContato
    {
        Email,
        Telefone
    }
}
