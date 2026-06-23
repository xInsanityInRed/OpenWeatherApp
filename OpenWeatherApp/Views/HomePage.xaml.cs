using OpenWeatherApp.Models;
using OpenWeatherApp.Services;

namespace OpenWeatherApp.Views;

public partial class HomePage : ContentPage
{
    string currentCityName = "Perth";
    List<Geocode> place;
    CurrentWeather weatherResult;
    
    float minTemp;
    float maxTemp;

    public HomePage()
	{
		InitializeComponent();
	}

    private async void LoadLocalWeather_Clicked(object sender, EventArgs e)
    {
        WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");
        UnixToUtcConverter timeConverter = new();
        SetImagesService convertImages = new();
        List<CurrentWeatherData> listOfWeatherResults = new();

        //Get current location latitude & longitude
        place = await service.TranslateCityToGeocode(currentCityName, service);
        weatherResult = await service.GetWeatherSearchResults(currentCityName, service, place[0]);
        (minTemp, maxTemp) = await service.GetMinAndMaxTemperatures(service, place[0]);

        // Change CurrentWeather items
        weatherResult.data[0].dateTime = timeConverter.ToDateTime(weatherResult.data[0].dt, weatherResult.timezone_offset);
        weatherResult.data[0].cityName = $"{place[0].name}, {place[0].state}";
        weatherResult.data[0].min_temp = minTemp;
        weatherResult.data[0].max_temp = maxTemp;

        var iconName = weatherResult.data[0].weather[0].icon;
        weatherResult.data[0].weather[0].icon = convertImages.ConvertToIconFilename(iconName);

        if (weatherResult != null && place != null)
        {
            foreach (var result in weatherResult.data)
            {
                listOfWeatherResults.Add(result);
            }
            HomeCollectionView.ItemsSource = listOfWeatherResults;
        }
    }
}