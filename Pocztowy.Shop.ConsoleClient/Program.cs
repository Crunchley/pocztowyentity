using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pocztowy.Shop.DbServices;
using Pocztowy.Shop.FakeServices;
using Pocztowy.Shop.Generator;
using Pocztowy.Shop.IServices;
using Pocztowy.Shop.Models;
using Pocztowy.Shop.Models.SearchCriteria;
using System;
using System.IO;
using System.Linq;

namespace Pocztowy.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextFactory contextFactory = new DbServices.ContextFactory();
            ShopContext context = contextFactory.CreateDbContext(args);


            IProductsService productsService = new DbProductsService(context);

            //productsService.Remove(20);

            ProductSearchCriteria productSearch = new ProductSearchCriteria
            {

            };
            var colorProducts = productsService.Get(productSearch);

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            context.Database.Migrate();

            for (int i = 2; i < 10; i++)
            {
                //CreateOrder(context, $"ZA {i}");
            }

            //var customers = context.Customers.ToList();
            //var products = context.Products
            //    .Where(p => p.UnitPrice > 100)
            //    .OrderBy(p => p.Name)
            //    .Select(p => new { p.Name, p.Color })
            //    .ToList();

            //var productsByColor = context.Products
            //    .GroupBy(p => p.Color)
            //    .ToList();

            //var productsQuantityByColor = context.Products
            //    .GroupBy(p => p.Color)
            //    .Select(g => new { Color = g.Key, Quantity = g.Count() })
            //    .ToList();

            //string customers = configuration["Generator:Customers"];

            //CreateSampleData(context);

            //Console.WriteLine("Liczba klientów: " + customers);
            Console.WriteLine("DONE");
            Console.ReadKey();

            var tuple = GetTuple();
        }

        private static void CreateOrder(ShopContext context, string orderNumber)
        {
            var customer = context.Customers.First();
            var order = new Order(orderNumber, customer);
            var product = context.Products.First();
            var service = context.Services.First();

            order.Details.Add(new OrderDetail(product));
            order.Details.Add(new OrderDetail(service));

            context.Orders.Add(order);
            context.SaveChanges();
        }

        private static (string name, string color) GetTuple()
        {
            return ("wine", "white");
        }

        private static void CreateSampleData(ShopContext context)
        {
            //generowanie danych
            Generator.Generator generator = new Generator.Generator();
            var products = generator.GetProducts(100);
            var services = generator.GetServices(100);
            var customers = generator.GetCustomers(10);

            context.Products.AddRange(products);
            context.Services.AddRange(services);
            context.Customers.AddRange(customers);
            context.SaveChanges();
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
