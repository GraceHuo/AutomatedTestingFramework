using OpenQA.Selenium;

namespace SpecFlowPlay.Tests
{
    public class SampleApplicationPage
    {
        private readonly IWebDriver _driver;
        private const string PageUrl = @"http://localhost:3000/Home";

        public SampleApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static SampleApplicationPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrl);
            return new SampleApplicationPage(driver);
        }

        public string FirstName
        {
            set
            {
                _driver.FindElement(By.Id("firstName")).SendKeys(value);
            }
        }

        public string LastName
        {
            set
            {
                _driver.FindElement(By.Id("lastName")).SendKeys(value);
            }
        }

        public string ErrorText
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li")).Text;
            }
        }

        public void SelectExistingLoan()
        {
            _driver.FindElement(By.Id("Loan")).Click();
        }

        public void AcceptTermsAndConditions()
        {
            _driver.FindElement(By.Name("TermsAcceptance")).Click();
        }

        public ApplicationConfirmationPage SubmitApplication()
        {
            _driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            return new ApplicationConfirmationPage(_driver);
        }
    }
}
