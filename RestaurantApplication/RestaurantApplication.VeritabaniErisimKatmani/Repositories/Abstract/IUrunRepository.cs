using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract
{
    public interface IUrunRepository : IRepository<Urun>   
    {
        ICollection<Urun> GetAllWithKategori();
        Urun GetItemWithKategori(int id);
    }
}
