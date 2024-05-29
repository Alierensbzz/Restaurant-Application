using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.İsKatmani
{
    public class KullaniciManager : IDisposable
    {
        private readonly UnitOfWork uow;
        public KullaniciManager()
        {
            uow = new UnitOfWork();
        }

        public Kullanici Login(string eposta, string parola)  //kullanıcı bulduysa kullanıcıyı dönüyor yoksa null.
        {
            return uow.kullaniciRepository.Login(eposta, parola);
        }

        public List<Kullanici> Listele()
        {
            return uow.kullaniciRepository.GetAll().ToList();
        }
        public Kullanici GetirKullanici(string eposta)
        {
            return uow.kullaniciRepository.GetItem(eposta);
        }
        public void Ekle(Kullanici item)
        {
            uow.kullaniciRepository.Add(item);
            uow.save();
        }
        public void Guncelle(Kullanici item)
        {
            uow.kullaniciRepository.Update(item);
            uow.save();
        }
        public void Sil(Kullanici kullanici)
        {
            uow.kullaniciRepository.Remove(kullanici);
            uow.save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
