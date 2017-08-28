using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PsyCoderEntity;


namespace PsyCoderDal
{
    public class UnitOfWork : IDisposable
    {
        private SkyWebContext context = new SkyWebContext();

        private GenericRepository<SysUser> SysUsersRepository;

         public GenericRepository<SysUser> sysUsersRepository
        {
            get
            {

                if (this.SysUsersRepository == null)
                {
                    this.SysUsersRepository = new GenericRepository<SysUser>(context);
                }
                return SysUsersRepository;
            }
        }

         private GenericRepository<Setting> SettingsRepository;

         public GenericRepository<Setting> settingsRepository
         {
             get
             {

                 if (this.SettingsRepository == null)
                 {
                     this.SettingsRepository = new GenericRepository<Setting>(context);
                 }
                 return SettingsRepository;
             }
         }

         private GenericRepository<Category> CategorysRepository;

         public GenericRepository<Category> categorysRepository
         {
             get
             {

                 if (this.CategorysRepository == null)
                 {
                     this.CategorysRepository = new GenericRepository<Category>(context);
                 }
                 return CategorysRepository;
             }
         }

         private GenericRepository<AdsVideo> AdsVideosRepository;

         public GenericRepository<AdsVideo> adsVideosRepository
         {
             get
             {

                 if (this.AdsVideosRepository == null)
                 {
                     this.AdsVideosRepository = new GenericRepository<AdsVideo>(context);
                 }
                 return AdsVideosRepository;
             }
         }

         private GenericRepository<AdsCustomer> AdsCustomersRepository;

         public GenericRepository<AdsCustomer> adsCustomersRepository
         {
             get
             {

                 if (this.AdsCustomersRepository == null)
                 {
                     this.AdsCustomersRepository = new GenericRepository<AdsCustomer>(context);
                 }
                 return AdsCustomersRepository;
             }
         }


         private GenericRepository<Integral> IntegralRepository;

         public GenericRepository<Integral> integralsRepository
         {
             get
             {

                 if (this.IntegralRepository == null)
                 {
                     this.IntegralRepository = new GenericRepository<Integral>(context);
                 }
                 return IntegralRepository;
             }
         }

         private GenericRepository<Level> LevelRepository;

         public GenericRepository<Level> levelsRepository
         {
             get
             {

                 if (this.LevelRepository == null)
                 {
                     this.LevelRepository = new GenericRepository<Level>(context);
                 }
                 return LevelRepository;
             }
         }

         private GenericRepository<Honor> HonorRepository;

         public GenericRepository<Honor> honorsRepository
         {
             get
             {

                 if (this.HonorRepository == null)
                 {
                     this.HonorRepository = new GenericRepository<Honor>(context);
                 }
                 return HonorRepository;
             }
         }

         private GenericRepository<Article> ArticleRepository;

         public GenericRepository<Article> articlesRepository
         {
             get
             {

                 if (this.ArticleRepository == null)
                 {
                     this.ArticleRepository = new GenericRepository<Article>(context);
                 }
                 return ArticleRepository;
             }
         }

     
        

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}