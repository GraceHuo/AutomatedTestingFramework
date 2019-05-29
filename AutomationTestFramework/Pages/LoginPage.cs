using System;
using AutomationTestFramework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestFramework.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "log-in");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "usernameOrEmail");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

       
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string passWord;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.passWord = password;
            return this;
        }

        public void Login()
        {
            // fill in the username
            var usernameOrEmailInput = Driver.Instance.FindElement(By.Id("usernameOrEmail"));
            usernameOrEmailInput.SendKeys(userName);

            // click the 'Continue' button
            var continueButton = Driver.Instance.FindElement(By.XPath("//button[.='Continue']"));
            continueButton.Click();

            // fill in the password
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("password")));
          
            var passwordInput = Driver.Instance.FindElement(By.Id("password"));
            passwordInput.SendKeys(passWord);

            // click the 'Continue' button
            var loginButton = Driver.Instance.FindElement(By.XPath("//button[.='Log In']"));
            loginButton.Click();

            // wait for the page load
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[.='Log In']")));
        }
    }
}
