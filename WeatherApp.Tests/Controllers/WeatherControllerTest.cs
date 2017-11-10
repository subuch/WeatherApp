using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using WeatherApp.Helper;
using WeatherApp.Controllers;
using Moq;
using WeatherApp.Models;
using System.Web.Http;
using System.Threading;
using System.Net;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Collections;
using System.Linq;
namespace WeatherApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for WeatherControllerTest
    /// </summary>
    [TestClass]
    public class WeatherControllerTest
    {
        private static IWeatherHelper _helper;

        /// <summary>
        /// Initialize method to register the mock helper and resolve t
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void WeatherClassInitial(TestContext context)
        {
            var container = new UnityContainer();
            container.RegisterType<IWeatherHelper, WeatherHelperTest>();
            _helper = container.Resolve<IWeatherHelper>();
        }


       /// <summary>
       /// Test method to check for 
       /// </summary>
       
        [TestMethod]
        [TestCategory("WeatherHelper")]

        public void verifyGetCitiesByEmpty()
        {
           //Arrange
            var controller = new WeatherController(_helper);
            //Act            
            var cityList = controller.GetCities(null) as IList<City>;
            //Assert
            Assert.IsNull(cityList);
        }

        /// <summary>
        /// Test method  to hit the moch helper to verify the data 
        /// </summary>
        [TestMethod]
        [TestCategory("WeatherHelper")]

        public void verifyGetCitiesByCountry()
        {
            //Arrange
            var controller = new WeatherController(_helper);
            
            //Act            
            IHttpActionResult contentResult= controller.GetCities("Australia"); 
            var response = contentResult as OkNegotiatedContentResult<IEnumerable<City>>;          

            //Assert
            Assert.AreEqual("Sydney", response.Content.First().CityName);       
        }

        /// <summary>
        /// Test method to test the exception
        /// </summary>

        [TestMethod]
        [TestCategory("WeatherController")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void verifyWeatherControllerConstructor()
        {           
            //Arrange
            var controller = new WeatherController(null);

            //Act            
            IHttpActionResult contentResult = controller.GetCities("Australia");
            var response = contentResult as OkNegotiatedContentResult<IEnumerable<City>>;

            //Assert
            Assert.IsNull(controller);
        }

        /// <summary>
        /// Test method to test weather info
        /// </summary>

        [TestMethod]
        public void verifyWeatherInfoByObject()
        {
            //Arrange

            var container = new UnityContainer();
            container.RegisterType<IWeatherHelper, WeatherHelper>("Helper");
            var _helper = container.Resolve<IWeatherHelper>("Helper");
            var controller = new WeatherController(_helper);

            CityWeatherInfo testInfo= new CityWeatherInfo()
            {
                Country = "Australia",
                Location = "Sydney"
            };

            //Act            
            IHttpActionResult contentResult = controller.GetCityWeatherInfo(testInfo);
            var response = contentResult as OkNegotiatedContentResult<IEnumerable<CityWeatherInfo>>;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("Sydney", response.Content.First().Location);       
        }
    }
}
