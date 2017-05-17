using Abp.Modules;

namespace SnowMoonFlowers.WebSpider.Tests
{
    [DependsOn(typeof(WebSpiderDataModule),typeof(WebSpiderApplicationModule),typeof(WebSpiderCoreModule))]
    public class WebSpiderTestModule:AbpModule
    {

    }
}
