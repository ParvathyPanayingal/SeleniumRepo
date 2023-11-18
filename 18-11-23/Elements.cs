using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture] // alwaysstart with test fixture.
    internal class Elements:CoreCodes
    {
        [Ignore("error")]
        [Test]
        public void TestCheckbox()
        {
            /*Thread.Sleep(3000);
            driver.findElement(By.Id("close_button_svg")).Click();
            IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Elements']//parent::div"));
            elements.Click();
            */
            IWebElement checkBoxMenu=driver.FindElement(By.XPath("//span[text()='Check Box']//parent::li"));
            checkBoxMenu.Click();
            List< IWebElement> expandCollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList(); //find elements returns a collection so we should convert it to list.
            foreach ( var item in expandCollapse ) 
            {
                item.Click();
            }
            IWebElement commandsCheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandsCheckbox.Click();

            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);

        }

        [Ignore("running other test")]
        [Test]

        //for form testing change add automation-practice-form in base url
        public void TestFormElements()
        {
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);

            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Doe");
            Thread.Sleep(2000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("Johndoe@gmail.com");
            Thread.Sleep(2000);

            IWebElement radioButton = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            radioButton.Click();
            Thread.Sleep(2000);

            IWebElement mobileNumberField = driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("933844729");
            Thread.Sleep(2000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(6);
            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1998");
            Thread.Sleep(3000);

            IWebElement dobDay = driver.FindElement(By.XPath("//div[text()='5'"));
            dobDay.Click();
            Thread.Sleep(2000);

            IWebElement subjectFeild = driver.FindElement(By.Id("subjectsInput"));
            subjectFeild.SendKeys("Maths");
            subjectFeild.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectFeild.SendKeys("Chemistry");
            subjectFeild.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement uploadImage = driver.FindElement(By.Id("uploadPicture"));
            uploadImage.SendKeys(@"C:\Users\Administrator\Pictures\Saved Pictures");
            Thread.Sleep(2000);

            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 Street, City, Country");
            Thread.Sleep(2000);

            /*
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();
            */
        }

        [Ignore("running other test")]

        [Test]
       public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle" +parentWindowHandle);

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(var i=0;i<3;i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);

            }

            List<string> listWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach(var win in listWindow)
            {
                Console.WriteLine("Switching to window ==>" + win);
                driver.SwitchTo().Window(win);
                Thread.Sleep(3000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);

                lastWindowHandle = win;
            }

            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }

        [Test]
        //to switch to alert we have to use ialert interface
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element= driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element); //we are making driver as javascript executor
            Thread.Sleep(5000);

            IAlert simpleAlert = driver.SwitchTo().Alert();

            Console.WriteLine("Alert text is " + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(5000);

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(5000);
            element.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;
            Console.WriteLine("Alert text is " + alertText);
            confirmationAlert.Dismiss();
            //Thread.Sleep(5000);

            element = driver.FindElement(By.Id("promtButton"));
            
            element.Click();
            Thread.Sleep(5000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is "+alertText);
            promptAlert.SendKeys("Accepting  the alert");
            Thread.Sleep(1000);
            promptAlert.Accept();



        }


    }
}
