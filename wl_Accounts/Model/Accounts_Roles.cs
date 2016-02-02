using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsRoles
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

        #region Description

        private String m_description;

        /// <summary>Gets or sets Description</summary>
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        #endregion


    }
}
