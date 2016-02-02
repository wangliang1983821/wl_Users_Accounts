using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using wl_Accounts.Model;
using Dapper;
namespace wl_Accounts.Data
{
    public class UserType:IUserType
    {
        public static string ConnString = PubConstant.ConnectionString;
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserType, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserType");
            strSql.Append(" where UserType=@UserType ");
            strSql.Append(" and Description=@Description ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Char,2),
            new SqlParameter("@Description", SqlDbType.VarChar,50)};
            parameters[0].Value = UserType;
            parameters[1].Value = Description;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(string UserType, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserType(");
            strSql.Append("UserType,Description)");
            strSql.Append(" values (");
            strSql.Append("@UserType,@Description)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Description", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserType;
            parameters[1].Value = Description;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(string UserType, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UserType set ");
            strSql.Append("Description=@Description");
            strSql.Append(" where UserType=@UserType ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Description", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserType;
            parameters[1].Value = Description;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string UserType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_UserType ");
            strSql.Append(" where UserType=@UserType ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Char,2)};
            parameters[0].Value = UserType;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到类型描述
        /// </summary>
        public string GetDescription(string UserType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Description from Accounts_UserType ");
            strSql.Append(" where UserType=@UserType ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Char,2)};
            parameters[0].Value = UserType;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["Description"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public object GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserType,Description ");
            strSql.Append(" FROM Accounts_UserType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            using (var conn = new System.Data.SqlClient.SqlConnection(ConnString))
            {
                return conn.Query<AccountsRoles>(strSql.ToString());
            }
        }

    }
        
    
}
