using Abp.Web.Mvc.Controllers;

namespace SnowMoonFlowers.WebSpider.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class WebSpiderControllerBase : AbpController
    {
        protected WebSpiderControllerBase()
        {
            LocalizationSourceName = WebSpiderConsts.LocalizationSourceName;
        }
    }
}