using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class SignInPage
    {

        IWebDriver driver;
        public SignInPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login1")]
        public IWebElement? UserNameText { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? PasswordText { get; set; }

        [FindsBy(How = How.Name, Using = "remember")]
        public IWebElement? RememberMeCheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "proceed")]
        public IWebElement? SignInButton { get; set; }


        public void TypeUserName(string userName)
        {
            UserNameText?.SendKeys(userName);
        }

        public void TypePassword(string password)
        {
            PasswordText?.SendKeys(password);
        }

        public void ClickRememberMeChkBox()
        {
            RememberMeCheckBox?.Click();
        }

        public void ClickSignInButton()
        {
            SignInButton?.Click();
        }
    }
}
