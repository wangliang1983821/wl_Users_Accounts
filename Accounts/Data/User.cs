using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace LTP.Accounts.Data
{
    /// <summary>
    /// �û�����
    /// </summary>
    [Serializable]
    public class User 
    {
        public User()
        { }


        #region �����û�

        /// <summary>
        /// �����û�
        /// </summary>
        public int Create(string userName,
            byte[] password,
            string trueName,
            string sex,
            string phone,
            string email,
            int employeeID,
            string departmentID,
            bool activity,
            string userType,
            int style)
        {
            int rowsAffected;
            SqlParameter[]
                parameters = {
								 new SqlParameter("@UserName", SqlDbType.VarChar, 50),
								 new SqlParameter("@Password", SqlDbType.Binary, 20),
								 new SqlParameter("@TrueName", SqlDbType.VarChar, 50),
								 new SqlParameter("@Sex", SqlDbType.Char, 1),
								 new SqlParameter("@Phone", SqlDbType.VarChar, 20),
								 new SqlParameter("@Email", SqlDbType.VarChar, 100),
								 new SqlParameter("@EmployeeID", SqlDbType.Int, 4),
								 new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15),
								 new SqlParameter("@Activity", SqlDbType.Bit, 1),
								 new SqlParameter("@UserType", SqlDbType.Char, 2),
								 new SqlParameter("@UserID", SqlDbType.Int, 4),
								 new SqlParameter("@Style", SqlDbType.Int, 4)
							 };

            parameters[0].Value = userName;
            parameters[1].Value = password;
            parameters[2].Value = trueName;
            parameters[3].Value = sex;
            parameters[4].Value = phone;
            parameters[5].Value = email;
            parameters[6].Value = employeeID;
            parameters[7].Value = departmentID;
            parameters[8].Value = activity ? 1 : 0;
            parameters[9].Value = userType;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = style;

            try
            {
                DbHelperSQL.RunProcedure("sp_Accounts_CreateUser", parameters, out rowsAffected);
            }
            catch (SqlException e)
            {
                if (e.Number == 2601)
                {
                    return -100;
                }
            }

            return (int)parameters[10].Value;
        }

        #endregion

        #region �õ��û���Ϣ
        /// <summary>
        /// ����UserID��ѯ�û���ϸ��Ϣ
        /// </summary>
        public DataRow Retrieve(int userID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;

            using (DataSet users = DbHelperSQL.RunProcedure("sp_Accounts_GetUserDetails", parameters, "Users"))
            {
                if (users.Tables[0].Rows.Count > 0)
                {
                    return users.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// ����UserName��ѯ�û���ϸ��Ϣ
        /// </summary>
        public DataRow Retrieve(string userName)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = userName;

            using (DataSet users = DbHelperSQL.RunProcedure("sp_Accounts_GetUserDetailsByUserName", parameters, "Users"))
            {
                if (users.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("�޴��û����û��ѹ��ڣ�" + userName);
                }
                else
                    return users.Tables[0].Rows[0];
            }
        }

        #endregion

        #region �Ƿ����
        /// <summary>
        /// �û����Ƿ��Ѿ�����
        /// </summary>
        public bool HasUser(string userName)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = userName;

            using (DataSet users = DbHelperSQL.RunProcedure("sp_Accounts_GetUserDetailsByUserName", parameters, "Users"))
            {
                if (users.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

        #region �޸��û�
        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        public bool Update(int userID,
            string userName,
            byte[] password,
            string trueName,
            string sex,
            string phone,
            string email,
            int employeeID,
            string departmentID,
            bool activity,
            string userType,
            int style)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.VarChar, 50),
											new SqlParameter("@Password", SqlDbType.Binary, 20),
											new SqlParameter("@TrueName", SqlDbType.VarChar, 50),
											new SqlParameter("@Sex", SqlDbType.Char, 2),
											new SqlParameter("@Phone", SqlDbType.VarChar, 20),
											new SqlParameter("@Email", SqlDbType.VarChar, 100),
											new SqlParameter("@EmployeeID", SqlDbType.Int, 4),
											new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15),
											new SqlParameter("@Activity", SqlDbType.Bit, 1),
											new SqlParameter("@UserType", SqlDbType.Char, 2),
											new SqlParameter("@UserID", SqlDbType.BigInt, 8),
											new SqlParameter("@Style", SqlDbType.BigInt, 8)
										};

            parameters[0].Value = userName;
            parameters[1].Value = password;
            parameters[2].Value = trueName;
            parameters[3].Value = sex;
            parameters[4].Value = phone;
            parameters[5].Value = email;
            parameters[6].Value = employeeID;
            parameters[7].Value = departmentID;
            parameters[8].Value = activity;
            parameters[9].Value = userType;
            parameters[10].Value = userID;
            parameters[11].Value = style;

            DbHelperSQL.RunProcedure("sp_Accounts_UpdateUser", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        public bool SetPassword(string UserName, byte[] encPassword)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
			{
				new SqlParameter("@UserName", SqlDbType.VarChar),
				new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20)
			};

            parameters[0].Value = UserName;
            parameters[1].Value = encPassword;

            DbHelperSQL.RunProcedure("sp_Accounts_SetPassword", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion

        #region ɾ���û�
        /// <summary>
        /// ɾ���û�
        /// </summary>
        public bool Delete(int userID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            int rowsAffected;

            parameters[0].Value = userID;

            DbHelperSQL.RunProcedure("sp_Accounts_DeleteUser", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion

        #region ��֤��½��Ϣ

/// <summary>
/// ��֤�û���¼��Ϣ
/// </summary>
public int ValidateLogin(string userName, byte[] encPassword)
{
    int rowsAffected;
    SqlParameter[] parameters = 
	  {
		  new SqlParameter("@UserName", SqlDbType.VarChar, 50),
		  new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20)
	  };

    parameters[0].Value = userName;
    parameters[1].Value = encPassword;

    return DbHelperSQL.RunProcedure("sp_Accounts_ValidateLogin", parameters, out rowsAffected);
}

        /// <summary>
        /// �����û�����
        /// </summary>
        public int TestPassword(int userID, byte[] encPassword)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
			{
				new SqlParameter("@UserID", SqlDbType.Int, 4),
				new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20)
			};

            parameters[0].Value = userID;
            parameters[1].Value = encPassword;

            return DbHelperSQL.RunProcedure("sp_Accounts_TestPassword", parameters, out rowsAffected);
        }

        
        #endregion

        #region ��ѯ�û���Ϣ    
  
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ�û�
        /// </summary>
        public DataSet GetUserList(string key)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@key", SqlDbType.VarChar, 50)
							 };

            parameters[0].Value = key;
            return DbHelperSQL.RunProcedure("sp_Accounts_GetUsers", parameters, "Users");
        }
        /// <summary>
        /// �����û����ͺ͹ؼ��ֲ�ѯ�û���Ϣ
        /// </summary>
        public DataSet GetUsersByType(string UserType, string Key)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@UserType", SqlDbType.Char, 2),
                    new SqlParameter("@key", SqlDbType.VarChar, 50)
							 };

            parameters[0].Value = UserType;
            parameters[1].Value = Key;
            return DbHelperSQL.RunProcedure("sp_Accounts_GetUsersByType", parameters, "Users");
        }
        /// <summary>
        /// ���ݲ��ź͹ؼ��ֲ�ѯ�û���Ϣ
        /// </summary>
        public DataSet GetUsersByDepart(string DepartmentID, string Key)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@DepartmentID", SqlDbType.VarChar, 30),
                    new SqlParameter("@key", SqlDbType.VarChar, 50)
							 };

            parameters[0].Value = DepartmentID;
            parameters[1].Value = Key;
            return DbHelperSQL.RunProcedure("sp_Accounts_GetUsersByDepart", parameters, "Users");
        }

        //public DataSet GetUserList()
        //{
        //    return DbHelperSQL.RunProcedure("sp_Accounts_GetUsers", new IDataParameter[] { }, "Users");
        //}        
        /// <summary>
        /// �����û����ͣ����ţ��ؼ��ֲ�ѯ�û�
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="DepartmentID"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public DataSet GetUserList(string UserType, string DepartmentID,string Key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users ");
            strSql.Append("where (1=1)");            
            strSql.Append(" and UserID in ( @UserType )");            
            strSql.Append(" and DepartmentID= @DepartmentID ");
            strSql.Append(" and (UserName like '%'+@Key+'%' or TrueName like '%'+@Key+'%')  ");
            strSql.Append(" order by UserName ");
            SqlParameter[]
                parameters = {
					new SqlParameter("@UserType", SqlDbType.Char, 2),
                    new SqlParameter("@DepartmentID", SqlDbType.VarChar, 30),
                    new SqlParameter("@Key", SqlDbType.VarChar, 50)
							 };
            parameters[0].Value = UserType;
            parameters[1].Value = DepartmentID;
            parameters[2].Value = Key;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region ��ȡĳ��ɫ�µ������û�
        /// <summary>
        /// ��ȡĳ��ɫ�µ������û�
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public DataSet GetUsersByRole(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users where UserID in ");
            strSql.Append("(select UserID from Accounts_UserRoles ");
            strSql.Append(" where RoleID= @RoleID) ");
            //strSql.Append(" ORDER BY Description ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)                    
				};
            parameters[0].Value = RoleID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion

        #region �õ��û��Ľ�ɫ��Ϣ
        /// <summary>
        /// ��ȡ�û��Ľ�ɫ��Ϣ
        /// </summary>
        public ArrayList GetUserRoles(int userID)
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

        #region �õ��û�Ȩ����Ϣ
        /// <summary>
        /// ��ȡ�û���Ч��Ȩ���б�
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
        /// ��ȡ�û���Ч��Ȩ��ID�б�
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

        #region ����/�Ƴ� ������ɫ
        /// <summary>
        /// Ϊ�û����ӽ�ɫ
        /// </summary>
        public bool AddRole(int userId, int roleId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@UserID", SqlDbType.Int, 4),
											new SqlParameter("@RoleID", SqlDbType.Int, 4)
										};
            parameters[0].Value = userId;
            parameters[1].Value = roleId;

            DbHelperSQL.RunProcedure("sp_Accounts_AddUserToRole", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }

        /// <summary>
        /// ���û��Ƴ���ɫ
        /// </summary>
        public bool RemoveRole(int userId, int roleId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@UserID", SqlDbType.Int, 4),
											new SqlParameter("@RoleID", SqlDbType.Int,4 )
										};
            parameters[0].Value = userId;
            parameters[1].Value = roleId;

            DbHelperSQL.RunProcedure("sp_Accounts_RemoveUserFromRole", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion


        #region  ��ͨ����Ա����Ȩ������Ϊ����û�����Ľ�ɫ

        /// <summary>
        /// Ҫ�����Ƿ���ڸü�¼
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
        /// ����һ����������
        /// </summary>
        public void AddAssignRole(int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserAssignmentRoles(");
            strSql.Append("UserID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ɾ��һ����������
        /// </summary>
        public void DeleteAssignRole(int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_UserAssignmentRoles ");
            strSql.Append(" where UserID= @UserID and RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ�û��Ŀ��Է���Ľ�ɫ�б�
        /// </summary>
        public DataSet GetAssignRolesByUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Roles where RoleID in ");
            strSql.Append("(select RoleID from Accounts_UserAssignmentRoles ");
            strSql.Append(" where UserID= @UserID) ");
            strSql.Append(" ORDER BY Description ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)                    
				};
            parameters[0].Value = UserID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ�û��Ĳ����Է���Ľ�ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetNoAssignRolesByUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Roles where RoleID not in ");
            strSql.Append("(select RoleID from Accounts_UserAssignmentRoles ");
            strSql.Append(" where UserID= @UserID) ");
            strSql.Append(" ORDER BY Description ASC ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)                    
				};
            parameters[0].Value = UserID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion 
    }
}
