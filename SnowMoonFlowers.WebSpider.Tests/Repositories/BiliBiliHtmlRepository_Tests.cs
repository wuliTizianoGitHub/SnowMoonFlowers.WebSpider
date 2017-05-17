using System.Text;
using Xunit;
using SnowMoonFlowers.WebSpider.IRepositories;
using Shouldly;
using SnowMoonFlowers.WebSpider.Entities;

namespace SnowMoonFlowers.WebSpider.Tests.Repositories
{

    public class BiliBiliHtmlRepository_Tests : WebSpiderTestBase
    {

        private IBiliBiliHtmlRepository _bilibiliDataRepository;

        public BiliBiliHtmlRepository_Tests()
        {
            _bilibiliDataRepository = LocalIocManager.Resolve<IBiliBiliHtmlRepository>();
        }

        [Fact]
        public void AddWebProxy_Tests()
        {
            string proxyUrl = "http://www.kuaidaili.com/free/";
            _bilibiliDataRepository.AddWebProxy(proxyUrl);
        }

        [Fact]
        public void GetBiliBiliWebStaticSiteData_Tests()
        {
            string BiliBiliUrl = "http://www.bilibili.com/";
            string html = _bilibiliDataRepository.GetBiliBiliWebStaticSiteData(BiliBiliUrl,Encoding.UTF8);
        }

        [Fact]
        public void InsertBiliBiliWebSiteOfHtml_Tests()
        {
            string BiliBiliUrl = "http://www.bilibili.com/";
            _bilibiliDataRepository.InsertBiliBiliWebSiteOfHtml(BiliBiliUrl).ShouldBe(1);
        }
    }
}
