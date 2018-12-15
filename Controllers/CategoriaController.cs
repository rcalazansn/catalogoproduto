using System.Collections.Generic;
using System.Linq;
using ApiProdutos.Data;
using ApiProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CatalogoContext _context;
        public CategoriaController(CatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/categorias")]
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet]
        [Route("v1/categorias/{id}")]
        public Categoria Get(int id)
        {
            return _context.Categorias.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            //Find(Id) não suporta
        }

        [HttpGet]
        [Route("v1/categorias/{id}/produtos")]
        public IEnumerable<Produto> GetProdutos(int id)
        {
            return _context.Produtos.AsNoTracking().Where(x => x.CategoriaId == id).ToList();
        }

        [HttpPost]
        [Route("v1/categorias")]
        public Categoria Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        [HttpPut]
        [Route("v1/categorias")]
        public Categoria Put([FromBody] Categoria categoria)
        {
            _context.Entry<Categoria>(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return categoria;
        }

        [HttpDelete]
        [Route("v1/categorias")]
        public Categoria Delete([FromBody] Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
    }
}