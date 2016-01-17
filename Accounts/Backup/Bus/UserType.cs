using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public class UserType
    {
        Data.UserType dal = new Data.UserType();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserType, string Description)
        {
            return dal.Exists(UserType, Description);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(string UserType, string Description)
        {
            dal.Add(UserType, Description);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(string UserType, string Description)
        {
            dal.Update(UserType, Description);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string UserType)
        {
            dal.Delete(UserType);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetDescription(string UserType)
        {
            return dal.GetDescription(UserType);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中。
        ///// </summary>
        //public string GetDescriptionByCache(string UserType)
        //{
        //    string CacheKey = "Accounts_UserTypeModel-" + UserType;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetDescription(UserType);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return objModel.ToString();
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
    }
}
