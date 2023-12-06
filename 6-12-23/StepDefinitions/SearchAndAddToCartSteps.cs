using BunnyCart.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps:CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;

        string? label;

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string productno)
        {
           IWebElement product= driver.FindElement(By.XPath("//div[@id='amasty-shopby-product-list']/div[2]/ol/li[1]/div/div[2]/strong/a["+productno+"]"));
            label = product.Text;
            product.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Equals(label));
                LogTestResult("Product Test", "Product Test success");

            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Test", "Product Test Failed", ex.Message);

            }
        }
       
    }
}
