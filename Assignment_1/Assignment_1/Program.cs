//using System;

//class Program
//{
//    static void Main()
//    {
Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Billing System ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.Write("\nDhairya Bhavsar");
Console.Write("\n8960102");
Console.Write("\nDbhavsar0102@conestogac.on.ca");
Console.Write("\n--------------------------------------------------------------------------------------------");


double subtotal = 0;
double bagsCost = 0;

Console.WriteLine("\nDo you have a discount card? (yes/no): ");
string? userResponseOnDiscountCard = Console.ReadLine();
bool hasDiscountCard = false;
while(userResponseOnDiscountCard != null)
{
    if (userResponseOnDiscountCard.ToLower() == "yes")
    {
        hasDiscountCard = true;
    } else
    {
        hasDiscountCard = false;
    }

    break;
}
Console.Write("\n--------------------------------------------------------------------------------------------\n");

while (true)
{
    Console.WriteLine("\nEnter the item Number (1. Chillies, 2. Tomatoes,3.Apples,4. Milk): ");
    string? itemName = Console.ReadLine();
    if (itemName != null)
    {
        itemName = itemName.ToLower();
    }
     
    Console.Write("\n--------------------------------------------------------------------------------------------\n");
    double basePrice = 0;
    bool applyDiscount = false;

    try
    {
        if (itemName == "1")
        {
            basePrice = 1.29;
            applyDiscount = true;
        }
        else if (itemName == "2")
        {
            basePrice = 1.45;
            applyDiscount = true;
        }
        else if (itemName == "3")
        {
            basePrice = 1.75;
            applyDiscount = true;
        }
        else if (itemName == "4")
        {
            Console.WriteLine("Enter the number of cartons of milk: ");
            int cartons = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n--------------------------------------------------------------------------------------------\n");
            basePrice = 6.54 * cartons;
        }
        else
        {
            Console.WriteLine("Invalid item name. Please enter a valid item name.");

            continue;
        }

        double weight = itemName == "milk" ? 1 : GetWeight();

        Console.WriteLine("Enter the number of store bags used: ");
        int bagsUsed = Convert.ToInt32(Console.ReadLine());
        Console.Write("\n--------------------------------------------------------------------------------------------\n");

        double itemPrice = basePrice * weight;
        double discountedPrice = applyDiscount && hasDiscountCard ? itemPrice * 0.9 : itemPrice;

        subtotal += discountedPrice;

        bagsCost += bagsUsed * 0.50;

        Console.WriteLine($"\nItem: {itemName}\nWeight: {weight} {(itemName == "milk" ? "carton" : "lbs")}\nPrice: ${itemPrice:F2}\nDiscounted Price: ${discountedPrice:F2}");

    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");

    }

    Console.WriteLine("\nDo you want to add another item? (yes/no): ");
    string? continueShopping = Console.ReadLine();
    if (continueShopping != null)
    {
        continueShopping = continueShopping.ToLower();
    }
    Console.Write("\n--------------------------------------------------------------------------------------------\n");
    if (continueShopping != "yes")
        break;
}


double tax = subtotal * 0.13;
double total = subtotal + bagsCost + tax;

Console.WriteLine($"\nNumber of bags used: {bagsCost / 0.50}\nBags cost: ${bagsCost:F2}");

Console.WriteLine($"\nSubtotal: ${subtotal:F2}\nTax (13%): ${tax:F2}\nTotal: ${total:F2}");



Console.WriteLine("\n*****************************Thank you for shopping with us!*****************************");
    //}

    static double GetWeight()
{
    Console.WriteLine("Enter the weight in lbs of the item purchased: ");
    return Convert.ToDouble(Console.ReadLine());
}
//}