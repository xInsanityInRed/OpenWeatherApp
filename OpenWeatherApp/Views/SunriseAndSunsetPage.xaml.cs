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
        RiseAndSetCollectionView.ItemsSource = null;

        SearchBar searchBar = (SearchBar)sender;
        string cityQuery = (searchBar.Text).Replace(' ', '+');
        bool correctCharactersInQuery = true;
        foreach (var character in cityQuery)
        {
            if (Char.IsLetter(character) == false && character != '+')
            {
                correctCharactersInQuery = false;
                break;
            }
        }
        if (correctCharactersInQuery)
        {
            WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");
            UnixToUtcConverter timeConverter = new();
            List<CurrentWeatherData> listOfWeatherResults = new();

            place = await service.TranslateCityToGeocode(searchBar.Text, service);
            if (place[0].name.Equals("Invalid"))
            {
                await DisplayAlertAsync("Error", "Did you spell the city correctly?", "OK");
            }
            else
            {
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
                    RiseAndSetCollectionView.ItemsSource = null;
                }
            }
        }
        else
        {
            await DisplayAlertAsync("Error", "Please only use letters.", "OK");
        }
    }
}