using System;

class Program
{
    static void Main(string? v2, string? v2, string? v2)
    {
        Console.Write("Enter your name: ");

        string? name = Console.ReadLine();
        Console.Write("\n--------------------------------------------------------------\n");

       
        Console.Write("Enter your student number: ");
        string? studentNumber = Console.ReadLine();

        Console.Write("Enter your email address: ");
        string? emailAddress = Console.ReadLine();

        double subtotal = 0;
        double bagsCost = 0;

        Console.WriteLine("\nDo you have a discount card? (yes/no): ");
        string? v = Console.ReadLine();
        bool hasDiscountCard = v.ToLower() == "yes";

        while (true)
        {
            Console.WriteLine("\nEnter the name of the item purchased (Chillies, Tomatoes, Apples, Milk): ");
            string? v1 = Console.ReadLine();
            string? itemName = v1.ToLower();

            double basePrice = 0;
            bool applyDiscount = false;

            try
            {
                if (itemName == "chillies")
                {
                    basePrice = 1.29;
                    applyDiscount = true;
                }
                else if (itemName == "tomatoes")
                {
                    basePrice = 1.45;
                    applyDiscount = true;
                }
                else if (itemName == "apples")
                {
                    basePrice = 1.75;
                    applyDiscount = true;
                }
                else if (itemName == "milk")
                {
                    Console.WriteLine("Enter the number of cartons of milk: ");
                    int cartons = Convert.ToInt32(Console.ReadLine());
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

            string? v2 = Console.ReadLine();
            string? continueShopping = v2.ToLower();
            if (continueShopping != "yes")
                break;
        }

        Console.WriteLine($"\nName: {name}\nStudent Number: {studentNumber}\nEmail Address: {emailAddress}");

        double tax = subtotal * 0.13;
        double total = subtotal + bagsCost + tax;

        Console.WriteLine($"\nNumber of bags used: {bagsCost / 0.50}\nBags cost: ${bagsCost:F2}");
        Console.WriteLine($"\nSubtotal: ${subtotal:F2}\nTax (13%): ${tax:F2}\nTotal: ${total:F2}");


        Console.WriteLine("\nThank you for shopping with us!");
    }

    static double GetWeight()
    {
        Console.WriteLine("Enter the weight in lbs of the item purchased: ");
        return Convert.ToDouble(Console.ReadLine());
    }
}