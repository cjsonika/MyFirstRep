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
    class Drafts
    {
        public IWebDriver driver;
        public Drafts(IWebDriver driver) => this.driver = driver;
        public IWebElement LetterToEdit => driver.FindElement(By.XPath("//span[@title='LetterEdit']")); //???
        public IWebElement LetterReceiver => driver.FindElement(By.XPath("//div[@class='row new']//span[@title='sofi@tradeescort.com']"));//Letter Preview
        public IWebElement LetterSubject => driver.FindElement(By.XPath("//span[@title='EdditedLetter']"));//Letter Preview
        public IWebElement DraftsHeader => driver.FindElement(By.XPath("//h2[contains(text(),'Чернетки')]")); //Чернетки h2

        public CreateLetterPage OpenDraft(string topic)
        {
            IWebElement DraftOpen = driver.FindElement(By.XPath("//span[text()='"+ topic + "']"));
            DraftOpen.Click();
            return new CreateLetterPage(driver);
        }
    }


}
