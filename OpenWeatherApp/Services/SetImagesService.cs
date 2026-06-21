using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Services
{
    /// <summary>
    /// Change current icon name from API to icon name in Resources/Images folder
    /// </summary>
    internal class SetImagesService
    {
        Dictionary<string, string> iconNameEquivalentsDictionary = new Dictionary<string, string>
        {
            {"01d", "icon_clear_day.png"},
            {"01n", "icon_clear_night.png"},
            {"02d", "icon_few_clouds_day.png"},
            {"02n", "icon_few_clouds_night.png"},
            {"03d", "icon_scattered_clouds_day.png"},
            {"03n", "icon_scattered_clouds_night.png"},
            {"04d", "icon_broken_clouds_day.png"},
            {"04n", "icon_broken_clouds_night.png"},
            {"09d", "icon_drizzle_day.png"},
            {"09n", "icon_drizzle_night.png"},
            {"10d", "icon_rain_day.png"},
            {"10n", "icon_rain_night.png"},
            {"11d", "icon_thunderstorm_day.png"},
            {"11n", "icon_thunderstorm_night.png"},
            {"13d", "icon_snow_day.png"},
            {"13n", "icon_snow_night.png"},
            {"50d", "icon_mist_day.png"},
            {"50n", "icon_mist_night.png"}
        };

        Dictionary<string, string> backgroundDictionary = new Dictionary<string, string>
        {
            {"Thunderstorm", "thunderstorm.png"},
            {"Drizzle", "rain_image.png"},
            {"Rain", "rain_image.png"},
            {"Snow", "snow_weather.png"},
            {"Atmosphere", "mist_weather.png"},
            {"Clear", "blue_sky.png"},
            {"Clouds", "cloudy_sky.png"}
        };

        public string ConvertToIconFilename(string apiIconName)
        {
            string newIconName;

            foreach (var name in iconNameEquivalentsDictionary)
            {
                if (apiIconName == name.Key)
                {
                    newIconName = name.Value;
                    return newIconName;
                }
            }
            return "icon_clear_day.png";
        }

        public string SetBackground(string apiMainWeatherName)
        {
            string newBackgroundName;

            foreach (var name in backgroundDictionary)
            {
                if (apiMainWeatherName == name.Key)
                {
                    newBackgroundName = name.Value;
                    return newBackgroundName;
                }
            }
            return "mist_weather.png";
        }
    }
}
