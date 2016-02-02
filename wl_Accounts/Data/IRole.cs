using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wl_Accounts.Data
{
    public   interface IRole
    {
        /// <summary>
        /// 增加角色
        /// </summary>       
         int Create(string description);

        /// <summary>
        /// 更新角色信息
        /// </summary>
         bool Update(int roleId, string description);
        /// <summary>
        /// 删除角色
        /// </summary>
         bool Delete(int roleId);

        /// <summary>
        /// 根据角色ID获取角色的信息
        /// </summary>
         object Retrieve(int roleId);

        /// <summary>
        /// 为角色增加权限
        /// </summary>
         void AddPermission(int roleId, int permissionId);
        /// <summary>
        /// 从角色移除权限
        /// </summary>
         void RemovePermission(int roleId, int permissionId);
        /// <summary>
        /// 清空角色的权限
        /// </summary>
         void ClearPermissions(int roleId);

        /// <summary>
        /// 获取所有角色的列表
        /// </summary>
         object GetRoleList();
    }
}
