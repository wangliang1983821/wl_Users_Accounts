using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
namespace LTP.Accounts.Bus
{
    /// <summary>
    /// ��ǰ�û��ı�ʶ����
    /// </summary>
    [Serializable]
    public class SiteIdentity: System.Security.Principal.IIdentity
	{
        Data.User dataUser = new Data.User();

        #region  �û�����
        private string userName;
        private string trueName;
        private string email;
        private byte[] password;
        private int userID;
        private string sex;

        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
        }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string TrueName
        {
            get
            {
                return trueName;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get
            {
                return userID;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public byte[] Password
        {
            get
            {
                return password;
            }
        }
        /// <summary>
        /// �Ա�
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
        /// ��ǰ�û�������
        /// </summary>
        public string Name
        {
            get
            {
                return userName;
            }
        }

        /// <summary>
        /// ��ȡ��ʹ�õ������֤�����͡�
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
        /// �Ƿ���֤���û�
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
        /// �����û�������
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
        /// �����û�ID����
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
        /// ��鵱ǰ�û���������
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
