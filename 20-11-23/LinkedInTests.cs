using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class LinkedInTests:CoreCodes
    {
        //we can give all the annotations in the same line also.But not description.
        [Test]
        [Author("Parvathy","parvathy@gmail.com")] //name and email of the author
        [Description("Check for valid login")]
        [Category("Regression testing")]
        public void LogInTest()
        {
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3); //implicit wait-works similar to explicit wait
            //WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10)); //explicit wait

            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key"))); //old format
            //IWebElement passwordInput=wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));

            //IWebElement emailInput = wait.Until(d=>driver.FindElement(By.Id("session_key"))); // in new format we don't use expected condition
            //IWebElement passwordInput = wait.Until(d=>driver.FindElement(By.Id("session_password")));

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); //checks in every 50ms
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //similar exceptions will also be ignored.
            fluentWait.Message = "Element not found.";
            
            IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key"))); 
            IWebElement passwordInput = fluentWait.Until(d=>driver.FindElement(By.Id("session_password")));
            emailInput.SendKeys("abcd@yy.com");
            passwordInput.SendKeys("qwerrty#12");

        }

        //incorrect way of writing code because of hardcoding.
        //[Test]
        //[Author("Parvathy", "parvathy@gmail.com")] //name and email of the author
        //[Description("Check for invalid login")]
        //[Category("Smoke testing")]

        //public void LogInTestWithInvalidData()
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); //checks in every 50ms
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //similar exceptions will also be ignored.
        //    fluentWait.Message = "Element not found.";

        //    IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => driver.FindElement(By.Id("session_password")));
        //    emailInput.SendKeys("qwerrte@yy.com");
        //    passwordInput.SendKeys("qwerrty#12");
        //    Thread.Sleep(3000);

        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //    emailInput.SendKeys("fhgjgjg@yy.com");
        //    passwordInput.SendKeys("123");
        //    Thread.Sleep(3000);

        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //    emailInput.SendKeys("poiue@yy.com");
        //    passwordInput.SendKeys("1223");
        //    Thread.Sleep(3000);

        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //    Thread.Sleep(3000);

        //}

        void clearForm(IWebElement element)
        {
            element.Clear();
        }


        //passing multiple data without hardcoding
        //This method is called parameterized testcase
        //But not practical to write n number of testcase 
        //[Test]
        //[Author("abc", "abc@gmail.com")] //name and email of the author
        //[Description("Check for invalid login")]
        //[Category("Regression testing")]
        //[TestCase("qwerty@yy.com","aaa!11")]
        //[TestCase("asdfg@xx.com", "111")]
        //[TestCase("zxcvvb@zz.com", "bbb")]

        //public void LogInTestWithInvalidCred(string email,string password)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); //checks in every 50ms
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //similar exceptions will also be ignored.
        //    fluentWait.Message = "Element not found.";

        //    IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => driver.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys(email); 
        //    passwordInput.SendKeys(password);
        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //}


        //Another way of writing parameterized test
        [Test]
        [Author("abc", "abc@gmail.com")] //name and email of the author
        [Description("Check for invalid login")]
        [Category("Regression testing")]
        [TestCaseSource(nameof(invalidLoginData))]

        public void LogInTestWithInvalidCred(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); //checks in every 50ms
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //similar exceptions will also be ignored.
            fluentWait.Message = "Element not found.";

            IWebElement emailInput = fluentWait.Until(d => driver.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => driver.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            clearForm(emailInput);
            clearForm(passwordInput);

        }

        static object[] invalidLoginData()
        {
            return new object[]
            {
                new object[] {"qwerty@yy.com","aaa!11"},
                new object[] {"asdfg@xx.com","22323"},
                new object[] {"zxcvbg@zz.com","vvbbb"}
            };
        }
    }
}
