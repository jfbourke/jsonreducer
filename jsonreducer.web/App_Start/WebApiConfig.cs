﻿using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace jsonreducer.web.App_Start
{
    public static class WebApiConfig
    {
        public static void ConfigureApi(HttpConfiguration config)
        {
            // todo: consider removing other formatters

            // setup json formatting 
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            RegisterRoutes(config);
        }

        static void RegisterRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("JsonReducerApi", "{controller}/", new { controller = "JsonReducer" });

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}