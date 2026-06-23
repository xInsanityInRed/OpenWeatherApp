using Newtonsoft.Json;
using OpenWeatherApp.Models;
using OpenWeatherApp.Services;
using PCLStorage;

namespace OpenWeatherApp.Views;

public partial class SearchCitiesPage : ContentPage
{
	public List<Geocode> place;
    CurrentWeather weatherResult;
    public int searchLimit = 5;
    WeatherApiService service = new WeatherApiService("b3aa72c0e805f0c66fae53311f9f0d47", "https://api.openweathermap.org/", "metric");

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

        
        UnixToUtcConverter timeConverter = new();
        SetImagesService convertImages = new();
        List<CurrentWeatherData> listOfWeatherResults = new();
        
        place = await service.TranslateCityToGeocode(searchBar.Text, service);
        weatherResult = await service.GetWeatherSearchResults(searchBar.Text, service, place[0]);

        // Change CurrentWeather items
        weatherResult.data[0].dateTime = timeConverter.ToDateTime(weatherResult.data[0].dt, weatherResult.timezone_offset);
        weatherResult.data[0].cityName = $"{place[0].name}, {place[0].state}";
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

    private async void favoriteButton_Clicked(object sender, EventArgs e)
    {
        favouriteButton.Text = "♥";
        // Get city Geocode object from latest collection view item
        if (CityCollectionSearchResults.ItemsSource != null)
        {
            List<CurrentWeatherData> cityData = (List<CurrentWeatherData>)CityCollectionSearchResults.ItemsSource;
            var location = cityData[0].cityName;
            var cityName = location.Split(",").First();

            place = await service.TranslateCityToGeocode(cityName, service);
            Geocode city = place[0];

            // Convert city to JSON string and create file
            string cityJsonData = JsonConvert.SerializeObject(city);

            string folderName = "OpenWeatherAppData";
            string favouriteCityJsonFile = "FavouriteCities.json";
            string contentToSave = cityJsonData;
            string loadedContent = "";

            IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(favouriteCityJsonFile, CreationCollisionOption.OpenIfExists);

            IFile openFile = await folder.GetFileAsync(favouriteCityJsonFile);

            loadedContent = await openFile.ReadAllTextAsync();
            await file.WriteAllTextAsync(loadedContent + contentToSave);

        }
        else
        {
            await DisplayAlertAsync("Error", "City cannot be saved", "OK");
        }


    }
}