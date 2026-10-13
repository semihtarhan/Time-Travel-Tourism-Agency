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
    }
}
