using System;
using System.Data;
using System.Data.SqlClient;

namespace LTP.Accounts.Data
{
    /// <summary>
    ///Ȩ�����
    /// </summary>
    public class PermissionCategory 
    {
        public PermissionCategory()           
        { }

        /// <summary>
        /// ����Ȩ�����
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
        /// ɾ��Ȩ�����
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
        /// ��ȡȨ�������Ϣ
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
        /// ��ȡָ������µ�Ȩ���б�
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
        /// ��ȡȨ�������б�
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
