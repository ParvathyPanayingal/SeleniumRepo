using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SelfExamples
{
    internal class GHTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

        }

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void TitleTest()
        {
            Thread.Sleep(2000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
            Console.WriteLine("title " + driver.Title);
            Console.WriteLine("Title length " + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }

        public void PageSourceandURLTest()
        {
            //Console.WriteLine("PS Len : " + driver.PageSource.Length);
            //Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Page source and url test - Pass");

        }

        public void GoogleSearchTest()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("hp laptops"); //to type inside the text box
            Thread.Sleep(2000);
            IWebElement googleSearchButton = driver.FindElement(By.Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
        }

        public void Destruct()
        {
            driver.Close();

        }
    }
}
