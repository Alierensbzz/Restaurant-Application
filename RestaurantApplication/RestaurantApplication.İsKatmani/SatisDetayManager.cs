using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.İsKatmani
{
    public class SatisDetayManager : IDisposable
    {
        private readonly UnitOfWork uow;
        public SatisDetayManager() 
        {
            uow= new UnitOfWork();
        }
        public List<SatisDetay> Listele()
        {
            return uow.satisDetayRepository.GetAllWithUrun().ToList();  //satış detayı getir ürünüde listele
        }
        public List<SatisDetay> GetSatisDetay(int id)   
        {
            return uow.satisDetayRepository.GetItemWithUrun(id);
        }
        public SatisDetay GetirSatis(int id)
        {
            return uow.satisDetayRepository.GetItem(id);
        }
        public void Ekle(SatisDetay item)
        {
            uow.satisDetayRepository.Add(item);
            uow.save();
        }
        public void Guncelle(SatisDetay item)
        {
            uow.satisDetayRepository.Update(item);
            uow.save();
        }
        public void Sil(SatisDetay item)
        {
            uow.satisDetayRepository.Remove(item);
            uow.save();
        }
                
        public void Dispose()
        {
            uow.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
