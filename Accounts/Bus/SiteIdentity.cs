using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 当前用户的标识对象
    /// </summary>
    [Serializable]
    public class SiteIdentity: System.Security.Principal.IIdentity
	{
        Data.User dataUser = new Data.User();

        #region  用户属性
        private string userName;
        private string trueName;
        private string email;
        private byte[] password;
        private int userID;
        private string sex;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
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
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get
            {
                return userID;
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
        }
        #endregion

        #region IIdentity interface requirments:
		
        /// <summary>
        /// 当前用户的名称
        /// </summary>
        public string Name
        {
            get
            {
                return userName;
            }
        }

        /// <summary>
        /// 获取所使用的身份验证的类型。
        /// </summary>
		public string AuthenticationType
		{
			get
			{
				return "Custom Authentication";
			}
			set 
			{
				// do nothing
			}
		}
        /// <summary>
        /// 是否验证了用户
        /// </summary>
		public bool IsAuthenticated
		{
			get 
			{				
				return true;
			}
        }
        #endregion

        /// <summary>
        /// 根据用户名构造
        /// </summary>
		public SiteIdentity( string currentUserName )
		{			
			DataRow userRow = dataUser.Retrieve( currentUserName );
            if (userRow != null)
            {
                userName = currentUserName;
                trueName = (string)userRow["TrueName"];
                email = (string)userRow["Email"];
                userID = (int)userRow["UserID"];
                password = (byte[])userRow["Password"];
                sex = (string)userRow["Sex"];
            }
			
		}
        /// <summary>
        /// 根据用户ID构造
        /// </summary>
		public SiteIdentity( int currentUserID )
		{			
			DataRow userRow = dataUser.Retrieve(currentUserID);
            if (userRow != null)
            {
                userName = (string)userRow["UserName"];
                trueName = (string)userRow["TrueName"];
                email = (string)userRow["Email"];
                userID = currentUserID;
                password = (byte[])userRow["Password"];
                sex = (string)userRow["Sex"];
            }
		}
        /// <summary>
        /// 检查当前用户对象密码
        /// </summary>
		public int TestPassword(string password)
		{
			// At some point, we may have a more complex way of encrypting or storing the passwords
			// so by supplying this procedure, we can simply replace its contents to move password
			// comparison to the database (as we've done below) or somewhere else (e.g. another
			// web service, etc).
			UnicodeEncoding encoding = new UnicodeEncoding();
			byte[] hashBytes = encoding.GetBytes( password );
			SHA1 sha1 = new SHA1CryptoServiceProvider();
			byte[] cryptPassword = sha1.ComputeHash( hashBytes );            			
			return dataUser.TestPassword( userID, cryptPassword );
		}
		
	}
}
