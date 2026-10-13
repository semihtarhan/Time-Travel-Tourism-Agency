using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TimeTravelTourismAgency.Data;
using TimeTravelTourismAgency.Services;
using TimeTravelTourismAgency.Validators;

var builder = WebApplication.CreateBuilder(args);

// 1. PostgreSQL DbContext Servis Kaydý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Service & Repository Kayýtlarý
builder.Services.AddScoped<ITimeDestinationService, TimeDestinationService>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// 3. MVC + API Controllers Kaydý
builder.Services.AddControllersWithViews();

// 4. FluentValidation Otomatik Doðrulama Kaydý
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTimeDestinationDtoValidator>();

// 5. Swagger Servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // API route'larý için

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();