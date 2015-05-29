using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        [HiddenInput(DisplayValue=false)]
        public int ProdutoId { get; set; }
     
        [Display(Name="Nome do produto:")]
        [Required(ErrorMessage="Informe o nome do produto")]
        public string Nome { get; set; }
        
        [Display(Name="Descrição:")]
        [Required(ErrorMessage="Informe a descrição do produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name="Preço produto:")]
        [Required(ErrorMessage="Informe o preço do produto")]
        [Range(0.01,double.MaxValue,ErrorMessage="Valor do produto inválido")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Display(Name="Categoria:")]
        [Required(ErrorMessage="Informe a categoria do produto")]
        public string Categoria { get; set; }

        [Display(Name="Imagem:")]
        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }
    }
}
