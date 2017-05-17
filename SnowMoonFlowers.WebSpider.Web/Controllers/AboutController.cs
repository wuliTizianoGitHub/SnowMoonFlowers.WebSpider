using System.Web.Mvc;

namespace SnowMoonFlowers.WebSpider.Web.Controllers
{
    public class AboutController : WebSpiderControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}