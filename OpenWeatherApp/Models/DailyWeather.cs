using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Class that contains fields for Daily Weather Forecasts as set by OpenWeather API.
    /// </summary>
    public class DailyWeather
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public Data[] data {  get; set; }
        public string prev { get; set; }
        public string next { get; set; }

        public class Data
        {
            [JsonPropertyName("data.dt")]
            public int dt { get; set; }
            [JsonPropertyName("data.sunrise")]
            public int sunrise { get; set; }
            [JsonPropertyName("data.sunset")]
            public int sunset { get; set; }
            [JsonPropertyName("data.moonrise")]
            public int moonrise { get; set; }
            [JsonPropertyName("data.moonset")]
            public int moonset { get; set; }
            [JsonPropertyName("data.moon_phase")]
            public float moon_phase { get; set; }
            [JsonPropertyName("data.temp")]
            public Temperature temp { get; set; }
            [JsonPropertyName("data.feels_like")]
            public Feels_Like feels_like { get; set; }
            [JsonPropertyName("data.pressure")]
            public int pressure { get; set; }
            [JsonPropertyName("data.humidity")]
            public int humidity { get; set; }
            [JsonPropertyName("data.dew_point")]
            public float dew_point { get; set; }
            [JsonPropertyName("data.wind_speed")]
            public float wind_speed { get; set; }
            [JsonPropertyName("data.wind_deg")]
            public int wind_deg { get; set; }
            [JsonPropertyName("data.wind_gust")]
            public float wind_gust { get; set; }
            public WeatherInfo[] weather { get; set; }
            public int clouds { get; set; }
            public int pop { get; set; }
            public float uvi { get; set; }
        }

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

        public class WeatherInfo
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }


    }
}
