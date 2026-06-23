using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using OpenWeatherApp.Models;
using Newtonsoft.Json;

namespace OpenWeatherApp.Services
{
    /// <summary>
    /// Handles any calls for the OpenWeather Map API (aka One Call API 4.0)
    /// </summary>
    internal class WeatherApiService
    {
        private string weatherApiKey;
        public string weatherApiUrl;
        //public string weatherTimeframe;
        public string temperatureUnit;

        public WeatherApiService(string apiKey, string url, string temperatureUnitsOfMeasurement)
        {
            this.weatherApiKey = apiKey;
            this.weatherApiUrl = url;
            this.temperatureUnit = temperatureUnitsOfMeasurement;
            //this.weatherTimeframe = timeframe;
        }

        // Get weather details using user's typed city
        public async Task<CurrentWeather> GetWeatherSearchResults(string cityName, WeatherApiService service, Geocode cityGeocode)
        {
            string requestUrl = service.weatherApiUrl + "data/4.0/onecall/" + "current" + "?lat=" + cityGeocode.lat + "&lon=" + cityGeocode.lon + "&units=" + service.temperatureUnit + "&appid=" + service.weatherApiKey;
            var response = await MakeRestRequest(requestUrl);
            CurrentWeather? weather = JsonConvert.DeserializeObject<CurrentWeather>(response);
            return weather;
        }

        // Get max and min temps
        public async Task<(float, float)> GetMinAndMaxTemperatures(WeatherApiService service, Geocode cityGeocode)
        {
            string requestUrl = service.weatherApiUrl + "data/4.0/onecall/" + "timeline/1day" + "?lat=" + cityGeocode.lat + "&lon=" + cityGeocode.lon + "&units=" + service.temperatureUnit + "&appid=" + service.weatherApiKey;
            var response = await MakeRestRequest(requestUrl);
            DailyWeather? weather = JsonConvert.DeserializeObject<DailyWeather>(response);
            return (weather.data[0].temp.min, weather.data[0].temp.max);
        }

        // Get weather alerts
        public async Task<List<WeatherAlert>> GetWeatherAlerts(WeatherApiService service, CurrentWeather cityweather)
        {
            List<WeatherAlert> listOfAlerts = new();
            for (int i = 0; i < cityweather.data[0].alerts.Count; i++)
            {
                string requestUrl = service.weatherApiUrl + "data/4.0/onecall/alert/" + cityweather.data[0].alerts[i] + "?appid=" + service.weatherApiKey;
                var response = await MakeRestRequest(requestUrl);
                WeatherAlert? alert = JsonConvert.DeserializeObject<WeatherAlert>(response);
                alert.cityName = cityweather.data[0].cityName;
                listOfAlerts.Add(alert);
            }
            return listOfAlerts;
        }

        // Translate city into geocode
        public async Task<List<Geocode>> TranslateCityToGeocode(string cityName, WeatherApiService service)
        {
            string geocodeUrl = service.weatherApiUrl + "geo/1.0/direct?q=" + cityName + "&limit=1&appid=" + service.weatherApiKey;
            var geocodeResponse = await MakeRestRequest(geocodeUrl);
            List<Geocode>? currentCityGeocode = JsonConvert.DeserializeObject<List<Geocode>>(geocodeResponse);
            return currentCityGeocode;
        }

        // Use for every function that requests data from OpenWeather
        // Returns Json to go into each function for processing
        private async Task<string> MakeRestRequest(string url)
        {
            HttpClient _client = new HttpClient();
            HttpRequestMessage restRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage responseMessage = await _client.SendAsync(restRequestMessage);

            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
