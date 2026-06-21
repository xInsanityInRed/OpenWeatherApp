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
        WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");
        
        place = await service.TranslateCityToGeocode(searchBar.Text, service);
        weatherResult = await service.GetWeatherSearchResults(searchBar.Text, service, place[0]);
        List<CurrentWeatherData> listOfWeatherResults = new();
        
        if (weatherResult != null && place != null)
        {

            /*customWeather = new Dictionary<string, string> {
                {"nameOfCity", place[0].name},
                {"nameOfCountry", place[0].country},
                {"nameOfState", place[0].state },
                {"actualDaytimeTemp", weatherResult.data[0].temp.day.ToString()},
                {"actualMinTemp", weatherResult.data[0].temp.min.ToString()},
                {"actualMaxTemp", weatherResult.data[0].temp.max.ToString()},
                {"feelsLikeDaytimeTemp", weatherResult.data[0].feels_like.day.ToString()}
            };*/
            foreach (var result in weatherResult.data)
            {
                listOfWeatherResults.Add(result);
            }
            CityCollectionSearchResults.ItemsSource = listOfWeatherResults;
        }
    }
}