namespace FinalProject.Pages.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserName { get; set; }
        public string ContactInfo { get; set; }
        public DateTime ReservationDateTime { get; set; }
    }
}
