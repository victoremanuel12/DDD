using Scalar.AspNetCore;
using Wpm.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();
app.EnsureDatabaseIsCreated();
// Scalar e OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Endpoint compatível com Scalar
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecastDto
        {
            Date = DateTime.Now.AddDays(index).ToString("yyyy-MM-dd"),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();

    return forecast; // Scalar detecta porque é array de tipo público
})
.WithName("GetWeatherForecast")
.WithTags("Weather");

app.Run();

// DTO público compatível com Scalar
public class WeatherForecastDto
{
    public string Date { get; set; } = default!;
    public int TemperatureC { get; set; }
    public string Summary { get; set; } = default!;
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
