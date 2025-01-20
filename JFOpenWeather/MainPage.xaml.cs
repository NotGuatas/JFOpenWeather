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

        private async void ObtenerClima(object sender, EventArgs e)
        {
            var city = CityEntry.Text;
            if (!string.IsNullOrWhiteSpace(city))
            {
                try
                {
                    var weather = await _weatherService.GetWeatherAsync(city);

                    TemperatureLabel.Text = $"Temperatura actual: {weather.Main.Temp}°C";
                    MinMaxTempLabel.Text = $"Mín: {weather.Main.TempMin}°C, Máx: {weather.Main.TempMax}°C";
                    DescriptionLabel.Text = $"Descripción: {weather.Weather[0].Description}";
                    WindLabel.Text = $"Viento: {weather.Wind.Speed} m/s, Dirección: {weather.Wind.Deg}°";
                    PressureLabel.Text = $"Presión: {weather.Main.Pressure} hPa";

                    var sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.Sys.Sunrise).ToLocalTime();
                    var sunset = DateTimeOffset.FromUnixTimeSeconds(weather.Sys.Sunset).ToLocalTime();
                    SunriseSunsetLabel.Text = $"Amanecer: {sunrise:HH:mm}, Atardecer: {sunset:HH:mm}";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo obtener el clima. Verifique el nombre de la ciudad e intente nuevamente.", "OK");
                }
            }
        }
    }
}

