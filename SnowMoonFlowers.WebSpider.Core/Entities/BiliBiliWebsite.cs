using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.Entities
{
    public class BiliBiliWebsite : Entity<long>
    {
        /// <summary>
        /// 主站URL
        /// </summary>
        public virtual string Url { get; set; }
    }
}
