using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FinalProject.Pages.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ReserveModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ReserveModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = new Reservation(); // Initialize Reservation object

        public List<Car> AvailableCars { get; private set; }

        public void OnGet()
        {
            LoadAvailableCars();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If validation failed
                LoadAvailableCars(); // Load available cars again to render the page
                return Page();
            }

            // Add the new reservation to the reservations.json file
            string reservationsFilePath = Path.Combine(_env.ContentRootPath, "Data", "reservations.json");
            string reservationsJson = System.IO.File.ReadAllText(reservationsFilePath);
            var reservations = JsonSerializer.Deserialize<List<Reservation>>(reservationsJson) ?? new List<Reservation>();
            reservations.Add(Reservation);
            
            // Serialize reservations with options
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Makes the JSON data more readable
            };
            string updatedReservationsJson = JsonSerializer.Serialize(reservations, options);
            
            // Write back to file
            System.IO.File.WriteAllText(reservationsFilePath, updatedReservationsJson);

            // Redirect to confirmation page
            return RedirectToPage("/Confirmation", new { carId = Reservation.CarId, userName = Reservation.UserName, contactInfo = Reservation.ContactInfo });
        }

        private void LoadAvailableCars()
        {
            string dataFilePath = Path.Combine(_env.ContentRootPath, "Data", "cars.json");
            string jsonData = System.IO.File.ReadAllText(dataFilePath);
            AvailableCars = JsonSerializer.Deserialize<List<Car>>(jsonData);
        }
    }
}
