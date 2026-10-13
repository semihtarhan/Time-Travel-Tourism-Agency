namespace TimeTravelTourismAgency.Models;

public class Booking
{
    public int Id { get; set; }

    // Foreign Key - Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Foreign Key - TimeDestination
    public int TimeDestinationId { get; set; }
    public TimeDestination TimeDestination { get; set; } = null!;

    public int PassengerCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Confirmed"; // Confirmed, Cancelled, Completed
}