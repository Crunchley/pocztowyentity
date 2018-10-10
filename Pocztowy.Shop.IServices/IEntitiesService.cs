using Pocztowy.Shop.Models;
using System.Collections.Generic;

namespace Pocztowy.Shop.IServices
{
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
