using Microsoft.AspNetCore.Mvc;
using Pocztowy.Shop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocztowy.Shop.Service.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        public IActionResult Get()
        {
            var customers = customersService.Get();
            return Ok(customers);
        }
    }
}
