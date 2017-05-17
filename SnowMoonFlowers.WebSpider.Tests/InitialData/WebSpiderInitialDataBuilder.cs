using SnowMoonFlowers.WebSpider.Entities;
using SnowMoonFlowers.WebSpider.EntityFramework;
using SnowMoonFlowers.WebSpider.Facility.Enums;
using System;
using System.Data.Entity.Migrations;

namespace SnowMoonFlowers.WebSpider.Tests.InitialData
{
    public class WebSpiderInitialDataBuilder
    {
        public void Build(WebSpiderDbContext context)
        {

            if (!context.Database.CreateIfNotExists()) { 

            context.BiliBiliHtmls.AddOrUpdate(new BiliBiliHtml() { Url="www.baidu.com", FetchingTime=DateTime.Now, HtmlContent="123", IsWebStaticSite=true, LastModifyTime = DateTime.Now, Title="百度", ProtocolType= EnumProtocolType.HTTPS });
           
            //context.Database.CreateIfNotExists();
            context.SaveChanges();
            }
        }
    }
}
