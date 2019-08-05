﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApplicationToken
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            // ELIMINAMOS EL FORMATEADOR DE RESPUESTAS XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            // HABILITAMOS EL FORMATEADOR DE RESPUESTAS JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // HABILITAMOS EL SERIALIZADOR DE XML
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // AÑADE EL HANDLER DE VALIDACIÓN DE TOKENS
            config.MessageHandlers.Add(new ValidarTokenHandler());
        }
    }
}
