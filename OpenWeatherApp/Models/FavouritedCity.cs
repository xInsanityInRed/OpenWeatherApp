using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenWeatherApp.Models
{
    class FavouritedCity
    {
        public string cityName { get; set; }
        public float cityLatitude { get; set; }
        public float cityLongitude { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }
}
