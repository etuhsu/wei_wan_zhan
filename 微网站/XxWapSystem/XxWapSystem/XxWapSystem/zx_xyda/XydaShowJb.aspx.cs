using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class XydaShowJb : System.Web.UI.Page
    {
        public string cqyname = string.Empty;     //公司名称
        public string ccredit = string.Empty;
        public string icreditvalue = string.Empty;
        public string cgrade = string.Empty;
        public string cfq = string.Empty;
        public string caddress = string.Empty;
        public string cyyzch = string.Empty;
        public string czzbh = string.Empty;
        public string czzjg = string.Empty;
        public string cswdj = string.Empty;
        public string cht = string.Empty;
        public string cgc = string.Empty;
        public string izczb = string.Empty;
        public string ctype = string.Empty;
        public string dCreateTime = string.Empty;
        public string ctel = string.Empty;
        public string ccor = string.Empty;
        public string cqyjl = string.Empty;
        public string iryzs = string.Empty;
        public string izyzs = string.Empty;
        public string ccheck = string.Empty;
        public string cintro = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int NewId = int.Parse(Request["id"]);
                string sqlstr = "select * from xyda_jb where iID=" + NewId;
                DataSet dt = DBHelperZxw.Query(sqlstr);

                cqyname = dt.Tables[0].Rows[0]["cqyname"].ToString();
                ccredit = dt.Tables[0].Rows[0]["ccredit"].ToString();
                icreditvalue = dt.Tables[0].Rows[0]["icreditvalue"].ToString();
                cgrade = dt.Tables[0].Rows[0]["cgrade"].ToString();
                cfq = dt.Tables[0].Rows[0]["cfq"].ToString();
                caddress = dt.Tables[0].Rows[0]["caddress"].ToString();
                cyyzch = dt.Tables[0].Rows[0]["cyyzch"].ToString();
                czzbh = dt.Tables[0].Rows[0]["czzbh"].ToString();
                czzjg = dt.Tables[0].Rows[0]["czzjg"].ToString();
                cswdj = dt.Tables[0].Rows[0]["cswdj"].ToString();
                cht = dt.Tables[0].Rows[0]["cht"].ToString();
                cgc = dt.Tables[0].Rows[0]["cgc"].ToString();
                izczb = dt.Tables[0].Rows[0]["izczb"].ToString();
                ctype = dt.Tables[0].Rows[0]["ctype"].ToString();
                dCreateTime = dt.Tables[0].Rows[0]["dCreateTime"].ToString();
                ctel = dt.Tables[0].Rows[0]["ctel"].ToString();
                ccor = dt.Tables[0].Rows[0]["ccor"].ToString();
                cqyjl = dt.Tables[0].Rows[0]["cqyjl"].ToString();
                iryzs = dt.Tables[0].Rows[0]["iryzs"].ToString();
                izyzs = dt.Tables[0].Rows[0]["izyzs"].ToString();
                ccheck = dt.Tables[0].Rows[0]["ccheck"].ToString();
                cintro = dt.Tables[0].Rows[0]["cintro"].ToString();
            }
        }
    }
}
