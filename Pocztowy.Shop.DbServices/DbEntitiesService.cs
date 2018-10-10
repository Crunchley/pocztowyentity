using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pocztowy.Shop.DbServices
{
    public class DbEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base, new()
    {
        protected readonly ShopContext context;
        public DbEntitiesService(ShopContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public virtual void Add(IList<TEntity> entities)
        {
            context.AddRange(entities);
            context.SaveChanges();
        }

        public virtual TEntity Get(int id) => context.Set<TEntity>().Find(id);

        public virtual IList<TEntity> Get() => context.Set<TEntity>().ToList();

        public virtual void Remove(int id)
        {
            //TEntity entity = Get(id);
            TEntity entity = new TEntity() { Id = id };
            context.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
