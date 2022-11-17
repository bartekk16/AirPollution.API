namespace AirPollution.API.Models
{
    public class Weather
    {
        public string? Date { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double? AirPollution { get; set; }
        public double Humidity { get; set; }
    }
}
