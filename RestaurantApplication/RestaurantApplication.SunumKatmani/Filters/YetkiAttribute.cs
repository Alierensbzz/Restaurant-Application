using RestaurantApplication.VarlikKatmani.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApplication.VarlikKatmani.Models;

namespace RestaurantApplication.SunumKatmani.Filters
{
    public class YetkiAttribute : FilterAttribute, IAuthorizationFilter
    {
        public Yetki Rol { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] != null)
            {
                Kullanici user = filterContext.HttpContext.Session["user"] as Kullanici;
                if (user != null)
                {
                    if (user.Yetki == Rol)
                    {
                        return;
                    }
                }
            }
            filterContext.Result = new ViewResult()
            {
                ViewName = "YetkisizErisim"
            };
        }
    }
}