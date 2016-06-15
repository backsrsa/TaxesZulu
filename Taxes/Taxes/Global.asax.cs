using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Taxes.Classes;
using Taxes.Models;
using Taxes.Migrations;
namespace Taxes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaxesContext, Configuration>());
            this.CheckRoles();
            this.CheckSuperUser();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckSuperUser()
        {
            
        }

        private void CheckRoles()
        {
            Utilities.CheckRole("Admin");
            Utilities.CheckRole("Employee");
            Utilities.CheckRole("TaxPaer");
        }
    }
}
