using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;

namespace Pocztowy.Shop.IServices
{
    public interface ICustomersService : IEntitiesService<Customer>
    {
        IList<Customer> Get(string name);
    }

    public interface IItemsService : IEntitiesService<Item>
    {

    }

    public interface IOrdersService : IEntitiesService<Order>
    {

    }

    public interface IEntitiesService<TEntity>
        where TEntity : Base
    {
        TEntity Get(int id);
        IList<TEntity> Get();
        void Add(TEntity entity);
        void Add(IList<TEntity> entities);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
