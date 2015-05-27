using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Dominio.Entidade;

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

        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutoRespositorio();

            var produto = _repositorio.Produtos
                .FirstOrDefault(x => x.ProdutoId == produtoId);

            return View(produto);
        }

        [HttpPost]
        public ViewResult Alterar(Produto produto)
        {
            return View(produto);
        }
    }
}