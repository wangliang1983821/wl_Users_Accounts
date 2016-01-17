using System;
using System.Data;
using System.Data.SqlClient;

namespace LTP.Accounts.Data
{
    /// <summary>
    ///权限类别
    /// </summary>
    public class PermissionCategory 
    {
        public PermissionCategory()           
        { }

        /// <summary>
        /// 创建权限类别
        /// </summary>        
        public int Create(string description)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
				{
					new SqlParameter("@Description", SqlDbType.VarChar, 50)
				};
            parameters[0].Value = description;

            return DbHelperSQL.RunProcedure("sp_Accounts_CreatePermissionCategory", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除权限类别
        /// </summary>        
        public bool Delete(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters =
				{
					new SqlParameter("@CategoryID", SqlDbType.Int, 4)
				};
            parameters[0].Value = id;
            DbHelperSQL.RunProcedure("sp_Accounts_DeletePermissionCategory", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }

        /// <summary>
        /// 获取权限类别信息
        /// </summary>        
        public DataRow Retrieve(int categoryId)
        {
            SqlParameter[] parameters = 
                {
                    new SqlParameter("@CategoryID", SqlDbType.Int, 4)
                };
            parameters[0].Value = categoryId;

            using (DataSet categories = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionCategoryDetails", parameters, "Categories"))
            {
                return categories.Tables[0].Rows[0];
            }
        }

        /// <summary>
        /// 获取指定类别下的权限列表
        /// </summary>        
        public DataSet GetPermissionsInCategory(int categoryId)
        {
            SqlParameter[] parameters =
				{
					new SqlParameter("@CategoryID", SqlDbType.Int, 4)
				};
            parameters[0].Value = categoryId;
            using (DataSet permissions = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionsInCategory",
                       parameters, "Categories"))
            {
                return permissions;
            }
        }
        
        /// <summary>
        /// 获取权限类别的列表
        /// </summary>        
        public DataSet GetCategoryList()
        {
            using (DataSet categories = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionCategories",
                       new IDataParameter[] { },
                       "Categories"))
            {
                return categories;
            }
        }
    }
}
