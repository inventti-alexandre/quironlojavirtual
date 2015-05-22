using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoRespositorio _repositorio;

        // GET: Produtos
        public ActionResult Index()
        {
            _repositorio = new ProdutoRespositorio();
            var produtos = _repositorio.Produtos.Take(10);
            return View(produtos);
        }
    }
}