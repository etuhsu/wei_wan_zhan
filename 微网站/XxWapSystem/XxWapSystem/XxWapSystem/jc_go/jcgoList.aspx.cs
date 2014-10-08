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
        protected void Page_Load(object sender, EventArgs e)
        {
            string sjcname= Request["jcname"];
            string sqlstr=string.Empty;
            if(!Equals(sjcname,null))
            {
                sqlstr = "select * from Sys_Product where cProductName like '%" + sjcname.ToString() + "%' order by iID desc";
            }
            else
            {
                sqlstr = "select top 10 * from Sys_Product order by iID desc";
            }
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();

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
