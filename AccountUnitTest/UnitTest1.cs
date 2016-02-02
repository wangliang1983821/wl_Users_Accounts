using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wl_Accounts.Model;

namespace AccountUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            int i=   ip.Create(1, "test");
            Console.WriteLine(i);
        }

        [TestMethod]
        public void Update()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            bool i = ip.Update(75, "update");
            Console.WriteLine(i.ToString());
        }

        [TestMethod]
        public void Delete()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            bool i = ip.Delete(80);
            Console.WriteLine(i.ToString());
        }

        [TestMethod]
        public void Retrieve()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            AccountsPermissions ap = ip.Retrieve(1) as AccountsPermissions;
            Console.WriteLine(ap.Description);
        }

        [TestMethod]
        public void GetPermissionList()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            List<AccountsPermissions> ap = ip.GetPermissionList(1) as List<AccountsPermissions>;
            Console.WriteLine(ap.Count);
        }

        [TestMethod]
        public void GetNoPermissionList()
        {
            wl_Accounts.Data.IPermission ip = new wl_Accounts.Data.Permission();

            List<AccountsPermissions> ap = ip.GetNoPermissionList(1) as List<AccountsPermissions>;
            Console.WriteLine(ap.Count);
        }
    }
}
