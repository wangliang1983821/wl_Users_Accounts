using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsUserType
    {

        #region UserType

        private String m_userType;

        /// <summary>Gets or sets UserType</summary>
        public String UserType
        {
            get { return m_userType; }
            set { m_userType = value; }
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
