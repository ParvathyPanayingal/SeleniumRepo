using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitAssignment;
using OpenQA.Selenium.Interactions;

namespace NunitAssignment
{
    internal class NaaptolTests:CoreCodes
    {
        [Order(10)]
        [Test]

        public void SearchBoxTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found.";

            IWebElement searchlInput = fluentWait.Until(d => driver.FindElement(By.Id("header_search_text")));
            searchlInput.SendKeys("eyewear");
            searchlInput.SendKeys(Keys.Enter);
            Assert.That( driver.Url.Contains("eyewear"));
            Thread.Sleep(2000);
        }

        [Order(11)]

        [Test]
        [TestCase(5)]

        public void selectFifthProductTest(int pid) { 

            string path = "//*[@id=\"productItem" + pid + "\"]";
            IWebElement productFive=driver.FindElement(By.XPath(path));
            Actions actions = new Actions(driver);
            Action selectProductAction = () => actions.MoveToElement(productFive)
            .Click()
            .Build()
            .Perform();

            selectProductAction.Invoke();

            List<string> listWindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(listWindow[1]);
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights"));

            Thread.Sleep(2000);
        }

        [Order(12)]

        [Test]
        public void addingProductToCartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            IWebElement path = driver.FindElement(By.LinkText("Black-3.00"));

            Actions actions = new Actions(driver);
            Action selectingSize = () => actions.MoveToElement(path).Click()
            .Build()
            .Perform();

            selectingSize.Invoke();

            IWebElement buttonPath= driver.FindElement(By.XPath("//*[@id=\"cart-panel-button-0\"]/span"));
            Action addingToCart = () => actions.MoveToElement(buttonPath).Click()
            .Build()
            .Perform();
            addingToCart.Invoke();
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
            Thread.Sleep(3000);
        }


        [Order(13)]

        [Test]
        public void viewShoppingCartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found.";

           // IWebElement shoppingCart =driver.FindElement(By.Id("shopCartHead"));
            //Assert.That(shoppingCart.Text == "My Shopping Cart: At present, you have (1) items.");

            IWebElement closeButton = driver.FindElement(By.XPath("/html/body/div[5]/div/a"));
            Actions actions = new Actions(driver);
            Action addingToCart = () => actions.MoveToElement(closeButton).Click()
            .Build() .Perform();
            addingToCart.Invoke();
            Thread.Sleep(2000);
            Destruct();
        }
    }
}

