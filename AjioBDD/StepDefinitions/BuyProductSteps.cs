using AjioBDD.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace AjioBDD.StepDefinitions
{
    [Binding]
    public class BuyProductSteps:CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;
        string? label;

        [Given(@"User is on the home page")]
        public void GivenUserIsOnTheHomePage()
        {
            driver.Url = "https://www.ajio.com/shop/women";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the search box")]
        public void WhenUserWillTypeTheInTheSearchBox(string searchtext)
        {
            IWebElement searchBox = driver.FindElement(By.Name("searchVal"));
            searchBox.SendKeys(searchtext);
            searchBox.SendKeys(Keys.Enter);
            Log.Information("Searched" + searchtext);
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            //TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }

        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                IWebElement searchHeading = driver.FindElement(By.XPath("//div[@class='header2']"));
                Assert.That(searchHeading.Text.Contains(searchtext));
                LogTestResult("Heading Test", "Heading Test Success");
                
            }
            catch (AssertionException ex)
            {
                LogTestResult("Heading Test", "Heading Test Failed", ex.Message);
            }
        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string productno)
        {
            IWebElement product = driver.FindElement(By.XPath("//div[@class='contentHolder']/div["+productno+"]"));
            label = product.Text;
            product.Click();
            
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);
            //TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                IWebElement ProductTitle = driver.FindElement(By.XPath("//h1[@class='prod-name']"));
                Assert.That(ProductTitle.Text.Equals(label));
                LogTestResult("Product Test", "Product Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Test", "Product Test Failed", ex.Message);
            }
        }
        [When(@"User selects '([^']*)' and clicks on Add to Cart Button")]
        public void WhenUserSelectsSizeAndClicksOnAddToCartButton(string size)
        {
            IWebElement SelectSize = driver.FindElement(By.XPath("(//div[@role='button'])/span["+size+"]"));
            SelectSize.Click();
            Thread.Sleep(3000);
            IWebElement AddToCartButton = driver.FindElement(By.XPath("(//div[@class='btn-gold'])/span[2]"));
            ScrollIntoView(driver, AddToCartButton);
            //AddToCartButton.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", AddToCartButton);

        }

        [Then(@"The product should be present inside the cart")]
        public void ThenTheProductShouldBePresentInsideTheCart()
        {
            IWebElement CartIcon = driver.FindElement(By.XPath("//a[@href='/cart']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", CartIcon);

            //CartIcon.Click();
            //TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Thread.Sleep(5000);
                IWebElement ProductText = driver.FindElement(By.XPath("(//div[@class='product-name'])/div/a"));
                Assert.That(ProductText.Text.Contains(label));
                LogTestResult("Product Test", "Product Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Test", "Product Test Failed", ex.Message);
            }
        }

        [When(@"User clicks on Proceed to buy button")]
        public void WhenUserClicksOnProceedToBuyButton()
        {
            IWebElement ProceedToBuy = driver.FindElement(By.XPath("//button[@aria-label='Proceed to shipping']"));
            ProceedToBuy.Click();
        }

        [Then(@"The login modal should display")]
        public void ThenTheLoginModalShouldDisplay()
        {
            try
            {

                Assert.IsTrue(driver?.FindElement(By.XPath(
                    "(//div[@class='modal-content'])//following::h1[1]")).Text
                    == "Welcome to AJIO", $"Test failed for Buy Product Test");
                LogTestResult("Login modal Test", "Login modal Test success");

            }
            catch (AssertionException ex)
            {
                LogTestResult("Login modal Test", "Login modal Test Failed", ex.Message);

            }
        }


    }
}
