using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Services
{
    /// <summary>
    /// Converts Unix timestamps to UTC time, and vice versa. Used for processing the timestamps included in the OpenWeather Map API response, which are in Unix format.
    /// </summary>
    internal class UnixToUtcConverter
    {
        public DateTime ToDateTime(int unixTime)
        {
            return new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime));
        }
    }
}
