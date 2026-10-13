using Microsoft.AspNetCore.Mvc;
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Services;

namespace TimeTravelTourismAgency.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeDestinationsController : ControllerBase
{
    private readonly ITimeDestinationService _service;

    public TimeDestinationsController(ITimeDestinationService service)
    {
        _service = service;
    }

    // GET: api/TimeDestinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeDestinationDto>>> GetDestinations()
    {
        var destinations = await _service.GetAllAsync();
        return Ok(destinations);
    }

    // GET: api/TimeDestinations/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TimeDestinationDto>> GetDestination(int id)
    {
        var destination = await _service.GetByIdAsync(id);
        if (destination == null)
        {
            return NotFound(new { message = $"{id} ID'li destinasyon bulunamadı." });
        }

        return Ok(destination);
    }

    // POST: api/TimeDestinations
    [HttpPost]
    public async Task<ActionResult<TimeDestinationDto>> CreateDestination([FromBody] CreateTimeDestinationDto dto)
    {
        // Parameter CreateTimeDestinationDto olduğu için FluentValidation burada otomatik çalışacak!
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetDestination), new { id = created.Id }, created);
    }

    // PUT: api/TimeDestinations/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDestination(int id, [FromBody] UpdateTimeDestinationDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        if (!success)
        {
            return NotFound(new { message = $"{id} ID'li destinasyon bulunamadı." });
        }

        return NoContent();
    }

    // DELETE: api/TimeDestinations/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success)
        {
            return NotFound(new { message = $"{id} ID'li destinasyon bulunamadı." });
        }

        return NoContent();
    }
}