namespace TimeTravelTourismAgency.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Property: Bir müşterinin birden fazla rezervasyonu olabilir
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}