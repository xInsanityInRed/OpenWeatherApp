using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenWeatherApp.Models
{
    /// <summary>
    /// Class containing the fields included in a Geocode, as per Geocoding API
    /// https://openweathermap.org/api/geocoding-api?collection=other
    /// </summary>
    public class Geocode
    {
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }

        public Geocode(string name, float lat, float lon, string country, string state)
        {
            this.name = name;
            this.lat = lat;
            this.lon = lon;
            this.country = country;
            this.state = state;
        }
    }
}
