using Pocztowy.Shop.Models;
using System.Collections.Generic;

namespace Pocztowy.Shop.IServices
{
    public interface IOrderDetailsService : IEntitiesService<OrderDetail>
    {
        IList<OrderDetail> GetByOrder(int orderId);
    }
}
