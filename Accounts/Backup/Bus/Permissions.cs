using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
	/// <summary>
	/// 权限管理。
	/// </summary>
    [Serializable]
	public class Permissions
	{
        Data.Permission dalPermission = new Data.Permission();

        /// <summary>
        /// 构造函数
        /// </summary>
		public Permissions()
		{			
		}

		/// <summary>
		/// 创建一个权限
		/// </summary>
		/// <param name="pcID">类别ID</param>
		/// <param name="description">权限描述</param>
		/// <returns></returns>
		public int Create(int pcID,string description)
		{			
			int pID = dalPermission.Create(pcID,description);
			return pID;
		}
		/// <summary>
		/// 更新权限
		/// </summary>
		/// <param name="pcID">权限ID</param>
		/// <param name="description">权限描述</param>
		/// <returns></returns>
		public bool Update(int pcID,string description)
		{			
			return dalPermission.Update(pcID,description);			
		}

		/// <summary>
		/// 删除权限
		/// </summary>
		/// <param name="pID"></param>
		/// <returns></returns>
		public bool Delete(int pID)
		{
			return dalPermission.Delete( pID );			
		}
		/// <summary>
		/// 得到权限名称
		/// </summary>
		/// <param name="pID"></param>
		/// <returns></returns>
		public string GetPermissionName(int pID)
		{
			return dalPermission.Retrieve(pID)["Description"].ToString();
		}
	}
}
