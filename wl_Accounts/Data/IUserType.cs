using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wl_Accounts.Data
{
     public  interface IUserType
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
         bool Exists(string UserType, string Description);


        /// <summary>
        /// 增加一条数据
        /// </summary>
          void Add(string UserType, string Description);
        /// <summary>
        /// 更新一条数据
        /// </summary>
           void Update(string UserType, string Description);

        /// <summary>
        /// 删除一条数据
        /// </summary>
            void Delete(string UserType);


        /// <summary>
        /// 得到类型描述
        /// </summary>
             string GetDescription(string UserType);

        /// <summary>
        /// 获得数据列表
        /// </summary>
            object GetList(string strWhere);
    }
}
