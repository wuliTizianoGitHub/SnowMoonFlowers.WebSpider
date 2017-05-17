using Abp.Application.Services;

namespace SnowMoonFlowers.WebSpider
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WebSpiderAppServiceBase : ApplicationService
    {
        protected WebSpiderAppServiceBase()
        {
            LocalizationSourceName = WebSpiderConsts.LocalizationSourceName;
        }
    }
}