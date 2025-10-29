// See https://aka.ms/new-console-template for more information
using DeliveryTimeCalculator;
using DeliveryTimeCalculator.Models;
using DeliveryTimeCalculator.Services;

Console.WriteLine("Enter Base Delivery Cost:");
int baseDeliveryCost = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter number of packages:");
int packageCount = Convert.ToInt32(Console.ReadLine());

List<Package> packages = new List<Package>();

for (int i = 0; i < packageCount; i++)
{
    Console.WriteLine($"\nEnter The Details For Package {i + 1} (Format: Id Weight_KG Distance_KM OfferCode):");
    var input = Console.ReadLine()?.Split(' ');

    if (input == null || input.Length < 4)
    {
        Console.WriteLine("Invalid Input Format. Please Enter Valid Input.");
        i--;
        continue;
    }

    packages.Add(new Package
    {
        Id = input[0],
        Weight_KG = Convert.ToInt32(input[1]),
        Distance_KM = Convert.ToInt32(input[2]),
        OfferCode = input[3]
    });

}

Console.WriteLine("\nEnter Vehicle Details (Format: No_Of_Vehicles Vehicle_Speed Vehicle_Carriable_Weight):");
var vehicleDetails = Console.ReadLine()?.Split(' ');

if (vehicleDetails == null || vehicleDetails.Length < 3)
{
    Console.WriteLine("Invalid Input Format. Please Enter Valid Input.");
}

int NumberOfVehicles = Convert.ToInt32(vehicleDetails[0]);
double VehicleSpeed= Convert.ToDouble(vehicleDetails[1]);
int VehicleMaxLimit = Convert.ToInt32(vehicleDetails[2]);

double deliveryCost;
double discountPercent;

var offerService = new OfferService();
var costCalculator = new CostCalculator(offerService);

foreach (var package in packages)
{
    costCalculator.CalculateDeliveryCost(baseDeliveryCost, package, out deliveryCost, out discountPercent);
    double discountAmount = (deliveryCost * discountPercent) / 100;
    double totalCost = deliveryCost - discountAmount;
    double deliveryTime = Math.Round(Convert.ToDouble(package.Distance_KM / VehicleSpeed), 2);
    Console.WriteLine($"\nPackage : {package.Id}");
    Console.WriteLine($"Delivery Cost : {deliveryCost}");
    Console.WriteLine($"Discount : {discountAmount}");
    Console.WriteLine($"Total Cost : {totalCost}");
    Console.WriteLine($"Delivery Time : {deliveryTime}");
}
Console.ReadLine();