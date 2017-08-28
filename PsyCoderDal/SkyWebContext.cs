using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PsyCoderEntity;


namespace PsyCoderDal
{
    public class SkyWebContext : DbContext
    {
        public SkyWebContext()
            : base("SkyWebContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Integral> Integrals { get; set; }
        public DbSet<IntegralDetail> IntegralDetails { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Honor> Honors { get; set; }
        public DbSet<Article> Articles { get; set; }

        public System.Data.Entity.DbSet<AdsVideo> AdsVideos { get; set; }

        public System.Data.Entity.DbSet<AdsCustomer> AdsCustomers { get; set; }

        public System.Data.Entity.DbSet<PsyCoderEntity.Orders> Orders { get; set; }



    }
}
