using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LojaT.Models.Entities;


namespace LojaT.Models.ViewModel
{
    public class ClienteGridViewModel
    {
        [Key]
        [DisplayName("id")]
        public int Id { get; set; }
        
        [DisplayName("Nome/Razão Social")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public bool Bloqueado { get; set; }

        public bool Selecionado { get; set; }

        public ClienteGridViewModel()
        {}

        public ClienteGridViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            DataCadastro = cliente.DataCadastro;
            Bloqueado = cliente.Bloqueado;
        }
    }
}
