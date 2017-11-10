using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WeatherApp.Helper;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherHelper _objHelper;
        
        public WeatherController(IWeatherHelper objHelper)
        {
            if (objHelper==null)
            {
                throw new ArgumentNullException("IWeatherHelper is Null");
            }
            this._objHelper = objHelper;
        }
       /// <summary>
       /// Get list of Cities from Service by Country
       /// </summary>
       /// <param name="Country"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("GetCities/{Country}")]
        public IHttpActionResult GetCities(string Country)
        {
            var cityList = _objHelper.getCityByCountryName(Country);
            if (cityList==null || cityList.Count() ==0)
            {
                return NotFound();
            }
            return Ok(cityList);

        }

        /// <summary>
        /// Get City Info by passing CityWeatherInfo Object
        /// </summary>
        /// <param name="cityInfo"></param>
        /// <returns></returns>
        [Route("GetCityWeatherInfo")]
        [HttpPost]
        public IHttpActionResult GetCityWeatherInfo(CityWeatherInfo cityInfo)
        {
            var cityList = _objHelper.GetCityWeatherInfo(cityInfo);
            if (cityList == null || cityList.Count() == 0)
            {
                return NotFound();
            }
            return Ok(cityList);
        }


        /// <summary>
        /// This API can be used to send id(city) and Country as string. This is an additional API which is not used from Client APP
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Country"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("WeatherInfoForCity/{id}/{Country}")]
        public IHttpActionResult WeatherInfoForCity(string id,string Country)
        {
         
           var cityInfo = _objHelper.GetCityWeatherInfo(id, Country);
            if (cityInfo == null)
            {
                return NotFound();
            }
            return Ok(cityInfo);
        }

     
    }
}
