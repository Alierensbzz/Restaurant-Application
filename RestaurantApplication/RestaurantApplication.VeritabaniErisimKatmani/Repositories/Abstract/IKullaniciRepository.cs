using RestaurantApplication.VarlikKatmani.Enums;
using RestaurantApplication.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Kullanici Login(string eposta, string parola);
    }
}
