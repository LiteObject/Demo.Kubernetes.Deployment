using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Demo.Kubernetes.Deployment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cities = new[]
        {
            "Fargo", "Frisco", "Fort Worth","Dhaka", "Dallas", "Moorhead"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogInformation("{ctor} has been instantiated.", nameof(WeatherForecastController));
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("{method} has been invoked.", nameof(Get));

            var rnd = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                City = Cities[rnd.Next(Cities.Length)],
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rnd.Next(-20, 55),
                Summary = Summaries[rnd.Next(Summaries.Length)]
            })
            .ToArray();

            _logger.LogInformation("Result: {result}", System.Text.Json.JsonSerializer.Serialize(result));

            return Ok(result);
        }
    }
}
