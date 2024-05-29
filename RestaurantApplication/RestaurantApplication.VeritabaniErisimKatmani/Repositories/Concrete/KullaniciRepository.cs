using RestaurantApplication.VarlikKatmani.Enums;
using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani.DatabaseContext;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Concrete
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici Login(string eposta, string parola)
        {
            return context.Set<Kullanici>().FirstOrDefault(x => 
            x.Eposta.ToLower().Equals(eposta.ToLower()) &&
            x.Parola.Equals(parola));

            
        }
    }
}
