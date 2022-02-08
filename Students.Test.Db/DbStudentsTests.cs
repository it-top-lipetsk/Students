using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.DB_Lib;
using Students.Model;

namespace Students.Test.Db
{
    [TestClass]
    public class DbStudentsTests
    {
        [TestMethod]
        public void TestTabAccount()
        {
            var db = new DbStudents();
            var tabAccounts_actual = db.TabAccounts.ToList();
            var tabAccounts_expected = new List<Account>
            {
                new() {Id = 1, Login = "student", Password = "123", IsActive = true},
                new() {Id = 2, Login = "teacher", Password = "123", IsActive = true},
                new() {Id = 3, Login = "admin", Password = "123", IsActive = true}
            };

            for (int i = 0; i < 3; i++)
            {
                //Assert.AreEqual<Account>(tabAccounts_expected[i], tabAccounts_actual[i]);
                var e = tabAccounts_expected[i];
                var a = tabAccounts_actual[i];
                Assert.AreEqual(e.Id, a.Id);
                Assert.AreEqual(e.Login, a.Login);
                Assert.AreEqual(e.Password, a.Password);
                Assert.AreEqual(e.IsActive, a.IsActive);
            }
        }
    }
}