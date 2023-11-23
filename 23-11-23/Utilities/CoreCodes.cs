using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart
{
    internal class CoreCodes
    {

        Dictionary<string, string>? properties;
        public IWebDriver? driver; //Use of Iwebdriver interface instead of webdriver class -We can choose webdriver

        public void ReadConfigSettings()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName; //taking dirctory of config file from working directory.

            properties = new Dictionary<string, string>(); //creating instance of dictionary
            string fileName = currentDirectory + "/Configsettings/config.properties";
            string[] lines=File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts=line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }

        public void TakeScreenshot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver; //ITakeScreenshot is the interface for taking screenshot
            Screenshot ss = ts.GetScreenshot(); //GetScreenshot is the method for taking screenshot

            string currentDirectory = Directory.GetParent(@"../../../").FullName; //storing our current directory in a string.
            string filePath = currentDirectory + "/Screenshots/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png"; //filepath of screenshot
            ss.SaveAsFile(filePath); //file will be saved with the specified file name format.
        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }

        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);//system.net is the namespace and httpwebrequest is the class.

                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [OneTimeSetUp] //this method will be executed initially.

        public void InitializeBrowser() 
        {
            ReadConfigSettings();
            
                if (properties ["browser"].ToLower() == "chrome")
                {
                    driver=new ChromeDriver();
                }
                else if (properties["browser"].ToLower() == "edge")
                {
                    driver = new EdgeDriver();
                }
                driver.Url = properties["baseUrl"];
                driver.Manage().Window.Maximize();
            
        }

        [OneTimeTearDown]
        public void Destruct() 
        {
           driver.Quit();
        }

    }
}
