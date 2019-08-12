using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unicorn.Core;
using Unicorn.Core.Middlewares;

namespace Unicorn
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 创建 Web API 的配置
            var config = new HttpConfiguration();
            // 启用标记路由
            //config.MapHttpAttributeRoutes();
            // 默认的 Web API 路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{area}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //启用Swagger
            config.EnableSwagger(x => x.SingleApiVersion("v1", "Application Name")).EnableSwaggerUi();

            //xml格式输出结果
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.Services.Replace(typeof(IAssembliesResolver), new ServiceAssembliesResolver());

            app.Use<StaticMiddleware>();

            // 将路由配置附加到 appBuilder
            app.UseWebApi(config);
        }
    }
}