using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Weather results to display in application's homepage.
    /// </summary>
    public class WeatherAlert
    {
        public string cityName { get; set; }
        public string id { get; set; }
        public string sender_name { get; set; }
        [JsonPropertyName("event")]
        public string event_type { get; set; }
        public float start { get; set; }
        public float end { get; set; }
        public string description { get; set; }
    }
}
