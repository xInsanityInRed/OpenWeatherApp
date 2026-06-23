using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Models
{
    public class CurrentWeather
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public CurrentWeatherData[] data { get; set; }
    }
    public class CurrentWeatherData
    {
        public string dateTime { get; set; }
        public string cityName { get; set; }
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float max_temp { get; set; }
        public float min_temp { get; set; }
        public float pressure { get; set; }
        public int humidity { get; set; }
        public float dew_point { get; set; }
        public WeatherInfo[] weather { get; set; }
        public int clouds { get; set; }
        public float uvi { get; set; }
        public float visibility { get; set; }
        public float wind_speed { get; set; }
        public int wind_deg { get; set; }
        public float wind_gust { get; set; }
    }
}
