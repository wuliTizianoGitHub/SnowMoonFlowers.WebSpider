using System.Data.Common;
using Abp.EntityFramework;
using SnowMoonFlowers.WebSpider.Entities;
using System.Data.Entity;

namespace SnowMoonFlowers.WebSpider.EntityFramework
{
    public class WebSpiderDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        public virtual IDbSet<BiliBiliData> BiliBiliDatas { get; set; }

        public virtual IDbSet<BiliBiliHtml> BiliBiliHtmls { get; set; }

        public virtual IDbSet<BiliBiliWebsite> BiliBiliWebsites { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WebSpiderDbContext()
            : base("BiliBiliDataDb")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WebSpiderDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WebSpiderDbContext since ABP automatically handles it.
         */
        public WebSpiderDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WebSpiderDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public WebSpiderDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
