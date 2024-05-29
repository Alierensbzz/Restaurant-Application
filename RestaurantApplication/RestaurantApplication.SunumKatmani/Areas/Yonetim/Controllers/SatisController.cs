using RestaurantApplication.İsKatmani;
using RestaurantApplication.SunumKatmani.Filters;
using RestaurantApplication.VarlikKatmani.Enums;
using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApplication.SunumKatmani.Areas.Yonetim.Controllers
{
    public class SatisController : Controller
    {
        // GET: Yonetim/Satis

        [Kimlik]
        public ActionResult Listele()
        {
            using (var satisManager = new SatisManager())
            {
                return View(satisManager.Listele());
            }
        }

        public ActionResult SatisDetay(int? id)
        {
            if (id != null)
            {
                using (var satisDetayManager = new SatisDetayManager())
                    return View(satisDetayManager.GetSatisDetay((int)id));
            }
            return RedirectToAction("Listele");
        }
        [Kimlik, Yetki(Rol = Yetki.Personel)]
        public ActionResult Ekle()
        {
            using (var urunManager = new UrunManager())
            {
                return View(urunManager.GetAllWithKategori());
            }
        }
        [Kimlik]
        [Yetki(Rol = Yetki.Personel)]
        public ActionResult SepeteEkle(int? id)
        {
            if (id != null)
            {
                Sepet sepet;
                if (Session["sepet"] != null)
                    sepet = Session["sepet"] as Sepet;
                else
                    sepet = new Sepet();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    Urun urun = uow.urunRepository.GetItem(id);
                    if (urun != null)
                    {
                        sepet.Ekle(urun);
                        Session["sepet"] = sepet;
                    }
                }
            }
            return RedirectToAction("Ekle");
        }
        [Kimlik]
        [Yetki(Rol = Yetki.Personel)]
        public ActionResult SepeteGoruntule()
        {
            Sepet sepet;
            if (Session["sepet"] != null)
                sepet = Session["sepet"] as Sepet;
            else
                sepet = new Sepet();

            return View(sepet.satis);
        }
        
        [Kimlik]
        [Yetki(Rol = Yetki.Personel)]
        public ActionResult SatisTamamla()
        {
            Sepet sepet;
            if (Session["sepet"] != null)
            {
                sepet = Session["sepet"] as Sepet;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    sepet.satis.TarihSaat = DateTime.Now;
                    uow.satisRepository.Add(sepet.satis);

                    foreach (var item in sepet.satis.Detaylar)
                    {
                        Urun urun = uow.urunRepository.GetItem(item.urun.Id);
                        if (urun != null)
                        {
                            uow.urunRepository.Update(urun);
                        }
                        else
                        {
                            ModelState.AddModelError("", "urun yetersiz.");
                            return View("Hata");
                        }
                    }

                    uow.save();

                    Session["sepet"] = null;
                }
            }
            return RedirectToAction("Ekle");
        }
    }

}