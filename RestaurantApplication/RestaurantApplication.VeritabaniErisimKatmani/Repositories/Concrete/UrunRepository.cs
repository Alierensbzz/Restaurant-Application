using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani.DatabaseContext;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Concrete
{
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(AppDbContext context) : base(context)
        {
        }

        public ICollection<Urun> GetAllWithKategori()
        {
            return context.Urunler.Include(x => x.Kategori).ToList();
        }

        public Urun GetItemWithKategori(int id)
        {
            return context.Urunler.Include(x => x.Kategori).FirstOrDefault(x=>x.Id==id);
        }
    }
}
