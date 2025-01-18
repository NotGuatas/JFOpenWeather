using JFOpenWeather.Services;

namespace JFOpenWeather
{
    public partial class MainPage : ContentPage
    {
        private readonly JFWeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new JFWeatherService();
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            var city = CityEntry.Text;
            if (!string.IsNullOrWhiteSpace(city))
            {
                try
                {
                    var weather = await _weatherService.GetWeatherAsync(city);
                    TemperatureLabel.Text = $"Temperatura: {weather.Main.Temp}°C";
                    DescriptionLabel.Text = $"Descripción: {weather.Weather[0].Description}";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo obtener el clima. Verifique el nombre de la ciudad e intente nuevamente.", "OK");
                }
            }

        }

    }
}

