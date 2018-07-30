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

    public class LoginTest:TestBase
    {

        public override void ExtendedOneTimeSetUp()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }

        [OneTimeTearDown]


        [Test]
        public void LogInMail()
        {
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = new EmailBox(driver);
            startPage.LoginField.SendKeys("sofi_mag@i.ua");
            startPage.PasswordField.SendKeys("agena123");
            ////emailBox.createLetterButton.Click();
            //startPage.Login();
            Assert.Multiple(() =>   //Check credentias values
            {
                Assert.AreEqual("sofi_mag@i.ua", startPage.LoginField.GetAttribute("value"));
                Assert.AreEqual("agena123", startPage.PasswordField.GetAttribute("value"));
            });
            Assert.AreEqual("i.ua", startPage.PostSelector.GetAttribute("value"));
            Assert.IsFalse(startPage.RememberMe.Selected);
            startPage.LoginButton.Click(); //Submit login
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            Assert.AreEqual("sofi_mag@i.ua", emailBox.MailOwner.Text); //Inside login check
            //Assert.AreEqual("Ласкаво просимо на I.UA!", emailBox.NativeMail.Text);
            //Actions action = new Actions(driver);
            //action.MoveToElement(emailBox.Popup).Build().Perform();
            //string blocktext = emailBox.Popup.Text;
            //Assert.IsTrue(emailBox.Popup.Text.Contains("Шановний користувач"));
        }
    }
}


