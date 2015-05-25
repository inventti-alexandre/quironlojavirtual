using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            // Arrange - criacao dos produtos
            var produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            var produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
            };

            // Arrange - adiciona itens ao carrinho
            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            // Act - retorna lista adicionada ao carrinho
            var itens = carrinho.ItensCarrinho.ToArray();

            // Assert - compara itens adicionados ao retorno da lista
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistenteAoCarrinho()
        {
            // Arrange - criacao dos produtos
            var produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            var produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
            };

            // Arrange - adiciona itens ao carrinho
            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            // Act
            var resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            // Assert
            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);
            Assert.AreEqual(resultado[1].Quantidade, 1);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            // Arrange - criacao dos produtos
            var produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            var produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
            };

            var produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3",
            };

            // Arrange - adiciona itens ao carrinho
            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            // Act
            carrinho.RemoverItem(produto2);

            // Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(c => c.Produto == produto2), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            // Arrange - criacao dos produtos
            var produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            var produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            // Act
            var resultado = carrinho.ObterValorTotal();

            // Assert
            Assert.AreEqual(resultado, 450);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            // Arrange - criacao dos produtos
            var produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            var produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            // Arrange - adiciona itens ao carrinho
            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);

            // Act - limpa o carrinho
            carrinho.LimparCarrinho();

            // Assert - verifica se o carrinho foi limpo
            Assert.AreEqual(carrinho.ItensCarrinho.Count, 0);
        }
    }
}
