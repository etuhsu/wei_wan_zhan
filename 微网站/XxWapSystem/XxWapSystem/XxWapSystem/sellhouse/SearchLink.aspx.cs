﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XxWapSystem.DAL;
namespace XxWapSystem.sellhouse
{
    public partial class SearchLink : System.Web.UI.Page
    {
        public string type = string.Empty;
        string strWhere = "";                //临时过滤器
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["k"] == null)
            {
                return;
            }
            else
            {
                type = HttpUtility.UrlDecode(Request["k"].ToString());
                strWhere = strWhere + " and Title like '%" + type + "%'";
                string sql = "select *,(select top 1 ImgPath from AL_ES_Images where type='sale' and ESID=V_AL_ES_Sale.id) pic FROM V_AL_ES_Sale WHERE  isDel=0 AND isOk=1 AND DateDiff(day,GetDate(),EndTime) > 0 " + strWhere + "  ORDER By SortID desc,isTop desc,updateTime desc,AddTime desc";
                DataSet dt = DBHelper.Query(sql);
                StringBuilder sb = new StringBuilder();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    sb.Append("{\"error\":\"false\",\"data\":[");
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (i == dt.Tables[0].Rows.Count - 1)
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["ID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["Title"].ToString() + "\"}");
                        }
                        else
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["ID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["Title"].ToString() + "\"},");
                        }
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"error\":\"true\",\"data\":\"\"}");
                }
                Response.Write(sb.ToString());
            }
        }
    }
}
