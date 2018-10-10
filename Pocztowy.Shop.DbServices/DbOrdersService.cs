using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pocztowy.Shop.DbServices
{
    public class DbOrdersService : DbEntitiesService<Order>, IOrdersService
    {
        public DbOrdersService(ShopContext context) : base(context)
        {

        }

        public override IList<Order> Get()
        {
            //var orders = context.Orders
            //    .Include(p => p.Customer)
            //    .Include(p => p.Details)
            //        .ThenInclude(p => p.Item)
            //    .ToList();

            var orders = context.Orders
                .Include(p => p.Customer)
                .ToList();

            return orders;
        }

        public override Order Get(int id)
        {
            var order = base.Get(id);

            string x = order.Customer.FullName;

            //var order = context.Orders
            //    .Include(p => p.Customer)
            //    .SingleOrDefault(p => p.Id == id);

            //jawne pobranie pojedynczego obiektu
            //context.Entry(order).Reference(p => p.Customer).Load();
            //jawne pobranie kolekcji obiektow
            //context.Entry(order).Collection(p => p.Details).Load();

            return order;
        }
    }
}
