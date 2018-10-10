using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using Pocztowy.Shop.Models.SearchCriteria;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Pocztowy.Shop.DbServices
{
    public class DbServicesService : DbEntitiesService<Service>, IServicesService
    {
        public DbServicesService(ShopContext context) : base(context)
        {
        }
    }
}
