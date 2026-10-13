using TimeTravelTourismAgency.DTOs;

namespace TimeTravelTourismAgency.Services;

public interface IBookingService
{
    Task<IEnumerable<BookingDtos>> GetAllAsync();
    Task<BookingDtos?> GetByIdAsync(int id);
    Task<BookingDtos?> CreateAsync(CreateBookingDto dto);
    Task<bool> CancelBookingAsync(int id);
}