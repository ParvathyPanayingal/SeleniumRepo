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
    internal class SearchTests:CoreCodes
    {
        [Test]
        public void CreateAccountTest()
        {
            BunnyCartHomePage bchp = new(driver);

            bchp.CreateAccLinkClick();
            Thread.Sleep(2000);

            Assert.That(driver?.FindElement(By.XPath("//div[" +
                "@class='modal-inner-wrap']//following::h1[2]")).Text,
                Is.EqualTo("Create an Account"));

            try
            {
                Assert.That(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));
                test = extent.CreateTest("Create Account Link Test - Pass");
                test.Pass("Create Account Link success");
                Console.WriteLine("ERCP");
            }
            catch
            {
                test = extent.CreateTest("Create Account Link Test - Fail");
                test.Fail("Create Account Link failed");
                Console.WriteLine("ERCF");
            }


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);

            }

        }

    }
}

