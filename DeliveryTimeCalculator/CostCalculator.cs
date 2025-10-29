using DeliveryTimeCalculator.Models;
using DeliveryTimeCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTimeCalculator
{
    public class CostCalculator
    {
        private readonly IOfferService _offerService;
        public CostCalculator(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public void CalculateDeliveryCost(double baseCost, Package package, out double deliveryCost, out double discountPercent)
        {
            deliveryCost = baseCost + (package.Weight_KG * 10) + (package.Distance_KM * 5);
            discountPercent = _offerService.GetDiscountPercentage(package);

        }

    }
}
