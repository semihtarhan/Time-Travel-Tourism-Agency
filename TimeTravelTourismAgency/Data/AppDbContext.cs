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
}
