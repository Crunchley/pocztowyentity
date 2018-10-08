using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pocztowy.Shop.FakeServices
{
    public class FakeCustomersService : FakeEntitiesService<Customer>, ICustomersService
    {
        public IList<Customer> Get(string name) => _entities.Where(e => e.FullName == name).ToList();
    }

    public class FakeItemsService : FakeEntitiesService<Item>, IItemsService
    {
        
    }

    public class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
    {
        protected IList<TEntity> _entities = new List<TEntity>();

        public virtual void Add(TEntity entity) => _entities.Add(entity);

        public virtual void Add(IList<TEntity> entities)
        {
            entities.ToList().ForEach(entity => Add(entity));
        }

        public virtual TEntity Get(int id) => _entities.SingleOrDefault(e => e.Id == id);

        public virtual IList<TEntity> Get() => _entities;

        public virtual void Remove(int id)
        {
            var entity = Get(id);
            _entities.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
