using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using wl_Accounts.Model;

namespace wl_Accounts.Data
{
    public  class User
    {
        public static string ConnString = PubConstant.ConnectionString;
        #region 增加用户

        /// <summary>
        /// 创建用户
        /// </summary>
        public   int Create(AccountsUsers user)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserName", user.UserName, DbType.String);
            p.Add("@Password", user.Password, DbType.Binary);
            p.Add("@TrueName", user.TrueName, DbType.String);
            p.Add("@Sex", user.Sex, DbType.String);
            p.Add("@Phone", user.Phone, DbType.String);
            p.Add("@Email", user.Email, DbType.String);
            p.Add("@EmployeeID", user.EmployeeID, DbType.Int32);
            p.Add("@DepartmentID", user.DepartmentID, DbType.String);
            p.Add("@Activity", user.Activity ? 1 : 0, DbType.Byte);
            p.Add("@UserType", user.UserType, DbType.String);
            p.Add("@UserID", null, DbType.Int32, ParameterDirection.ReturnValue);
            p.Add("@Style", user.Style, DbType.String);
           
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                 conn.Execute("sp_Accounts_CreateUser", p, null, null, CommandType.StoredProcedure);
                 return p.Get<int>("@UserID");
            }
        }

        #endregion

        #region 得到用户信息
        /// <summary>
        /// 根据UserID查询用户详细信息
        /// </summary>
        public object Retrieve(int userID)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsUsers>("sp_Accounts_GetUserDetails", new { UserID = userID }, null, true, null, CommandType.StoredProcedure).SingleOrDefault();

            }
        }

        /// <summary>
        /// 根据UserName查询用户详细信息
        /// </summary>
        public object Retrieve(string userName)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsUsers>("sp_Accounts_GetUserDetailsByUserName", new { UserName = userName }, null, true, null, CommandType.StoredProcedure).SingleOrDefault();

            }
        }

        #endregion

        #region 是否存在
        /// <summary>
        /// 用户名是否已经存在
        /// </summary>
        public bool HasUser(string userName)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsUsers>("sp_Accounts_GetUserDetailsByUserName", new { UserName = userName }, null, true, null, CommandType.StoredProcedure).Count() > 0 ? true : false;

            }
        }
        #endregion

        #region 修改用户
        /// <summary>
        /// 更新用户信息
        /// </summary>
        public bool Update(AccountsUsers user)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserName", user.UserName, DbType.String);
            p.Add("@Password", user.Password, DbType.Binary);
            p.Add("@TrueName", user.TrueName, DbType.String);
            p.Add("@Sex", user.Sex, DbType.String);
            p.Add("@Phone", user.Phone, DbType.String);
            p.Add("@Email", user.Email, DbType.String);
            p.Add("@EmployeeID", user.EmployeeID, DbType.Int32);
            p.Add("@DepartmentID", user.DepartmentID, DbType.String);
            p.Add("@Activity", user.Activity ? 1 : 0, DbType.Byte);
            p.Add("@UserType", user.UserType, DbType.String);
            p.Add("@UserID", user.UserID, DbType.Int32);
            p.Add("@Style", user.Style, DbType.String);

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_UpdateUser", p, null, null, CommandType.StoredProcedure) > 0;
                
            }
        }


        /// <summary>
        /// 设置用户密码
        /// </summary>
        public bool SetPassword(string UserName, byte[] encPassword)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserName", UserName, DbType.String);
            p.Add("@Password", encPassword, DbType.Binary);
          

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_SetPassword", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        public bool Delete(int userID)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserID", userID, DbType.Int32);
          

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_DeleteUser", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }
        #endregion

        #region 验证登陆信息

        /// <summary>
        /// 验证用户登录信息
        /// </summary>
        public  int ValidateLogin(string userName, byte[] encPassword)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserName", userName, DbType.String);
            p.Add("@EncryptedPassword", encPassword, DbType.Binary);
          

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_ValidateLogin", p, null, null, CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// 测试用户密码
        /// </summary>
        public int TestPassword(int userID, byte[] encPassword)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserID", userID, DbType.Int32);
            p.Add("@EncryptedPassword", encPassword, DbType.Binary);
          

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_TestPassword", p, null, null, CommandType.StoredProcedure);

            }
        }


        #endregion

        #region 查询用户信息

        /// <summary>
        /// 根据关键字查询用户
        /// </summary>
        public object GetUserList(string key)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@key",key, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>("sp_Accounts_GetUsers", p, null, true, null, CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// 根据用户类型和关键字查询用户信息
        /// </summary>
        public  object GetUsersByType(string UserType, string Key)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@key", Key, DbType.String);
            p.Add("@UserType", UserType, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>("sp_Accounts_GetUsersByType", p, null, true, null, CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// 根据部门和关键字查询用户信息
        /// </summary>
        public object GetUsersByDepart(string DepartmentID, string Key)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@key", Key, DbType.String);
            p.Add("@DepartmentID", DepartmentID, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>("sp_Accounts_GetUsersByDepart", p, null, true, null, CommandType.StoredProcedure);

            }
        }


        /// <summary>
        /// 根据用户类型，部门，关键字查询用户
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="DepartmentID"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public object GetUserList(string UserType, string DepartmentID, string Key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users ");
            strSql.Append("where (1=1)");
            strSql.Append(" and UserID in ( @UserType )");
            strSql.Append(" and DepartmentID= @DepartmentID ");
            strSql.Append(" and (UserName like '%'+@Key+'%' or TrueName like '%'+@Key+'%')  ");
            strSql.Append(" order by UserName ");
            DynamicParameters p = new DynamicParameters();
            p.Add("@key", Key, DbType.String);
            p.Add("@DepartmentID", DepartmentID, DbType.String);
            p.Add("@UserType", UserType, DbType.String);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>(strSql.ToString(), p, null, true, null, CommandType.Text);

            }
        }
        #endregion

        #region 获取某角色下的所有用户
        /// <summary>
        /// 获取某角色下的所有用户
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public   object GetUsersByRole(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users where UserID in ");
            strSql.Append("(select UserID from Accounts_UserRoles ");
            strSql.Append(" where RoleID= @RoleID) ");
            DynamicParameters p = new DynamicParameters();
            p.Add("@RoleID", RoleID, DbType.Int32);
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Query<AccountsRoles>(strSql.ToString(), p, null, true, null, CommandType.Text);

            }
        }

        #endregion

        #region 得到用户的角色信息
        /// <summary>
        /// 获取用户的角色信息
        /// </summary>
        public   ArrayList GetUserRoles(int userID)
        {
            ArrayList roles = new ArrayList();
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;

            SqlDataReader tmpReader = DbHelperSQL.RunProcedure("sp_Accounts_GetUserRoles", parameters);
            while (tmpReader.Read())
            {
                roles.Add(tmpReader.GetString(1));
            }
            tmpReader.Close();
            return roles;
        }
        #endregion

        #region 得到用户权限信息
        /// <summary>
        /// 获取用户有效的权限列表
        /// </summary>
        public ArrayList GetEffectivePermissionList(int userID)
        {
            ArrayList permissions = new ArrayList();
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;

            SqlDataReader tmpReader = DbHelperSQL.RunProcedure("sp_Accounts_GetEffectivePermissionList", parameters);
            while (tmpReader.Read())
            {
                permissions.Add(tmpReader.GetString(0));
            }
            tmpReader.Close();
            return permissions;
        }
        /// <summary>
        /// 获取用户有效的权限ID列表
        /// </summary>
        public ArrayList GetEffectivePermissionListID(int userID)
        {
            ArrayList permissionsid = new ArrayList();
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;

            SqlDataReader tmpReader = DbHelperSQL.RunProcedure("sp_Accounts_GetEffectivePermissionListID", parameters);
            while (tmpReader.Read())
            {
                permissionsid.Add(tmpReader.GetInt32(0));
            }
            tmpReader.Close();
            return permissionsid;
        }
        #endregion

        #region 增加/移除 所属角色
        /// <summary>
        /// 为用户增加角色
        /// </summary>
        public bool AddRole(int userId, int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserID", userId, DbType.Int32);
            p.Add("@RoleID", roleId, DbType.Int32);

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_AddUserToRole", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }

        /// <summary>
        /// 从用户移除角色
        /// </summary>
        public bool RemoveRole(int userId, int roleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserID", userId, DbType.Int32);
            p.Add("@RoleID", roleId, DbType.Int32);

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                return conn.Execute("sp_Accounts_RemoveUserFromRole", p, null, null, CommandType.StoredProcedure) == 1;

            }
        }
        #endregion


        #region  普通管理员（有权）可以为别的用户分配的角色

        /// <summary>
        /// 要分配是否存在该记录
        /// </summary>
        public bool AssignRoleExists(int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserAssignmentRoles");
            strSql.Append(" where UserID= @UserID and RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条关联数据
        /// </summary>
         public  void AddAssignRole(int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserAssignmentRoles(");
            strSql.Append("UserID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID)");

            DynamicParameters p = new DynamicParameters();
            p.Add("@UserID", UserID, DbType.Int32);
            p.Add("@RoleID", RoleID, DbType.Int32);

            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {

                 conn.Execute(strSql.ToString(), p, null, null, CommandType.Text);

            }
        }
        /// <summary>
        /// 删除一条关联数据
        /// </summary>
         public void DeleteAssignRole(int UserID, int RoleID)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("delete Accounts_UserAssignmentRoles ");
             strSql.Append(" where UserID= @UserID and RoleID=@RoleID ");

             DynamicParameters p = new DynamicParameters();
             p.Add("@UserID", UserID, DbType.Int32);
             p.Add("@RoleID", RoleID, DbType.Int32);

             using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
             {

                 conn.Execute(strSql.ToString(), p, null, null, CommandType.Text);

             }
         }

        /// <summary>
        /// 获取用户的可以分配的角色列表
        /// </summary>
         public   object GetAssignRolesByUser(int UserID)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select * from Accounts_Roles where RoleID in ");
             strSql.Append("(select RoleID from Accounts_UserAssignmentRoles ");
             strSql.Append(" where UserID= @UserID) ");
             strSql.Append(" ORDER BY Description ASC ");

             DynamicParameters p = new DynamicParameters();
             p.Add("@UserID", UserID, DbType.Int32);
             using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
             {
                 return conn.Query<AccountsRoles>(strSql.ToString(), p, null, true, null, CommandType.Text);
             }
         }

        /// <summary>
        /// 获取用户的不可以分配的角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
         public object GetNoAssignRolesByUser(int UserID)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select * from Accounts_Roles where RoleID not in ");
             strSql.Append("(select RoleID from Accounts_UserAssignmentRoles ");
             strSql.Append(" where UserID= @UserID) ");
             strSql.Append(" ORDER BY Description ASC ");
             DynamicParameters p = new DynamicParameters();
             p.Add("@UserID", UserID, DbType.Int32);
             using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
             {
                 return conn.Query<AccountsRoles>(strSql.ToString(), p, null, true, null, CommandType.Text);
             }
         }
        #endregion 
    }
}
