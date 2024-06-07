// ReservationConfirmation.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReservationConfirmationModel : PageModel
{
    public int CarId { get; set; }
    public string UserName { get; set; }
    public string ContactInfo { get; set; }

    public void OnGet(int carId, string userName, string contactInfo)
    {
        CarId = carId;
        UserName = userName;
        ContactInfo = contactInfo;
    }
}
