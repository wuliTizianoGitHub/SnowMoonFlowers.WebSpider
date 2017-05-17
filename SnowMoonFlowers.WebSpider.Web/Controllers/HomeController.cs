using SnowMoonFlowers.WebSpider.EntityFramework.Repositories;
using System.Web.Mvc;

namespace SnowMoonFlowers.WebSpider.Web.Controllers
{
    public class HomeController : WebSpiderControllerBase
    {
        private BiliBiliHtmlRepository _res;

        public HomeController(BiliBiliHtmlRepository res)
        {
            _res = res;
        }
        public ActionResult Index()
        {
            _res.InsertBiliBiliWebSiteOfHtml("http://www.bilibili.com");
            return View();
        }
	}
}