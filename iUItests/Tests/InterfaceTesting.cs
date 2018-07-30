using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iUItests.PageObject;
using iUItests.Framework;



namespace iUItests.Tests
{
    namespace iUItests
    {
        public class InterfaceTesting : TestBase
        {
            //IWebDriver driver;

            [OneTimeSetUp]
            public override void ExtendedOneTimeSetUp()
            {
                driver.Navigate().GoToUrl("http://www.i.ua/");
            }



            [Test]
            public void CheckElementsPresent()
            {
                StartPage startPage = new StartPage(driver);
                startPage.FieldsDisplayed();
            }

 



          

        }
    }
}