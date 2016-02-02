using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using wl_Accounts.Model;

namespace wl_Accounts.Data
{
    public   class Role :IRole
    {
        public static string ConnString = PubConstant.ConnectionString;
        /// <summary>
        /// 增加角色
        /// </summary>       
        public int Create(string description)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("@Description", description, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return Convert.ToInt32(conn.ExecuteScalar("sp_Accounts_CreateRole", p, null, null, CommandType.StoredProcedure));

            }
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        public bool Update(int roleId, string description)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            p.Add("@Description", description, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_UpdateRole", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        public bool Delete(int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_DeleteRole", p, null, null, CommandType.StoredProcedure) == 1;

            }

        }

        /// <summary>
        /// 根据角色ID获取角色的信息
        /// </summary>
        public object Retrieve(int roleId)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>("sp_Accounts_GetRoleDetails", new { RoleID = roleId }, null, true, null, CommandType.StoredProcedure).SingleOrDefault();

            }

        }

        /// <summary>
        /// 为角色增加权限
        /// </summary>
        public void AddPermission(int roleId, int permissionId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            p.Add("@PermissionID", permissionId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                 conn.Execute("sp_Accounts_AddPermissionToRole", p, null, null, CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// 从角色移除权限
        /// </summary>
        public void RemovePermission(int roleId, int permissionId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            p.Add("@PermissionID", permissionId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                conn.Execute("sp_Accounts_RemovePermissionFromRole", p, null, null, CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// 清空角色的权限
        /// </summary>
        public void ClearPermissions(int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", roleId, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                conn.Execute("sp_Accounts_ClearPermissionsFromRole", p, null, null, CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// 获取所有角色的列表
        /// </summary>
        public object GetRoleList()
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsPermissionCategories>("sp_Accounts_GetAllRoles", null, null, true, null, CommandType.StoredProcedure);
            }
        }
    }
}
