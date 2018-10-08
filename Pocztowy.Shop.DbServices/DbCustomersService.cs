using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pocztowy.Shop.DbServices
{
    public class DbCustomersService : ICustomersService
    {
        private readonly ShopContext context;

        public DbCustomersService(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public void Add(IList<Customer> entities)
        {
            context.Customers.AddRange(entities);
            context.SaveChanges();
        }

        public IList<Customer> Get(string name)
        {
            return context.Customers.Where(c => c.FullName == name).ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public IList<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public void Remove(int id)
        {
            var customer = Get(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            context.Customers.Update(entity);
            context.SaveChanges();
        }
    }
}
