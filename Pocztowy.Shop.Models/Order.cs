using System;
using System.Collections.Generic;

namespace Pocztowy.Shop.Models
{
    public class Order : Base
    {
        protected Order()
        {
            OrderDate = DateTime.Today;
            Details = new List<OrderDetail>();
        }

        public Order(string number, Customer customer)
            : this()
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
        
            Number = number;
            Customer = customer;
        }

        public DateTime OrderDate { get; set; }
        public string Number { get; set; }
        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public IList<OrderDetail> Details { get; set; }

    }
}
