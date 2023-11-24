using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Testscripts
{
    [TestFixture]
    internal class BunnyCartTests:CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BunnyCartHomePage bchp = new(driver);

            bchp.CreateAccLinkClick();
            Thread.Sleep(2000);

            string currentDirectory = Directory.GetParent(@"../../../").FullName; //taking dirctory of config file from working directory.
            string excelFilePath = currentDirectory + "/TestData/InputData.xlsx";
            string? sheetname = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath,sheetname);








            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));

                bchp.SignUp("john", "Doe", "Johndoe@xample.com", "12345", "12345", "9009009009");
            }
            catch
            {
                Console.WriteLine("Create acc modal not present");
            }
        }

        
    }
}
