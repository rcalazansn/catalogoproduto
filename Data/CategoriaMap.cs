using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProdutos.Data
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tab_categotias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");
        }
    }
}