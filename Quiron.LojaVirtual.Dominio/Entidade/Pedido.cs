using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Display(Name = "Nome do cliente:")]
        [Required(ErrorMessage="Informe seu nome")]
        public string NomeCliente { get; set; }

        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage="Informe o endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        [Display(Name="Cidade:")]
        [Required(ErrorMessage="Informe a cidade")]
        public string Cidade { get; set; }

        [Display(Name="Bairro:")]
        [Required(ErrorMessage="Informe o bairro")]
        public string Bairro { get; set; }

        [Display(Name="Estado:")]
        [Required(ErrorMessage="Informe o Estado")]
        public string Estado { get; set; }

        [Display(Name="E-mail:")]
        [Required(ErrorMessage="Informe seu e-mail")]
        [EmailAddress(ErrorMessage="E-mail inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Embrulhar para presente")]
        public bool EmbrulhaPresente { get; set; }
    }
}
