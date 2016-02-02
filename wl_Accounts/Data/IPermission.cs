using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wl_Accounts.Data
{
       /// <summary>
    /// 权限管理
    /// </summary>
    public interface IPermission
    {
        /// <summary>
        /// 创建一个权限
        /// </summary>
         int Create(int categoryID, string description);
      

        /// <summary>
        /// 更新权限信息
        /// </summary>
         bool Update(int PermissionID, string description);
       
        /// <summary>
        /// 删除权限
        /// </summary>        
         bool Delete(int id);
       
        /// <summary>
        /// 根据权限ID获取权限信息
        /// </summary>
         object Retrieve(int permissionId);
       
        /// <summary>
        /// 获取权限列表
        /// </summary>        
         object GetPermissionList();
      

        /// <summary>
        /// 获取指定角色的权限列表
        /// </summary>        
         object GetPermissionList(int roleId);
      

        /// <summary>
        /// 获取指定角色没有的权限列表
        /// </summary>        
         object GetNoPermissionList(int roleId);
       

    }
}
