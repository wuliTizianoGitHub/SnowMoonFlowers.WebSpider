using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SnowMoonFlowers.WebSpider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.IRepositories
{
    public interface IBiliBiliHtmlRepository : IRepository<BiliBiliHtml, long>
    {
        /// <summary>
        /// 获取BiliBili主站数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="IsUsedProxy"></param>
        /// <returns></returns>
        string GetBiliBiliWebStaticSiteData(string url, Encoding encoding, bool IsUsedProxy = true);

        /// <summary>
        /// 异步，获取BiliBili主站数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="IsUsedProxy"></param>
        /// <returns></returns>
        Task<string> GetBiliBiliWebStaticSiteDataAsync(string url, Encoding encoding, bool IsUsedProxy = true);

        /// <summary>
        /// 添加代理
        /// </summary>
        /// <param name="proxyUrl"></param>
        void AddWebProxy(string proxyUrl);

        /// <summary>
        /// 添加主站数据源
        /// </summary>
        /// <param name="url"></param>
        int InsertBiliBiliWebSiteOfHtml(string url);
    }
}
