/*
* Name: Aaron Robinson
*Course CSCI 1250, Section 001
*Assignment Lab 02, Trip Calculator
*Date September 23, 2026
*Description: Calculates the fuel, food, and work hours behind one road trip.
*/

// CONSTANT IS HERE
const double TAX_RATE = 0.18;
const int SLICES_PER_PIZZA = 8;


string[] names = {"Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = {22, 15, 30, 18 };
double[] hourRate = {13.50, 16.00, 11.20, 14.80 };

int numberOfPeople = names.Length;

// Asking questions
Console.Write("Round trip miles: ");
double totalMiles = Convert.ToDouble(Console.ReadLine());

Console.Write("Miles per gallon: ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("Price per gallon: ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("How many pizzas: ");
int numberOfPizzas = Convert.ToInt32(Console.ReadLine());

Console.Write("Price per pizza: ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

// Calculations

// Find take home pay for each person and assigns it to an array
double[] takeHomePay = new double[numberOfPeople];
for(int i = 0; i < names.Length; i++)
{

    takeHomePay[i] = TakeHomePay(hoursWorked[i], hourRate[i], TAX_RATE);
}


double tripTotal = FuelCost();
double costPerPerson = tripTotal / numberOfPeople;
double takeHomePayPerHour = takeHomePay / hoursWorked;

double totalSlices = numberOfPizzas * SLICES_PER_PIZZA;

double pizzaCost = numberOfPizzas * pricePerPizza;

double slicesPerPerson = totalSlices / numberOfPeople;




Console.WriteLine("=== Part 1: The Trip ===");


Console.WriteLine($"Fuel cost:  + {FuelCost(totalMiles, milesPerGallon, pricePerGallon):C}");
Console.WriteLine($"Pizza cost:  + {pizzaCost:C}");
System.Console.WriteLine($"Trip total + {tripTotal:C}");


Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));
Console.WriteLine("Take home pay per hour: " + takeHomePayPerHour.ToString("C"));
Console.WriteLine($"Hours you must work to cover your share: + {HoursToCover(tripTotal, takeHomePayPerHour):F2}");





static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}


static double TakeHomePay(double hoursWorked, double hourRate, double taxRate)
{
    double grossPay = hoursWorked * hourRate;
    double taxWithheld = grossPay * TAX_RATE;
    double takeHomePay = grossPay - taxWithheld;

    return takeHomePay;
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    double total = amountOwed / takeHomePerHour;
    return total;
}