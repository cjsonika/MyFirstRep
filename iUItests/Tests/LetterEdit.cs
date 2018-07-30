using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iUItests.Framework;
using NUnit.Framework;
using iUItests.PageObject;
using NUnit.Framework.Internal;

namespace iUItests.Tests
{
    class LetterEdit : TestBase
    {
        string topic = "SubjectEdit";
        string editedTopic = "EdditedSubject";
        public override void ExtendedOneTimeSetUp()
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = startPage.Login();
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            //startPage.Login();
            Assert.AreEqual("sofi_mag@i.ua", emailBox.MailOwner.Text); //Inside login check
            emailBox.createLetterButton.Click();
            Assert.AreEqual("Новий лист - I.UA ", driver.Title);
            createLetterPage.CreateLetter(topic); 

        }



        [Test]
        public void LetterReceiverEdit()
        {
            Drafts drafts = new Drafts(driver);
            EmailBox emailBox = new EmailBox(driver);
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            emailBox.DraftsButton.Click();
            driver.WaitForElementDisplayed(drafts.DraftsHeader);
            drafts.LetterToEdit.Click();
            createLetterPage.LetterReciverField.Clear();
            createLetterPage.LetterReciverField.SendKeys("sofi@tradeescort.com");
            createLetterPage.SaveInDraftsButton.Click();
            emailBox.DraftsButton.Click();
            Assert.AreEqual("sofi@tradeescort.com", drafts.LetterReceiver);
        }

        [Test]
        public void LetterSubjectEdit()
        {
            Drafts drafts = new Drafts(driver);
            EmailBox emailBox = new EmailBox(driver);
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            emailBox.DraftsButton.Click();
            drafts.LetterToEdit.Click();
            //Assert.AreEqual(topic, createLetterPage.LetterSubjectField);
            createLetterPage.LetterSubjectField.SendKeys(editedTopic);
            createLetterPage.SaveInDraftsButton.Click();
            emailBox.DraftsButton.Click();
            Assert.AreEqual(editedTopic, drafts.LetterSubject);
            topic = editedTopic;
        }

        [Test]
        public void LetterTextEdit()
        {
            Drafts drafts = new Drafts(driver);
            EmailBox emailBox = new EmailBox(driver);
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            emailBox.DraftsButton.Click();
            drafts.LetterToEdit.Click();
            Assert.AreEqual("Нередагований текст листа", createLetterPage.LetterTextField);
            createLetterPage.LetterTextField.SendKeys("Вже редагований текст листа");
            createLetterPage.SaveInDraftsButton.Click();
            emailBox.DraftsButton.Click();

            Assert.AreEqual("EditedLetter", drafts.LetterSubject);
        }


    }
}
