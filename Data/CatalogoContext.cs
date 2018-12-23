using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiProdutos.Data
{
    public class CatalogoContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public CatalogoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("connectionString"));
            //$"{Configuration["connectionString"]}"
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}