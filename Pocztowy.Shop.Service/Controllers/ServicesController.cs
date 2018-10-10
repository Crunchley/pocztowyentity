using Microsoft.AspNetCore.Mvc;
using Pocztowy.Shop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocztowy.Shop.Service.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public IActionResult Get()
        {
            var services = servicesService.Get();
            return Ok(services);
        }
    }
}
