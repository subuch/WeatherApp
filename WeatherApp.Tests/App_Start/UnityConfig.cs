using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WeatherApp.Helper;
using WeatherApp.Tests.Controllers;

namespace WeatherApp.Tests
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
          
            container.RegisterType<IWeatherHelper, WeatherHelper>();

            container.Resolve<IWeatherHelper>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}