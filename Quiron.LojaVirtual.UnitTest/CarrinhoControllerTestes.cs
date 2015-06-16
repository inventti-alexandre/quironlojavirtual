using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Controllers;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);

            CarrinhoController controller = new CarrinhoController();

            // Action
            controller.Adicionar(carrinho, 2, "");

            // Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count, 1);
            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);
        }

        [TestMethod]
        public void AdicionoProdutoNoCarrinoVoltaparaCategoria()
        {
            // Arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            // Action
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }

        [TestMethod]
        public void PossoVerOConteudoDoCarrinho()
        {
            // Arrange
            var carrinho = new Carrinho();
            var controller = new CarrinhoController();

            // Action
            var resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;

            // Assert
            Assert.AreSame(resultado.Carrinho, carrinho);
            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
        }
    }
}
