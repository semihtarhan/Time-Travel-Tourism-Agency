using TimeTravelTourismAgency.DTOs;

namespace TimeTravelTourismAgency.Services;

public interface ITimeDestinationService
{
    Task<IEnumerable<TimeDestinationDto>> GetAllAsync();
    Task<TimeDestinationDto?> GetByIdAsync(int id);
    Task<TimeDestinationDto> CreateAsync(CreateTimeDestinationDto dto);
    Task<bool> UpdateAsync(int id, UpdateTimeDestinationDto dto);
    Task<bool> DeleteAsync(int id);
}