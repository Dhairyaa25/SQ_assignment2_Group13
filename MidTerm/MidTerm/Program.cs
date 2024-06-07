class Program
{
    static List<Appointment> appointments = new List<Appointment>();

    static void Main()
    {
        appointments.Add(new Appointment
        {
            FirstName = "Dhairya",
            LastName = "Bhavsar",
            Email = "dhairyabhavsar@gmail.com",
            MembershipNumber = "AAAA-123-AAAA",
            AppointmentDateTime = DateTime.Now.AddDays(2).AddHours(10),
            Services = new List<string> { "Manicure", "Pedicure" }
        });

        appointments.Add(new Appointment
        {
            FirstName = "Mark",
            LastName = "Grayson",
            Email = "markgrayson@gmail.com",
            MembershipNumber = "BBBB-456-BBBB",
            AppointmentDateTime = DateTime.Now.AddDays(3).AddHours(14),
            Services = new List<string> { "Solar Refill" }
        });

        appointments.Add(new Appointment
        {
            FirstName = "Sasha",
            LastName = "Johnson",
            Email = "sasha.johnson@gmail.com",
            MembershipNumber = "CCCC-789-CCCC",
            AppointmentDateTime = DateTime.Now.AddDays(4).AddHours(11),
            Services = new List<string> { "Manicure", "Pedicure", "Solar Refill" }
        });
        int choice;
        do
        {
            Console.WriteLine("Nail Salon Scheduling Application");
            Console.WriteLine("\n========================================================");
            Console.WriteLine("1. List all appointments");
            Console.WriteLine("2. Create an appointment");
            Console.WriteLine("3. Reset schedule");
            Console.WriteLine("4. Show closest appointment slot available on the week");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\n========================================================");

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

    static void ListAllAppointments()
    {
        Console.WriteLine("List of all appointments:");
        foreach (var appointment in appointments)
        {
            Console.WriteLine("\n========================================================");
            Console.WriteLine($"Name: {appointment.FirstName} {appointment.LastName}");
            Console.WriteLine($"Email: {appointment.Email}");
            Console.WriteLine($"Membership Number: {appointment.MembershipNumber}");    
            Console.WriteLine($"Appointment Date and Time: {appointment.AppointmentDateTime}");
            Console.WriteLine("\n========================================================");
            Console.WriteLine("Services:");
            
            foreach (var service in appointment.Services)
            {
                Console.WriteLine($"{service}");
            }
            Console.WriteLine($"Total Amount: {appointment.CalculateValue():C}");
        }
    }

    static void CreateAppointment()
    {
        Console.WriteLine("\n========================================================");
        Console.Write("Enter First Name: ");
        string? firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string? lastName = Console.ReadLine();

        Console.Write("Enter Email Address: ");
        string? email = Console.ReadLine();

        string membershipNumber;
        do
        {
            Console.Write("Enter Membership Number (AAAA-111-AAAA): ");
            membershipNumber = Console.ReadLine();
#pragma warning disable CS8604 // Possible null reference argument.
            if (!IsValidMembershipNumber(membershipNumber))
            {
                Console.WriteLine("Invalid membership number format. Please enter again.");
            }
#pragma warning restore CS8604 // Possible null reference argument.

        } while (!IsValidMembershipNumber(membershipNumber));


        Console.Write("Enter Appointment Date and Time (mm/dd/yyyy - hh:mm): ");
        DateTime appointmentDateTime;
        while (!DateTime.TryParse(Console.ReadLine(), out appointmentDateTime))
        {
            Console.WriteLine("Slot is Not Available.");
        }
        Console.WriteLine("\n========================================================");
        Console.WriteLine("Available Services:");
        Console.WriteLine("1. Manicure - $200.00");
        Console.WriteLine("2. Pedicure - $153.50");
        Console.WriteLine("3. Solar Refill - $51.30");
        Console.Write("Select Service: ");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string[] selectedServices = Console.ReadLine().Split(',');
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        var newAppointment = new Appointment
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            MembershipNumber = membershipNumber,
            AppointmentDateTime = appointmentDateTime,
            Services = new List<string>(selectedServices)
        };

        appointments.Add(newAppointment);
        Console.WriteLine("Appointment created successfully!");
    }
        static bool IsValidMembershipNumber(string membershipNumber)
    {
        // Validate membership number format (AAAA-111-AAAA)
        string pattern = @"^[A-Za-z]{4}-\d{3}-[A-Za-z]{4}$";
        return System.Text.RegularExpressions.Regex.IsMatch(membershipNumber, pattern);
    }

    static void ResetSchedule()
    {
        appointments.Clear();
        Console.WriteLine("Schedule reset. All appointments deleted.");
    }

    static void ShowClosestAppointmentSlot()
    {
        
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            const int totalSlots = 8;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
            const int hoursPerSlot = 1;
            const int daysToCheck = 7;

            DateTime currentDate = DateTime.Now;
            DateTime closestSlot = DateTime.MaxValue;

            foreach (var appointment in appointments)
            {
                // Check if the appointment date is within the specified number of days to check
                if ((appointment.AppointmentDateTime - currentDate).Days <= daysToCheck)
                {
                    // Determine the difference in time between the current date and appointment date
                    TimeSpan timeDifference = appointment.AppointmentDateTime - currentDate;

                    // Calculate the total hours difference
                    double totalHoursDifference = Math.Abs(timeDifference.TotalHours);

                    // Calculate the slot index based on the appointment date and time
                    int slotIndex = (int)((appointment.AppointmentDateTime.Hour - 9) / hoursPerSlot);

                    // Calculate the closest slot based on the time difference
                    DateTime slotDateTime = currentDate.Date.AddHours(9 + slotIndex * hoursPerSlot);
                    if (totalHoursDifference < Math.Abs((closestSlot - currentDate).TotalHours))
                    {
                        closestSlot = slotDateTime;
                    }
                }
            }

            if (closestSlot != DateTime.MaxValue)
            {
                Console.WriteLine($"The closest available appointment slot is on {closestSlot:MM/dd/yyyy} at {closestSlot:hh:mm tt}.");
            }
            else
            {
                Console.WriteLine("No available appointment slots within the specified days.");
            }
        

    }
}

