using Naaptol.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    //this file contains all the locators
    internal class SearchForProducts
    {
        IWebDriver driver;
       public SearchForProducts(IWebDriver? driver)
        {
            this.driver=driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //ARRANGE
        [FindsBy(How = How.Id, Using = "header_search_text")] 
        public IWebElement? SearchBox { get; set; }



        public void SearchBoxClick()
        {
            SearchBox?.Click();
        }

        public SelectProduct SearchBoxType(string product)
        {
            SearchBox?.SendKeys(product);
            SearchBox?.SendKeys(Keys.Enter);

            return new SelectProduct(driver);
            
        }
        
    }
}
