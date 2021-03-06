﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XxWapSystem.DAL;

namespace XxWapSystem.BLL
{
    /// <summary>
    /// Sys_GroupBuySignUp
    /// </summary>
    public partial class Sys_GroupBuySignUp
    {
        private readonly XxWapSystem.DAL.Sys_GroupBuySignUp dal = new XxWapSystem.DAL.Sys_GroupBuySignUp();
        public Sys_GroupBuySignUp()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            return dal.Exists(iID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public funRtn Add(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新报名信息已用
        /// </summary>
        public int Update_Audit(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            XxWapSystem.DAL.Sys_GroupBuySignUp update = new XxWapSystem.DAL.Sys_GroupBuySignUp();
            return update.Update_Audit(model);
        }

        /// <summary>
        /// 更新报名信息是否审核
        /// </summary>
        public int Update_Shenhe(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            XxWapSystem.DAL.Sys_GroupBuySignUp update = new XxWapSystem.DAL.Sys_GroupBuySignUp();
            return update.Update_Shenhe(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public funRtn Delete(int iID)
        {
            return dal.Delete(iID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_GroupBuySignUp GetModel(int iID)
        {
            return dal.GetModel(iID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public PagerInfo GetList(string strGetFields, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            return dal.GetList(strGetFields, PageSize, PageIndex, bDesc, strFliter);
        }
        #endregion  Method
    }
}
