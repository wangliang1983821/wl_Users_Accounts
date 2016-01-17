using System;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Text;
namespace LTP.Accounts.Bus
{
    /// <summary>
    /// 用户对象的安全上下文信息
    /// </summary>
	public class AccountsPrincipal: System.Security.Principal.IPrincipal
    {
        Data.User dataUser = new Data.User();		

        #region 属性
        protected System.Security.Principal.IIdentity identity;
		protected ArrayList permissionList;
		protected ArrayList permissionListid;
		protected ArrayList roleList;

        /// <summary>
        /// 当前用户的所有角色
        /// </summary>
		public ArrayList Roles
		{
			get 
			{
				return roleList;
			}
		}
        /// <summary>
        /// 当前用户拥有的权限列表
        /// </summary>
		public ArrayList Permissions
		{
			get 
			{
				return permissionList;
			}
		}
        /// <summary>
        /// 当前用户拥有的权限ID列表
        /// </summary>
		public ArrayList PermissionsID
		{
			get 
			{
				return permissionListid;
			}
		}
        // IPrincipal Interface Requirements:
        /// <summary>
        /// 当前用户的标识对象
        /// </summary>
		public System.Security.Principal.IIdentity Identity
		{
			get 
			{
				return identity;
			}
			set 
			{
				identity = value;
			}
        }
        #endregion

        /// <summary>
        /// 根据用户编号构造
        /// </summary>
        public AccountsPrincipal(int userID)
		{				
			identity = new SiteIdentity(userID);
			permissionList = dataUser.GetEffectivePermissionList(userID);
			permissionListid=dataUser.GetEffectivePermissionListID(userID);
			roleList = dataUser.GetUserRoles(userID);
		}
        /// <summary>
        /// 根据用户名构造
        /// </summary>
		public AccountsPrincipal(string userName)
		{		
			identity = new SiteIdentity(userName);
			permissionList = dataUser.GetEffectivePermissionList( ((SiteIdentity)identity).UserID );
			permissionListid=dataUser.GetEffectivePermissionListID(((SiteIdentity)identity).UserID);
			roleList = dataUser.GetUserRoles(((SiteIdentity)identity).UserID );
		}
        /// <summary>
        /// 当前用户是否属于指定名称的角色
        /// </summary>
		public bool IsInRole(string role)
		{
			return roleList.Contains( role );
		}
        /// <summary>
        /// 当前用户是否拥有指定名称的权限
        /// </summary>
		public bool HasPermission( string permission )
		{
			return permissionList.Contains( permission );
		}
        /// <summary>
        /// 当前用户是否拥有指定的权限
        /// </summary>
		public bool HasPermissionID(int permissionid )
		{
			return permissionListid.Contains( permissionid );
		}
        /// <summary>
        /// 验证登录信息
        /// </summary>
		public static AccountsPrincipal ValidateLogin(string userName, string password)
		{
			int newID;
			byte[] cryptPassword = EncryptPassword( password );
            Data.User dataUser = new Data.User();
			if ((newID = dataUser.ValidateLogin(userName, cryptPassword)) > 0 )
				return new AccountsPrincipal( newID );
			else
				return null;			
		}
        /// <summary>
        /// 密码加密
        /// </summary>
		public static byte[] EncryptPassword(string password)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			byte[] hashBytes = encoding.GetBytes( password );			
			SHA1 sha1 = new SHA1CryptoServiceProvider();
			byte[] cryptPassword = sha1.ComputeHash ( hashBytes);
			return cryptPassword;
		}
		
	}
}
