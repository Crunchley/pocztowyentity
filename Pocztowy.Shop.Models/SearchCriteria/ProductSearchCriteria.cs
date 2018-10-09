using System;
using System.Collections.Generic;
using System.Text;

namespace Pocztowy.Shop.Models.SearchCriteria
{
    public class ProductSearchCriteria : SearchCriteria
    {
        public string Color { get; set; }
        public string Barcode { get; set; }
        public float? Weight { get; set; }

        public Range<decimal?> UnitPrice { get; set; }

        public ProductSearchCriteria()
        {
            UnitPrice = new Range<decimal?>();
        }
    }
}
