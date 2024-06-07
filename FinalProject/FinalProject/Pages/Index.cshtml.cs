using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using assignment_3.Pages.Models;

namespace assignment_3.Pages
{
    public class IndexModel : PageModel
    {
        // Store Details
        public string StoreName { get; } = "Yash Patel Car Rentals";
        public string Address { get; } = "123 Franklin St, Kitchener, Canada";
        public string PhoneNumber { get; } = "123-456-7890";
        public List<Car> AvailableCars { get; set; } = new List<Car>
        {
            // Cars details with brand, model, image, and Small Description
            new Car { Id = 1, Brand = "TESLA", Model = "Y", ImageUrl = "/images/TESLA Y.jpg", Description = "Tesla has an autopilot system, OTA software updates, falcon doors, supercharging, key card access, plaid mode, etc., among its enhanced standout features", ReservedCount = 0 },
            new Car { Id = 2, Brand = "TOYOTA", Model = "Camry", ImageUrl = "/images/Toyota Carmy.jpg", Description = "All Camrys come with Toyota's Safety Sense 2.5+. It's an impressive suite of standard driver assistance features such as adaptive cruise control, automatic emergency braking and lane keeping assistance.", ReservedCount = 0 },
            new Car { Id = 3, Brand = "HONDA", Model = "Accord", ImageUrl = "/images/Honda Accotd.jpg", Description = "Price. Affordability is a significant selling point for the Honda Accord. Compared to some of its competitors in the midsize sedan segment, the Accord often comes with a lower starting price.", ReservedCount = 0 },
            // Add more cars as needed
        };

        public void OnGet()
        {
            // Initialization or data retrieval logic can be added here
        }
    }
}
