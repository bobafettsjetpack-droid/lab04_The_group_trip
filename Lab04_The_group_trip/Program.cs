/*
*Name: Aaron Robinson
*Course CSCI 1250, Section 001
*Assignment Lab 04, The Group Trip
*Date October 7, 2026
*Description: Rebuilds the trip calculator with methods and arrays so it reports on a whole group instead of one person.
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
System.Console.WriteLine();
// Calculations

// Find take home pay for each person and assigns it to an array
double[] takeHomePay = new double[numberOfPeople];
for(int i = 0; i < numberOfPeople; i++)
{

    takeHomePay[i] = TakeHomePay(hoursWorked[i], hourRate[i], TAX_RATE);
}

double totalSlices = numberOfPizzas * SLICES_PER_PIZZA;
double pizzaCost = numberOfPizzas * pricePerPizza;
double slicesPerPerson = totalSlices / numberOfPeople;

double tripTotal = FuelCost(totalMiles, milesPerGallon, pricePerGallon) + pizzaCost;
double costPerPerson = tripTotal / numberOfPeople;

// Array of take home pay per hour for each person in correct order
double[] takeHomePayPerHour = new double[numberOfPeople];
for(int i = 0; i < numberOfPeople; i++)
{
    takeHomePayPerHour[i] = takeHomePay[i] / hoursWorked[i];
}

//Outputs

// Part 1
Console.WriteLine("=== Part 1: The Trip ===");

Console.WriteLine($"Fuel cost: {FuelCost(totalMiles, milesPerGallon, pricePerGallon):C}");
Console.WriteLine($"Pizza cost:  + {pizzaCost:C}");
System.Console.WriteLine($"Trip total + {tripTotal:C}");
System.Console.WriteLine();

// Part 2
System.Console.WriteLine("=== Part 2: The Group ===");
System.Console.WriteLine($"People going: {numberOfPeople}");
System.Console.WriteLine($"Slices each: {slicesPerPerson:F1}");
System.Console.WriteLine($"Cost per person: {costPerPerson:C}");
System.Console.WriteLine();

// Part 3
System.Console.WriteLine("=== Part 3: Who Works How Long ===");

double[] mustWork = new double[numberOfPeople];
double[] takeHomePerHour = new double[numberOfPeople];
double totalTakeHomePay = 0;
double totalHours = 0;

for(int i = 0; i < numberOfPeople; i++)
{
    takeHomePerHour[i] = takeHomePay[i] / hoursWorked[i];
}


// Get the longest number from the must work array
double longest = 0;
longest = Math.Max(longest, mustWork.Max());

// Part 3 output
for(int i = 0; i < names.Length; i++)
{
    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay[i];

    mustWork[i] = HoursToCover(costPerPerson, takeHomePerHour[i]);

    System.Console.WriteLine($"{names[i]}: takes home {takeHomePay[i]:C} for {hoursWorked[i]} hours, {hourRate[i]} per hour, must work {mustWork[i]:F2} hours ");

}

System.Console.WriteLine($"Total hours worked: {totalHours}");
System.Console.WriteLine($"Total take home pay: {totalTakeHomePay:C}");
System.Console.WriteLine($"Longest anyone must work: {longest:F2}");


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