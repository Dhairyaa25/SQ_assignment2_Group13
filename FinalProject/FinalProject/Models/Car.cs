namespace FinalProject.Pages.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ReservedCount { get; set; } // New property to track reservation count
    }
}
