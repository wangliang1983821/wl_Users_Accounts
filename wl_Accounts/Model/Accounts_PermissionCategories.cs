using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsPermissionCategories
    {

        #region CategoryID

        private Int32 m_categoryID;

        /// <summary>Gets or sets CategoryID</summary>
        public Int32 CategoryID
        {
            get { return m_categoryID; }
            set { m_categoryID = value; }
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


        public List<AccountsPermissions> accountsPermissionsList=new List<AccountsPermissions> ();

        public List<AccountsPermissions> AccountsPermissionsList
        {
            get { return accountsPermissionsList; }
            set { accountsPermissionsList = value; }
        }
        #endregion


    }
}
