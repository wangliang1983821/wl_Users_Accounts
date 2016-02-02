using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsRolePermissions
    {

        #region RoleID

        private Int32 m_roleID;

        /// <summary>Gets or sets RoleID</summary>
        public Int32 RoleID
        {
            get { return m_roleID; }
            set { m_roleID = value; }
        }

        #endregion

        #region PermissionID

        private Int32 m_permissionID;

        /// <summary>Gets or sets PermissionID</summary>
        public Int32 PermissionID
        {
            get { return m_permissionID; }
            set { m_permissionID = value; }
        }

        #endregion


    }
}
