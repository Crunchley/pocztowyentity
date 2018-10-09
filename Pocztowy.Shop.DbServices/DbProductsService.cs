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
    public class DbProductsService : IProductsService
    {
        private ShopContext context;

        public DbProductsService(ShopContext context)
        {
            this.context = context;
        }
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IList<Product> entities)
        {
            throw new NotImplementedException();
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
                products = products.Where(p => p.UnitPrice >= searchCriteria.UnitPrice.To);
            }

            var colors = new List<string> { "Red", "Blue" };
            products.Where(p => colors.Contains(p.Color));

            return products.ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public IList<Product> Get()
        {
            return context.Products.ToList();
        }

        public void Remove(int id)
        {
            Product product = new Product { Id = id };
            context.Entry(product).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
