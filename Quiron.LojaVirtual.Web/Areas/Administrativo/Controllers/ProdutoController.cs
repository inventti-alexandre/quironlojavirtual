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

        public ActionResult Alterar(int produtoId)
        {
            _repositorio = new ProdutoRespositorio();

            var produto = _repositorio.Produtos
                .FirstOrDefault(x => x.ProdutoId == produtoId);

            ViewBag.Operacao = "Alteração";
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new ProdutoRespositorio();
                _repositorio.Salvar(produto);

                TempData["mensagem"] = string.Format("{0} gravado", produto.Nome);

                return RedirectToAction("Index");
            }

            ViewBag.Operacao = "Alteração";
            return View(produto);
        }

        public ViewResult NovoProduto()
        {
            ViewBag.Operacao = "Inclusão";
            return View("Alterar", new Produto());
        }

        [HttpPost]
        public ActionResult Excluir(int produtoId)
        {
            _repositorio = new ProdutoRespositorio();

            var produto = _repositorio.Excluir(produtoId);

            if (produto != null)
            {
                TempData["mensagem"] = string.Format("Produto {0} excluído", produto.Nome);
            }

            return RedirectToAction("Index");
        }
    }
}