using Microsoft.AspNetCore.Mvc;
using Pocztowy.Shop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocztowy.Shop.Service.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Get()
        {
            var products = productsService.Get();
            return Ok(products);
        }
    }
}
