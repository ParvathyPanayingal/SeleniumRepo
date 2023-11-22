using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver? driver;
        public CreateAccountPage(IWebDriver driver) //writing constructor
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); //pagefactory-it is a collection of all the page elements that are provided inside page class.Initelements-to initiate all the elements in 'this',here this refers to driver.that is,currectnt driver,homepage
        }

        //ARRANGE
        //properties

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'name')")] 
        public IWebElement? FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')")]
        public IWebElement? RediffMailText { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkavail')")]
        public IWebElement? CheckAvailablilityBtn { get; set; }
        [FindsBy(How =How.Id,Using ="Register")]
        public IWebElement? CreateMyAccountButton { get; set; }

        //ACT

        public void FullNameSendData(string fullName)
        {
            FullNameText?.SendKeys(fullName);
        }

        public void RediffMailSendData(string email)
        {
            RediffMailText?.SendKeys(email);
        }

        public void CheckAvailabilityBtnClick()
        {
            CheckAvailablilityBtn?.Click();
        }
        public void CreateMyAccountButtonClick()
        {
            CreateMyAccountButton?.Click();
        }

        public void FullNameClear()
        {
            FullNameText?.Clear();
        }

        public void RediffMailClear()
        {
            RediffMailText?.Clear();
        }

    }
}
