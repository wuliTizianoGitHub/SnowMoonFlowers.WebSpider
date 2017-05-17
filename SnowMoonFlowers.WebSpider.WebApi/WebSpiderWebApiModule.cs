using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace SnowMoonFlowers.WebSpider
{
    [DependsOn(typeof(AbpWebApiModule), typeof(WebSpiderApplicationModule))]
    public class WebSpiderWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(WebSpiderApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
