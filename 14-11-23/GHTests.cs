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
        

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

        }

        public void TitleTest()
        {
            Thread.Sleep(2000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
            Console.WriteLine("title" + driver.Title);
            Console.WriteLine("Titile length " + driver.Title.Length);
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
            Thread.Sleep(5000);
            //IWebElement googleSearchButton = driver.FindElement(By.Name("btnK"));
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));

            googleSearchButton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
        }

        public void GmailLinkTest()
        {
            // driver.FindElement(By.LinkText("Gmail")).Click(); //not need of iwebdriver since we are not using it again.
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("gmail")); //if we don't know what we will get then use 'that'.
            Console.WriteLine("Gmail link -Pass");
;        }

        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Images")); //if we don't know what we will get then use 'that'.
            Console.WriteLine("Image link -Pass");
            ;
        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(1000);
            Assert.That(loc.Equals("India")); 
            Console.WriteLine("Localization -Pass");
            ;
        }

        public void GAppYoutube()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName(""));
            Thread.Sleep(3000);
            Assert.That("Youtube".Equals(driver.Title));

        }

        public void Destruct()
        {
            driver.Close();

        }
    }
}
