﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherApp.GlobalWeatherService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET", ConfigurationName="GlobalWeatherService.GlobalWeatherSoap")]
    public interface GlobalWeatherSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetWeather", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetWeather(string CityName, string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetWeather", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetWeatherAsync(string CityName, string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetCitiesByCountry", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCitiesByCountry(string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetCitiesByCountry", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetCitiesByCountryAsync(string CountryName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GlobalWeatherSoapChannel : WeatherApp.GlobalWeatherService.GlobalWeatherSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GlobalWeatherSoapClient : System.ServiceModel.ClientBase<WeatherApp.GlobalWeatherService.GlobalWeatherSoap>, WeatherApp.GlobalWeatherService.GlobalWeatherSoap {
        
        public GlobalWeatherSoapClient() {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GlobalWeatherSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetWeather(string CityName, string CountryName) {
            return base.Channel.GetWeather(CityName, CountryName);
        }
        
        public System.Threading.Tasks.Task<string> GetWeatherAsync(string CityName, string CountryName) {
            return base.Channel.GetWeatherAsync(CityName, CountryName);
        }
        
        public string GetCitiesByCountry(string CountryName) {
            return base.Channel.GetCitiesByCountry(CountryName);
        }
        
        public System.Threading.Tasks.Task<string> GetCitiesByCountryAsync(string CountryName) {
            return base.Channel.GetCitiesByCountryAsync(CountryName);
        }
    }
}
