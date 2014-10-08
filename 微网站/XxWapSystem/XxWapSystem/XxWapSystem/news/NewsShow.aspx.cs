using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using XxWapSystem.DAL;
namespace XxWapSystem.news
{
    public partial class NewsShow : System.Web.UI.Page
    {
        public string Title = string.Empty;
        public string MsgContent = string.Empty;
        public string AddTime = string.Empty;
        public string ShortContent = string.Empty;

        public string msgid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
                return;
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                

                if (!IsPostBack)
                {
                    msgid = Request.QueryString["ID"].ToString();
                    string sql = "select * from AlArticle where id=" + msgid + "";
                    DataSet dt = DBHelper.Query(sql);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        Title = dt.Tables[0].Rows[0]["Title"].ToString();
                        AddTime = DateTime.Parse(dt.Tables[0].Rows[0]["AddTime"].ToString()).ToString("yyyy-MM-dd");
                        MsgContent = dt.Tables[0].Rows[0]["Content"].ToString();
                        ShortContent = dt.Tables[0].Rows[0]["ShortContent"].ToString();
                    }
                }
            }
        }
    }
}
