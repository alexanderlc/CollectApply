using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CollectApply.Utils
{
    class Tools
    {
        public static string prepareHTML(string Htmlstring) //去除HTML标记   
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "#", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "#", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "#", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "#", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "#", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(/d+);", "#", RegexOptions.IgnoreCase);

            Htmlstring=Htmlstring.Replace("<", "#");
            Htmlstring = Htmlstring.Replace(">", "#");
            Htmlstring = Htmlstring.Replace("/r/n", "#");
            Htmlstring = Htmlstring.Trim().Replace("\t", "#");
            Htmlstring = Htmlstring.Trim().Replace(":", "#");
            Htmlstring = Htmlstring.Trim().Replace("：", "#");
           // Htmlstring = Regex.Replace(Htmlstring, @"+#","#", RegexOptions.IgnoreCase);
            Boolean end = false;
            do{
                if (Htmlstring.Contains("##"))
                {
                    Htmlstring = Htmlstring.Replace("##", "#");
                }
                else
                {
                    end = true;  
                }
            }while(!end);
            return Htmlstring;
        }  
    }
}
