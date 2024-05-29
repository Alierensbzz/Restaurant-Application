using RestaurantApplication.VarlikKatmani.Models;
using RestaurantApplication.VeritabaniErisimKatmani.DatabaseContext;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Abstract;
using RestaurantApplication.VeritabaniErisimKatmani.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.VeritabaniErisimKatmani
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        private IUrunRepository _urunRepo;
        private IKullaniciRepository _kullaniciRepo;
        private IRepository<Kategori> _kategoriRepo;
        private ISatisDetayRepository _satisDetayRepo;
        private IRepository<Satis> _satisRepo;


        public UnitOfWork()
        {
            context = new AppDbContext(); 
        } 
        public IRepository<Satis> satisRepository    //unitofwork sayesinde o repositoryi kullanıcaz
        {
            get
            {
                if(_satisRepo == null) 
                    _satisRepo = new Repository<Satis>(context);    //sarmallama işlemleri yaptım
                return _satisRepo;
            }
        }
        public ISatisDetayRepository satisDetayRepository
        {
            get
            {
                if(_satisDetayRepo == null) 
                    _satisDetayRepo = new SatisDetayRepository(context);
                return _satisDetayRepo;
            }
        }
        public IRepository<Kategori> kategoriRepository
        {
            get
            {
                if (_kategoriRepo == null)
                    _kategoriRepo = new Repository<Kategori>(context);
                return _kategoriRepo;
            }
        }
      
        public IUrunRepository urunRepository
        {
            get
            {
                if (_urunRepo == null)
                    _urunRepo = new UrunRepository(context);
                return _urunRepo;
            }
        }
        public IKullaniciRepository kullaniciRepository
        {
            get
            {
                if (_kullaniciRepo == null)
                    _kullaniciRepo = new KullaniciRepository(context);
                return _kullaniciRepo;
            }
        }

        public void save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            _satisRepo?.Dispose();  //satış repo null değilse dispose et çöpe at
            _satisDetayRepo?.Dispose();
            _kategoriRepo?.Dispose();
            _kullaniciRepo?.Dispose();
            _urunRepo?.Dispose();
            context?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}

