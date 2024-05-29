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
    public class UrunController : Controller
    {
        [Kimlik]
        public ActionResult Listele()
        {
            using (var urunManager = new UrunManager())
            {
                return View(urunManager.Listele());
            }
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Ekle()
        {
            using (var kategoriManager = new KategoriManager())
            {
                List<Kategori> liste = kategoriManager.Listele();
                SelectList selectedList = new SelectList(liste, "Id", "Ad");
                ViewBag.Kategoriler = selectedList;
            }

            return View();
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Urun item)
        {
            if (ModelState.IsValid)
            {
                using (var urunManager = new UrunManager())
                {
                    urunManager.Ekle(item);
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
                List<Kategori> liste = kategoriManager.Listele();
                SelectList selectedList = new SelectList(liste, "Id", "Ad");
                ViewBag.Kategoriler = selectedList;
            }

            using (var urunManager = new UrunManager())
            {
                var item = urunManager.GetirUrun(id);

                if (item == null)
                    return HttpNotFound();

                return View(item);
            }
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(int id, Urun item)
        {
            if (ModelState.IsValid)
            {
                using (var urunManager = new UrunManager())
                {
                    urunManager.Guncelle(item);
                    return RedirectToAction("Listele");
                }
            }
            return View(item);
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Sil(int id)
        {
            using (var urunManager = new UrunManager())
            {
                var item = urunManager.GetirUrun(id);

                if (item == null)
                    return HttpNotFound();

                return View(item);
            }
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public ActionResult SilOnay(Urun item)
        {
            using (var urunManager = new UrunManager())
            {
                urunManager.Sil(item);
                return RedirectToAction("Listele");
            }
        }

    }
}