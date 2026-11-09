using Microsoft.AspNetCore.Mvc;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context; // Kendi DbContext sınıfın

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ViewBag.Error = "Lütfen e-posta adresinizi girin.";
                return View(model);
            }

            var customer = _context.Customers
                .FirstOrDefault(c => c.Email.ToLower() == model.Email.Trim().ToLower());

            if (customer == null)
            {
                ViewBag.Error = "Bu e-posta adresine kayıtlı müşteri bulunamadı.";
                return View(model);
            }

            // Oturuma ID ve Tam Adı kaydediyoruz
            HttpContext.Session.SetInt32("CustomerId", customer.Id);
            HttpContext.Session.SetString("CustomerName", $"{customer.FirstName} {customer.LastName}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        // --- ADMİN GİRİŞ İŞLEMLERİ ---

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);

            if (admin == null)
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }

            // Admin oturumunu başlatıyoruz
            HttpContext.Session.SetInt32("AdminId", admin.Id);
            HttpContext.Session.SetString("AdminName", admin.Username);

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("AdminId");
            HttpContext.Session.Remove("AdminName");
            return RedirectToAction("AdminLogin", "Auth");
        }
    }
}