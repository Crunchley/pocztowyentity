using System;
using System.Collections.Generic;
using System.Text;

namespace Pocztowy.Shop.Models.SearchCriteria
{
    public class OrderSearchCriteria : SearchCriteria
    {
        public Range<DateTime?> Perdiod { get; set; }
    }
}
