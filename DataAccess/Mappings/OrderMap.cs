using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TotalAmount)
                   .IsRequired()
                   .HasPrecision(18,2);
    
            builder.Property(x => x.OrderDate)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.UpdatedAt)
                   .IsRequired(false);
        }
    }
}
