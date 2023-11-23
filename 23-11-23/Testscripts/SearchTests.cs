using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Testscripts
{
    [TestFixture]
    internal class SearchTests:CoreCodes
    {
        [Test]
        [TestCase("Water ")]

        public void SearchProductAndAddToCartTest(string searchtext)
        {
            BunnyCartHomePage bchp = new(driver);
            var searchresultpage = bchp?.TypeSearchInput(searchtext);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\'amasty-shopby-product-list\']/div[2]/ol/li[1]")));
            Thread.Sleep(5000);
            //Assert.That(searchtext.Contains(searchresultpage?.GetFirstProductLink()));
            var productpage = searchresultpage?.ClickFirstProductLink();
            //Assert.That(searchtext.Equals(productpage?.GetProductTitleLable()));
            productpage?.ClickIntQtyLink();
            productpage?.ClickAddToCartBtn();
            Thread.Sleep(5000);
        }
    }
}
