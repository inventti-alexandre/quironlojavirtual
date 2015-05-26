using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutoRespositorio _repositorio;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutoRespositorio();

            var produtos = _repositorio.Produtos.OrderBy(p => p.Nome);

            return View(produtos);
        }
    }
}