using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowPlay.Tests
{
    [Binding]
    public class SampleApplicationSteps
    {
        private IWebDriver _driver;
        private SampleApplicationPage _sampleApplicationPage;
        private ApplicationConfirmationPage _applicationConfirmationPage;

        [Given(@"I am on the loan application screen")]
        public void GivenIAmOnTheLoanApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

            // _driver.Navigate().GoToUrl("http://localhost:3000/startApplication");
            _sampleApplicationPage = SampleApplicationPage.NavigateTo(_driver);
        }

        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            // IWebElement firstNameInput = _driver.FindElement(By.Id("firstName"));
            // firstNameInput.SendKeys(firstName);
            _sampleApplicationPage.FirstName = firstName;
        }

        [Given(@"I endter a family name of (.*)")]
        public void GivenIEndterAFamilyNameOfTest(string lastName)
        {
            // IWebElement lastNameInput = _driver.FindElement(By.Id("lastName"));
            // lastNameInput.SendKeys(lastName);
            _sampleApplicationPage.LastName = lastName;
        }

        [Given(@"I select that I have an existing loan account")]
        public void GivenISelectThatIHaveAnExistingLoanAccount()
        {
            // _driver.FindElement(By.Id("radioChoice1")).Click();
            _sampleApplicationPage.SelectExistingLoan();
        }

        [Given(@"I confirm my acceptance of the tems and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTemsAndConditions()
        {
            // _driver.FindElement(By.Id("checkbox")).Click();
            _sampleApplicationPage.AcceptTermsAndConditions();
        }

        [When(@"I submit my application")]
        public void WhenISubmitMyApplication()
        {
            // _driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            _applicationConfirmationPage = _sampleApplicationPage.SubmitApplication();
        }

        [Then(@"I should see the application complete confirmation for Grace")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForGrace()
        {
            // IWebElement confirmationNameSpan = _driver.FindElement(By.Id("firstName"));
            // string confirmationName = confirmationNameSpan.Text;
            Assert.Equal("Grace", _applicationConfirmationPage.FirstName);
        }

        [Then(@"I should see an error message telling me I mush accept the terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMushAcceptTheTermsAndConditions()
        {
            // IWebElement errorElement = _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li"));
            Assert.Equal("You must accept the terms and conditions", _applicationConfirmationPage.ErrorText);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
