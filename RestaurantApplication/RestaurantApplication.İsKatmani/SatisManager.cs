using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.İsKatmani
{
    public class SatisManager : IDisposable
    {
        private readonly UnitOfWork uow;

        public SatisManager()
        {
            uow = new UnitOfWork();
        }

        public List<Satis> Listele()
        {
            return uow.satisRepository.GetAll().ToList();
        }
        public Satis GetirSatis(int id)
        {
            return uow.satisRepository.GetItem(id);
        }
        public void Ekle(Satis item)
        {
            uow.satisRepository.Add(item);
            uow.save();
        }
        public void Guncelle(Satis item)
        {
            uow.satisRepository.Update(item);
            uow.save();
        }
        public void Sil(Satis item)
        {
            uow.satisRepository.Remove(item);
            uow.save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
