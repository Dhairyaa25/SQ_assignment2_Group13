using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ConfirmationModel : PageModel
{
    public int CarId { get; set; }
    public required string UserName { get; set; }
    public required string ContactInfo { get; set; }

    public void OnGet(int carId, string userName, string contactInfo)
    {
        // Print Reservation data
        CarId = carId;
        UserName = userName;
        ContactInfo = contactInfo;
    }
}
