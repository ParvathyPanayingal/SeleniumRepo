using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTest.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver? driver;

        //[BeforeScenario]
        //public void InitializeBrowser()
        //{
        //    driver = new ChromeDriver();

        //}
        //[AfterScenario]
        //public void CleanupBrowser()
        //{
        //    driver?.Quit();
        //}
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver=new ChromeDriver();
            driver.Url = "https://linkedin.com";
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key")));
            emailInput.SendKeys("abcd@yy.com");


        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found.";

            IWebElement passwordInput = fluentWait.Until(d => driver.FindElement(By.Id("session_password")));
            passwordInput.SendKeys("qw2");
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",
                driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(2000);

            js.ExecuteScript("arguments[0].click();",
                driver.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }

        [Then(@"Error message for password length will be thrown")]
        public void ThenErrorMessageForPasswordLengthWillBeThrown()
        {
            throw new PendingStepException();
        }

    }
}
