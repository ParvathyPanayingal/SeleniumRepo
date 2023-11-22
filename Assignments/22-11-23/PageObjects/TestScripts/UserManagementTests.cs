//using Naaptol.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Naaptol.TestScripts
//{
//    [TestFixture]

//    internal class UserManagementTests : CoreCodes
//    {
//        //ASSERT
//        //[Order(0)]
//        //[Test]
//        //[Category("Smoke Test")]
//        //[Ignore("running other test")]

//        //public void CreateAccLinkTest()
//        //{
//        //    var homePage = new RediffHomePage(driver); //we cannot inherit rediffhomepage since we already nherited core codes.so we create object of rediffhomepage.the rediffhomepage constructor call all the properties ot to initialise all the webelements in rediffhomepage.
//        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
//        //    homePage.CreateAccountLinkClick(); //with that object we are calling the create acc method 
//        //    Assert.That(driver.Url.Contains("register"));
//        //}

//        //[Order(1)]
//        //[Test]
//        //[Category("Smoke Test")]
//        //[Ignore("running other test")]

//        //public void SignInLinkTest()
//        //{
//        //    var homePage = new RediffHomePage(driver);
//        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
//        //    homePage.SignInLinkClick(); 
//        //    Assert.That(driver.Url.Contains("login.cgi"));
//        //}

//        // [Order(2)]
//        //[Test]
//        //[Category("Regression test")] //end to end test
//        //public void CreateAccFunctionalityTest()
//        //{
//        //    var homePage = new RediffHomePage(driver);
//        //    if (!driver.Url.Equals("https://www.rediff.com/"))
//        //    {
//        //        driver.Navigate().GoToUrl("https://www.rediff.com/");

//        //    }
//        //   var createAccPage = homePage.CreateAccountClick();//page object for create acc page
//        //    Thread.Sleep(3000);
//        //    createAccPage.FullNameSendData("aaa");
//        //    createAccPage.RediffMailSendData("bbb@gg.com");
//        //    createAccPage.CheckAvailabilityBtnClick();
//        //    Thread.Sleep(3000);
//        //    createAccPage.CreateMyAccountButtonClick();

//        //}

//        [Test, Order(2)]
//        [Category("Regression test")]
//        public void SignInTest()
//        {
//            var homePage = new SearchForProducts(driver);
//            if (!driver.Url.Equals("https://www.rediff.com/"))
//            {
//                driver.Navigate().GoToUrl("https://www.rediff.com/");

//            }
//            var signInpage = homePage.SignInClick();
//            Thread.Sleep(3000);
//            signInpage.TypeUserName("aaaa");
//            signInpage.TypePassword("bbbb");
//            signInpage.ClickRememberMeChkBox();
//            Assert.False(signInpage?.RememberMeCheckBox?.Selected);
//            Thread.Sleep(3000);
//            signInpage?.ClickSignInButton();

//            Assert.True(true);
//        }
//    }
//}
