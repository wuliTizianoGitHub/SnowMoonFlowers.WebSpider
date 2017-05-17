using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.Entities
{
    [Table("BiliBili_Data")]
    public class BiliBiliData :  Entity<long>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(255)]
        public virtual string Title { get; set; }

        /// <summary>
        /// 总类型
        /// </summary>
        public virtual int TotalType { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public virtual int DataType { get; set; }

        /// <summary>
        /// 封面Url
        /// </summary>
        [StringLength(255)]
        public virtual string CoverUrl { get; set; }

        //public virtual string 

        /// <summary>
        /// 播放时间
        /// </summary>
        public virtual DateTime PlayTime { get; set; }

        /// <summary>
        /// 观看人数
        /// </summary>
        public virtual long Audience { get; set; }

        /// <summary>
        /// 弹幕数量
        /// </summary>
        public virtual long BarrageNumber { get; set; }

        /// <summary>
        /// 硬币数量
        /// </summary>
        public virtual long CoinsNumber { get; set; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        public virtual long CollectionNumber { get; set; }

        /// <summary>
        /// 分享数量
        /// </summary>
        public virtual long ShareNumber { get; set; }

        /// <summary>
        /// 投稿人
        /// </summary>
        [StringLength(255)]
        public virtual string Contributor { get; set; }

        /// <summary>
        /// 投稿时间
        /// </summary>
        public virtual DateTime ContributionsTime { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public virtual string Introduction { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(255)]
        public virtual string DataTag { get; set; }

        /// <summary>
        /// 承包数量
        /// </summary>
        public virtual long Contract { get; set; }


        [MaxLength]
        public virtual string HtmlContent { get; set; }

        /// <summary>
        /// 追番人数
        /// </summary>
        public virtual long ThemNumber { get; set; }

        /// <summary>
        /// 数据创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime LastModifyTime { get; set; }
    }
}
