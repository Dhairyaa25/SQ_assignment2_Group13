using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Passenger> passengers = new List<Passenger>();

        // Add yourself as a passenger (hardcoded)
        passengers.Add(new EconomyPassenger("Your", "Name", "(123) 456-7890", 2, 30, 25));

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a new Passenger");
            Console.WriteLine("2. Display Passenger list");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice (1-3): ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPassenger(passengers);
                    break;

                case "2":
                    DisplayPassengerList(passengers);
                    break;

                case "3":
                    Console.WriteLine("Exiting program. Thank you!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
    }

    static void AddPassenger(List<Passenger> passengers)
    {
        Console.WriteLine("Enter Passenger Details:");

        Console.Write("First Name: ");
        string? firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string? lastName = Console.ReadLine();

        Console.Write("Phone Number (in the format (XXX) XXX-XXXX): ");
        string? phoneNumber;
        do
        {
            phoneNumber = Console.ReadLine();
            if (!IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid phone number format. Please enter again.");
            }
        } while (!IsValidPhoneNumber(phoneNumber));

        Console.Write("Number of Bags: ");
        int numberOfBags = int.Parse(Console.ReadLine());

        Console.Write("Total Weight of Bags: ");
        double totalWeightOfBags = double.Parse(Console.ReadLine());

        Console.Write("Class (1 for Business, 2 for Economy): ");
        int classChoice = int.Parse(Console.ReadLine());

        if (classChoice == 1)
        {
            Console.Write("Company Name: ");
            string? companyName = Console.ReadLine();

            Console.Write("Preferred Seat (W for window, A for aisle): ");
            char preferredSeat = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("Food Preference: ");
            string? foodPreference = Console.ReadLine();

            passengers.Add(new BusinessPassenger(firstName, lastName, phoneNumber, numberOfBags, totalWeightOfBags, companyName, preferredSeat, foodPreference));
        }
        else if (classChoice == 2)
        {
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            passengers.Add(new EconomyPassenger(firstName, lastName, phoneNumber, numberOfBags, totalWeightOfBags, age));
        }
        else
        {
            Console.WriteLine("Invalid class choice. Please enter 1 for Business or 2 for Economy.");
        }

        Console.WriteLine("Passenger added successfully!\n");
    }

    static void DisplayPassengerList(List<Passenger> passengers)
    {
        Console.WriteLine("\nPassenger List:");

        foreach (var passenger in passengers)
        {
            Console.WriteLine(passenger);
        }

        Console.WriteLine();
    }

    static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 14)
        {
            return false;
        }

        for (int i = 0; i < 14; i++)
        {
            if (i == 0 || i == 1 || i == 2 || i == 4 || i == 5 || i == 6 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13)
            {
                if (!Char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }
            else
            {
                if (phoneNumber[i] != '(' && phoneNumber[i] != ')' && phoneNumber[i] != ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }
}

class Passenger
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int NumberOfBags { get; set; }
    public double TotalWeightOfBags { get; set; }

    public Passenger(string firstName, string lastName, string phoneNumber, int numberOfBags, double totalWeightOfBags)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        NumberOfBags = numberOfBags;
        TotalWeightOfBags = totalWeightOfBags;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Phone: {PhoneNumber}, Bags: {NumberOfBags}, Weight: {TotalWeightOfBags}kg";
    }
}

class BusinessPassenger : Passenger
{
    public string CompanyName { get; set; }
    public char PreferredSeat { get; set; }
    public string FoodPreference { get; set; }

    public BusinessPassenger(string firstName, string lastName, string phoneNumber, int numberOfBags, double totalWeightOfBags,
        string companyName, char preferredSeat, string foodPreference)
        : base(firstName, lastName, phoneNumber, numberOfBags, totalWeightOfBags)
    {
        CompanyName = companyName;
        PreferredSeat = preferredSeat;
        FoodPreference = foodPreference;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Class: Business, Company: {CompanyName}, Seat: {PreferredSeat}, Food: {FoodPreference}";
    }
}

class EconomyPassenger : Passenger
{
    public int Age { get; set; }

    public EconomyPassenger(string firstName, string lastName, string phoneNumber, int numberOfBags, double totalWeightOfBags, int age)
        : base(firstName, lastName, phoneNumber, numberOfBags, totalWeightOfBags)
    {
        Age = age;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Class: Economy, Age: {Age}";
    }
}
