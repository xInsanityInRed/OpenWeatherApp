using OpenWeatherApp.Models;
using OpenWeatherApp.Services;

namespace OpenWeatherApp.Views;

public partial class SunriseAndSunsetPage : ContentPage
{
    List<Geocode> place;
    CurrentWeather weatherResult;

    public SunriseAndSunsetPage()
	{
		InitializeComponent();
	}

    private async void SunriseAndSunsetSearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");
        UnixToUtcConverter timeConverter = new();
        List<CurrentWeatherData> listOfWeatherResults = new();

        place = await service.TranslateCityToGeocode(searchBar.Text, service);
        weatherResult = await service.GetWeatherSearchResults(searchBar.Text, service, place[0]);

        weatherResult.data[0].cityName = $"{place[0].name}, {place[0].state}";
        weatherResult.data[0].dateTime = timeConverter.ToDayMonthOnly(weatherResult.data[0].dt, weatherResult.timezone_offset);

        if (weatherResult.data[0].sunrise.ToString() != null && place != null)
        {
            weatherResult.data[0].new_sunrise = timeConverter.ToTimeOnly(weatherResult.data[0].sunrise, weatherResult.timezone_offset);
            weatherResult.data[0].new_sunset = timeConverter.ToTimeOnly(weatherResult.data[0].sunset, weatherResult.timezone_offset);
            foreach (var result in weatherResult.data)
            {
                listOfWeatherResults.Add(result);
            }
            RiseAndSetCollectionView.ItemsSource = listOfWeatherResults;
        }
        else
        {
            RiseAndSetCollectionView.ItemsSource = listOfWeatherResults;
            await DisplayAlertAsync("Error", "No data found! Maybe the sun doesn't set/rise often here...", "OK");
        }
    }
}