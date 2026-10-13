using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        return await _context.Customers
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PassportNumber = c.PassportNumber,
                Phone = c.Phone
            })
            .ToListAsync();
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        var c = await _context.Customers.FindAsync(id);
        if (c == null) return null;

        return new CustomerDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            PassportNumber = c.PassportNumber,
            Phone = c.Phone
        };
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PassportNumber = dto.PassportNumber,
            Phone = dto.Phone,
            CreatedAt = DateTime.UtcNow
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PassportNumber = customer.PassportNumber,
            Phone = customer.Phone
        };
    }
}