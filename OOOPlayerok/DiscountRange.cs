using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOOPlayerok
{
    internal class DiscountRange
    {
        public string DisplayName { get; set; }
        public double MinDiscount { get; set; }
        public double MaxDiscount { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
