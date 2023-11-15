using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SelfExamples
{
    internal class AmazonTests
    {
        IWebDriver? driver;


        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }

        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();

        }

        public void TitleTest()
        {
            Thread.Sleep(2000); 
            Console.WriteLine("title" + driver.Title);
            Console.WriteLine("Titile length " + driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - Pass");
        }

        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo test - Pass");

        }

        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title)) && (driver.Url.Contains("mobiles")));
            Console.WriteLine("Search Product test - Pass");

        }

        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            Thread.Sleep(3000);
        }

        public void TodaysDealsTest()
        {
            IWebElement todaysDeals= driver.FindElement(By.LinkText("Today's Deals"));
        if (todaysDeals == null)
            {
                throw new NoSuchElementException("Today's Deals Link not present");
            }

            todaysDeals.Click();
           Assert.That( driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("Today's Deals test - Pass");

        }

        public void SignInAccListTest()
        {
            IWebElement helloSignIn= driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if (helloSignIn == null)
            {
                throw new NoSuchElementException("Hello,sign in not present");
            }
            IWebElement accAndList = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span")); //back slash with double quotes or single quotes alone can be used.
            if(accAndList == null)
            {
                throw new NoSuchElementException("Accounts and lists not present");

            }
            Assert.That(helloSignIn.Text.Equals("Hello, sign in") );
            Console.WriteLine("Hello sign in test -Pass");
            Assert.That(accAndList.Text.Equals("Account & Lists"));
            Console.WriteLine("Accounts & lists -Pass");
        }

        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Motorola is selected");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click(); //clicking see more
            driver.FindElement(By.XPath("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/i")).Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/input")).Selected); 
            Console.WriteLine("Xiaomi is selected.");
        }

        public void SortBySelectTest()
        {
          IWebElement sortBy=  driver.FindElement(By.ClassName("a-native-dropdown.a-declarative"));
            SelectElement sortBySelect = (SelectElement)sortBy;
            sortBySelect.SelectByValue("1");
            Thread.Sleep(5000);
            Console.WriteLine(sortBySelect.SelectedOption);
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
