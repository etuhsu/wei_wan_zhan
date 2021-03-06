﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Sys_SmsSend
    /// </summary>
    public partial class Sys_SmsSend
    {
        public Sys_SmsSend()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            int result = DBHelper.RunProcedure("Sys_SmsSend_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public funRtn Add(XxWapSystem.Model.Sys_SmsSend model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cUserName", SqlDbType.NVarChar),
					new SqlParameter("@cMobile", SqlDbType.NVarChar),
					new SqlParameter("@cMsg", SqlDbType.NVarChar),
					new SqlParameter("@bIsSend", SqlDbType.NVarChar,50),
					new SqlParameter("@cWhy", SqlDbType.NVarChar),
					new SqlParameter("@dSendTime", SqlDbType.DateTime),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cUserName;
            parameters[2].Value = model.cMobile;
            parameters[3].Value = model.cMsg;
            parameters[4].Value = model.bIsSend;
            parameters[5].Value = model.cWhy;
            parameters[6].Value = model.dSendTime;
            parameters[7].Value = model.dAddTime;
            parameters[8].Direction = ParameterDirection.Output;
            parameters[9].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_SmsSend_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[8].Value.ToString());
            rtn.rtnMsg.Append(parameters[9].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_SmsSend model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cUserName", SqlDbType.NVarChar),
					new SqlParameter("@cMobile", SqlDbType.NVarChar),
					new SqlParameter("@cMsg", SqlDbType.NVarChar),
					new SqlParameter("@bIsSend", SqlDbType.NVarChar,50),
					new SqlParameter("@cWhy", SqlDbType.NVarChar),
					new SqlParameter("@dSendTime", SqlDbType.DateTime),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cUserName;
            parameters[2].Value = model.cMobile;
            parameters[3].Value = model.cMsg;
            parameters[4].Value = model.bIsSend;
            parameters[5].Value = model.cWhy;
            parameters[6].Value = model.dSendTime;
            parameters[7].Value = model.dAddTime;
            parameters[8].Direction = ParameterDirection.Output;
            parameters[9].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_SmsSend_Update", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[8].Value.ToString());
            rtn.rtnMsg.Append(parameters[9].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public funRtn Delete(int iID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@iID", SqlDbType.Int,4),
											new SqlParameter("@rtnID", SqlDbType.Int,4),
											new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)
										};
            parameters[0].Value = iID;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_SmsSend_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_SmsSend GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Sys_SmsSend model = new XxWapSystem.Model.Sys_SmsSend();
            DataSet ds = DBHelper.RunProcedure("Sys_SmsSend_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cUserName = ds.Tables[0].Rows[0]["cUserName"].ToString();
                model.cMobile = ds.Tables[0].Rows[0]["cMobile"].ToString();
                model.cMsg = ds.Tables[0].Rows[0]["cMsg"].ToString();
                model.bIsSend = ds.Tables[0].Rows[0]["bIsSend"].ToString();
                model.cWhy = ds.Tables[0].Rows[0]["cWhy"].ToString();
                if (ds.Tables[0].Rows[0]["dSendTime"].ToString() != "")
                {
                    model.dSendTime = DateTime.Parse(ds.Tables[0].Rows[0]["dSendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取一个分页对象
        /// </summary>
        /// <param name="strGetFields">要获取的字段</param>
        /// <param name="PageSize">每页的大小</param>
        /// <param name="PageIndex">当前的页号</param>
        /// <param name="bDesc">是否降序排列记录</param>
        /// <param name="strFliter">条件</param>
        /// <returns>分页对象</returns>
        public PagerInfo GetList(string strGetFields, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            PagerInfo PI = new PagerInfo("Sys_SmsSend", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }

        #endregion  Method
    }
}
