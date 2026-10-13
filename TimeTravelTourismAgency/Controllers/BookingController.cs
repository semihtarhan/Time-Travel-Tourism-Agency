using Microsoft.AspNetCore.Mvc;
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Services;

namespace TimeTravelTourismAgency.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingDtos>>> GetAll()
    {
        var bookings = await _bookingService.GetAllAsync();
        return Ok(bookings);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookingDtos>> GetById(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        if (booking == null) return NotFound(new { message = "Rezervasyon bulunamadı." });
        return Ok(booking);
    }

    [HttpPost]
    public async Task<ActionResult<BookingDtos>> Create([FromBody] CreateBookingDto dto)
    {
        var result = await _bookingService.CreateAsync(dto);
        if (result == null)
            return BadRequest(new { message = "Geçersiz Müşteri ID veya Zaman Hedefi ID." });

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        var success = await _bookingService.CancelBookingAsync(id);
        if (!success) return NotFound(new { message = "Rezervasyon bulunamadı." });
        return NoContent();
    }
}