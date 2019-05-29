using AutomationTestFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests
{
    [TestClass]
    public class PageTests : BasicTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("TestPage1");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("TestPage1", NewPostPage.Title, "Title did not match");
        }
    }
}
