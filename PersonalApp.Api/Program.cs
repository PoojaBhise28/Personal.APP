using Microsoft.EntityFrameworkCore;
using PersonalApp.Data;
using PersonalApp.IRepository;
using PersonalApp.IService;
using PersonalApp.Repository;
using PersonalApp.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("DefaultConnection");
 

builder.Services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("PersonalApp.Api")));

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();




builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
app.MapControllers();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
