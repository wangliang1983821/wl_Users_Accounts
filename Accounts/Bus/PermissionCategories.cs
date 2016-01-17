using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
	/// <summary>
	/// 权限类别。
	/// </summary>
	public class PermissionCategories
	{

        Data.PermissionCategory dalpc = new Data.PermissionCategory();

        /// <summary>
        /// 构造函数
        /// </summary>
		public PermissionCategories()
		{			
		}

        /// <summary>
        /// 创建权限类别
        /// </summary>
		public int Create(string description)
		{
            int pcID = dalpc.Create(description);
			return pcID;
		}
        /// <summary>
        /// 删除权限类别
        /// </summary>
		public bool Delete(int pID)
		{
            return dalpc.Delete(pID);			
		}
	}
}
