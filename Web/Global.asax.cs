using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region Dependency Injection with Autofac

            // http://docs.autofac.org/en/latest/integration/mvc.html

            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WebEAVContext>().AsSelf();

            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
