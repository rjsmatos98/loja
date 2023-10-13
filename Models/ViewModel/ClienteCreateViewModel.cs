using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LojaT.Models.Entities;


namespace LojaT.Models.ViewModel
{
    public class ClienteCreateViewModel
    {        
        [Required(ErrorMessage = "Nome/Razão Social obrigaório!")]
        [Description("Nome completo ou Razão Social do Cliente")]
        [DisplayName("Nome do Cliente/Razão Social")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de e-mail válido.")]
        [Description("E-mail do Cliente")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório!")]
        [Description(" Telefone do Cliente")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [ReadOnly(true)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Tipo de Pessoa é obrigatório!")]
        [Description("Selecione o tipo de Pessoa")]
        [DisplayName("Tipo de Pessoa")]
        [RegularExpression(@"^(Jurídica|Física)$", ErrorMessage = "O campo Tipo deve ser 'Jurídica' ou 'Física'.")]
        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ é obrigatório!")]
        [MaxLength(18)]
        [Description("Insira o CPF ou o CNPJ do Cliente")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [MaxLength(15)]
        [Description("Inscrição Estadual do Cliente, selecionar Isento caso assim for")]
        [DisplayName("Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        public bool Isento { get; set; }

        [Description("Selecione o gênero do Cliente")]
        [DisplayName("Gênero")]
        [RegularExpression(@"^(Feminino|Masculino|Outro)$", ErrorMessage = "O campo Gênero deve ser 'Feminino', 'Masculino' ou 'Outro'.")]
        public string Genero { get; set; }

        [DataType(DataType.Date)]

        [Description("Data de Nascimento do Cliente")]
        [DisplayName("Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Description("Bloqueio o acesso do Cliente na sua Loja")]
        public bool Bloqueado { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Description("Cadastre a senha de acesso do seu Cliente")]
        [MaxLength(15, ErrorMessage = "A senha deve conter no máximo 15 caracteres")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracterres")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [MaxLength(15)]
        public string ConfirmarSenha { get; set; }

        public ClienteCreateViewModel()
        {}

        public ClienteCreateViewModel(Cliente cliente)
        {
            Nome = cliente.Nome;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            DataCadastro = cliente.DataCadastro;
            TipoPessoa = cliente.TipoPessoa;
            CpfCnpj = cliente.CpfCnpj;
            InscricaoEstadual = cliente.InscricaoEstadual;
            Isento = cliente.Isento;
            Genero = cliente.Genero;
            DataNascimento = cliente.DataNascimento;
            Bloqueado = cliente.Bloqueado;
            Senha = cliente.Senha;
        }
    }
}
