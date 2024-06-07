using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CarReservationSystem.Pages
{
    public class IndexModel : PageModel
    {
        public string CarRentalName { get; } = "Muthu Vaidhianathan's Car Rentals";
        public string Address { get; } = "123 Main St, City, Country";
        public string PhoneNumber { get; } = "123-456-7890";

        public List<Car> AvailableCars { get; set; }

        public void OnGet()
        {
            // Mock data for available cars
            AvailableCars = new List<Car>
            {
                new Car { Brand = "Toyota", Model = "Camry" },
                new Car { Brand = "Honda", Model = "Civic" },
                new Car { Brand = "Ford", Model = "Mustang" }
            };
        }
    }

    public class Car
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
    }
}
