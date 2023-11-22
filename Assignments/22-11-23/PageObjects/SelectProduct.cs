using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class SelectProduct
    {
        IWebDriver driver;
        public SelectProduct(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "productItem5")]
        public IWebElement? SelectproductFive { get; set; }


        [FindsBy(How = How.LinkText, Using = "Black-3.00")]
        public IWebElement? SelectSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"cart-panel-button-0\"]/span")]
        public IWebElement? ClickHereToBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cartData']/li[1]/div[2]/h2/a")]
        public IWebElement? CartItem { get; set; }


        public void productClick()
        {
            SelectproductFive?.Click();
        }
        public void sizeClick()
        {
            SelectSize?.Click();
        }

        public void ClickHereToBuyBtnClick()
        {
            ClickHereToBuyBtn?.Click();
        }

        public string? GetCartItemUrl()
        {
            return CartItem?.GetAttribute("href");
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }
    }
}
