using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMoonFlowers.WebSpider.Facility.Extensions
{
    public static class StringExtensions
    {
        public static string GetPartHtmlString(this string str ,string startStr,string endStr)
        {
            int firstIndex  =  str.IndexOf(startStr);
            int lastIndex = str.IndexOf(endStr);

            return str.Substring(firstIndex+ startStr.Length, lastIndex-firstIndex- endStr.Length+1);
        }
    }
}
