using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BunnyCart.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;


        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();

        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }
        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com");
        }
        
    }
}