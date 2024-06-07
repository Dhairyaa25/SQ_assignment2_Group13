using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CarReservationSystem.Pages
{
    public class ConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? ReservedCarModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? UserName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PhoneNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime ReservationDateTime { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve reservation details
            // For simplicity, assume the details are passed through query parameters

            // Mock reservation details
            ReservedCarModel = Request.Query["car"];
            UserName = Request.Query["name"];
            PhoneNumber = Request.Query["phone"];
            ReservationDateTime = DateTime.Parse(Request.Query["reservationDateTime"]);

            return Page();
        }
    }
}
