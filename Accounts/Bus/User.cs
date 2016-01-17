using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 用户
    /// </summary>
    [Serializable]
	public class User
    {
        Data.User dataUser = new Data.User();
        
        #region 属性
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
        /// 用户编号
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
        /// 用户名
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
        /// 密码
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
        /// 真实姓名
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
        /// 性别
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
        /// 联系电话
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
        /// 邮箱
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
        /// （员工）编号
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
        /// 用户所在单位或部门
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
        /// 用户状态
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
        /// 用户类型
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
        /// 风格
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
        /// 加载用户数据
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

        #region 构造用户信息
        public User()
        { }

        /// <summary>
        /// 根据用户ID构造
        /// </summary> 
        public User( int existingUserID )
		{			
			userID = existingUserID;
			LoadFromID();						
		}
        /// <summary>
        /// 根据用户名构造
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
        /// 根据AccountsPrincipal构造
        /// </summary>        
		public User(AccountsPrincipal existingPrincipal )
		{									
			userID = ((SiteIdentity)existingPrincipal.Identity).UserID;
			LoadFromID();
        }
        #endregion

        #region 是否存在
        /// <summary>
        /// 用户名是否已经存在
        /// </summary>
        public bool HasUser(string userName)
		{			
			return dataUser.HasUser(userName);
        }

        #endregion

        #region 增加用户
        /// <summary>
        /// 创建用户
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

        #region 修改用户
        /// <summary>
        /// 更新用户信息
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
        /// 设置用户密码
        /// </summary>
        public bool SetPassword(string UserName, string password)
        {
            byte[] cryptPassword = AccountsPrincipal.EncryptPassword(password);            
            return dataUser.SetPassword(UserName, cryptPassword);
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        public bool Delete()
		{			
			return dataUser.Delete(userID);
        }
        #endregion

        #region 查询用户
        /// <summary>
        /// 根据关键字查询用户
        /// </summary>
        public DataSet GetUserList(string key)
        {
            return dataUser.GetUserList(key);
        }
        /// <summary>
        /// 根据部门和关键字查询用户信息
        /// </summary>
        public DataSet GetUsersByDepart(string DepartmentID, string Key)
        {
            return dataUser.GetUsersByDepart(DepartmentID, Key);
        }
        /// <summary>
        /// 根据用户类型和关键字查询用户信息
        /// </summary>
        public DataSet GetUsersByType(string usertype, string key)
        {
            return dataUser.GetUsersByType(usertype, key);
        }
        /// <summary>
        /// 根据用户类型，部门，关键字查询用户
        /// </summary>
        public DataSet GetUserList(string UserType, string DepartmentID, string Key)
        {
            return dataUser.GetUserList(UserType, DepartmentID, Key);
        }
        /// <summary>
        /// 获取某角色下的所有用户
        /// </summary>
        public DataSet GetUsersByRole(int RoleID)
        {
            return dataUser.GetUsersByRole(RoleID);
        }
        #endregion

        #region 增加/移除 所属角色
        /// <summary>
        /// 为用户增加角色
        /// </summary>
        public bool AddToRole(int roleId)
		{			
			return dataUser.AddRole(userID, roleId);
		}
        /// <summary>
        /// 从用户移除角色
        /// </summary>
		public bool RemoveRole(int roleId)
		{			
			return dataUser.RemoveRole( userID, roleId );
        }

        #endregion


        #region  管理员（有权）可以分配的角色

        /// <summary>
        /// 要分配是否存在该记录
        /// </summary>
        public bool AssignRoleExists(int UserID, int RoleID)
        {            
            return dataUser.AssignRoleExists(UserID, RoleID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddAssignRole(int UserID, int RoleID)
        {            
            if (!AssignRoleExists(UserID, RoleID))
            {
                dataUser.AddAssignRole(UserID, RoleID);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteAssignRole(int UserID, int RoleID)
        {           
            dataUser.DeleteAssignRole(UserID, RoleID);
        }
        /// <summary>
        /// 获取用户的可以分配的角色列表
        /// </summary>
        public DataSet GetAssignRolesByUser(int UserID)
        {            
            return dataUser.GetAssignRolesByUser(UserID);
        }
        
        /// <summary>
        /// 获取用户的不可以分配的角色列表
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
