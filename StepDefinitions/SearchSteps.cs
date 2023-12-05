using BunnyCart.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchSteps:CoreCodes
    {
        IWebDriver driver = BeforeHooks.driver;
        
        [Given(@"User will be on the home page")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the search box")]
        public void WhenUserWillTypeTheIntHeSearchBox(string searchtext)
        {
            IWebElement searchInput = driver.FindElement(By.Id("search"));
            searchInput.SendKeys(searchtext);
            searchInput.SendKeys(Keys.Enter);
        }


        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            TakeScreenShot(driver);
            try
            {
                Thread.Sleep(2000);
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test success");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed",ex.Message);
            }


        }
    }
}
