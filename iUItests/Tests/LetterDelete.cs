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

    public class LetterDelete:TestBase
    {
 
        [OneTimeTearDown]

        public override void ExtendedOneTimeSetUp()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }


        [Test]
        public void CheckLetterDelete()
        {
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = new EmailBox(driver);
            startPage.Login();
            try
            {
                emailBox.ClickLetterCheckbox("Видалення");
                string xpath = "//span[text()='" + "Видалення" + "']/ancestor::div[@class='row new']//input";  //!!! name??
                if (driver.FindElement(By.XPath(xpath)).Displayed)
                {
                    IWebElement CheckBox = driver.FindElement(By.XPath(xpath));
                    emailBox.ClickDeleteBtn();
                    Actions action = new Actions(driver);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    emailBox.CheckLetterPresense("Видалення");
                }
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine("Sorry, we couldn't find a proper element");
            }
        }

        [Test]
        public void WorkWithWindows()
        {
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = new EmailBox(driver);
            startPage.Login();
            emailBox.Main.SendKeys(Keys.Control + Keys.Return);
            Assert.AreEqual(2, driver.WindowHandles.Count);
            SeleniumExtentions.SwitchToLastWindow(driver);
            emailBox.LogOut();
            SeleniumExtentions.SwitchToFirstWindow(driver);
            driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            Assert.IsTrue(emailBox.Vhid.Text.Contains("Вхід"));
        }

    }
}

