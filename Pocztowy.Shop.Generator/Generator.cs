using Bogus;
using Pocztowy.Shop.Models;
using System;
using System.Collections.Generic;

namespace Pocztowy.Shop.Generator
{
    public class Generator
    {
        public Faker<Product> FakeProducts => new Faker<Product>()
            .StrictMode(true)
            //.RuleFor(p => p.Id, f => f.IndexFaker)
            .Ignore(p => p.Id)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(p => p.Color, f => f.Commerce.Color())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .FinishWith((f, product) => Console.WriteLine($"Product {product.Name} was created."));

        public Faker<Service> FakeServices => new Faker<Service>()
            .StrictMode(true)
            //.RuleFor(s => s.Id, f => -f.IndexFaker)
            .Ignore(p => p.Id)
            .RuleFor(s => s.Name, f => f.Commerce.ProductName())
            .RuleFor(s => s.UnitPrice, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(s => s.Duration, f => f.Date.Timespan(TimeSpan.FromHours(4)))
            .FinishWith((f, service) => Console.WriteLine($"Service {service.Name} was created."));

        public Faker<Customer> FakeCustomers = new Faker<Customer>()
            .StrictMode(true)
            .RuleFor(c => c.Id, f => f.IndexFaker)
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .FinishWith((f, customer) => Console.WriteLine($"Customer {customer.FullName} was created."));

        public IList<Product> GetProducts(int count) => FakeProducts.Generate(count);
        public IList<Service> GetServices(int count) => FakeServices.Generate(count);
        public IList<Customer> GetCustomers(int count) => FakeCustomers.Generate(count);
    }
}
