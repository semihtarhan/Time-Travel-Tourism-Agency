using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Models;

namespace TimeTravelTourismAgency.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    //postgreSQL tarafında tablo olusturdum ve models sınıfımızladaki TimeDestination classımızla eslestirdim
    public DbSet<TimeDestination> TimeDestinations { get; set; }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Booking> Bookings => Set<Booking>();


    public DbSet<Admin> Admins => Set<Admin>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Booking - Customer İlişkisi
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Customer)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Booking - TimeDestination İlişkisi
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.TimeDestination)
            .WithMany()
            .HasForeignKey(b => b.TimeDestinationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>().HasData(

        new Customer { Id = 1, FirstName = "Ayşe", LastName = "Kaya", Email = "ayse.kaya@gelecek.com", PassportNumber = "TR123456789", Phone = "+905321112233", Password = "Password123*", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 2, FirstName = "Kaan", LastName = "Demir", Email = "kaan.demir@paradoks.com", PassportNumber = "TR987654321", Phone = "+905332223344", Password = "Time456*", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 3, FirstName = "Zeynep", LastName = "Çelik", Email = "zeynep.celik@zamanagaci.com", PassportNumber = "TR555666777", Phone = "+905553334455", Password = "Chrono789!", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 4, FirstName = "Can", LastName = "Özkan", Email = "can.ozkan@gecmis.net", PassportNumber = "TR111222333", Phone = "+905444445566", Password = "Kuantum2026!", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 5, FirstName = "Elif", LastName = "Yıldız", Email = "elif.yildiz@sonsuzluk.com", PassportNumber = "TR999888777", Phone = "+905305556677", Password = "Infinity99*", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 6, FirstName = "Burak", LastName = "Yılmaz", Email = "burak.yilmaz@gmail.com", PassportNumber = "TR555111222", Phone = "+905321234567", Password = "BurakPassword1*", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 7, FirstName = "Ceren", LastName = "Aydın", Email = "ceren.aydin@hotmail.com", PassportNumber = "TR777888999", Phone = "+905339876543", Password = "CerenTime2026!", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 8, FirstName = "Tolga", LastName = "Şahin", Email = "tolga.sahin@yahoo.com", PassportNumber = "TR112233445", Phone = "+905441112233", Password = "TolgaQuantum9^", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 9, FirstName = "Melis", LastName = "Koç", Email = "melis.koc@outlook.com", PassportNumber = "TR998877665", Phone = "+905556667788", Password = "MelisFuture5!", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) },
        new Customer { Id = 10, FirstName = "Ozan", LastName = "Tekin", Email = "ozan.tekin@icloud.com", PassportNumber = "TR334455667", Phone = "+905309998877", Password = "OzanHistory7*", CreatedAt = new DateTime(2026, 11, 14, 12, 0, 0, DateTimeKind.Utc) }
    );

        // 🚀 Zaman Rotaları (TimeDestination) Seed Verileri
        modelBuilder.Entity<TimeDestination>().HasData(
            new TimeDestination { Id = 1, Title = "Antik Roma", Description = "Kolezyum'daki gladyatör dövüşlerini canlı izleyin ve Roma Senatosu'na tanıklık edin.", TargetYear = "MS 80", Price = 12500, Capacity = 15, DangerLevel = 3 },
            new TimeDestination { Id = 2, Title = "Rönesans Floransa", Description = "Leonardo da Vinci ve Michelangelo'nun atölyelerini ziyaret edin, sanatın altın çağını yaşayın.", TargetYear = "1504", Price = 18000, Capacity = 10, DangerLevel = 1 },
            new TimeDestination { Id = 3, Title = "Jura Devri", Description = "Devasa dinozorların arasında, güvenli kuantum gözlem kubbemizden doğayı keşfedin.", TargetYear = "MÖ 150 Milyon", Price = 45000, Capacity = 8, DangerLevel = 5 },
            new TimeDestination { Id = 4, Title = "İstanbul'un Fethi", Description = "1453 yılında Fatih Sultan Mehmet'in akınlarına ve tarihi gemilerin karadan yürütülmesine tanık olun.", TargetYear = "1453", Price = 15000, Capacity = 20, DangerLevel = 4 },
            new TimeDestination { Id = 5, Title = "Viktorya Dönemi Londra", Description = "Sisli Londra sokaklarında at arabalarıyla gezinin ve Sherlock Holmes atmosferini soluyun.", TargetYear = "1888", Price = 9500, Capacity = 12, DangerLevel = 2 },
            new TimeDestination { Id = 6, Title = "Ay'a İlk Ayak Basılış", Description = "Apollo 11'in fırlatılışını Kennedy Uzay Merkezi'nden en önde izleyin.", TargetYear = "1969", Price = 35000, Capacity = 6, DangerLevel = 2 },
            new TimeDestination { Id = 7, Title = "Antik Yunan - Antik Olaylar", Description = "İlk Olimpiyat oyunlarının düzenlendiği Olympos'ta tarihin sportmenlik ruhunu hissedin.", TargetYear = "MÖ 776", Price = 11000, Capacity = 14, DangerLevel = 2 },
            new TimeDestination { Id = 8, Title = "Vahşi Batı", Description = "Teksas kasabalarında dönemin atmosferini yaşayın, tüccarlar ve şeriflerle tanışın.", TargetYear = "1875", Price = 13500, Capacity = 10, DangerLevel = 4 },
            new TimeDestination { Id = 9, Title = "Kuantum Gelecek - Neo İstanbul", Description = "Yüzyıllar sonrasının uçan arabaları ve holografik gökdelenleriyle dolu metropolünü keşfedin.", TargetYear = "3024", Price = 50000, Capacity = 25, DangerLevel = 1 },
            new TimeDestination { Id = 10, Title = "Mezopotamya - Babil", Description = "Babil'in Asma Bahçeleri'nin ihtişamını görün ve insanlık tarihinin ilk yazılı kanunlarına tanıklık edin.", TargetYear = "MÖ 1750", Price = 16000, Capacity = 12, DangerLevel = 3 }
        );


    }
}
