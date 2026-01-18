using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMakers.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMakers.Products.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Category).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            
            // Add indexes for commonly filtered columns to improve query performance
            builder.HasIndex(p => p.Category);
            builder.HasIndex(p => p.IsActive);
            builder.HasIndex(p => p.Price);
            builder.HasIndex(p => p.CreatedDate);
        }
    }
}
