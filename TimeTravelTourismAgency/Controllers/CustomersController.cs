using Microsoft.AspNetCore.Mvc;
using TimeTravelTourismAgency.DTOs;
using TimeTravelTourismAgency.Services;

namespace TimeTravelTourismAgency.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound(new { message = "Müşteri bulunamadı." });
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto dto)
    {
        var created = await _customerService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _customerService.DeleteAsync(id); // Servisteki silme metodun (adını kendi servisine göre kontrol edebilirsin)
        if (!success)
            return NotFound(new { message = "Müşteri bulunamadı." });

        return NoContent(); // Başarılı silme durumunda 204 döner
    }
}