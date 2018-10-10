using System;

namespace Pocztowy.Shop.Models
{
    public class OrderDetail : Base
    {
        public OrderDetail()
        {

        }

        public OrderDetail(Item item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!(quantity > 0))
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            Item = item;
            Quantity = quantity;
            UnitPrice = item.UnitPrice;
        }

        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Order Order { get; set; }
    }
}
