using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalProject.Pages.Models;
using System.Text.Json;

namespace FinalProject.Pages
{
    public class ReservationsModel : PageModel
    {
        public List<ReservationViewModel> Reservations { get; set; }

        public void OnGet()
        {
            // Load reservations from JSON file
            string reservationsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "reservations.json");
            var reservationsJson = System.IO.File.ReadAllText(reservationsFilePath);
            var reservations = JsonSerializer.Deserialize<List<Reservation>>(reservationsJson);

            // Load cars from JSON file
            string carsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cars.json");
            var carsJson = System.IO.File.ReadAllText(carsFilePath);
            var cars = JsonSerializer.Deserialize<List<Car>>(carsJson);

            // Join reservations with cars to get car model
            Reservations = (from r in reservations
                            join c in cars on r.CarId equals c.Id
                            select new ReservationViewModel
                            {
                                CarModel = c.Model,
                                ReservationDateTime = r.ReservationDateTime,
                                UserName = r.UserName,
                                ContactInfo = r.ContactInfo
                            }).ToList();
        }
    }

    public class ReservationViewModel
    {
        public string CarModel { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string UserName { get; set; }
        public string ContactInfo { get; set; }
    }
}
