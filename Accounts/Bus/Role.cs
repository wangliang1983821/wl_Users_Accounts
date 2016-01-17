using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
    /// <summary>
    /// ��ɫ����
    /// </summary>
    [Serializable]
    public class Role
    {
        #region ����
        private int roleId;
		private string description;
		private DataSet permissions;
		private DataSet nopermissions;
        private DataSet users;
        /// <summary>
        /// ��ɫ���
        /// </summary>
        public int RoleID
        {
            get
            {
                return roleId;
            }
        }
        /// <summary>
        /// ��ɫ����
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
        /// �ý�ɫӵ�е�Ȩ���б�
        /// </summary>
        public DataSet Permissions
        {
            get
            {
                return permissions;
            }
        }
        /// <summary>
        /// �ý�ɫû�е�Ȩ���б�
        /// </summary>
        public DataSet NoPermissions
        {
            get
            {
                return nopermissions;
            }
        }
        /// <summary>
        /// �ý�ɫ�µ������û�
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

        #region ����

        /// <summary>
        /// ���캯��
        /// </summary>
        public Role()
		{ }

        /// <summary>
        /// ���ݽ�ɫID�����ɫ����Ϣ
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
        /// ���ӽ�ɫ
        /// </summary>
		public int Create()
		{				
			roleId = dataRole.Create(description);
			return roleId;
		}
        /// <summary>
        /// ���½�ɫ
        /// </summary>
		public bool Update()
		{		
			return dataRole.Update(roleId, description);
		}
        /// <summary>
        /// ɾ����ɫ
        /// </summary>
		public bool Delete()
		{			
			return dataRole.Delete( roleId );			
		}
        /// <summary>
        /// Ϊ��ɫ����Ȩ��
        /// </summary>
		public void AddPermission(int permissionId)
		{			
			dataRole.AddPermission( roleId, permissionId );
		}
        /// <summary>
        /// �ӽ�ɫ�Ƴ�Ȩ��
        /// </summary>
		public void RemovePermission(int permissionId)
		{			
			dataRole.RemovePermission( roleId, permissionId );
		}
        /// <summary>
        /// ��ս�ɫ��Ȩ��
        /// </summary>
		public void ClearPermissions()
		{			
			dataRole.ClearPermissions( roleId );
        }
        /// <summary>
        /// ��ȡ���н�ɫ���б�
        /// </summary>
        public DataSet GetRoleList()
        {
            return dataRole.GetRoleList();
        }
        #endregion

    }
}
