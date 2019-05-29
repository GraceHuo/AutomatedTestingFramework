using AutomationTestFramework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTestFramework.Pages
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            var newPostButton = Driver.Instance.FindElement(By.CssSelector("[href*='/post/gracetest.home.blog']"));
            newPostButton.Click();

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("is-iframe-loaded")));

        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GotoNewPost()
        {

            var notifications = Driver.Instance.FindElement(By.ClassName("components-notice__content"));
            var newPostLink = notifications.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.ClassName("post-edit-button__label")) != null;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("reader-full-post__header-title-link"));
                if (title != null)
                {
                    return title.Text;
                }
                return string.Empty;
            }
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;
        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            var iframe = Driver.Instance.FindElement(By.ClassName("is-iframe-loaded"));
            Driver.Instance.SwitchTo().Frame(iframe);
            Driver.Instance.FindElement(By.ClassName("editor-post-title__input")).SendKeys(title); 
            Driver.Instance.FindElement(By.ClassName("block-editor-rich-text__editable")).SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            var publishButton = Driver.Instance.FindElement(By.XPath("//button[.='Publish...']"));
            publishButton.Click();
            var publishButton2 = Driver.Instance.FindElement(By.XPath("//button[.='Publish...']"));
            publishButton2.Click();
        }
    }
}
