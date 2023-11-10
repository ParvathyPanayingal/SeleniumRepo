
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNunitEx
{
    public class Tests
    {
        IWebDriver driver; //initialising here because driver is used by other methods also.
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
        }

        [Test]
        public void CheckForTitle()
        {
              
            Thread.Sleep(2000);
            string title = driver.Title;
            Assert.AreEqual("Google", title); //used like if condition
        }
        [TearDown] 
        public void TearDown()
        {
            driver.Close();  //closing should be written seperately.

        }
    }
}