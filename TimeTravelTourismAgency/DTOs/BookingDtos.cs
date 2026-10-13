namespace TimeTravelTourismAgency.DTOs;

public class BookingDtos
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int TimeDestinationId { get; set; }
    public string DestinationTitle { get; set; } = string.Empty;
    public int PassengerCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime BookingDate { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class CreateBookingDto
{
    public int CustomerId { get; set; }
    public int TimeDestinationId { get; set; }
    public int PassengerCount { get; set; }
}