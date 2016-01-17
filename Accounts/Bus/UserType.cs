using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// �û�����
    /// </summary>
    public class UserType
    {
        Data.UserType dal = new Data.UserType();

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string UserType, string Description)
        {
            return dal.Exists(UserType, Description);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(string UserType, string Description)
        {
            dal.Add(UserType, Description);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(string UserType, string Description)
        {
            dal.Update(UserType, Description);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string UserType)
        {
            dal.Delete(UserType);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public string GetDescription(string UserType)
        {
            return dal.GetDescription(UserType);
        }

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
    }
}
