using Pocztowy.Shop.Models;
using Pocztowy.Shop.Models.SearchCriteria;
using System.Collections.Generic;

namespace Pocztowy.Shop.IServices
{
    public interface IProductsService : IEntitiesService<Product>
    {
        IList<Product> Get(ProductSearchCriteria searchCriteria);

        IList<Product> GetByColor(string color);
    }
}
