using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using XxWapSystem.DAL;

namespace XxWapSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        public string HouseNewsHtml = string.Empty;   //房产资讯
        public string ZxNewsHtml = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doDataBind();
                doDataBind1();
            }
        }

        private void doDataBind()
        {
            string sql = "select  top 10 * from AlArticle where IsDeleted=0 AND ColId in (904,913,917) and Status='3' order by AddTime desc";
            DataSet dt = DBHelper.Query(sql);

            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    HouseNewsHtml = HouseNewsHtml + "<li id=\"redone\"><span>" + dt.Tables[0].Rows[i]["AddTime"].ToString() + "</span> <a href=\"/news/NewsShow.aspx?id=" + dt.Tables["ds"].Rows[i]["Id"].ToString() + "\" target=\"_self\">" + dt.Tables[0].Rows[i]["Title"].ToString() + "</a></li>";
                }
            }
            else
            {
                HouseNewsHtml = HouseNewsHtml + "<li id=\"redone\"><span></span> 暂无数据！</li>";
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
        private void doDataBind1()
        {
            string sql = "select top 10 * from Sys_News where (iTypeID=7 or iTypeID=9 or iTypeID=10) and bIsAudit = 1 order by iID desc";
            DataSet dt = DBHelperZxw.Query(sql);
            
            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    ZxNewsHtml = ZxNewsHtml + "<li id=\"redone\"><span>" + dt.Tables[0].Rows[i]["dAddTime"].ToString() + "</span> <a href=\"/zx_news/Show.aspx?id=" + dt.Tables["ds"].Rows[i]["iId"].ToString() + "\" target=\"_self\">" + dt.Tables[0].Rows[i]["cTitle"].ToString() + "</a></li>";
                }
            }
            else
            {
                ZxNewsHtml = ZxNewsHtml + "<li id=\"redone\"><span></span> 暂无数据！</li>";
            }

        }
    }
}
