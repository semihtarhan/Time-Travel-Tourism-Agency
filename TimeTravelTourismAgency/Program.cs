using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.Services;

var builder = WebApplication.CreateBuilder(args);

//PostgreSQL DbContext Servis Kaydý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Interface & Services.
//builder.Services.AddScoped<ITimeDestinationService, TimeDestinationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. EKLENEN: Swagger Servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // 2. EKLENEN: Geliþtirme (Development) ortamýnda Swagger'ý açar
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
