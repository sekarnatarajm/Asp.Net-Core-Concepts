using AspNetCoreLearning.Configuration.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLearning.Configuration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        private readonly ISmtpSettings _smtpSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config, ISmtpSettings smtpSettings)
        {
            _logger = logger;
            _config = config;
            _smtpSettings = smtpSettings;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var asas = _config["DevTeamNames"];
            var devTeamNames = _config["DevTeamNames"];

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("getsmtp/setting")]
        public IActionResult GetSmtpSetting()
        {
            var a = _smtpSettings.GetFrom();
            var aa = _smtpSettings.GetPassword();
            var aaa = _smtpSettings.GetUserName();
            var aaaa = _smtpSettings.GetPort();
            var smtpSetting = _config.GetSection("SmtpSettings").Get<SmtpSettings>();
            return Ok();
        }
    }
}
