using System;
using System.Collections.Generic;
using System.Text;

namespace Pocztowy.Shop.Models.SearchCriteria
{
    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
}
