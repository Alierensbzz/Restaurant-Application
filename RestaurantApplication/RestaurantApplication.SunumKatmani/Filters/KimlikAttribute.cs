using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using RestaurantApplication.VarlikKatmani.Models;

namespace RestaurantApplication.SunumKatmani.Filters
{
    public class KimlikAttribute : FilterAttribute, IAuthenticationFilter   
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] != null)   
            {
                Kullanici user = filterContext.HttpContext.Session["user"] as Kullanici;
                if (user != null)
                {
                    return;  //Kullanıcı Giriş yapmıştır
                }
            }

            filterContext.Result = new HttpUnauthorizedResult(); //oturum açılmamışsa kullanıcı nesnesi null döndüyse yetkisiz erişim döner
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result != null && filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Kullanici" },   //Kullanıcı controllerin login actionana git
                        {"action", "Login" }
                    }
                    );
            }
        }
    }
}