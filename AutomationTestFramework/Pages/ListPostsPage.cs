using AutomationTestFramework.Navigation;
using AutomationTestFramework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutomationTestFramework.Pages
{
    public class ListPostsPage
    {
        private static int lastCount;

        public static int PreviousPostCount
        {
            get
            {
                return lastCount;
            }
        }

        public static int CurrentPostCount
        {
            get
            {
                return GetPostCount();
            }
        }

        public static bool IsAt
        {
            get
            {
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                {
                    return h2s[0].Text == "Posts";
                }
                return false;
            }
        }
        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "read/feeds/96134327");
                    break;
                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    if (!IsAt)
                    {
                        // Log the error and stop the tests
                        // Error.Log("Did not navigate to all posts!");
                    }
                    break;
            }

        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText(title));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("dispaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                if (links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }
            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
