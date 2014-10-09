using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.jc_go
{
    public partial class jcgoList : System.Web.UI.Page
    {
        public string AllBudingCount = string.Empty;
        public string ScriptStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstr=string.Empty;
            sqlstr = "select * from Sys_Product" + BuileWhere() + " order by iID desc";

            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();

        }

        private string BuileWhere()
        {
            string StrWhere = " where 1=1 ";
            string sjcname = Request["jcname"];
            string ty=Request["ty"];
            if (!Equals(sjcname, null))
            {
                StrWhere +=" and cProductName like '%" + sjcname + "%'";
            }
            else if(!Equals(ty,null))
            {
                StrWhere += " and iProductTypeID in  (select iID from Sys_ProductType where iID=" + ty + " or iPartentID =" + ty + ")";
            }
            ScriptStr = ScriptStr + "$(\"#t" + ty + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + ty + "\").parent().toggleClass('checked');choose_opts.put(\"HType\", \"" + "类型" + "\");choose_opt_labels['HType']='类型';";
            return StrWhere;
        }

        //返回产品图片
        public string Thumbnail(string id)
        {
            string msg = string.Empty;
            string sql = "select top 1 * from Sys_ProductImages where iProductID=" + id + " and bIsTop=1 order by dAddTime desc";
            DataSet ds = DBHelperZxw.Query(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                msg = "http://zx.yyfdcw.com/" + ds.Tables[0].Rows[0]["cProductThumbnail"].ToString();
            }
            else
            {
                string sql_Image = "select top 1 * from Sys_ProductImages where iProductID=" + id + " order by dAddTime desc";
                DataSet ds1 = DBHelperZxw.Query(sql_Image);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    msg ="http://zx.yyfdcw.com/" + ds1.Tables[0].Rows[0]["cProductThumbnail"].ToString();
                }
                else
                {
                    msg = "";
                }
            }
            return msg;
        }
        //返回产品品牌名称
        public string Brand(string iBrandid)
        {
            string msg = string.Empty;
            string sql = "select top 1 * from Sys_Brand where iID=" + iBrandid + " order by dAddTime desc";
            DataSet ds = DBHelperZxw.Query(sql);
            return ds.Tables[0].Rows[0]["cBrandName"].ToString();
        }
    }
}
