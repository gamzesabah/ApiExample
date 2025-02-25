using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Mappings
    {
        public class ProductMap : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Id)
                       .ValueGeneratedOnAdd();

                builder.Property(p => p.Name)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(p => p.Description)
                       .HasMaxLength(1000);

                builder.Property(p => p.Category)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(p => p.ImageUrl)
                       .HasMaxLength(500);

                builder.Property(p => p.Price)
                       .IsRequired()
                       .HasPrecision(18, 2);

                builder.Property(p => p.StockQuantity)
                       .IsRequired();

                builder.Property(p => p.IsActive)
                       .IsRequired();

                builder.Property(p => p.CreatedAt)
                       .IsRequired();

                builder.Property(p => p.UpdatedAt)
                       .IsRequired(false);

                builder.HasMany(p => p.OrderItems)
                       .WithOne(oi => oi.Product)
                       .HasForeignKey(oi => oi.ProductId)
                       .OnDelete(DeleteBehavior.NoAction);
               
                builder.HasMany(p => p.CartItems)
                       .WithOne(ci => ci.Product)
                       .HasForeignKey(ci => ci.ProductId)
                       .OnDelete(DeleteBehavior.NoAction);
            }
    }
}
