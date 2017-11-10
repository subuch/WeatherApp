using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helper;
using WeatherApp.Models;

namespace WeatherApp.Tests.Controllers
{
    public class WeatherHelperTest : IWeatherHelper
    {
        public WeatherHelperTest()
        {

        }
        public IEnumerable<City> getCityByCountryName(string CountryName)
        {
            if(CountryName==null)
            {
                return null;
            }
              var obj = new List<City>()
                {
                   new City(){CityName = "Sydney"},
                    new City(){CityName = "Adelaide"}
                };
              return obj;
        }

        public IEnumerable<CityWeatherInfo> GetCityWeatherInfo(string city, string Country)
        {
            var obj = new List<CityWeatherInfo>()
            {
               new CityWeatherInfo(){Location = "Dubai"},
                new CityWeatherInfo(){Location = "London"}
            };
            return obj;
        }

        public IEnumerable<CityWeatherInfo> GetCityWeatherInfo(CityWeatherInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
