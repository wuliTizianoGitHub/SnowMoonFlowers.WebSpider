using Abp.Domain.Entities;
using Abp.EntityFramework;
using Castle.Core.Logging;
using SnowMoonFlowers.WebSpider.Entities;
using SnowMoonFlowers.WebSpider.Facility;
using SnowMoonFlowers.WebSpider.Facility.Extensions;
using SnowMoonFlowers.WebSpider.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.EntityFramework.Repositories
{
    public class BiliBiliHtmlRepository : WebSpiderRepositoryBase<BiliBiliHtml, long>, IBiliBiliHtmlRepository
    {
        const string proxyUrl = "http://www.kuaidaili.com/free/";
        const string BiliBiliUrl = "http://www.bilibili.com/";
        public readonly WebClient client = new WebClient();

        //代理队列
        public readonly Queue<KeyValuePair<string, int>> _proxyQueue = new Queue<KeyValuePair<string, int>>();


        private WebSpiderDbContext _context;


        private ILogger Logger { get; set; }



        public BiliBiliHtmlRepository(IDbContextProvider<WebSpiderDbContext> dbContextProvider, WebSpiderDbContext context)
            :base(dbContextProvider)
        {
            _context = context;
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 连接次数
        /// </summary>
        private int _tryTimes;

        /// <summary>
        /// 添加主站数据
        /// </summary>
        public int InsertBiliBiliWebSiteOfHtml(string url)
        {
        //    BiliBiliHtml data1 = _context.BiliBiliHtmls.FirstOrDefault();


            string html = GetBiliBiliWebStaticSiteData(url, Encoding.UTF8);


            //添加主站
            BiliBiliHtml data = new BiliBiliHtml();
            data.FetchingTime = DateTime.Now;
            data.Title = html.GetPartHtmlString("<title>", "</title>");
            data.Url = url;
            data.LastModifyTime = data.FetchingTime;
            data.HtmlContent = "";
            data.ProtocolType = Facility.Enums.EnumProtocolType.HTTPS;
            _context.BiliBiliHtmls.Add(data);



            html = Regex.Replace(html.Trim(), "\\s+", " ");
            //Match m = Regex.Match(html, "<div class=\"menu.*\">.*</div>");



            //string str1= m.Groups[0].Value;


            Match m = Regex.Match(html, "<(?<HtmlTag>[\\w]+)[^>]*\\s(?class|id)=(?<Quote>[\"']?)menu.*(?(Quote)\\k<Quote>)[\"']?[^>]*>((?<Nested><\\k<HtmlTag>[^>]*>)|</\\k<HtmlTag>>(?<-Nested>)|.*?)*</\\k<HtmlTag>>");


            int i= _context.SaveChanges();
            return i;
        }



        public string GetBiliBiliWebStaticSiteData(string url,Encoding encoding,bool IsUsedProxy = true)
        {
            if (IsUsedProxy)
            {
                InitWebProxy();
            }
            else
            {
                client.Proxy = null;
            }
            try
            {
                client.Headers.Add("Accept-Encoding", "gzip");
                Uri uri = new Uri(url);
                string proxyhtml = encoding.GetString(ZipHelper.GzipDecompress(client.DownloadData(uri)));


                //获取菜单项
                //将多余空格转换为单个空格
                //proxyhtml = Regex.Replace(proxyhtml.Trim(), "\\s+", " ");
                


                return proxyhtml;
            }
            catch (WebException e)
            {
                if (e.Message.Contains("404") || 
                      e.Status == WebExceptionStatus.ProtocolError || _tryTimes == 2)
                {

                    _tryTimes = 0;
                    return null;
                }
                else if(e.Status == WebExceptionStatus.ConnectFailure) {
                    _tryTimes = 0;
                    InitWebProxy();
                    return GetBiliBiliWebStaticSiteData(url, encoding, IsUsedProxy);
                }
                else
                {
                    _tryTimes++;
                    return GetBiliBiliWebStaticSiteData(url, encoding, IsUsedProxy);
                }
            }         
        }

        public Task<string>  GetBiliBiliWebStaticSiteDataAsync(string url, Encoding encoding, bool IsUsedProxy)
        {
            return Task.FromResult(GetBiliBiliWebStaticSiteData(url, encoding, IsUsedProxy));
        }

        /// <summary>
        /// 使用代理
        /// </summary>
        public void InitWebProxy()
        {
            if (_proxyQueue.Count == 0)
            {
                AddWebProxy(proxyUrl);
            }
            KeyValuePair<string, int> proxy = _proxyQueue.Dequeue();
            client.Proxy = new WebProxy(proxy.Key, proxy.Value);
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        public void AddWebProxy(string proxyUrl)
        {
            client.Headers.Add("Accept-Encoding", "gzip");
            Uri uri = new Uri(proxyUrl);
            string proxyhtml = Encoding.UTF8.GetString(ZipHelper.GzipDecompress(client.DownloadData(uri)));
            string IPRow = proxyhtml.Replace("\n","").GetPartHtmlString("<tbody>", "</tbody>");

            IPRow = Regex.Replace(IPRow.Trim(), "\\s+", " ");
            GetIpAndPost(IPRow);
        }

        public void GetIpAndPost(string str)
        {
           
            bool isOver = true;
            while (isOver)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    isOver = false;
                }
                else
                {
                    int i = 0;
                    string startStr = "<tr>";
                    string engStr = "</tr>";
                    int firstIndex = str.IndexOf(startStr);
                    int lastIndex = str.IndexOf(engStr);
                    string str1 = str.Substring(firstIndex + startStr.Length, lastIndex - firstIndex - startStr.Length);
                    str = str.Substring(lastIndex + engStr.Length);
                    string startIPStr = "<td data-title=\"IP\">";
                    string engIPStr = "</td>";
                    int firstIPIndex = str1.IndexOf(startIPStr) + startIPStr.Length;
                    int lastIPIndex = str1.IndexOf(engIPStr) - startIPStr.Length - 1;
                    string ip = str1.Substring(firstIPIndex, lastIPIndex);
                    string startportStr = "<td data-title=\"PORT\">";
                    string engportStr = "</td>";
                    int firstportIndex = str1.IndexOf(startportStr) + startportStr.Length;
                    int lastportIndex = str1.IndexOf(engportStr, firstportIndex);
                    string port = str1.Substring(firstportIndex, lastportIndex - firstportIndex);
                    i++;
                    if (i == 100)
                    {
                        isOver = false;
                    }
                    _proxyQueue.Enqueue(new KeyValuePair<string, int>(ip, Convert.ToInt32(port)));
                }

            }
        }
    }
}
