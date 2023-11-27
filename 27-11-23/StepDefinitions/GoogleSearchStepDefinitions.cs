using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProj.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver? driver;

        [BeforeScenario]
        public void InitializeBrowser()
        {
            driver = new ChromeDriver();
            
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }
        [Given(@"Google home page should be loaded")] //@ indicates for an identification of an attribute
        public void GivenGoogleHomePageShouldBeLoaded() //use the same sentence in the given attribute without whitespace
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""(.*)"" in the search input box")]
        public void WhenTypeInTheSearchInputBox(string searchtext)
        {
            IWebElement searchBox = driver.FindElement(By.Id("APjFqb"));
            searchBox.SendKeys(searchtext);
        }

        [When(@"Click on the google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            //giving fluent wait for async operations
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnK"));
                return searchButton.Displayed ? searchButton : null;
            });
            if(gsb != null)
            {
                gsb.Click();
            }
           
        }

        [Then(@"the results should be displayed on the next page with title ""(.*)""")] //we are not passing data directly so additional double quotes
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver.Title,Is.EqualTo(title));
        }
    }
}
