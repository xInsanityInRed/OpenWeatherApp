using OpenWeatherApp.Models;
using OpenWeatherApp.Services;

namespace OpenWeatherApp.Views;

public partial class SearchCitiesPage : ContentPage
{
	public List<Geocode> place;
    CurrentWeather weatherResult;
    public int searchLimit = 5;
    public SearchCitiesPage()
	{
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        favouriteButton.IsVisible = true;
        favouriteButton.Text = "♡";

        WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");
        UnixToUtcConverter timeConverter = new();
        SetImagesService convertImages = new();
        List<CurrentWeatherData> listOfWeatherResults = new();
        
        place = await service.TranslateCityToGeocode(searchBar.Text, service);
        weatherResult = await service.GetWeatherSearchResults(searchBar.Text, service, place[0]);

        weatherResult.data[0].dateTime = timeConverter.ToDateTime(weatherResult.data[0].dt);

        // Change CurrentWeather items
        var iconName = weatherResult.data[0].weather[0].icon;
        weatherResult.data[0].weather[0].icon = convertImages.ConvertToIconFilename(iconName);

        var weatherConditionName = weatherResult.data[0].weather[0].main;
        weatherResult.data[0].weather[0].main = convertImages.SetBackground(weatherConditionName);

        if (weatherResult != null && place != null)
        {
            foreach (var result in weatherResult.data)
            {
                listOfWeatherResults.Add(result);
            }
            CityCollectionSearchResults.ItemsSource = listOfWeatherResults;
        }
    }

    private void favoriteButton_Clicked(object sender, EventArgs e)
    {
        favouriteButton.Text = "♥";
    }
}