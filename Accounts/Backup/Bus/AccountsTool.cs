using System;
using System.Data;
namespace LTP.Accounts.Bus
{
    /// <summary>
    /// Ȩ�޹�����
    /// </summary>
	public class AccountsTool
	{
        /// <summary>
        /// ��ȡ����Ȩ�����
        /// </summary>
		public static DataSet GetAllCategories()
		{
			Data.PermissionCategory dataPermissionCategory = new Data.PermissionCategory();
			return dataPermissionCategory.GetCategoryList();
		}
        /// <summary>
        /// ��ȡĳ��������Ȩ��
        /// </summary>
        public static DataSet GetPermissionsByCategory(int categoryID)
        {
            Data.PermissionCategory dataPermission = new Data.PermissionCategory();
            return dataPermission.GetPermissionsInCategory(categoryID);
        }

        /// <summary>
        /// ��ȡ����Ȩ��
        /// </summary>
		public static DataSet GetAllPermissions()
		{
			Data.Permission dataPermission = new Data.Permission();
			return dataPermission.GetPermissionList();
		}        
        /// <summary>
        /// ��ȡ���н�ɫ
        /// </summary>
		public static DataSet GetRoleList()
		{
			Data.Role dataRole = new Data.Role();
			return dataRole.GetRoleList();
		}
	}
}
