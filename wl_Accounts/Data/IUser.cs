using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wl_Accounts.Model;

namespace wl_Accounts.Data
{
    public   interface IUser
    {
        #region 增加用户

        /// <summary>
        /// 创建用户
        /// </summary>
         int Create(AccountsUsers user);

        #endregion

        #region 得到用户信息
        /// <summary>
        /// 根据UserID查询用户详细信息
        /// </summary>
         object Retrieve(int userID);

        /// <summary>
        /// 根据UserName查询用户详细信息
        /// </summary>
         object Retrieve(string userName);

        #endregion

        #region 是否存在
        /// <summary>
        /// 用户名是否已经存在
        /// </summary>
         bool HasUser(string userName);
        #endregion

        #region 修改用户
        /// <summary>
        /// 更新用户信息
        /// </summary>
         bool Update(AccountsUsers user);
        

        /// <summary>
        /// 设置用户密码
        /// </summary>
         bool SetPassword(string UserName, byte[] encPassword);
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
         bool Delete(int userID);
        #endregion

        #region 验证登陆信息

        /// <summary>
        /// 验证用户登录信息
        /// </summary>
         int ValidateLogin(string userName, byte[] encPassword);

        /// <summary>
        /// 测试用户密码
        /// </summary>
         int TestPassword(int userID, byte[] encPassword);


        #endregion

        #region 查询用户信息

        /// <summary>
        /// 根据关键字查询用户
        /// </summary>
         object GetUserList(string key);
        /// <summary>
        /// 根据用户类型和关键字查询用户信息
        /// </summary>
         object GetUsersByType(string UserType, string Key);
        /// <summary>
        /// 根据部门和关键字查询用户信息
        /// </summary>
         object GetUsersByDepart(string DepartmentID, string Key);

          
        /// <summary>
        /// 根据用户类型，部门，关键字查询用户
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="DepartmentID"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
         object GetUserList(string UserType, string DepartmentID, string Key);
        #endregion

        #region 获取某角色下的所有用户
        /// <summary>
        /// 获取某角色下的所有用户
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
         object GetUsersByRole(int RoleID);

        #endregion

        #region 得到用户的角色信息
        /// <summary>
        /// 获取用户的角色信息
        /// </summary>
         ArrayList GetUserRoles(int userID);
        #endregion

        #region 得到用户权限信息
        /// <summary>
        /// 获取用户有效的权限列表
        /// </summary>
         ArrayList GetEffectivePermissionList(int userID);
        /// <summary>
        /// 获取用户有效的权限ID列表
        /// </summary>
         ArrayList GetEffectivePermissionListID(int userID);
        #endregion

        #region 增加/移除 所属角色
        /// <summary>
        /// 为用户增加角色
        /// </summary>
         bool AddRole(int userId, int roleId);

        /// <summary>
        /// 从用户移除角色
        /// </summary>
         bool RemoveRole(int userId, int roleId);
        #endregion


        #region  普通管理员（有权）可以为别的用户分配的角色

        /// <summary>
        /// 要分配是否存在该记录
        /// </summary>
         bool AssignRoleExists(int UserID, int RoleID);


        /// <summary>
        /// 增加一条关联数据
        /// </summary>
         void AddAssignRole(int UserID, int RoleID);
        /// <summary>
        /// 删除一条关联数据
        /// </summary>
         void DeleteAssignRole(int UserID, int RoleID);

        /// <summary>
        /// 获取用户的可以分配的角色列表
        /// </summary>
         object GetAssignRolesByUser(int UserID);

        /// <summary>
        /// 获取用户的不可以分配的角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
         object GetNoAssignRolesByUser(int UserID);
        #endregion 
    }
}
