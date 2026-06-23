using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Services
{
    /// <summary>
    /// Converts Unix timestamps from API to UTC time, date, day of the week and datetime.
    /// </summary>
    internal class UnixToUtcConverter
    {
        public string ToTimeOnly(int unixTime, int timeOffset)
        {
            var newDateTime = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime + timeOffset));
            string formattedDateTime = newDateTime.ToString("HH:mm");
            return formattedDateTime;
        }

        public string ToDayMonthOnly(int unixTime, int timeOffset)
        {
            var newDateTime = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime + timeOffset));
            string formattedDateTime = newDateTime.ToString("dd-MM");
            return formattedDateTime;
        }
        public string ToDayOfTheWeekOnly(int unixTime, int timeOffset)
        {
            var newDateTime = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime + timeOffset));
            string formattedDateTime = newDateTime.ToString("dddd");
            return formattedDateTime;
        }

        public string ToDateTime(int unixTime, int timeOffset)
        {
            var newDateTime = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime + timeOffset));
            string formattedDateTime = newDateTime.ToString("dd-MM-yyyy HH:mm");
            return formattedDateTime;
        }
    }
}
