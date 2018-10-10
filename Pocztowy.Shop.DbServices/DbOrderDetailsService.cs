using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pocztowy.Shop.DbServices
{
    public class DbOrderDetailsService : DbEntitiesService<OrderDetail>, IOrderDetailsService
    {
        public DbOrderDetailsService(ShopContext context) : base(context)
        {
        }

        public IList<OrderDetail> GetByOrder(int orderId)
        {
            return context.OrderDetails.Where(p => p.Order.Id == orderId).ToList();
        }
    }
}
