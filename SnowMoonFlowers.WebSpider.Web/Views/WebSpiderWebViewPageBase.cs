using Abp.Web.Mvc.Views;

namespace SnowMoonFlowers.WebSpider.Web.Views
{
    public abstract class WebSpiderWebViewPageBase : WebSpiderWebViewPageBase<dynamic>
    {

    }

    public abstract class WebSpiderWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WebSpiderWebViewPageBase()
        {
            LocalizationSourceName = WebSpiderConsts.LocalizationSourceName;
        }
    }
}