using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wl_Accounts.Data
{
    public  interface IPermissionCategory
    {
        /// <summary>
        /// 创建权限类别
        /// </summary>        
         int Create(string description);
       

        /// <summary>
        /// 删除权限类别
        /// </summary>        
         bool Delete(int id);

        /// <summary>
        /// 获取权限类别信息
        /// </summary>        
         object Retrieve(int categoryId);

        /// <summary>
        /// 获取指定类别下的权限列表
        /// </summary>        
         object GetPermissionsInCategory(int categoryId);

        /// <summary>
        /// 获取权限类别的列表
        /// </summary>        
         object GetCategoryList();
    }
}
