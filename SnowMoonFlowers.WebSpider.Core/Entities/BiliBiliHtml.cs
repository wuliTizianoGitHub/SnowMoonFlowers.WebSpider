using Abp.Domain.Entities;
using SnowMoonFlowers.WebSpider.Facility.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.Entities
{
   
    [Table("BiliBili_Source")]
    public class BiliBiliHtml : Entity<long>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(255)]
        public virtual string Title { get; set; }

        /// <summary>
        /// 待抓取Url
        /// </summary>
        [StringLength(255)]
        public virtual string Url { get; set; }


        /// <summary>
        /// 协议类型，HTTP https ftp之类的
        /// </summary>
        public virtual EnumProtocolType ProtocolType { get; set; }


        //public virtual Tag


        /// <summary>
        /// 数据源
        /// </summary>
        [MaxLength]
        public virtual string HtmlContent { get; set; }

        /// <summary>
        /// 是否为主站站点
        /// </summary>
        public virtual bool IsWebStaticSite { get; set; }

        /// <summary>
        /// 抓取时间
        /// </summary>
        public virtual DateTime FetchingTime { get; set; }


        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime LastModifyTime { get; set; }
    }
}
