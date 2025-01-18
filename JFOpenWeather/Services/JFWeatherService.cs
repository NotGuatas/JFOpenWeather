using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using JFOpenWeather.Models;


namespace JFOpenWeather.Services;

public class JFWeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "cf2d539a5efe27414b7afccb2b553009";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public JFWeatherService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<JFWeahterInfo> GetWeatherAsync(string city)
    {
        var url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric&lang=es";
        var response = await _httpClient.GetStringAsync(url);
        return JsonConvert.DeserializeObject<JFWeahterInfo>(response);
    }
}

