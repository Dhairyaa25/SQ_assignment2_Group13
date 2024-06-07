class Appointment: Program
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? MembershipNumber { get; set; }
    public DateTime AppointmentDateTime { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public List<string> Services { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public decimal CalculateValue()
    {
        decimal totalValue = 0;

        foreach (var service in Services)
        {
            string trimmedService = service.Trim().ToLower();

            switch (trimmedService)
            {
                case "manicure":
                    totalValue += 200.00m;
                    break;
                case "pedicure":
                    totalValue += 153.50m;
                    break;
                case "solar refill":
                    totalValue += 51.30m;
                    break;
                default:
                    Console.WriteLine($"service: {service}");
                    break;
            }
        }

        return totalValue;
    }
    public decimal CalculateTotal()
    {
        decimal totalValue = CalculateValue();
        decimal taxRate = 0.136m; // 13.6% tax rate

        // Calculate total amount including tax
        decimal totalAmount = totalValue + (totalValue * taxRate);

        return totalAmount;
    }
}
