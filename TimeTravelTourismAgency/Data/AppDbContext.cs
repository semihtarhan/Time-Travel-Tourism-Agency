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
    }
}
