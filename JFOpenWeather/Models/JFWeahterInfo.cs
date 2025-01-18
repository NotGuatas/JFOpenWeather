using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFOpenWeather.Models;

public class JFWeahterInfo
{
    public Main Main { get; set; }
    public Weather[] Weather { get; set; }
}

public class Main
{
    public float Temp { get; set; }
    public int Humidity { get; set; }
}

public class Weather
{
    public string Description { get; set; }
    public string Icon { get; set; }
}