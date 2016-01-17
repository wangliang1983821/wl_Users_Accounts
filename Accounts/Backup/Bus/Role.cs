using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Serializable]
    public class Role
    {
        #region 属性
        private int roleId;
		private string description;
		private DataSet permissions;
		private DataSet nopermissions;
        private DataSet users;
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID
        {
            get
            {
                return roleId;
            }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        /// <summary>
        /// 该角色拥有的权限列表
        /// </summary>
        public DataSet Permissions
        {
            get
            {
                return permissions;
            }
        }
        /// <summary>
        /// 该角色没有的权限列表
        /// </summary>
        public DataSet NoPermissions
        {
            get
            {
                return nopermissions;
            }
        }
        /// <summary>
        /// 该角色下的所有用户
        /// </summary>
        public DataSet Users
        {
            get
            {
                return users;
            }
        }
        #endregion


        Data.Role dataRole = new Data.Role();

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
		{ }

        /// <summary>
        /// 根据角色ID构造角色的信息
        /// </summary>
		public Role(int currentRoleId)
		{			
			DataRow roleRow;			
			roleRow = dataRole.Retrieve(currentRoleId );
			roleId = currentRoleId;
            if (roleRow["Description"] != null)
            {
                description = (string)roleRow["Description"];
            }
			Data.Permission dataPermission = new Data.Permission();
			permissions = dataPermission.GetPermissionList( currentRoleId );
			nopermissions=dataPermission.GetNoPermissionList(currentRoleId);

            Data.User user = new Data.User();
            users = user.GetUsersByRole(currentRoleId);
		}

        /// <summary>
        /// 增加角色
        /// </summary>
		public int Create()
		{				
			roleId = dataRole.Create(description);
			return roleId;
		}
        /// <summary>
        /// 更新角色
        /// </summary>
		public bool Update()
		{		
			return dataRole.Update(roleId, description);
		}
        /// <summary>
        /// 删除角色
        /// </summary>
		public bool Delete()
		{			
			return dataRole.Delete( roleId );			
		}
        /// <summary>
        /// 为角色增加权限
        /// </summary>
		public void AddPermission(int permissionId)
		{			
			dataRole.AddPermission( roleId, permissionId );
		}
        /// <summary>
        /// 从角色移除权限
        /// </summary>
		public void RemovePermission(int permissionId)
		{			
			dataRole.RemovePermission( roleId, permissionId );
		}
        /// <summary>
        /// 清空角色的权限
        /// </summary>
		public void ClearPermissions()
		{			
			dataRole.ClearPermissions( roleId );
        }
        /// <summary>
        /// 获取所有角色的列表
        /// </summary>
        public DataSet GetRoleList()
        {
            return dataRole.GetRoleList();
        }
        #endregion

    }
}
