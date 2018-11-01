using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IBO.MVC03.CircloidTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            if (Application["aktifKullanici"]==null)
            {
               
                Application["aktifKullanici"] = 1;
            }
            else
            {
                Application["aktifKullanici"] = (int)Application["aktifKullanici"] + 1;
            }

            if (Application["toplamZiyaretci"]==null)
            {
                Application["toplamZiyaretci"] = 1;
            }
            else
            {
                Application["toplamZiyaretci"] =(int) Application["toplamZiyaretci"] + 1;
            }

        }
        protected void Session_End()
        {
            Application["aktifKullanici"] = (int)Application["aktifKullanici"] - 1;
        }

    }
}
