using AutomationTestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests
{
    [TestClass]
    public class CreatePostTests : BasicTest
    {
        /*
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            NewPostPage.GoTo();

            NewPostPage.CreatePost("This is the title")
                .WithBody("Hi This is body.")
                .Publish();

            NewPostPage.GotoNewPost();
            Assert.AreEqual(PostPage.Title, "This is the title", "Title did not match new post.");
        }
        */
    }
}
