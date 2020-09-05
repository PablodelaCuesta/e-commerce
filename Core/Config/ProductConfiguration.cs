using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Core.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Description).IsRequired().HasMaxLength(255);
            builder.Property(product => product.Price).HasColumnType("decimal(18,2)");
            builder.Property(product => product.PictureUrl).IsRequired();
            builder.HasOne(brand => brand.ProductBrand).WithMany()
                   .HasForeignKey(product => product.ProductBrandId);
            builder.HasOne(type => type.ProductType).WithMany()
                   .HasForeignKey(product => product.ProductBrandId);
        }
    }
}