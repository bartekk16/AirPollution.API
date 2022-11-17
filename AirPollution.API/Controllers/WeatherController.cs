using AirPollution.API.Models;
using AirPollution.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirPollution.API.Controllers
{
    [ApiController]
    [Route("api/Weather")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost]
        public List<Weather> ProcessWeather([FromBody]List<Weather> weather)
        {
            return _weatherService.ProcesWeather(weather);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
