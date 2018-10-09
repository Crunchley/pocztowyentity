using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pocztowy.Shop.DbServices
{
    public class ContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.development.json", optional: true)
                .Build();

            string connectionString = configuration.GetConnectionString("ShopConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(connectionString);

            ShopContext context = new ShopContext(optionsBuilder.Options);

            return context;
        }
    }
}
