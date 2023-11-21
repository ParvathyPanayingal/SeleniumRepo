using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class ActionEvents:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homeLink=driver.FindElement(By.LinkText("Home"));
            IWebElement tdHomeLink = driver.FindElement(By.XPath
                ("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            
            Actions actions = new Actions(driver); //actions creation.with this we can imitate any action
            Action mouseOverAction = ()=> actions.MoveToElement(homeLink)
            .Build().Perform(); //build will generate that action sequence one after the other.

            Thread.Sleep(3000);
            Console.WriteLine("Before:" + tdHomeLink.GetCssValue("background-color"));
            mouseOverAction.Invoke();

            Console.WriteLine("After:" + tdHomeLink.GetCssValue("background-color"));

           
        
        }
        [Test]
        public void MultipleActionsTest()
        {
            driver.Navigate().GoToUrl("https://in.linkedin.com/");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); //checks in every 50ms
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //similar exceptions will also be ignored.
            fluentWait.Message = "Element not found.";

            IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key")));

            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions.KeyDown(Keys.Shift)
            .SendKeys(emailInput,"hello")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();

            upperCaseInput.Invoke();
            Console.WriteLine("Text is :" + emailInput.GetAttribute("value"));
            Thread.Sleep(3000);
        }
    }
}
