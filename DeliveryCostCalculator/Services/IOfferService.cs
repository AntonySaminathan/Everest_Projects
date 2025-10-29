using DeliveryCostCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostCalculator.Services
{
    public interface IOfferService
    {
        double GetDiscountPercentage(Package package);
    }
}
