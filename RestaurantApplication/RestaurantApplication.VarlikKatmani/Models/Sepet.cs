using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VarlikKatmani.Models
{
    public class Sepet
    {
        public Satis satis { get; set; }

        public Sepet()
        {
            satis = new Satis();
        }

        public void Ekle(Urun urun)
        {
            if (satis.Detaylar.FirstOrDefault(x => x.urun.Id == urun.Id) == null)
            {
                satis.Detaylar.Add(new SatisDetay { Adet = 1, urun = urun, Tutar = urun.Fiyat }); 
                satis.ToplamTutar += urun.Fiyat; 
            }
            else
            {
                int index = satis.Detaylar.FindIndex(x => x.urun.Id == urun.Id);
                satis.Detaylar[index].Adet++;
                satis.Detaylar[index].Tutar += urun.Fiyat;
                satis.ToplamTutar += urun.Fiyat;
            }
        }

        public void Sil(int urunId)
        {
            int index = satis.Detaylar.FindIndex(x => x.Id == urunId);
            if (index != -1)
            {
                satis.Detaylar.RemoveAt(index);
            }
        }


    }
}

/*
 * Sepette daha önce eklenmemiş olan bir ürünse 
 * (FirstOrDefault kontrolü ile), yeni bir 
 * SatisDetay nesnesi oluşturur ve bu ürünü sepete ekler.
 * ---       ---       ---     ---
 * Bu ürünün adedini ve tutarını artırır.
 * Her iki durumda da, sepete eklenen ürünün fiyatı Toplam 
 * Tutara eklenir.
 * 
 * Ürün Detaylar listesinde bulunuyorsa (FindIndex ile), 
 * o ürün listeden kaldırılır (RemoveAt ile).

 */