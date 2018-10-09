namespace Pocztowy.Shop.Models
{
    public class Product : Item
    {
        public string Color { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public float? Weight { get; set; }
    }
}
