using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsUserRoles
    {

        #region UserID

        private Int32 m_userID;

        /// <summary>Gets or sets UserID</summary>
        public Int32 UserID
        {
            get { return m_userID; }
            set { m_userID = value; }
        }

        #endregion

        #region RoleID

        private Int32 m_roleID;

        /// <summary>Gets or sets RoleID</summary>
        public Int32 RoleID
        {
            get { return m_roleID; }
            set { m_roleID = value; }
        }

        #endregion


    }
	
}
