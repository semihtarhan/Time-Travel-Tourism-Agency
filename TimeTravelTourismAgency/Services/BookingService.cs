using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _context;

    public BookingService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookingDtos>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.TimeDestination)
            .Select(b => new BookingDtos
            {
                Id = b.Id,
                CustomerId = b.CustomerId,
                CustomerName = $"{b.Customer.FirstName} {b.Customer.LastName}",
                TimeDestinationId = b.TimeDestinationId,
                DestinationTitle = b.TimeDestination.Title,
                PassengerCount = b.PassengerCount,
                TotalPrice = b.TotalPrice,
                BookingDate = b.BookingDate,
                Status = b.Status
            })
            .ToListAsync();
    }

    public async Task<BookingDtos?> GetByIdAsync(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.TimeDestination)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null) return null;

        return new BookingDtos
        {
            Id = booking.Id,
            CustomerId = booking.CustomerId,
            CustomerName = $"{booking.Customer.FirstName} {booking.Customer.LastName}",
            TimeDestinationId = booking.TimeDestinationId,
            DestinationTitle = booking.TimeDestination.Title,
            PassengerCount = booking.PassengerCount,
            TotalPrice = booking.TotalPrice,
            BookingDate = booking.BookingDate,
            Status = booking.Status
        };
    }

    public async Task<BookingDtos?> CreateAsync(CreateBookingDto dto)
    {
        var customer = await _context.Customers.FindAsync(dto.CustomerId);
        var destination = await _context.TimeDestinations.FindAsync(dto.TimeDestinationId);

        if (customer == null || destination == null) return null;

        var booking = new Booking
        {
            CustomerId = dto.CustomerId,
            TimeDestinationId = dto.TimeDestinationId,
            PassengerCount = dto.PassengerCount,
            TotalPrice = destination.Price * dto.PassengerCount, // Otomatik hesaplama
            BookingDate = DateTime.UtcNow,
            Status = "Confirmed"
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return new BookingDtos
        {
            Id = booking.Id,
            CustomerId = customer.Id,
            CustomerName = $"{customer.FirstName} {customer.LastName}",
            TimeDestinationId = destination.Id,
            DestinationTitle = destination.Title,
            PassengerCount = booking.PassengerCount,
            TotalPrice = booking.TotalPrice,
            BookingDate = booking.BookingDate,
            Status = booking.Status
        };
    }

    public async Task<bool> CancelBookingAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return false;

        booking.Status = "Cancelled";
        await _context.SaveChangesAsync();
        return true;
    }
}