using TimeTravelTourismAgency.DTOs;

namespace TimeTravelTourismAgency.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(int id);
    Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
    Task<bool> DeleteAsync(int id);
}