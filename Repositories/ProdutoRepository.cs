using System.Collections.Generic;
using System.Linq;
using ApiProdutos.Data;
using ApiProdutos.Models;
using ApiProdutos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Repositories
{
    public class ProdutoRepository
    {
        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public IEnumerable<ListaProdutosViewModel> Get()
        {
            var result = _context.Produtos
                       .Include(x => x.Categoria)
                       .Select(x => new ListaProdutosViewModel()
                       {
                           Id = x.Id,
                           Descricao = x.Descricao,
                           Preco = x.Preco,
                           Nome = x.Nome,
                           Categoria = x.Categoria.Descricao,
                           CategoriaId = x.CategoriaId
                       })
                       .AsNoTracking()
                       .ToList();

            return result;
        }

        public ListaProdutosViewModel Get(int id)
        {
            var result = _context.Produtos
                       .Include(x => x.Categoria)
                       .Select(x => new ListaProdutosViewModel()
                       {
                           Id = x.Id,
                           Descricao = x.Descricao,
                           Preco = x.Preco,
                           Nome = x.Nome,
                           Categoria = x.Categoria.Descricao,
                           CategoriaId = x.CategoriaId
                       })
                       .AsNoTracking()
                       .FirstOrDefault();

            return result;
        }
        public Produto Find(int id)
        {
            var result = _context.Produtos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            return result;
        }

        public void Insert(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Entry<Produto>(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }
    }
}