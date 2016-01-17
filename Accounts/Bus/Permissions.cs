using System;
using System.Data;
using System.Configuration;

namespace LTP.Accounts.Bus
{
	/// <summary>
	/// Ȩ�޹���
	/// </summary>
    [Serializable]
	public class Permissions
	{
        Data.Permission dalPermission = new Data.Permission();

        /// <summary>
        /// ���캯��
        /// </summary>
		public Permissions()
		{			
		}

		/// <summary>
		/// ����һ��Ȩ��
		/// </summary>
		/// <param name="pcID">���ID</param>
		/// <param name="description">Ȩ������</param>
		/// <returns></returns>
		public int Create(int pcID,string description)
		{			
			int pID = dalPermission.Create(pcID,description);
			return pID;
		}
		/// <summary>
		/// ����Ȩ��
		/// </summary>
		/// <param name="pcID">Ȩ��ID</param>
		/// <param name="description">Ȩ������</param>
		/// <returns></returns>
		public bool Update(int pcID,string description)
		{			
			return dalPermission.Update(pcID,description);			
		}

		/// <summary>
		/// ɾ��Ȩ��
		/// </summary>
		/// <param name="pID"></param>
		/// <returns></returns>
		public bool Delete(int pID)
		{
			return dalPermission.Delete( pID );			
		}
		/// <summary>
		/// �õ�Ȩ������
		/// </summary>
		/// <param name="pID"></param>
		/// <returns></returns>
		public string GetPermissionName(int pID)
		{
			return dalPermission.Retrieve(pID)["Description"].ToString();
		}
	}
}
