﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using XxWapSystem.DAL;

namespace XxWapSystem.news
{
    public partial class newsajax_jyhq : System.Web.UI.Page
    {
        public int PageSize = 20;      //每页显示数据量
        public int ColID = 0;          //定义栏目编号
        public int Pages = 1;          //定义页数

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["channel"] == null)
                return;
            if (Request["page"] == null)
                return;
            if (!string.IsNullOrEmpty(Request["channel"]))
            {
                ColID = int.Parse(Request["channel"].ToString());
                Pages = int.Parse(Request["page"].ToString());
                if (!IsPostBack)
                {
                    string result = string.Empty;   //定义返回值
                    //定义sql语句
                    string sql = string.Empty;
                    //定义页数对应要筛选的条数
                    int NewsCount = (Pages - 1) * PageSize;
                    sql = "select top " + PageSize + "  * from AlArticle where ID not in (select top " + NewsCount + " ID from AlArticle where IsDeleted=0 AND ColId = " + ColID + " and Status='3' order by AddTime desc ) and IsDeleted=0 AND ColId = " + ColID + " and Status='3' order by AddTime desc";
                    DataSet dt = DBHelper.Query(sql);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder ReturnMsg = new StringBuilder();
                        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                        {
                            ReturnMsg.Append(string.Format("<li onclick=\"gourl('NewsShow.aspx?id=" + dt.Tables["ds"].Rows[i]["Id"].ToString() + "')\">" + dt.Tables["ds"].Rows[i]["Title"].ToString() + "</li>"));
                        }
                        result = ReturnMsg.ToString();
                    }

                    Response.Write(result);
                }
            }
        }


        public string IsImg(string ImgAddress)
        {
            string msg = string.Empty;
            if (ImgAddress.Length > 0)
            {
                msg = "http://xx.yyfdcw.com/upload/news/" + ImgAddress;
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
