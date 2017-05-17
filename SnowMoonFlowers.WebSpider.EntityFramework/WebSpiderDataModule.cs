using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using SnowMoonFlowers.WebSpider.EntityFramework;

namespace SnowMoonFlowers.WebSpider
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(WebSpiderCoreModule))]
    public class WebSpiderDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "BiliBiliDataDb";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<WebSpiderDbContext>(null);
        }
    }
}
