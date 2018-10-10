using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;

namespace Pocztowy.Shop.IServices
{
    public interface ICustomersService : IEntitiesService<Customer>
    {
        IList<Customer> Get(string name);
    }
}
