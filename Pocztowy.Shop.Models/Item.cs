namespace Pocztowy.Shop.Models
{
    public abstract class Item : Base
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
