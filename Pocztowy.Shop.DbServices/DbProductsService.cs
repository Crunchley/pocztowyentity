using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using Pocztowy.Shop.Models.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Pocztowy.Shop.DbServices
{
    public class DbProductsService : DbEntitiesService<Product>, IProductsService
    {
        public DbProductsService(ShopContext context) : base(context)
        {
        }

        public IList<Product> Get(ProductSearchCriteria searchCriteria)
        {
            var products = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.Color))
            {
                products = products.Where(p => p.Color == searchCriteria.Color);
            }
            if (!string.IsNullOrEmpty(searchCriteria.Barcode))
            {
                products = products.Where(p => p.Barcode == searchCriteria.Barcode);
            }
            if (searchCriteria.UnitPrice.From.HasValue)
            {
                products = products.Where(p => p.UnitPrice >= searchCriteria.UnitPrice.From);
            }
            if (searchCriteria.UnitPrice.To.HasValue)
            {
                products = products.Where(p => p.UnitPrice <= searchCriteria.UnitPrice.To);
            }

            var colors = new List<string> { "Red", "Blue" };
            products.Where(p => colors.Contains(p.Color));

            return products.ToList();
        }

        public IList<Product> GetByColor(string color)
        {
            return context.Products.Where(p => p.Color == color).ToList();
        }
    }
}
