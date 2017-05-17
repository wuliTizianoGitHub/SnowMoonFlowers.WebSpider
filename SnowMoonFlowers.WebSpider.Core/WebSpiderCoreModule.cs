using System.Reflection;
using Abp.Modules;

namespace SnowMoonFlowers.WebSpider
{
    public class WebSpiderCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
