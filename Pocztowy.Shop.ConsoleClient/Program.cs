using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pocztowy.Shop.DbServices;
using Pocztowy.Shop.FakeServices;
using Pocztowy.Shop.Generator;
using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using System;
using System.IO;
using System.Linq;

namespace Pocztowy.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateOrderTest();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.development.json", optional: true)
                //.AddCommandLine(args)
                //.AddXmlFile("appsettings.xml")
                .Build();

            string connectionString = configuration.GetConnectionString("ShopConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(connectionString);

            ShopContext context = new ShopContext(optionsBuilder.Options);

            context.Database.EnsureCreated();

            string customers = configuration["Generator:Customers"];

            //generowanie danych
            Generator.Generator generator = new Generator.Generator();
            var products = generator.GetProducts(100);
            var services = generator.GetServices(100);

            context.Products.AddRange(products);
            context.Services.AddRange(services);
            context.SaveChanges();

            Console.WriteLine("Liczba klientów: " + customers);
            Console.ReadKey();
        }

        private static void CreateOrderTest()
        {
            Console.WriteLine("Witaj w naszym sklepie! ('_')");

            Console.WriteLine("Podaj id klienta:");
            int customerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj id produktu:");
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ilość:");
            int quantity = int.Parse(Console.ReadLine());

            //przygotowanie danych
            Generator.Generator generator = new Generator.Generator();
            ICustomersService customersService = new FakeCustomersService();
            IItemsService itemsService = new FakeItemsService();
            var customers = generator.GetCustomers(100);
            var products = generator.GetProducts(50);
            var services = generator.GetServices(50);

            //połączenie zbiorów
            var items = products.OfType<Item>().Concat(services).ToList();

            customersService.Add(customers);
            itemsService.Add(items);

            //pobranie danych
            Customer customer = customersService.Get(customerId);
            Item item = itemsService.Get(productId);

            Order order = new Order("ZA 001", customer);
            order.Details.Add(new OrderDetail(item, quantity));

            //var products = generator.GetProducts(10);
            //var services = generator.GetServices(10);
            //var customers = generator.GetCustomers(10);
        }
    }
}
