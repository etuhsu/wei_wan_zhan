﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using XxWapSystem.DAL;

namespace XxWapSystem.news
{
    public partial class PolicyNews : System.Web.UI.Page
    {
        public string colid = "909";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doDataBind();
            }
        }
        private void doDataBind()
        {
            DataSet dt = new DataSet();
            SqlConnection sqlcon;
            string strCon = "Data Source=192.168.5.253\\YYFDCW;Database=yyfcj_data;Uid=yyfcj;Pwd=yyfcj_gov_cn2012";
            sqlcon = new SqlConnection(strCon);


            string sql = "select  top 10 * from AlArticle where IsDeleted=0 AND ColId =909 and Status='3' order by AddTime desc";
            sqlcon.Open();
            SqlDataAdapter command = new SqlDataAdapter(sql, sqlcon);
            command.Fill(dt, "ds"); 

            this.rptlist.DataSource = dt;
            this.rptlist.DataBind();
            sqlcon.Close();
        }
        public string IsImg(string ImgAddress)
        {
            string msg = string.Empty;
            if (ImgAddress.Length > 0)
            {
                msg = "http://zw.yyfdcw.com/upload/news/" + ImgAddress;
            }
            else
            {
                msg = "../images/no_pic.jpg";
            }
            return msg;
        }
        public string IsShort(string ShortContent, string Content)
        {
            string msg = string.Empty;
            if (ShortContent.Length > 0)
            {
                msg = ShortContent;
            }
            else
            {
                msg = XxWapSystem.DAL.WbText.SqlText(NoHtml(Content), 100);
            }
            return msg;
        }


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
    }
}
