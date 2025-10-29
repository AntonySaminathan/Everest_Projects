using DeliveryCostCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostCalculator.Services
{
    public class OfferService: IOfferService
    {
        private readonly List<OfferCategory> _offerCategory;
        public OfferService()
        {
            _offerCategory = new List<OfferCategory>
            {
                new OfferCategory
                {
                    OfferCode = "OFR001",
                    MinDistance = 1,
                    MaxDistance = 200,
                    MinWeight = 70,
                    MaxWeight = 200,
                    DiscountPercentage = 10
                },
                new OfferCategory
                {
                    OfferCode = "OFR002",
                    MinDistance = 50,
                    MaxDistance = 150,
                    MinWeight = 100,
                    MaxWeight = 250,
                    DiscountPercentage = 7
                },
                new OfferCategory
                {
                    OfferCode = "OFR003",
                    MinDistance = 50,
                    MaxDistance = 250,
                    MinWeight = 10,
                    MaxWeight = 150,
                    DiscountPercentage = 5
                }
            };
        }

        public double GetDiscountPercentage(Package package)
        {
            var rule = _offerCategory.FirstOrDefault(o =>
                  o.OfferCode.Equals(package.OfferCode, System.StringComparison.OrdinalIgnoreCase) &&
                  package.Distance_KM >= o.MinDistance && package.Distance_KM <= o.MaxDistance &&
                  package.Weight_KG >= o.MinWeight && package.Weight_KG <= o.MaxWeight);

            return rule?.DiscountPercentage ?? 0;
        }
    }
}
