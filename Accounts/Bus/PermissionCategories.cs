using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
	/// <summary>
	/// Ȩ�����
	/// </summary>
	public class PermissionCategories
	{

        Data.PermissionCategory dalpc = new Data.PermissionCategory();

        /// <summary>
        /// ���캯��
        /// </summary>
		public PermissionCategories()
		{			
		}

        /// <summary>
        /// ����Ȩ�����
        /// </summary>
		public int Create(string description)
		{
            int pcID = dalpc.Create(description);
			return pcID;
		}
        /// <summary>
        /// ɾ��Ȩ�����
        /// </summary>
		public bool Delete(int pID)
		{
            return dalpc.Delete(pID);			
		}
	}
}
