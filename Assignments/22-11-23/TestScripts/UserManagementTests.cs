using Naaptol.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.TestScripts
{
    [TestFixture]

    internal class UserManagementTests:CoreCodes
    {
        

        [Test,Order(2)]
        [Category("Regression test")] 
        public void SearchBoxTest()
        {
            var searchforProduct = new SearchForProducts(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");

            }
            searchforProduct?.SearchBoxClick();
            searchforProduct?.SearchBoxType("eyewear");

            Assert.True(true);
        }


        [Test, Order(3)]
        [Category("Regression test")]
        public void AddingProductToCart()
        {

            var selectFifthProduct = new SelectProduct(driver);
            selectFifthProduct.productClick();
            List<string> listWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(listWindows[1]);

            selectFifthProduct?.sizeClick();
            selectFifthProduct?.ClickHereToBuyBtnClick();
            Assert.AreEqual(selectFifthProduct.GetCurrentUrl(), selectFifthProduct.GetCartItemUrl());
        }
    }
}
