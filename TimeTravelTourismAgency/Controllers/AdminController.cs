using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // Admin Dashboard Ana Sayfası & İstatistikler
        public async Task<IActionResult> Index()
        {
            var totalDestinations = await _context.TimeDestinations.CountAsync();
            var totalBookings = await _context.Bookings.CountAsync();
            var totalCustomers = await _context.Customers.CountAsync();

            // Toplam Ciro Hesaplama
            decimal totalRevenue = 0;
            if (totalBookings > 0)
            {
                totalRevenue = await _context.Bookings
                    .Include(b => b.TimeDestination)
                    .SumAsync(b => b.PassengerCount * (b.TimeDestination != null ? b.TimeDestination.Price : 0));
            }

            ViewBag.TotalDestinations = totalDestinations;
            ViewBag.TotalBookings = totalBookings;
            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalRevenue = totalRevenue;

            var destinations = await _context.TimeDestinations.ToListAsync();
            return View(destinations);
        }

        // Yeni Rota Ekleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDestination(TimeDestination destination)
        {
            if (ModelState.IsValid)
            {
                _context.TimeDestinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // Rota Silme
        [HttpPost]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var destination = await _context.TimeDestinations.FindAsync(id);
            if (destination != null)
            {
                // Önce bu rotaya ait yapılmış rezervasyonları bulup siliyoruz
                var relatedBookings = _context.Bookings.Where(b => b.TimeDestinationId == id);
                _context.Bookings.RemoveRange(relatedBookings);

                // Şimdi rotayı güvenle silebiliriz
                _context.TimeDestinations.Remove(destination);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}