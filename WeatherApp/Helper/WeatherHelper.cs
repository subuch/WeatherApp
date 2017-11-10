using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WeatherApp.Models;
using System.Data;
using System.Data.Entity;
using System.Web.Script.Serialization;

namespace WeatherApp.Helper
{
    public class WeatherHelper:IWeatherHelper
    {
        private GlobalWeatherService.GlobalWeatherSoap _serviceObject;

        public WeatherHelper()
        {
            _serviceObject = new GlobalWeatherService.GlobalWeatherSoapClient();
        }

        /// <summary>
        /// This helper Method to get list of Cities by Country
        /// </summary>
        /// <param name="CountryName"></param>
        /// <returns></returns>
        public IEnumerable<City> getCityByCountryName(string CountryName)
        {
            XDocument xDoc;
            string strReponse = this.getCityFromService(CountryName);
            if (strReponse == null)
            {
                return null;
            }
            using (StringReader sr = new StringReader(strReponse))
            {
                xDoc = XDocument.Load(sr);
                var elementCity= (from xmlElement in xDoc.Descendants("City")
                        select  new City { CityName= xmlElement.Value}).ToList<City>();
                return elementCity;
            }           
            
        }

        /// <summary>
        /// This helper method is a overloading type to get City info by City and Country
        /// </summary>
        /// <param name="city"></param>
        /// <param name="Country"></param>
        /// <returns></returns>
        public IEnumerable<CityWeatherInfo> GetCityWeatherInfo(string city, string Country)
        {
            XDocument xDoc;
            string strReponse = this.getWeatherInfoFromService(city, Country);
            if (strReponse==null || strReponse=="Data Not Found")
            {
                return null;
            }
            using (StringReader sr = new StringReader(strReponse))
            {
                xDoc = XDocument.Load(sr);
                var elementCity = (from xmlElement in xDoc.Descendants("City")
                                   select new CityWeatherInfo { Location = xmlElement.Value }).ToList<CityWeatherInfo>();
                return elementCity;
            }
        }

        /// <summary>
        /// This helper method can be used to get a mock WeatherInfo for a city from JSON file
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<CityWeatherInfo> GetCityWeatherInfo(CityWeatherInfo info)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\WeatherInfo.json";  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist= ser.Deserialize<List<CityWeatherInfo>>(Json);
            return personlist.FindAll(c => c.Country == info.Country && c.Location == info.Location);
        }

        #region ServiceCall
        /// <summary>
        /// Methods to hit the Web Service
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        private string getCityFromService(string countryName)
        {
            return this._serviceObject.GetCitiesByCountry(countryName);
        }

        private string getWeatherInfoFromService(string cityName, string countryName)
        {
            return this._serviceObject.GetWeather(cityName, countryName);
        }


        #endregion
            }
}