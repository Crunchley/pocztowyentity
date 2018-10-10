using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pocztowy.Shop.DbServices
{
    public class DbCustomersService : DbEntitiesService<Customer>, ICustomersService
    {
        public DbCustomersService(ShopContext context) : base(context)
        {
        }

        public IList<Customer> Get(string name)
        {
            return context.Customers.Where(c => c.FullName == name).ToList();
        }
    }
}
