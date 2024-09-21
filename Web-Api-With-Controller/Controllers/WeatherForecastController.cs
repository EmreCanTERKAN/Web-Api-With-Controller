using Microsoft.AspNetCore.Mvc;

namespace Web_Api_With_Controller.Controllers
{
    // Bu s�n�f�n bir api controller oldu�unu belirtiyor.
    [ApiController]
    // Burada ise WeatherForecastController olarak tamam� de�il sadece WeatherForecast'i almas�n� bekliyor.
    [Route("[controller]")]

    // Buradaki miras alan s�n�f�n MVC'den fark� MVCde viewleri ile birlikte miras almaktad�r. AP�lerde ise Controller'dan miras almaktad�r.
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly ILogger<WeatherForecastController> _logger;
        // constructor tan�mlanm�� // Dependency Injection olarak ba��ml�l��� enjekte etmi�tir.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // GetWeatherForecast end point ile get i�lemlerinin d�nd���n� belirten bir attribute tan�mlan�yor. Bu metot bu i�e yarayaca��n�n bilgisini vermektedir.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
