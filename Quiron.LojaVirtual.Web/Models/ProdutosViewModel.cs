using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public Paginacao Paginacao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}