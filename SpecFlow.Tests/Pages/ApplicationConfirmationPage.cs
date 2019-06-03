using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecFlowPlay.Tests
{
    public class ApplicationConfirmationPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstName;

        public ApplicationConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string FirstName
        {
            get
            {
                return _firstName.Text; // As an example of decoraor
            }
        }

        public string ErrorText
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li")).Text;
            }
        }
    }
}