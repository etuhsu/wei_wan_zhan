using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class xydaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqyname = Request["qyname"];
            string sqlstr = string.Empty;
            if (!Equals(sqyname, null))
            {
                sqlstr = "select * from xyda_jb where cqyname like '%" + sqyname.ToString() + "%' order by icreditvalue desc";
            }
            else
            {
                sqlstr = "select top 10 * from xyda_jb order by icreditvalue desc";
            }
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();
        }
    }
}
