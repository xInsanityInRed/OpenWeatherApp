using System;
using System.Collections.Generic;
using System.Text;
using static OpenWeatherApp.Models.DailyWeather;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Weather results to display in application.
    /// </summary>
    public class WeatherResults : DailyWeather
    {
        public string cityName { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        /*public Temperature temp { get; set; }
        public Feels_Like feels_like { get; set; }

        public class Temperature
        {
            public float day { get; set; }
            public float min { get; set; }
            public float max { get; set; }
            public float night { get; set; }
            public float eve { get; set; }
            public float morn { get; set; }
        }

        public class Feels_Like
        {
            public float day { get; set; }
            public float night { get; set; }
            public float eve { get; set; }
            public float morn { get; set; }
        }

        public WeatherResults(string cityName, string country, string state, Temperature temp, Feels_Like feels_like)
        {
            this.cityName = cityName;
            this.country = country;
            this.state = state;
            this.temp = temp;
            this.feels_like = feels_like;
        }*/
    }
}
