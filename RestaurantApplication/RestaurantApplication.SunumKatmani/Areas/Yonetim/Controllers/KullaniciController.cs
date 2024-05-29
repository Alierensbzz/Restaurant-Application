using RestaurantApplication.İsKatmani;
using RestaurantApplication.SunumKatmani.Filters;
using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VarlikKatmani.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApplication.SunumKatmani.Areas.Yonetim.Controllers
{
    public class KullaniciController : Controller
    {
        public ActionResult Login()
        {
            if (Session["user"] == null)
                return View();
            else
            {
                return RedirectToAction("Listele", "Kullanici");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Kullanici kullanici)
        {
            if (string.IsNullOrEmpty(kullanici.Eposta))
            {
                ModelState.AddModelError("Eposta", "Boş olamaz!!!");
                return View(kullanici);
            }

            if (string.IsNullOrEmpty(kullanici.Parola))
            {
                ModelState.AddModelError("Parola", "Boş olamaz!!!");
                return View(kullanici);
            }

            if (kullanici != null)
            {
                using (var kullaniciManager = new KullaniciManager())
                {
                    Kullanici user = kullaniciManager.Login(kullanici.Eposta, kullanici.Parola);
                    if (user != null)
                    {
                        Session["user"] = user;
                        return RedirectToAction("Listele", "Kullanici");
                    }
                }
            }

            ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!!!");
            return View(kullanici);
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur), Hata]
        public ActionResult Listele()
        {
            using (var kullaniciManager = new KullaniciManager())
            {
                return View(kullaniciManager.Listele());
            }
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Ekle()
        {
            return View();
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                using (var kullaniciManager = new KullaniciManager())
                {
                    kullaniciManager.Ekle(kullanici);
                    return RedirectToAction("Listele");
                }
            }
            return View(kullanici);
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        public ActionResult Duzenle(string eposta)
        {
            using (var KullaniciManager = new KullaniciManager())
            {
                Kullanici kullanıcı = KullaniciManager.GetirKullanici(eposta);
                if (kullanıcı != null)
                    return View(kullanıcı);
                else
                    return HttpNotFound();
            }
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                using (var KullaniciManager = new KullaniciManager())
                {
                    KullaniciManager.Guncelle(kullanici);
                    return RedirectToAction("Listele");
                }
            }
            return View(kullanici);
        }
        [Kimlik, Yetki(Rol = Yetki.Mudur), Hata]
        public ActionResult Sil(string eposta)
        {
            using (var KullaniciManager = new KullaniciManager())
            {
                Kullanici kullanıcı = KullaniciManager.GetirKullanici(eposta);
                if (kullanıcı != null)
                    return View(kullanıcı);
                else
                    return HttpNotFound();
            }
        }

        [Kimlik, Yetki(Rol = Yetki.Mudur)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil"), Hata]
        public ActionResult SilOnay(Kullanici model)
        {
            using (var KullaniciManager = new KullaniciManager())
            {
                KullaniciManager.Sil(model);
                return RedirectToAction("Listele");
            }
        }

        public ActionResult Logout()
        {
            if (Session["user"] != null)
                Session.Remove("user");

            return RedirectToAction("Login");
        }
    }
}