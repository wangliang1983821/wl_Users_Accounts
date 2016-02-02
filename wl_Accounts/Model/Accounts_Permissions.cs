using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsPermissions
    {

        #region PermissionID

        private Int32 m_permissionID;

        /// <summary>Gets or sets PermissionID</summary>
        public Int32 PermissionID
        {
            get { return m_permissionID; }
            set { m_permissionID = value; }
        }

        #endregion

        #region Description

        private String m_description;

        /// <summary>Gets or sets Description</summary>
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        #endregion

        #region CategoryID

        private Int32? m_categoryID;

        /// <summary>Gets or sets CategoryID</summary>
        public Int32? CategoryID
        {
            get { return m_categoryID; }
            set { m_categoryID = value; }
        }

        #endregion


    }
	
}
