using Quiron.LojaVirtual.Dominio.Entidade;
using System.Collections.Generic;

namespace Quiron.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public Paginacao Paginacao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}