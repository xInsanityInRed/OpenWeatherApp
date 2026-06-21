using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Weather results to display in application's homepage.
    /// </summary>
    public class WeatherResults
    {
        public string cityName { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public float currentTemp { get; set; }
        public float minTemp { get; set; }
        public float maxTemp { get; set; }
        public float feels_likeTemp { get; set; }
        public string dayOfTheWeek { get; set; }
        public string hourOfTheDay { get; set; }

        public WeatherResults(string cityName, string country, string state, float currentTemp, float minTemp, float maxTemp, float feels_likeTemp)
        {
            this.cityName = cityName;
            this.country = country;
            this.state = state;
            this.currentTemp = currentTemp;
            this.minTemp = minTemp;
            this.maxTemp = maxTemp;
            this.feels_likeTemp = feels_likeTemp;
        }
    }
}
