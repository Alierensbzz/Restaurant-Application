using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani.DatabaseContext;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Concrete
{
    public class SatisDetayRepository : Repository<SatisDetay>, ISatisDetayRepository
    {
        public SatisDetayRepository(AppDbContext context) : base(context)
        {
        }

        public ICollection<SatisDetay> GetAllWithUrun()
        {
            return context.SatisDetaylar.Include(x=>x.urun).ToList();
        }

        public List<SatisDetay> GetItemWithUrun(int satisid)
        {
            return context.SatisDetaylar.Include(x=> x.urun).Where(x=>x.SatisId == satisid).ToList();
        }
    }
}
