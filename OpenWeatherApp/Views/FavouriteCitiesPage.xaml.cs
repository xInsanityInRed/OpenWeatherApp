using Newtonsoft.Json;
using OpenWeatherApp.Models;
using PCLStorage;

namespace OpenWeatherApp.Views;

public partial class FavouriteCitiesPage : ContentPage
{
	string favouriteCityJsonFile = "FavouriteCities.json";
	List<Geocode> favouriteCities;
	JsonSerializer serializer = new();

    public FavouriteCitiesPage()
	{
		InitializeComponent();
	}

    private async void LoadFavouritesButton_Clicked(object sender, EventArgs e)
    {
        IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;
        folder = await folder.CreateFolderAsync(favouriteCityJsonFile, CreationCollisionOption.OpenIfExists);

		ExistenceCheckResult folderExists = await folder.CheckExistsAsync(favouriteCityJsonFile);
        if (folderExists == ExistenceCheckResult.FileExists)
		{
			string favouritesJsonString = File.ReadAllText(favouriteCityJsonFile);
			List<Geocode> savedCities = JsonConvert.DeserializeObject<List<Geocode>>(favouritesJsonString);

			FavouriteCitiesCollectionView.ItemsSource = savedCities;
        }
		else
		{
			await DisplayAlertAsync("Error", "You haven't saved any cities!", "OK");
		}
    }
}