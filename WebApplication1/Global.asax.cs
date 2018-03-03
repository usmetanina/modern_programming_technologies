using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static AssemblyCatalog catalog { get; set; } 

        protected void Application_Start()
        {
            var newAssembly = "ioc";
            var pathNewAssembly = Directory.GetParent((Server.MapPath("~"))).Parent.FullName + @"\" + newAssembly + @"\bin\Debug\" + newAssembly + ".exe";

            catalog = new AssemblyCatalog(Assembly.LoadFile(pathNewAssembly));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
