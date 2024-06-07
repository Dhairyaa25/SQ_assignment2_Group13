
using System.ComponentModel.DataAnnotations;

interface IServiceCalculator
{
    decimal CalculateTotal();
}

class Service
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}

class Appointment : IServiceCalculator
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? MembershipNumber { get; set; }
    public DateTime AppointmentDateTime { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public List<Service> Services { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var service in Services)
        {
            total += service.Price;
        }

        // Include 13.6% Tax
        total *= 1.136m;
        
        
        return total;
    }
}

class Program
{
    static List<Appointment> appointments = new List<Appointment>();
    static int availableSlots = 8;

    static void Main()
    {
        InitializeAppointments();

        int choice;
        do
        {
            Console.WriteLine("Nail Salon Scheduling Application");
            Console.WriteLine("1. List all appointments");
            Console.WriteLine("2. Create an appointment");
            Console.WriteLine("3. Reset Schedule");
            Console.WriteLine("4. Show closest appointment slot available on the week");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ListAllAppointments();
                        break;
                    case 2:
                        CreateAppointment();
                        break;
                    case 3:
                        ResetSchedule();
                        break;
                    case 4:
                        ShowClosestAppointmentSlot();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        } while (choice != 5);
    }

    static void InitializeAppointments()
    {
        // Automatically add 3 people to the appointments array
        appointments.Add(new Appointment
        {
            FirstName = "Dhairya",
            LastName = "Bhavsar",
            Email = "dhairyabhavsar@gmail.com",
            MembershipNumber = "AAAA-111-AAAA",
            AppointmentDateTime = DateTime.Now.AddDays(1).AddHours(9),
            Services = new List<Service> { new Manicure() }
        });

        appointments.Add(new Appointment
        {
            FirstName = "Nathan",
            LastName = "Albers",
            Email = "nathanalbers@gmail.com",
            MembershipNumber = "BBBB-222-BBBB",
            AppointmentDateTime = DateTime.Now.AddDays(2).AddHours(10),
            Services = new List<Service> { new Pedicure() }
        });

        appointments.Add(new Appointment
        {
            FirstName = "Sasha",
            LastName = "Olive",
            Email = "sashaolive@gmail.com",
            MembershipNumber = "CCCC-333-CCCC",
            AppointmentDateTime = DateTime.Now.AddDays(3).AddHours(11),
            Services = new List<Service> { new SolarRefill() }

        });
       
    }

    static void ListAllAppointments()
    {
        Console.WriteLine("List of all appointments:");
        foreach (var appointment in appointments)
        {
            Console.WriteLine($"Name: {appointment.FirstName} {appointment.LastName}");
            Console.WriteLine($"Email: {appointment.Email}");
            Console.WriteLine($"Membership Number: {appointment.MembershipNumber}");
            Console.WriteLine($"Appointment Date and Time: {appointment.AppointmentDateTime}");
            Console.WriteLine("Services:");
            foreach (var service in appointment.Services)
            {
                Console.WriteLine($"{service.Name}");
            }
            Console.WriteLine($"Total Amount: {appointment.CalculateTotal():C}");
            Console.WriteLine();
        }
    }
   

    static void CreateAppointment()
    {
        if (availableSlots > 0)
        {
            Console.Write("Enter First Name: ");
            string? firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string? lastName = Console.ReadLine();

            Console.Write("Enter Email Address: ");
            string? email = Console.ReadLine();

            string? membershipNumber;
            do
            {
                Console.Write("Enter Membership Number (AAAA-111-AAAA): ");
                membershipNumber = Console.ReadLine();

#pragma warning disable CS8604 // Possible null reference argument.
                if (Validator.IsValidMembershipNumber(membershipNumber))
                {
                    Console.WriteLine("Invalid membership number format. Please enter again.");
                }
#pragma warning restore CS8604 // Possible null reference argument.

            } while (Validator.IsValidMembershipNumber(membershipNumber));

            Console.Write("Enter Appointment Date and Time (mm/dd/yyyy - hh:mm): ");
            DateTime appointmentDateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out appointmentDateTime))
            {
                Console.WriteLine("Invalid date format. Please enter again.");
            }
            static bool IsValidMembershipNumber(string membershipNumber)
            {
                // Validate membership number format (AAAA-111-AAAA)
                string pattern = @"^[A-Za-z]{4}-\d{3}-[A-Za-z]{4}$";
                return System.Text.RegularExpressions.Regex.IsMatch(membershipNumber, pattern);
            }

            var selectedServices = new List<Service>();
            DisplayServiceMenu();

            Console.Write("Select Service: ");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string[] selectedServiceNames = Console.ReadLine().Split(',');
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            foreach (var serviceName in selectedServiceNames)
            {
                Service? service = GetServiceByName(serviceName.Trim());
                if (service != null)
                {
                    selectedServices.Add(service);
                }
                else
                {
                    Console.WriteLine($"Invalid service: {serviceName}");
                }
            }

            var newAppointment = new Appointment
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                MembershipNumber = membershipNumber,
                AppointmentDateTime = appointmentDateTime,
                Services = selectedServices
            };

            appointments.Add(newAppointment);
            availableSlots--;
            Console.WriteLine("Appointment created successfully!");
        }
        else
        {
            Console.WriteLine("All appointment slots are booked. Cannot create a new appointment.");
        }
    }

    static void ResetSchedule()
    {
        appointments.Clear();
        availableSlots = 8;
        Console.WriteLine("Schedule reset. All appointments deleted.");
    }

    static void ShowClosestAppointmentSlot()
    {
        // Implement logic to find the closest available appointment slot
        // based on the current date and existing appointments.
        Console.WriteLine("Showing closest appointment slot available on the week.");
    }

    static void DisplayServiceMenu()
    {
        Console.WriteLine("Available Services:");
        Console.WriteLine("1. Manicure - $200.00");
        Console.WriteLine("2. Pedicure - $153.50");
        Console.WriteLine("3. Solar Refill - $51.30");
    }

    static Service? GetServiceByName(string serviceName)
    {
        switch (serviceName.ToLower())
        {
            case "manicure":
                return new Manicure();
            case "pedicure":
                return new Pedicure();
            case "solar refill":
                return new SolarRefill();
            default:
                return null;
        }
    }
}
