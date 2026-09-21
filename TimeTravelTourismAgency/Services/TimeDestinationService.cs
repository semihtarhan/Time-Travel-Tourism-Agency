using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data; 
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Services;

public class TimeDestinationService : ITimeDestinationService
{
    private readonly AppDbContext _context;

    public TimeDestinationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TimeDestinationDto>> GetAllAsync()
    {
        return await _context.TimeDestinations
            .AsNoTracking()
            .Select(d => new TimeDestinationDto
            {
                Id = d.Id,
                Title = d.Title,
                TargetYear = d.TargetYear,
                Description = d.Description,
                Price = d.Price,
                Capacity = d.Capacity,
                DangerLevel = d.DangerLevel,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<TimeDestinationDto?> GetByIdAsync(int id)
    {
        var destination = await _context.TimeDestinations.FindAsync(id);
        if (destination == null) return null;

        return new TimeDestinationDto
        {
            Id = destination.Id,
            Title = destination.Title,
            TargetYear = destination.TargetYear,
            Description = destination.Description,
            Price = destination.Price,
            Capacity = destination.Capacity,
            DangerLevel = destination.DangerLevel,
            IsActive = destination.IsActive,
            CreatedAt = destination.CreatedAt
        };
    }

    public async Task<TimeDestinationDto> CreateAsync(CreateTimeDestinationDto dto)
    {
        var entity = new TimeDestination
        {
            Title = dto.Title,
            TargetYear = dto.TargetYear,
            Description = dto.Description,
            Price = dto.Price,
            Capacity = dto.Capacity,
            DangerLevel = dto.DangerLevel,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _context.TimeDestinations.Add(entity);
        await _context.SaveChangesAsync();

        return new TimeDestinationDto
        {
            Id = entity.Id,
            Title = entity.Title,
            TargetYear = entity.TargetYear,
            Description = entity.Description,
            Price = entity.Price,
            Capacity = entity.Capacity,
            DangerLevel = entity.DangerLevel,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateTimeDestinationDto dto)
    {
        var entity = await _context.TimeDestinations.FindAsync(id);
        if (entity == null) return false;

        entity.Title = dto.Title;
        entity.TargetYear = dto.TargetYear;
        entity.Description = dto.Description;
        entity.Price = dto.Price;
        entity.Capacity = dto.Capacity;
        entity.DangerLevel = dto.DangerLevel;
        entity.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.TimeDestinations.FindAsync(id);
        if (entity == null) return false;

        _context.TimeDestinations.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}