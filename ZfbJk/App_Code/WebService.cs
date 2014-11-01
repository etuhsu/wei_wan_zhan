using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using ZfbzJk;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    /*  select distinct clh,fh  from fdcmain.rs_syqfjxx where sjbh in(
  select distinct sjbh from fdcmain.ep_fjywxx
  where ywdl in('房屋所有权初始登记','数据录入','其他登记','房屋所有权转移登记','房屋所有权变更登记','预告登记','变更登记','转移登记','预告登记','初始登记','总登记')
  ) and sjbh in( select sjbh from fdcmain.rs_syqjbxx  where  trim(replace(syqrmc,' ','')) like '%朱四%' or  trim(replace(zjhm,' ','')) like '%430602%' )
  */



    [WebMethod]
    List<Fwcqxx> GetFwCqxxs(List<User> users)
    {
        List<Fwcqxx> fwcqxxs = null;
        foreach (User user in users)
        {
            ToolKit toolkit = new ToolKit();
            string sjbh="",clh = "", fh = "";
            string sql = " select distinct sjbh,clh,fh  from fdcmain.rs_syqfjxx where sjbh in( " +
                       " select distinct sjbh from fdcmain.ep_fjywxx " +
                       " where ywdl in('房屋所有权初始登记','数据录入','其他登记','房屋所有权转移登记','房屋所有权变更登记','预告登记','变更登记','转移登记','预告登记','初始登记','总登记') " +
                       " ) and sjbh in( select sjbh from fdcmain.rs_syqjbxx  where  trim(replace(syqrmc,' ','')) like '%"+user.sqrzjmc+"%' or  trim(replace(zjhm,' ','')) like '%"+user.sqrzjhm+"%' ) ";

            
            
            DataTable datatable = toolkit.Get_Tbl(sql);
            foreach (DataRow datarow in datatable.Rows)
            {
                if (fwcqxxs == null)
                {
                    fwcqxxs = new List<Fwcqxx>();
                }
                sjbh=datarow["sjbh"].ToString();
                clh = datarow["clh"].ToString();
                fh = datarow["fh"].ToString();
                Fwcqxx fwcqxx = new Fwcqxx();
                fwcqxx.zjhm=user.sqrzjhm;
                fwcqxx.cqlrmc=user.sqrzjmc;
                fwcqxx.fwzl=toolkit.ExecuteOracleStr(" select fwzl from fdcmain.ep_jzwzjbxx where clh='"+clh+"'");
                fwcqxx.jzmj = toolkit.ExecuteOracleStr("select zjzmj  from fdcmain.rs_syqfjxx where sjbh='"+sjbh+"' and clh='"+clh+"' and and fh='"+fh+"'");
                fwcqxx.cqlx = toolkit.ExecuteOracleStr("select ywbz  from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "' and clh='" + clh + "' and and fh='" + fh + "'");
                DataRow row=toolkit.Get_Row("select trim(replace(syqrmc)),trim(replace(cqqdsj)),trim(replace(zjhm))  from fdcmain.rs_syqjbxx where sjbh='"+sjbh+"'");
                fwcqxx.qssj = row["cqqdsj"].ToString();
                fwcqxx.cqlrmc = row["syqrmc"].ToString()==user.sqrzjmc? "1":"0";
                fwcqxx.zjhm = row["zjhm"].ToString()==user.sqrzjmc? "1":"0";
                fwcqxx.fwzt = "";
                fwcqxxs.Add(fwcqxx);
            }
        }
        return fwcqxxs;
    }
    [WebMethod]
    List<Htbaxx> GetHtbaxxs(List<User> users)
    {
        List<Htbaxx> htbaxxs = null;
        foreach (User user in users)
        {
            string sqlstr = "select 乙方,预购人身份证号,座落,预售面积,成交金额,合同类型,签订时间 from 合同流程控制 where 乙方 like '%" + user.sqrxm + "%' and 预购人身份证件 like '%" + user.sqrzjhm + "%'";
            DataSet dt = DBHelper.Query(sqlstr);
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                Htbaxx htbaxx = new Htbaxx();
                htbaxx.gfr = dt.Tables[0].Rows[i]["乙方"].ToString();
                htbaxx.zjhm = dt.Tables[0].Rows[i]["预购人身份证号"].ToString();
                htbaxx.fwzl = dt.Tables[0].Rows[i]["座落"].ToString();
                htbaxx.htmj = dt.Tables[0].Rows[i]["预售面积"].ToString();
                htbaxx.htje = dt.Tables[0].Rows[i]["成交金额"].ToString();
                htbaxx.htlb = dt.Tables[0].Rows[i]["合同类型"].ToString();
                htbaxx.htqdsj = dt.Tables[0].Rows[i]["签订时间"].ToString();
                htbaxx.xm_match = "1";
                htbaxx.hm_match = "1";
                htbaxxs.Add(htbaxx);
            }
        }
        return htbaxxs;
    }
}

