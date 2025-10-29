using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTimeCalculator.Models
{
    public class Package
    {
        public string Id { get; set; }
        public int Weight_KG { get; set; }
        public int Distance_KM { get; set; }
        public string OfferCode { get; set; }
    }
}
