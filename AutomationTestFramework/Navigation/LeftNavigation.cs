using AutomationTestFramework.Selenium;
using OpenQA.Selenium;

namespace AutomationTestFramework.Navigation
{
    public class LeftNavigation
    {
        public class Tools
        {
            public class Activity
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-tools", "Activity");
                }
            }
        }

        public class Posts
        {
            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "All Posts");
                }
            }
        }
    }

    internal class MenuSelector
    {
        public static void Select(string topLevelMenuId, string subMenuLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
            Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
        }
    }
}
