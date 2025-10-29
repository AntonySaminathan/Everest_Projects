using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTimeCalculator.Models
{
    public class OfferCategory
    {
        public string OfferCode { get; set; }
        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
