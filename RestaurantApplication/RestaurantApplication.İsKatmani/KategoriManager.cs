using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.İsKatmani
{
    public class KategoriManager : IDisposable
    {
        private readonly UnitOfWork uow;    

        public KategoriManager()
        {
           uow = new UnitOfWork(); 
        }

        public List<Kategori> Listele()          
        {
            return uow.kategoriRepository.GetAll().ToList();  //liste halinde kategoriler gidicek
        }
        public Kategori GetirKategori(int id)
        {
            return uow.kategoriRepository.GetItem(id); //kategorileri getiricem
        }
        public void Ekle (Kategori item)  //gelen kategori classını eklesin ve kaydetsin
        {
            uow.kategoriRepository.Add(item);
            uow.save();
        }
        public void Guncelle(Kategori item)
        {
            uow.kategoriRepository.Update(item);
            uow.save();
        }
        public void Sil(Kategori item)
        {                   
            uow.kategoriRepository.Remove(item);
            uow.save();
        }

        public void Dispose()
        {
            uow?.Dispose();  //uow null değilse dispose et
            GC.SuppressFinalize(this);
        }
    }
}
