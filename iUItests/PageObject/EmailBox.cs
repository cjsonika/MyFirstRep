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

namespace iUItests.PageObject
{
    class EmailBox
    {
        public IWebDriver driver;
        public EmailBox(IWebDriver driver) => this.driver = driver;

        public IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@id='fieldset1']//span[@class='button l_r del']"));

        public IWebElement LogOutButton => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a"));
        public IWebElement Main => driver.FindElement(By.XPath("//a[text()='Головна']"));
        public IWebElement Vhid => driver.FindElement(By.XPath("//a[text()='Вхід']"));
        public IWebElement createLetterButton => driver.FindElement(By.XPath("//p[@class='make_message']"));
        public IWebElement MailOwner => driver.FindElement(By.XPath("//span[@class='sn_menu_title']"));
        public IWebElement NativeMail => driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[3]/a/span[3]/span")); //Native mails check
        public IWebElement Popup => driver.FindElement(By.XPath("//div[@id='prflpudvmbox']")); //Pop-up on email check
        public IWebElement DraftsButton => driver.FindElement(By.XPath("//li[@class='new'][2]/a")); //Чернетки
        

        public void ClickLetterCheckbox(string name)  // Click checkbox with a letter to choose which to delete
        {
            Actions action = new Actions(driver);
            string xpath = "//span[text()='" + name + "']/ancestor::div[@class='row new']//input"; //!!!!!
            IWebElement CheckBox = driver.FindElement(By.XPath(xpath));
            action.Click(CheckBox).Build().Perform();
            Assert.IsTrue(CheckBox.Selected);
        }

        public void ClickDeleteBtn()  // Click Delete
        {
            Actions action = new Actions(driver);
            action.Click(DeleteButton).Build().Perform();
            IAlert alert = driver.SwitchTo().Alert(); //Yes/No Popup
            alert.Accept();
        }

        public void CheckLetterPresense(string name)  // Check the presense of deleted letter
        {
            string xpath = "//span[text()='" + name + "']/ancestor::div[@class='row new']//input";  
            IWebElement DeletedMail = driver.FindElement(By.XPath(xpath));
            Assert.AreNotEqual(name, DeletedMail.Text);
        }

        public void LogOut()
        {
            Actions action = new Actions(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            action.Click(LogOutButton).Build().Perform();
        }

        public CreateLetterPage CreateLetter()
        {
            createLetterButton.Click();
            return new CreateLetterPage(driver);
        }
       


    }


}
