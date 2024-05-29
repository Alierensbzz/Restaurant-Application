using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll(); 
        T GetItem(object key); //imzaları tanımladık
        void Add(T item);  
        void Remove(T item);
        void Update(T item);
    }
}
