using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunitEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitAssignment
{
    internal class FlipkartTests:CoreCodes
    {
        [Test]
        [Description("Check for search box")]
        public void SearchBoxTest()
        {
            

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            driver.FindElement(By.XPath("/html/body/div[3]/div/span")).Click();
            IWebElement searchlInput = fluentWait.Until(d => driver.FindElement(By.ClassName("Pke_EE")));
            searchlInput.SendKeys("laptops");
            searchlInput.SendKeys(Keys.Enter);

                     
        }
    }
}
