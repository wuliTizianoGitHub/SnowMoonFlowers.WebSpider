using System.Reflection;
using Abp.Modules;

namespace SnowMoonFlowers.WebSpider
{
    [DependsOn(typeof(WebSpiderCoreModule))]
    public class WebSpiderApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
