using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    //this file contains all the locators
    internal class RediffHomePage
    {
        IWebDriver driver;
        public RediffHomePage(IWebDriver? driver) //writing constructor
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this); //pagefactory-it is a collection of all the page elements that are provided inside page class.Initelements-to initiate all the elements in 'this',here this refers to driver.that is,currectnt driver,homepage
        }

        //ARRANGE
        //properties

        [FindsBy(How =How.LinkText,Using = "Create Account")] //how to find create acc element
        public IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")] //FindsBy is an attiribute
        public IWebElement? SignInLink { get; set; }

        //ACT
        //we should write action methods here

        //public void CreateAccountLinkClick()
        //{
        //    CreateAccountLink?.Click();
            
        //}

        //public void SignInLinkClick()
        //{
        //    SignInLink?.Click();
        //}

        public CreateAccountPage CreateAccountClick()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver); //returning createaccountpage object.
        }

        public SignInPage SignInClick()
        {
            SignInLink?.Click();
            return new SignInPage(driver); //returning createaccountpage object.
        }
    }
}
