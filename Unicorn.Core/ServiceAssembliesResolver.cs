using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace Unicorn.Core
{
    public class ServiceAssembliesResolver: DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            //动态加载dll中的Controller，类似于插件服务，在WebApiConifg中添加配置
            // config.Services.Replace(typeof(IAssembliesResolver), new PluginsResolver());

            List<Assembly> assemblies = new List<Assembly>(base.GetAssemblies());
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(directoryPath, "*Service.dll");
            foreach (var fileName in files)
            {
                assemblies.Add(Assembly.LoadFrom(Path.Combine(directoryPath, fileName)));
            }
            return assemblies;
        }
    }
}