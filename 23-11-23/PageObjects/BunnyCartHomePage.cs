using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver driver;
        public BunnyCartHomePage(IWebDriver? driver)
        {
            this.driver=driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id,Using ="search")]
        [CacheLookup] //will  store the particular element to the cache of the pagefactory so that it will be really fast.This element will not be searched again and again.Initelements will save element in a static way so that it will not be reinitialized again and again.

        private IWebElement? SearchInput { get; set; } //to restrict the use outside the class we are making it private

        [FindsBy(How =How.XPath,Using = "//a[text()='Create an Account']")]
        private IWebElement? CreateAccLink { get; set;}

        [FindsBy(How =How.Id,Using = "firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "popup-email_address")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }
        
        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }
        
        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account'")]
        private IWebElement? CreateAccountButton { get; set; }

        public void CreateAccLinkClick() //for clikcing only.Methods are public since we are calling this from testpage.
        {
            CreateAccLink.Click();
        }

        public void SignUp(string firstName,string lastName,string email,string pswd,string cnfmPswd,string mobilenmbr) //after clicking on create acc signing up
        {
            //calling all the properties from here beacuse it is private.
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstNameInput?.SendKeys(firstName);
            LastNameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, PasswordInput);
            PasswordInput?.SendKeys(pswd);
            ConfirmPasswordInput?.SendKeys(cnfmPswd);

            CoreCodes.ScrollIntoView(driver, MobileNumberInput);
            MobileNumberInput?.SendKeys(mobilenmbr);
            Thread.Sleep(2000);
            CreateAccountButton?.Click();

        }

        

        public SearchResultsPage TypeSearchInput(string searchText)
        {
            if(SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchText);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
