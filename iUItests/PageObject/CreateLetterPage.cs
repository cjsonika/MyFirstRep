using iUItests.Framework;
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
    class CreateLetterPage
    {
        public IWebDriver driver;
        public CreateLetterPage(IWebDriver driver) => this.driver = driver;

        public IWebElement LetterReciverField => driver.FindElement(By.XPath("//textarea[@id='to']"));
        public IWebElement LetterSubjectField => driver.FindElement(By.XPath("//input[@name='subject']"));
        public IWebElement LetterTextField => driver.FindElement(By.XPath("//div[@class='text_editor_browser']//textarea"));
        public IWebElement SendLetterButton => driver.FindElement(By.XPath("//p[@class='send_container clear']/input[@name='send']"));
        public IWebElement SaveInDraftsButton => driver.FindElement(By.XPath("//p[@class='send_container clear']/input[@name='save_in_drafts']"));
        public IWebElement AttachmentButton => driver.FindElement(By.XPath("//span[@swclass='link cancel']"));
        public IWebElement ChooseFileButton => driver.FindElement(By.XPath("//div[@class='file_upload']"));

        public EmailBox CreateLetter(string topic)
        {
            LetterReciverField.SendKeys("sofi_mag@i.ua"); //Кому
            LetterSubjectField.SendKeys(topic);
            LetterTextField.SendKeys("Нередагований текст листа");     
            SaveInDraftsButton.Click();
            return new EmailBox(driver);
        }

    }
}
