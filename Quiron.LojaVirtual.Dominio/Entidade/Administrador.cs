using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Administrador
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name="Login:")]
        [Required(ErrorMessage="Informe o login")]
        public string Login { get; set; }

        [Display(Name="Senha:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Informe a senha")]
        public string Senha { get; set; }

        [Display(Name="Último acesso em:")]
        public DateTime UltimoAcesso { get; set; }
    }
}
