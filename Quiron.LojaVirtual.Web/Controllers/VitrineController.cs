using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRespositorio _repositorio;

        // GET: Vitrine
        public ActionResult Index()
        {
            _repositorio = new ProdutoRespositorio();
            var produtos = _repositorio.Produtos;
            return View();
        }
    }
}