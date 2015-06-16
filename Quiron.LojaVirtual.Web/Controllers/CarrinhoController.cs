using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutoRespositorio _repositorio;

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            //var carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {

            //var carrinho = ObterCarrinho();
            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho esta vazio!");
            }

            if (ModelState.IsValid)
            {
                var email = new EmailConfiguracoes
                {
                    EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"]) == true ? true : false
                };

                var emailPedido = new EmailPedido(email);
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }

            return View(pedido);
        }

        public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new ProdutoRespositorio();

            var produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                //ObterCarrinho().AdicionarItem(produto, 1);
                carrinho.AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new ProdutoRespositorio();

            var produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                //ObterCarrinho().RemoverItem(produto);
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
        
        //private Carrinho ObterCarrinho()
        //{
        //    var carrinho = (Carrinho)Session["Carrinho"];
        //    if (carrinho == null)
        //    {
        //        carrinho = new Carrinho();
        //        Session["Carrinho"] = carrinho;
        //    }

        //    return carrinho;
        //}
    }
}