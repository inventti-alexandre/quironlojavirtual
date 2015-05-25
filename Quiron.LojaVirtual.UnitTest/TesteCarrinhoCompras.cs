using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            // Arrange - criacao dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
            };

            // Arrange - adiciona itens ao carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            // Act - retorna lista adicionada ao carrinho
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            // Assert - compara itens adicionados ao retorno da lista
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }
    }
}
