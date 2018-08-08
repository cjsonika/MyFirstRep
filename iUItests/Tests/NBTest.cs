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
using OpenQA.Selenium.Support.UI;

namespace iUItests.Tests
{
    class NBTest : TestBase
    {
        public override void ExtendedOneTimeSetUp()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }

        [OneTimeTearDown]


        [Test]
        public void NB_LogInMail()
        {
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = new EmailBox(driver);
            startPage.LoginField.SendKeys(TestConfigurations.Username);
            startPage.PasswordField.SendKeys(TestConfigurations.Password);
            startPage.SelectDomn();
            startPage.LoginButton.Click();
            Assert.IsTrue(startPage.IncorPass.Displayed);

         
        }
    }
}
