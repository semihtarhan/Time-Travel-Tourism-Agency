using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TimeTravelTourismAgency.Models;
using TimeTravelTourismAgency.Services;

namespace TimeTravelTourismAgency.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITimeDestinationService _destinationService;
    private readonly IBookingService _bookingService;

    public HomeController(
        ILogger<HomeController> logger,
        ITimeDestinationService destinationService,
        IBookingService bookingService)
    {
        _logger = logger;
        _destinationService = destinationService;
        _bookingService = bookingService;
    }

    // GET: / (Ana Sayfa)
    public async Task<IActionResult> Index()
    {
        var destinations = await _destinationService.GetAllAsync();
        return View(destinations);
    }

    // GET: /Home/Bookings (Rezervasyonlar Sayfası)
    public async Task<IActionResult> Bookings()
    {
        var bookings = await _bookingService.GetAllAsync();
        return View(bookings);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}