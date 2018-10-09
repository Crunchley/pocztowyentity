using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pocztowy.Shop.DbServices.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.Color)
                .HasMaxLength(20);

            builder
                .Property(p => p.Barcode)
                .HasMaxLength(13)
                .IsUnicode(false);
        }
    }
}
