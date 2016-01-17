using System;
using System.Data;
using System.Data.SqlClient;

namespace LTP.Accounts.Data
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class Permission 
    {
        public Permission()            
        { }


        /// <summary>
        /// 创建一个权限
        /// </summary>
        public int Create(int categoryID, string description)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
				{
					new SqlParameter("@CategoryID", SqlDbType.Int, 8),
					new SqlParameter("@Description", SqlDbType.VarChar, 50)
				};
            parameters[0].Value = categoryID;
            parameters[1].Value = description;

            return DbHelperSQL.RunProcedure("sp_Accounts_CreatePermission", parameters, out rowsAffected);
        }

        /// <summary>
        /// 更新权限信息
        /// </summary>
        public bool Update(int PermissionID, string description)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
				{
					new SqlParameter("@PermissionID", SqlDbType.Int, 8),
					new SqlParameter("@Description", SqlDbType.VarChar, 50)
				};
            parameters[0].Value = PermissionID;
            parameters[1].Value = description;

            DbHelperSQL.RunProcedure("sp_Accounts_UpdatePermission", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        /// <summary>
        /// 删除权限
        /// </summary>        
        public bool Delete(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters =
				{
					new SqlParameter("@PermissionID", SqlDbType.Int, 4)
				};
            parameters[0].Value = id;
            DbHelperSQL.RunProcedure("sp_Accounts_DeletePermission", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }

        /// <summary>
        /// 根据权限ID获取权限信息
        /// </summary>
        public DataRow Retrieve(int permissionId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = permissionId;
            using (DataSet permissions = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionDetails", parameters, "Permissions"))
            {
                if (permissions.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("找不到权限 （" + permissionId + "）");
                }
                else
                    return permissions.Tables[0].Rows[0];
            }
        }
        
        /// <summary>
        /// 获取权限列表
        /// </summary>        
        public DataSet GetPermissionList()
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) };
            using (DataSet permissions = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionCategories", new IDataParameter[] { }, "Categories"))
            {
                DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionList", parameters, permissions, "Permissions");
                DataRelation permissionCategories = new DataRelation("PermissionCategories",
                    permissions.Tables["Categories"].Columns["CategoryID"],
                    permissions.Tables["Permissions"].Columns["CategoryID"], true);
                permissions.Relations.Add(permissionCategories);
                DataColumn[] categoryKeys = new DataColumn[1];
                categoryKeys[0] = permissions.Tables["Categories"].Columns["CategoryID"];
                DataColumn[] permissionKeys = new DataColumn[1];
                permissionKeys[0] = permissions.Tables["Permissions"].Columns["PermissionID"];
                permissions.Tables["Categories"].PrimaryKey = categoryKeys;
                permissions.Tables["Permissions"].PrimaryKey = permissionKeys;
                return permissions;
            }
        }
        
        /// <summary>
        /// 获取指定角色的权限列表
        /// </summary>        
        public DataSet GetPermissionList(int roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;
            using (DataSet permissions = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionCategories", new IDataParameter[] { }, "Categories"))
            {
                DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionList", parameters, permissions, "Permissions");
                DataRelation permissionCategories = new DataRelation("PermissionCategories",
                    permissions.Tables["Categories"].Columns["CategoryID"],
                    permissions.Tables["Permissions"].Columns["CategoryID"], true);
                permissions.Relations.Add(permissionCategories);
                DataColumn[] categoryKeys = new DataColumn[1];
                categoryKeys[0] = permissions.Tables["Categories"].Columns["CategoryID"];
                DataColumn[] permissionKeys = new DataColumn[1];
                permissionKeys[0] = permissions.Tables["Permissions"].Columns["PermissionID"];
                permissions.Tables["Categories"].PrimaryKey = categoryKeys;
                permissions.Tables["Permissions"].PrimaryKey = permissionKeys;
                return permissions;
            }
        }
        
        /// <summary>
        /// 获取指定角色没有的权限列表
        /// </summary>        
        public DataSet GetNoPermissionList(int roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;
            using (DataSet permissions = DbHelperSQL.RunProcedure("sp_Accounts_GetPermissionCategories", new IDataParameter[] { }, "Categories"))
            {
                DbHelperSQL.RunProcedure("sp_Accounts_GetNoPermissionList", parameters, permissions, "Permissions");
                DataRelation permissionCategories = new DataRelation("PermissionCategories",
                    permissions.Tables["Categories"].Columns["CategoryID"],
                    permissions.Tables["Permissions"].Columns["CategoryID"], true);
                permissions.Relations.Add(permissionCategories);
                DataColumn[] categoryKeys = new DataColumn[1];
                categoryKeys[0] = permissions.Tables["Categories"].Columns["CategoryID"];
                DataColumn[] permissionKeys = new DataColumn[1];
                permissionKeys[0] = permissions.Tables["Permissions"].Columns["PermissionID"];
                permissions.Tables["Categories"].PrimaryKey = categoryKeys;
                permissions.Tables["Permissions"].PrimaryKey = permissionKeys;
                return permissions;
            }
        }




    }
}
