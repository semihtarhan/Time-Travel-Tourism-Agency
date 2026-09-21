using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeDestinationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TimeDestinationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/TimeDestinations (Tüm destinasyonları getirir)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeDestination>>> GetDestinations()
    {
        return await _context.TimeDestinations.ToListAsync();
    }

    // GET: api/TimeDestinations/5 (ID'ye göre tek bir destinasyon getirir)
    [HttpGet("{id}")]
    public async Task<ActionResult<TimeDestination>> GetDestination(int id)
    {
        var destination = await _context.TimeDestinations.FindAsync(id);

        if (destination == null)
        {
            return NotFound(new { message = $"{id} ID'li destinasyon bulunamadı." });
        }

        return destination;
    }

    // POST: api/TimeDestinations (Yeni bir zaman destinasyonu ekler)
    [HttpPost]
    public async Task<ActionResult<TimeDestination>> CreateDestination(TimeDestination destination)
    {
        _context.TimeDestinations.Add(destination);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDestination), new { id = destination.Id }, destination);
    }

    // PUT: api/TimeDestinations/5 (Mevcut destinasyonu günceller)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDestination(int id, TimeDestination destination)
    {
        if (id != destination.Id)
        {
            return BadRequest(new { message = "ID eşleşmiyor." });
        }

        _context.Entry(destination).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DestinationExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/TimeDestinations/5 (Destinasyonu siler)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
        var destination = await _context.TimeDestinations.FindAsync(id);
        if (destination == null)
        {
            return NotFound();
        }

        _context.TimeDestinations.Remove(destination);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DestinationExists(int id)
    {
        return _context.TimeDestinations.Any(e => e.Id == id);
    }
}