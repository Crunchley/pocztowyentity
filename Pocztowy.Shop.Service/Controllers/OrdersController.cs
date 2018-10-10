using Microsoft.AspNetCore.Mvc;
using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocztowy.Shop.Service.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;
        private readonly IOrderDetailsService orderDetailsService;

        public OrdersController(IOrdersService ordersService, IOrderDetailsService orderDetailsService)
        {
            this.ordersService = ordersService;
            this.orderDetailsService = orderDetailsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ordersService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ordersService.Get(id));
        }

        [HttpGet]
        [Route("{orderId}/details")]
        public IActionResult GetDetails(int orderId)
        {
            return Ok(orderDetailsService.GetByOrder(orderId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            ordersService.Add(order);

            return CreatedAtRoute(new { id = order.Id }, order);
        }
    }
}
