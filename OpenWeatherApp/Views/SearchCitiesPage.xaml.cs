using Newtonsoft.Json;
using OpenWeatherApp.Models;
using OpenWeatherApp.Services;

namespace OpenWeatherApp.Views;

public partial class SearchCitiesPage : ContentPage
{
	public List<Geocode> place;
    CurrentWeather weatherResult;
    public int searchLimit = 5;
    string temperatureUnit;

    public SearchCitiesPage()
	{
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        CityCollectionSearchResults.ItemsSource = null;

        SearchBar searchBar = (SearchBar)sender;
        string cityQuery = (searchBar.Text).Replace(' ', '+');

        UnixToUtcConverter timeConverter = new();
        SetImagesService convertImages = new();
        List<CurrentWeatherData> listOfWeatherResults = new();
        temperatureUnit = WeatherApiService.GetTemperatureUnitType();
        WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", temperatureUnit);

        place = await service.TranslateCityToGeocode(cityQuery, service);
        if (place[0].name.Equals("Invalid"))
        {
            await DisplayAlertAsync("Error", "Did you spell the city correctly?", "OK");
        }
        else
        {
            weatherResult = await service.GetWeatherSearchResults(cityQuery, service, place[0]);

            // Change CurrentWeather items
            weatherResult.data[0].dateTime = timeConverter.ToDateTime(weatherResult.data[0].dt, weatherResult.timezone_offset);
            weatherResult.data[0].cityName = $"{place[0].name}, {place[0].state}";
            var iconName = weatherResult.data[0].weather[0].icon;
            weatherResult.data[0].weather[0].icon = convertImages.ConvertToIconFilename(iconName);
            if (temperatureUnit == "imperial")
            {
                weatherResult.data[0].temperatureUnitOfMeasurement = "°F";
            }
            else
            {
                weatherResult.data[0].temperatureUnitOfMeasurement = "°C";
            }

            var weatherConditionName = weatherResult.data[0].weather[0].main;
            weatherResult.data[0].weather[0].main = convertImages.SetBackground(weatherConditionName);

            foreach (var result in weatherResult.data)
            {
                listOfWeatherResults.Add(result);
            }
            CityCollectionSearchResults.ItemsSource = listOfWeatherResults;
        }
        
    }
}