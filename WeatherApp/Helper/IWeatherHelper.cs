using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.Helper
{
    /// <summary>
    /// Interface for WeatherHelper
    /// </summary>
    public interface IWeatherHelper
    {
        IEnumerable<City> getCityByCountryName(string CountryName);

        IEnumerable<CityWeatherInfo> GetCityWeatherInfo(string city,string Country);

        IEnumerable<CityWeatherInfo> GetCityWeatherInfo(CityWeatherInfo info);

    }
}
