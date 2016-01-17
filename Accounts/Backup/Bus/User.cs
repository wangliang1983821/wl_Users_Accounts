using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// �û�
    /// </summary>
    [Serializable]
	public class User
    {
        Data.User dataUser = new Data.User();
        
        #region ����
        private int userID;
		private string userName;
		private string trueName;
		private string sex;
		private string phone;
		private string email;
		private int employeeID;
		private string departmentID="-1";
		private bool activity;
		private string userType;
		private byte[] password;
		private int style;
        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public byte[] Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string TrueName
        {
            get
            {
                return trueName;
            }
            set
            {
                trueName = value;
            }
        }

        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// ��Ա�������
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        /// <summary>
        /// �û����ڵ�λ����
        /// </summary>
        public string DepartmentID
        {
            get
            {
                return departmentID;
            }
            set
            {
                departmentID = value;
            }
        }

        /// <summary>
        /// �û�״̬
        /// </summary>
        public bool Activity
        {
            get
            {
                return activity;
            }
            set
            {
                activity = value;
            }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        public int Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }
        #endregion
        
        
        /// <summary>
        /// �����û�����
        /// </summary>
		private void LoadFromID()
		{           
			DataRow userRow = dataUser.Retrieve( userID );
			if(userRow!=null)
			{
				userName= (string)userRow["UserName"];
				trueName = (string)userRow["TrueName"];
				sex = (string)userRow["Sex"];
				phone = (string)userRow["Phone"];
				email     = (string)userRow["Email"];
				employeeID    = (int)userRow["EmployeeID"];
				departmentID  = (string)userRow["DepartmentID"];
				activity= (bool)userRow["Activity"];
				userType = (string)userRow["UserType"];
				password = (byte[])userRow["Password"];
				style = (int)userRow["Style"];
			}
        }

        #region �����û���Ϣ
        public User()
        { }

        /// <summary>
        /// �����û�ID����
        /// </summary> 
        public User( int existingUserID )
		{			
			userID = existingUserID;
			LoadFromID();						
		}
        /// <summary>
        /// �����û�������
        /// </summary>        
		public User( string UserName )
		{			
			DataRow userRow = dataUser.Retrieve( UserName );
			if(userRow!=null)
			{
				userID = (int)userRow["UserID"];
				trueName = (string)userRow["TrueName"];
				sex = (string)userRow["Sex"];
				phone = (string)userRow["Phone"];
				email     = (string)userRow["Email"];
				employeeID    = (int)userRow["EmployeeID"];
                departmentID = (string)userRow["DepartmentID"];
                activity = (bool)userRow["Activity"];
                userType = (string)userRow["UserType"];
				password = (byte[])userRow["Password"];
				style = (int)userRow["Style"];
			}
		}
        /// <summary>
        /// ����AccountsPrincipal����
        /// </summary>        
		public User(AccountsPrincipal existingPrincipal )
		{									
			userID = ((SiteIdentity)existingPrincipal.Identity).UserID;
			LoadFromID();
        }
        #endregion

        #region �Ƿ����
        /// <summary>
        /// �û����Ƿ��Ѿ�����
        /// </summary>
        public bool HasUser(string userName)
		{			
			return dataUser.HasUser(userName);
        }

        #endregion

        #region �����û�
        /// <summary>
        /// �����û�
        /// </summary>
        public int Create()
		{			
			userID = dataUser.Create(
				userName,
				password,
				trueName,
				sex,
				phone,
				email,
				employeeID,
				departmentID,
				activity,
				userType,
				style);

			return userID;
        }
        #endregion

        #region �޸��û�
        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        public bool Update()
		{			
			return dataUser.Update(
				userID,
				userName,
				password,
				trueName,
				sex,
				phone,
				email,
				employeeID,
				departmentID,
				activity,
				userType,
				style);
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        public bool SetPassword(string UserName, string password)
        {
            byte[] cryptPassword = AccountsPrincipal.EncryptPassword(password);            
            return dataUser.SetPassword(UserName, cryptPassword);
        }
        #endregion

        #region ɾ���û�
        /// <summary>
        /// ɾ���û�
        /// </summary>
        public bool Delete()
		{			
			return dataUser.Delete(userID);
        }
        #endregion

        #region ��ѯ�û�
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ�û�
        /// </summary>
        public DataSet GetUserList(string key)
        {
            return dataUser.GetUserList(key);
        }
        /// <summary>
        /// ���ݲ��ź͹ؼ��ֲ�ѯ�û���Ϣ
        /// </summary>
        public DataSet GetUsersByDepart(string DepartmentID, string Key)
        {
            return dataUser.GetUsersByDepart(DepartmentID, Key);
        }
        /// <summary>
        /// �����û����ͺ͹ؼ��ֲ�ѯ�û���Ϣ
        /// </summary>
        public DataSet GetUsersByType(string usertype, string key)
        {
            return dataUser.GetUsersByType(usertype, key);
        }
        /// <summary>
        /// �����û����ͣ����ţ��ؼ��ֲ�ѯ�û�
        /// </summary>
        public DataSet GetUserList(string UserType, string DepartmentID, string Key)
        {
            return dataUser.GetUserList(UserType, DepartmentID, Key);
        }
        /// <summary>
        /// ��ȡĳ��ɫ�µ������û�
        /// </summary>
        public DataSet GetUsersByRole(int RoleID)
        {
            return dataUser.GetUsersByRole(RoleID);
        }
        #endregion

        #region ����/�Ƴ� ������ɫ
        /// <summary>
        /// Ϊ�û����ӽ�ɫ
        /// </summary>
        public bool AddToRole(int roleId)
		{			
			return dataUser.AddRole(userID, roleId);
		}
        /// <summary>
        /// ���û��Ƴ���ɫ
        /// </summary>
		public bool RemoveRole(int roleId)
		{			
			return dataUser.RemoveRole( userID, roleId );
        }

        #endregion


        #region  ����Ա����Ȩ�����Է���Ľ�ɫ

        /// <summary>
        /// Ҫ�����Ƿ���ڸü�¼
        /// </summary>
        public bool AssignRoleExists(int UserID, int RoleID)
        {            
            return dataUser.AssignRoleExists(UserID, RoleID);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void AddAssignRole(int UserID, int RoleID)
        {            
            if (!AssignRoleExists(UserID, RoleID))
            {
                dataUser.AddAssignRole(UserID, RoleID);
            }
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void DeleteAssignRole(int UserID, int RoleID)
        {           
            dataUser.DeleteAssignRole(UserID, RoleID);
        }
        /// <summary>
        /// ��ȡ�û��Ŀ��Է���Ľ�ɫ�б�
        /// </summary>
        public DataSet GetAssignRolesByUser(int UserID)
        {            
            return dataUser.GetAssignRolesByUser(UserID);
        }
        
        /// <summary>
        /// ��ȡ�û��Ĳ����Է���Ľ�ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetNoAssignRolesByUser(int UserID)
        {            
            return dataUser.GetNoAssignRolesByUser(UserID);
        }
        #endregion
			

	}
}
