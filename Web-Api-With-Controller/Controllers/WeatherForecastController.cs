using Microsoft.AspNetCore.Mvc;

namespace Web_Api_With_Controller.Controllers
{
    // Bu sýnýfýn bir api controller olduðunu belirtiyor.
    [ApiController]
    // Burada ise WeatherForecastController olarak tamamý deðil sadece WeatherForecast'i almasýný bekliyor.
    [Route("[controller]")]

    // Buradaki miras alan sýnýfýn MVC'den farký MVCde viewleri ile birlikte miras almaktadýr. APÝlerde ise Controller'dan miras almaktadýr.
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly ILogger<WeatherForecastController> _logger;
        // constructor tanýmlanmýþ // Dependency Injection olarak baðýmlýlýðý enjekte etmiþtir.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // GetWeatherForecast end point ile get iþlemlerinin döndüðünü belirten bir attribute tanýmlanýyor. Bu metot bu iþe yarayacaðýnýn bilgisini vermektedir.
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
