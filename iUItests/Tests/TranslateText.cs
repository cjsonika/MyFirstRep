using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using iUItests.PageObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iUItests.Framework;


namespace iUItests
{

    [TestFixture]
    class TranslateText : TestBase
    {
        TranslatePage translatePage;

        public override void ExtendedOneTimeSetUp()
        {
            driver.Navigate().GoToUrl("https://perevod.i.ua/");
        }

        [TestCase("Английский", "Украинский", "lesson", "урок")]
        [TestCase("Немецкий", "Украинский", "schnell", "швидко")]
        [TestCase("Французский", "Английский", "un enfant", "child")]

        [Test]
        public void translateIT(string from, string to, string first_word, string expected_res)
        {

            translatePage = new TranslatePage(driver);
            translatePage.Translate(from, to, first_word, expected_res);
            Assert.AreEqual(expected_res, translatePage.SecondTextArea.Text);
        }

        [TearDown]
        public void TearDown()
        {
            translatePage.FirstTextArea.Clear();
        }


    }
}
