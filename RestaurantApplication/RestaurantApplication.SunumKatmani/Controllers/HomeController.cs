using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RestaurantApplication.İsKatmani;
using RestaurantApplication.SunumKatmani.Filters;
using RestaurantApplication.VarlikKatmani.Enums;
using RestaurantApplication.VeritabaniErisimKatmani;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories;

namespace RestaurantApplication.SunumKatmani.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (var urunManager = new UrunManager())
            {
                var item = urunManager.Listele();
            }
            return View();

        }
    }
}