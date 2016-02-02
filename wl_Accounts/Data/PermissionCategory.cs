using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using wl_Accounts.Model;

namespace wl_Accounts.Data
{
    public class PermissionCategory : IPermissionCategory
    {

        public static string ConnString = PubConstant.ConnectionString;
        /// <summary>
        /// 创建权限类别
        /// </summary>        
        public int Create(string description)
        {
            DynamicParameters p = new DynamicParameters();
         
            p.Add("@Description", description, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return Convert.ToInt32(conn.ExecuteScalar("sp_Accounts_CreatePermissionCategory", p, null, null, CommandType.StoredProcedure));

            }
        }


        /// <summary>
        /// 删除权限类别
        /// </summary>        
        public bool Delete(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@CategoryID", id, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_DeletePermissionCategory", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }

        /// <summary>
        /// 获取权限类别信息
        /// </summary>        
        public object Retrieve(int categoryId)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsPermissionCategories>("sp_Accounts_GetPermissionCategoryDetails", new { CategoryID = categoryId }, null, true, null, CommandType.StoredProcedure).SingleOrDefault();

            }
        }

        /// <summary>
        /// 获取指定类别下的权限列表
        /// </summary>        
        public object GetPermissionsInCategory(int categoryId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@CategoryID", categoryId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissionCategories>("sp_Accounts_GetPermissionsInCategory", p, null, true, null, CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 获取权限类别的列表
        /// </summary>        
        public object GetCategoryList()
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissionCategories>("sp_Accounts_GetPermissionCategories", null, null, true, null, CommandType.StoredProcedure);
            }
        }
    }
}
