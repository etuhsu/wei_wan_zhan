﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace XxWapSystem.zx_news
{
    public partial class jjList : System.Web.UI.Page
    {
        public string NoHtml(string Htmlstring) //去除HTML标记 
        {
            //删除脚本 
            Htmlstring = Regex.Replace(Htmlstring, @" <script[^>]*?>.*? </script>", "", RegexOptions.IgnoreCase);
            //删除HTML 
            Htmlstring = Regex.Replace(Htmlstring, @" <(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @" <!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", " <", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\<(?<x>[^\>]*)\>", @"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[(?<x>[^\]]*)\]", @"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace(" <", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstr = "select top 10 * from Sys_News where (iTypeID=3 or iTypeID=2 or iTypeID=26) and bIsAudit = 1 order by iID desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.repbuild.DataSource = dt;
            this.repbuild.DataBind();
        }

        protected string BindPic(string pic)
        {
            string msg = string.Empty;
            if (pic.Length > 5)
            {
                msg = "http://zx.yyfdcw.com" + pic;
            }
            else
            {
                msg = "/images/no_pic.jpg";
            }
            return msg;
        }
    }
}
