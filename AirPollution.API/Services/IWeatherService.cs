using AirPollution.API.Models;

namespace AirPollution.API.Services
{
    public interface IWeatherService
    {
        List<Weather> ProcesWeather(List<Weather> weather);
    }
}
