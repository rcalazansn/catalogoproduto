using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tab_produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Criacao).IsRequired();
            builder.Property(x => x.Alteracao).IsRequired();
            builder.Property(x => x.Preco).IsRequired().HasColumnType("money");
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");

            builder.HasOne(x => x.Categoria).WithMany(x=>x.Produtos);
        }
    }
}