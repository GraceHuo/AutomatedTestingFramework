using AutomationTestFramework.Selenium;
using OpenQA.Selenium;
using System;

namespace AutomationTestFramework.Pages
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("entry-title"));
                if (title != null)
                {
                    return title.Text;
                }
                return String.Empty;
            }
        }
    }
}
