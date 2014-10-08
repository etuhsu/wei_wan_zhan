using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class xydaAjax : System.Web.UI.Page
    {
        public int Pagesize = 10;
        public int Page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                Page = int.Parse(Request["page"].ToString());
                int PageCount = (Page - 1) * Pagesize;
                string sqlstr = "select top " + Pagesize + " * from xyda_jb where iID not in (select top " + PageCount + " iID from xyda_jb order by iID desc) order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    string shuchu = string.Format("<li onclick=\"gourl('XydaShowJb.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-txt\"><div class=\"p-title\"><a target=\"_self\" href=\"XydaShowJb.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">" + dt.Tables[0].Rows[i]["cqyname"].ToString() + "</a></div><div class=\"p-summary\">" + dt.Tables[0].Rows[i]["ccredit"].ToString() + "(" + dt.Tables[0].Rows[i]["icreditvalue"].ToString() + "分)</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);

        }
    }
}
