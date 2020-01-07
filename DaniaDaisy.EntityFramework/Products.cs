using System;
using Microsoft.EntityFrameworkCore;
namespace DaniaDaisy.EntityFramework
{
    public partial class Products
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public Boolean? IsOnline { get; set; }
    }

    public static partial class ModelBuilders
    {
        public static void SetupProductEntity(this ModelBuilder builder)
        {
            builder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProductCategory).HasMaxLength(255);

                entity.Property(e => e.ProductName).HasMaxLength(255);
            });
        }
    }
}
