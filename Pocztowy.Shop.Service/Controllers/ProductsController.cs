using Microsoft.AspNetCore.Mvc;
using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using Pocztowy.Shop.Models.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var products = productsService.Get();
        //    return Ok(products);
        //}

        [HttpGet("{id:int}", Name = "GetProductLink")]
        public IActionResult Get(int id)
        {
            var product = productsService.Get(id);

            if (product == null)
                return NotFound();

            //HttpResponseMessage response = new HttpResponseMessage();
            //response.StatusCode = System.Net.HttpStatusCode.OK;

            return Ok(product);
        }

        [HttpGet("{color:alpha}")]
        public IActionResult Get(string color)
        {
            var products = productsService.GetByColor(color);

            return Ok(products);
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] ProductSearchCriteria criteria)
        {
            var products = productsService.Get(criteria);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            productsService.Add(product);

            //return Created($"https://localhost:44320/api/products/{product.Id}", product);
            return CreatedAtRoute("GetProductLink", new { id = product.Id }, product);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (Get(id) == null)
                return NotFound(id);

            productsService.Remove(id);

            return Ok(id);
        }
    }
}
