using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CarReservationSystem.Pages
{
    public class ReserveModel : PageModel
    {
        public IActionResult OnPost()
        {
            // Implement reservation logic here
            // Example: Save reservation to database or in-memory list
            // Redirect to success page or error page based on reservation status

            // For simplicity, just redirect to success page
            return RedirectToPage("/Confirmation");
        }
    }
}
