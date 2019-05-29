using AutomationTestFramework.Pages;
using AutomationTestFramework.Selenium;
using AutomationTestFramework.Workflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests
{
    public class BasicTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            PostCreator.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("GraceHuo0403")
                .WithPassword("GraceTest345")
                .Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();

            // Driver.Close();
        }
    }
}
