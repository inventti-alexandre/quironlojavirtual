using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutoRespositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produto; }
        }

        // Grava produto
        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                // inclusao
                _context.Produto.Add(produto);
            }
            else
            {
                // alteracao
                var prod = _context.Produto.Find(produto.ProdutoId);
                if (prod != null)
                {
                    prod.Categoria = produto.Categoria;
                    prod.Descricao = produto.Descricao;
                    prod.Nome = produto.Nome;
                    prod.Preco = produto.Preco;
                }
            }

            // grava
            _context.SaveChanges();
        }

        // Exclui produto
        public Produto Excluir(int produtoId)
        {
            var produto = _context.Produto.Find(produtoId);

            if (produto != null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();
            }

            return produto;
        }
    }
}
