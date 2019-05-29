using AutomationTestFramework.Pages;
using AutomationTestFramework.Workflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests.PostsTests
{
    [TestClass]
    class AllPostsTests : BasicTest
    {
        // Added posts show up in all posts
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            // Add a new post
            PostCreator.CreatePost();

            // Go to posts, get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // Check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle), "Post title is wrong");

            // Trash post (clean up): leave it here for tesing TrashPost
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Counldn't trash the post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create a new post
            PostCreator.CreatePost();

            // Go to list posts: handled in ListPostsPage.SearchForPost

            // Search for post
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            // Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
