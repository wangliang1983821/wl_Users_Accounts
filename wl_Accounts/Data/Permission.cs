using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using wl_Accounts.Model;

namespace wl_Accounts.Data
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public   class Permission :IPermission
    {

        public static string ConnString = PubConstant.ConnectionString;
        /// <summary>
        /// 创建一个权限
        /// </summary>
        public int Create(int categoryID, string description)
        { 
            DynamicParameters p = new DynamicParameters();
            p.Add("@CategoryID", categoryID, DbType.Int32);
            p.Add("@Description", description, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
              
               return Convert.ToInt32(conn.ExecuteScalar("sp_Accounts_CreatePermission", p, null, null, CommandType.StoredProcedure));
               
            }
            
        }


        /// <summary>
        /// 更新权限信息
        /// </summary>
        public bool Update(int PermissionID, string description)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@PermissionID", PermissionID, DbType.Int32);
            p.Add("@Description", description, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_UpdatePermission", p, null, null, CommandType.StoredProcedure)==1;

            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>        
        public bool Delete(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@PermissionID", id, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_DeletePermission", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }

        /// <summary>
        /// 根据权限ID获取权限信息
        /// </summary>
        public object Retrieve(int permissionId)
        {
           
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
               
                return conn.Query<AccountsPermissions>("sp_Accounts_GetPermissionDetails", new { PermissionID = permissionId }, null, true, null, CommandType.StoredProcedure).SingleOrDefault();

            }
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>        
        public object GetPermissionList()
        {
            //string sqlCommandText = "select * from Accounts_PermissionCategories as a join Accounts_Permissions as p on a.CategoryID=p.CategoryID";
            //List<AccountsPermissionCategories> userList = new List<AccountsPermissionCategories>();
            //using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            //{

            //    var lookUp = new Dictionary<int, AccountsPermissionCategories>();
            //    userList = conn.Query<AccountsPermissionCategories, AccountsPermissions, AccountsPermissionCategories>(sqlCommandText,
            //        (user, role) =>
            //        {
            //            AccountsPermissionCategories u;
            //            if (!lookUp.TryGetValue(user.CategoryID, out u))
            //            {
            //                lookUp.Add(user.CategoryID, u = user);
            //            }
            //            u.AccountsPermissionsList.Add(role);
            //            return user;
            //        }, null, null, true, "PermissionID", null, null).ToList();
            //    var result = lookUp.Values;

            //}
            //return userList;

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissions>("sp_Accounts_GetPermissionList", null, null, true, null, CommandType.StoredProcedure);
            }


        }


        /// <summary>
        /// 获取指定角色的权限列表
        /// </summary>        
        public object GetPermissionList(int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissions>("sp_Accounts_GetPermissionList",p, null, true, null, CommandType.StoredProcedure);
            }
        }


        /// <summary>
        /// 获取指定角色没有的权限列表
        /// </summary>        
        public object GetNoPermissionList(int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissions>("sp_Accounts_GetNoPermissionList", p, null, true, null, CommandType.StoredProcedure);
            }
        }
    }
}
