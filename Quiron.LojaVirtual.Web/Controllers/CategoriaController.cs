using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutoRespositorio _repositorio;

        // GET: Categoria
        public PartialViewResult Menu(string categoria = null)
        {
            // instancia repositorio de produtos
            _repositorio = new ProdutoRespositorio();

            // lista de categorias
            IEnumerable<string> categorias = _repositorio.Produtos
                .Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c);

            // ViewBag
            ViewBag.CategoriaSelecionada = categoria;

            // retorna Menu view com IEnumerable de categorias
            return PartialView(categorias);
        }
    }
}