using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pocztowy.Shop.DbServices;
using Pocztowy.Shop.IServices;

namespace Pocztowy.Shop.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("ShopConnection");

            services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductsService, DbProductsService>();
            services.AddScoped<ICustomersService, DbCustomersService>();
            services.AddScoped<IServicesService, DbServicesService>();
            services.AddScoped<IOrdersService, DbOrdersService>();
            services.AddScoped<IOrderDetailsService, DbOrderDetailsService>();

            services.AddMvc(options => options.RespectBrowserAcceptHeader = true)
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
