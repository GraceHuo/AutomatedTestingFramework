using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace SpecFlowPlay.Tests
{
    public class SampleApplicationTests
    {
        //[Fact]
        public void StartApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:3000/");

                IWebElement applicationButton = driver.FindElement(By.Id("startApplication"));
                applicationButton.Click();

                Assert.Equal("Start Application", driver.Title);
            }
        }

        //[Fact]
        public void SubmitApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:3000/startApplication");

                IWebElement firstNameInput = driver.FindElement(By.Id("firstName"));
                firstNameInput.SendKeys("Grace");

                IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
                lastNameInput.SendKeys("Test");

                driver.FindElement(By.Id("radioChoice1")).Click();

                driver.FindElement(By.Id("checkbox")).Click();

                driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();

                IWebElement confirmationNameSpan = driver.FindElement(By.Id("firstName"));

                Assert.Equal("Grace", confirmationNameSpan.Text);
            }
        }
    }
}
