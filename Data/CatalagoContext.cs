using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Data
{
    public class CatalagoContext : DbContext
    {
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;

        public CatalagoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CatalagoContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            else
                optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Criacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Criacao").CurrentValue = DateTime.Now;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                  //  entry.Property("Criacao").IsModified = false;
                 //   entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Deleted)
                {
                    //desativar item
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Criacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Criacao").CurrentValue = DateTime.Now;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Criacao").IsModified = false;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Deleted)
                {
                    //desativar item
                }
            }

            return base.SaveChanges();
        }
    }
}
