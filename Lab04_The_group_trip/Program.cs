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

//Part 1

Console.WriteLine("=== Part 1: Road Trip ===");
Console.Write("Round trip miles: ");
double totalMiles = Convert.ToDouble(Console.ReadLine());

Console.Write("Miles per gallon: ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("Price per gallon: ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

double gallonsNeeded = totalMiles / milesPerGallon;

Console.WriteLine("Gallons needed: " + gallonsNeeded.ToString("F2"));
Console.WriteLine($"Fuel cost:  + {FuelCost(totalMiles, milesPerGallon, pricePerGallon):C}");


//Part 2

System.Console.WriteLine();

//asking questions
Console.Write("How many pizzas: ");
int numberOfPizzas = Convert.ToInt32(Console.ReadLine());

Console.Write("Price per pizza: ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

//calculating
int totalSlices = numberOfPizzas * SLICES_PER_PIZZA;
double slicesPerPerson = (double)totalSlices / numberOfPeople;
double pizzaCost = numberOfPizzas * pricePerPizza;

Console.WriteLine("Total slices: " + totalSlices);
Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Total pizza cost: " + pizzaCost.ToString("C"));

//Part 3
Console.WriteLine();
Console.WriteLine("=== Part 3: Paycheck ===");


//calculating
double grossPay = hoursWorked * hourRate;
double taxWithheld = grossPay * TAX_RATE;
double takeHomePay = grossPay - taxWithheld;

Console.WriteLine("Gross pay: " + grossPay.ToString("C"));
Console.WriteLine("Tax withheld: " + taxWithheld.ToString("C"));
Console.WriteLine("Take home pay: " + takeHomePay.ToString("C"));




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