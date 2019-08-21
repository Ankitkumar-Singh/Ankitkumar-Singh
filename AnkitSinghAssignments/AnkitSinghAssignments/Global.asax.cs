using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnkitSinghAssignments
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<AnkitSinghAssignments.Models.GuestListContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}
