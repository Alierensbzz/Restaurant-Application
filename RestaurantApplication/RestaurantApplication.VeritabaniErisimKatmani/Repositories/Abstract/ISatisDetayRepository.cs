using RestaurantApplication.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract
{
    public interface ISatisDetayRepository : IRepository<SatisDetay>
    {
        ICollection<SatisDetay> GetAllWithUrun();
        List<SatisDetay> GetItemWithUrun(int satisid);
    }
}
