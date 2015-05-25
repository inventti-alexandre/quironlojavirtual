using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        // lista do carrinho
        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();

        // Adiciona itens ao carrinho
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                // novo produto - adiciona item ao carrinho
                _itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                // produto ja existente no carrinho - soma a quantidade
                item.Quantidade += quantidade;
            }
        }

        // Remove itens ao carrinho
        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        // Valor total adicionado ao carrinho
        public decimal ObterValorTotal()
        {
            return _itensCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        // Limpar o carrinho
        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

        // Itens do carrinho
        public List<ItemCarrinho> ItensCarrinho
        {
            get { return _itensCarrinho.ToList(); }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
