using RestaurantApplication.İsKatmani;
using RestaurantApplication.SunumKatmani.Filters;
using RestaurantApplication.VarlikKatmani.Enums;
using RestaurantApplication.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApplication.SunumKatmani.Areas.Yonetim.Controllers
{
    public class KategoriController : Controller
    {
        [Kimlik]
        public ActionResult Listele()
        {
            using (var kategoriManager = new KategoriManager())
            {
                return View(kategoriManager.Listele());
            }
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Ekle()
        {
            return View();
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Kategori item)
        {
            if (ModelState.IsValid)
            {
                using (var kategoriManager = new KategoriManager())
                {
                    kategoriManager.Ekle(item);
                    return RedirectToAction("Listele");
                }
            }
            return View(item);
        }
       
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Duzenle(int id)
        {
            using (var kategoriManager = new KategoriManager())
            {
                var item = kategoriManager.GetirKategori(id);

                if (item == null)
                    return HttpNotFound();

                return View(item);
            }
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(int id, Kategori item)
        {
            if (ModelState.IsValid)
            {
                using (var kategoriManager = new KategoriManager())
                {
                    kategoriManager.Guncelle(item);
                    return RedirectToAction("Listele");
                }
            }
            return View(item);
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Sil(int id)
        {
            using (var kategoriManager = new KategoriManager())
            {
                var item = kategoriManager.GetirKategori(id);

                if (item == null)
                    return HttpNotFound();

                return View(item);
            }
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public ActionResult SilOnay(Kategori item)
        {
            using (var kategoriManager = new KategoriManager())
            {
                kategoriManager.Sil(item);
                return RedirectToAction("Listele");
            }
        }

    }
}