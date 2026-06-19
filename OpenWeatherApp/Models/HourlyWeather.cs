using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Class that contains fields for Hourly Weather Forecasts as set by OpenWeather API.
    /// </summary>
    public class HourlyWeather
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public DataList[] data { get; set; }
        public string prev { get; set; }
        public string next { get; set; }

        public class DataList
        {
            public int dt { get; set; }
            public int temp { get; set; }
            public float feels_like { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float dew_point { get; set; }
            public float uvi { get; set; }
            public int clouds { get; set; }
            public int visibility { get; set; }
            public float wind_speed { get; set; }
            public int wind_deg { get; set; }
            public float wind_gust { get; set; }
            public WeatherInfo[] weather { get; set; }
            public string[] alerts { get; set; }
            public int pop { get; set; }
        }

        public class WeatherInfo
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
    }
}
