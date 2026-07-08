namespace OpenWeatherApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void TemperatureTypeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
		if (TemperatureTypeSwitch.IsToggled)
		{
			Preferences.Set("TemperatureType", "imperial");
		}
		else
		{
			Preferences.Set("TemperatureType", "metric");
		}
    }
}