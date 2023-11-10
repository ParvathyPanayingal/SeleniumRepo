
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver= new ChromeDriver(); //browser will open automatically
driver.Url= "https://www.google.com/";  //to type
Thread.Sleep(2000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
string title = driver.Title;
try
{
    Assert.AreEqual("Google", title);
    Console.WriteLine("Pass");
}
catch(AssertionException)
{
    Console.WriteLine("Fail");
}
driver.Close();