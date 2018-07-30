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
    class UploadDownloadFile : TestBase
    {
        public override void ExtendedOneTimeSetUp()
        {

            driver.Navigate().GoToUrl("http://www.i.ua/");
            StartPage startPage = new StartPage(driver);
            EmailBox emailBox = startPage.Login();
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);

            emailBox.CreateLetter();
            createLetterPage.AttachmentButton.Click();
            createLetterPage.ChooseFileButton.Click();
            DocumentUtils.Upload(driver, @"C:\Users\Sofiya\Documents\Visual Studio 2017\Projects\DOCUMENT_UTILS\Upload\Doc_to_Upload.txt");
        }

        [Test]
        public void UploadFile()
        {  
            Assert.IsTrue(true); //!!!
        }

        [Test]
        public void DownloadFile()
        {
            DocumentUtils.Download(driver, "Doc_to_Upload");
            Assert.IsTrue(true);

        }
}
}
