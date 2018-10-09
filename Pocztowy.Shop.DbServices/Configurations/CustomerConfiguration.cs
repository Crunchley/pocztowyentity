using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pocztowy.Shop.DbServices.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(p => p.Id); //p => { p.Id, p.LastName} dla klucza zlozonego

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(40);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
