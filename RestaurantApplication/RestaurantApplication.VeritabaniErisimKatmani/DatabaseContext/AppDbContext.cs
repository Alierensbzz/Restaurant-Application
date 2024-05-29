using RestaurantApplication.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApplication.VarlikKatmani.Enums;

namespace RestaurantApplication.VeritabaniErisimKatmani.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<SatisDetay> SatisDetaylar { get; set; }
        public DbSet<Satis> Satislar { get; set; }

        public AppDbContext() : base("deneme001")
        {
            Database.SetInitializer<AppDbContext>(new MyDBInitializer());
        }
    }

    public class MyDBInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            // Kategori
            context.Kategoriler.Add(new Kategori { Ad = "Başlangıç" });
            context.Kategoriler.Add(new Kategori { Ad = "Ara Sıcak" });
            context.Kategoriler.Add(new Kategori { Ad = "Ana Yemek" });
            context.Kategoriler.Add(new Kategori { Ad = "İçecekler" });
            context.SaveChanges();

            //Ürünler
            Urun urun1 = context.Set<Urun>().Add(new Urun { Ad = "Mercimek Çorbası", Fiyat = 60, KategoriId = 1 });
            Urun urun2 = context.Set<Urun>().Add(new Urun { Ad = "İçli Köfte", Fiyat = 75, KategoriId = 2 });
            Urun urun3 = context.Set<Urun>().Add(new Urun { Ad = "Et İskender", Fiyat = 300, KategoriId = 3 });
            Urun urun4 = context.Set<Urun>().Add(new Urun { Ad = "Tavuk Döner Porsiyon", Fiyat = 150, KategoriId = 3 });
            Urun urun5 = context.Set<Urun>().Add(new Urun { Ad = "Kola", Fiyat = 50, KategoriId = 4 });
            Urun urun6 = context.Set<Urun>().Add(new Urun { Ad = "Ayran", Fiyat = 30, KategoriId = 4 });
            context.SaveChanges();

            //Kullanıcılar
            context.Kullanicilar.Add(new Kullanici { Ad = "Ali Eren", Soyad = "Sabaz", Eposta = "ali@restaurant.com", Parola = "190312", Yetki = Yetki.Mudur });
            context.Kullanicilar.Add(new Kullanici { Ad = "Deneme", Soyad = "Denemeoğlu", Eposta = "deneme@hotmail.com", Parola = "123456", Yetki = Yetki.Personel });
            context.Kullanicilar.Add(new Kullanici { Ad = "Emre", Soyad = "Koyuncux", Eposta = "emrekoyuncu@icloud.com", Parola = "1234", Yetki = Yetki.Mudur });
            context.Kullanicilar.Add(new Kullanici { Ad = "Kadir", Soyad = "Hazar", Eposta = "kadirhazar@hotmail.com", Parola = "1234", Yetki = Yetki.Personel });
            context.SaveChanges();

            // Satışlar
            Satis satis1 = context.Set<Satis>().Add(new Satis { TarihSaat = DateTime.Now, ToplamTutar = 100 });
            Satis satis2 = context.Set<Satis>().Add(new Satis { TarihSaat = DateTime.Now, ToplamTutar = 80 });
            Satis satis3 = context.Set<Satis>().Add(new Satis { TarihSaat = DateTime.Now, ToplamTutar = 62 });
            Satis satis4 = context.Set<Satis>().Add(new Satis { TarihSaat = DateTime.Now, ToplamTutar = 120 });
            Satis satis5 = context.Set<Satis>().Add(new Satis { TarihSaat = DateTime.Now, ToplamTutar = 60 });

            //Satış Detaylar
            context.SaveChanges();
            satis1.Detaylar = new List<SatisDetay>()
              {
                 new SatisDetay{ urun = urun1, Adet = 2, Tutar = urun1.Fiyat * 2},
                 new SatisDetay{ urun = urun2, Adet = 1, Tutar = urun2.Fiyat * 1},
                 new SatisDetay{ urun = urun3, Adet = 1, Tutar = urun3.Fiyat * 1}
              };
            satis3.Detaylar = new List<SatisDetay>()
              {
                 new SatisDetay{urun = urun4, Adet = 2, Tutar = urun4.Fiyat * 2},
                 new SatisDetay{urun = urun5, Adet = 1, Tutar = urun5.Fiyat * 1},
                 new SatisDetay{urun = urun6, Adet = 1, Tutar = urun6.Fiyat * 1},
             };
            satis4.Detaylar = new List<SatisDetay>()
              {
                 new SatisDetay{urun = urun2, Adet = 2, Tutar = urun2.Fiyat * 2},
                 new SatisDetay{urun = urun1, Adet = 1, Tutar = urun1.Fiyat * 1},
                 new SatisDetay{urun = urun4, Adet = 1, Tutar = urun4.Fiyat * 1},
             };
            satis5.Detaylar = new List<SatisDetay>()
              {
                 new SatisDetay{urun = urun5, Adet = 2, Tutar = urun5.Fiyat * 2},
                 new SatisDetay{urun = urun1, Adet = 1, Tutar = urun1.Fiyat * 1},
                 new SatisDetay{urun = urun3, Adet = 1, Tutar = urun3.Fiyat * 1},
             };
            satis2.Detaylar = new List<SatisDetay>()
              {
                 new SatisDetay{urun = urun2, Adet = 2, Tutar = urun2.Fiyat * 2},
                 new SatisDetay{urun = urun4, Adet = 1, Tutar = urun4.Fiyat * 1},
                 new SatisDetay{urun = urun6, Adet = 1, Tutar = urun6.Fiyat * 1},
             };
            context.SaveChanges();
        }
    }
}
