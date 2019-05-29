using AutomationTestFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests
{
    [TestClass]
    public class LoginTests : BasicTest
    {
        [TestMethod]
        public void User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Fail to login.");
        }
    }
}
