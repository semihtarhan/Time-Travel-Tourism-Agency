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
    private readonly ICustomerService _customerService;

    public HomeController(
        ILogger<HomeController> logger,
        ITimeDestinationService destinationService,
        IBookingService bookingService,
        ICustomerService customerService)
    {
        _logger = logger;
        _destinationService = destinationService;
        _bookingService = bookingService;
        _customerService = customerService;
    }

    // GET: / (Ana Sayfa)
    public async Task<IActionResult> Index()
    {
        var destinations = await _destinationService.GetAllAsync();
        var bookings = await _bookingService.GetAllAsync();
        var customers = await _customerService.GetAllAsync();

        // 1. Sadece Onaylı Rezervasyonlar (İptal edilenler hariç)
        var confirmedBookings = bookings.Where(b => b.Status == "Confirmed").ToList();

        // 2. Toplam Rezervasyon Sayısı (İptal edilenler sayılmaz)
        ViewBag.TotalBookings = confirmedBookings.Count();

        // 3. Toplam Ciro (Sadece onaylı rezervasyonların tutarları toplanır)
        ViewBag.TotalRevenue = confirmedBookings.Sum(b => b.TotalPrice);

        // 4. Kayıtlı Müşteri Sayısı
        ViewBag.TotalCustomers = customers.Count();

        // 5. Aktif Rota Sayısı
        ViewBag.TotalDestinations = destinations.Count();

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