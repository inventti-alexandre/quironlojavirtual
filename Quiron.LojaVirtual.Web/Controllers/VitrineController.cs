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
        private int produtosPorPagina = 3;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutoRespositorio();
            var produtos = _repositorio.Produtos
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina);                

            return View(produtos);
        }
    }
}