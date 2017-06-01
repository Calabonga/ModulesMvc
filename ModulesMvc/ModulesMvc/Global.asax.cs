using System.Web.Mvc;
using System.Web.Routing;

namespace ModulesMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacConfig.Initialize();
        }
    }
}
