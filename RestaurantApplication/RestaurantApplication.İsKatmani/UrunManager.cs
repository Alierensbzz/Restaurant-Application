using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.İsKatmani
{
    public class UrunManager : IDisposable
    {
        private readonly UnitOfWork uow;
        public UrunManager()
        {
          uow = new UnitOfWork();
        }
        public List<Urun> Listele()
        {
            return uow.urunRepository.GetAll().ToList();
        }
        public Urun GetirUrun(int id)
        {
            return uow.urunRepository.GetItem(id);
        }
        public void Ekle (Urun item)
        {
            uow.urunRepository.Add(item);
            uow.save();
        }
        public void Guncelle(Urun item)
        {
            uow.urunRepository.Update(item);
            uow.save();
        }
        public void Sil(Urun item)
        {
            uow.urunRepository.Remove(item);
            uow.save();
        }
        public List<Urun> GetAllWithKategori()
        {
            return uow.urunRepository.GetAllWithKategori().ToList();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
