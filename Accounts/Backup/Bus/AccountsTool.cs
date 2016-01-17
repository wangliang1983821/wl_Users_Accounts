using System;
using System.Data;
namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 权限工具类
    /// </summary>
	public class AccountsTool
	{
        /// <summary>
        /// 获取所有权限类别
        /// </summary>
		public static DataSet GetAllCategories()
		{
			Data.PermissionCategory dataPermissionCategory = new Data.PermissionCategory();
			return dataPermissionCategory.GetCategoryList();
		}
        /// <summary>
        /// 获取某类别的所有权限
        /// </summary>
        public static DataSet GetPermissionsByCategory(int categoryID)
        {
            Data.PermissionCategory dataPermission = new Data.PermissionCategory();
            return dataPermission.GetPermissionsInCategory(categoryID);
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
		public static DataSet GetAllPermissions()
		{
			Data.Permission dataPermission = new Data.Permission();
			return dataPermission.GetPermissionList();
		}        
        /// <summary>
        /// 获取所有角色
        /// </summary>
		public static DataSet GetRoleList()
		{
			Data.Role dataRole = new Data.Role();
			return dataRole.GetRoleList();
		}
	}
}
