using System;
using System.Collections.Generic;
using System.Text;

namespace wl_Accounts.Model
{
    [Serializable]
    public  class AccountsUsers
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

        #region UserName

        private String m_userName;

        /// <summary>Gets or sets UserName</summary>
        public String UserName
        {
            get { return m_userName; }
            set { m_userName = value; }
        }

        #endregion

        #region Password

        private Byte[] m_password;

        /// <summary>Gets or sets Password</summary>
        public Byte[] Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        #endregion

        #region TrueName

        private String m_trueName;

        /// <summary>Gets or sets TrueName</summary>
        public String TrueName
        {
            get { return m_trueName; }
            set { m_trueName = value; }
        }

        #endregion

        #region Sex

        private String m_sex;

        /// <summary>Gets or sets Sex</summary>
        public String Sex
        {
            get { return m_sex; }
            set { m_sex = value; }
        }

        #endregion

        #region Phone

        private String m_phone;

        /// <summary>Gets or sets Phone</summary>
        public String Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }

        #endregion

        #region Email

        private String m_email;

        /// <summary>Gets or sets Email</summary>
        public String Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        #endregion

        #region EmployeeID

        private Int32? m_employeeID;

        /// <summary>Gets or sets EmployeeID</summary>
        public Int32? EmployeeID
        {
            get { return m_employeeID; }
            set { m_employeeID = value; }
        }

        #endregion

        #region DepartmentID

        private String m_departmentID;

        /// <summary>Gets or sets DepartmentID</summary>
        public String DepartmentID
        {
            get { return m_departmentID; }
            set { m_departmentID = value; }
        }

        #endregion

        #region Activity

        private Boolean m_activity;

        /// <summary>Gets or sets Activity</summary>
        public Boolean Activity
        {
            get { return m_activity; }
            set { m_activity = value; }
        }

        #endregion

        #region UserType

        private String m_userType;

        /// <summary>Gets or sets UserType</summary>
        public String UserType
        {
            get { return m_userType; }
            set { m_userType = value; }
        }

        #endregion

        #region Style

        private Int32? m_style;

        /// <summary>Gets or sets Style</summary>
        public Int32? Style
        {
            get { return m_style; }
            set { m_style = value; }
        }

        #endregion


    }
}
