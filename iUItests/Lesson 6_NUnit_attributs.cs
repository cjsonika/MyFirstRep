using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iUItests
{
    class Lesson6_NUnit_attributs
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://perevod.i.ua/");

        }

        [SetUp]
        [TestCase("Англійська", "Українська", "lesson", "урок")]
        [TestCase("Німецька", "Українська", "schnell", "швидко")]
        [TestCase("Французька", "Англійська", "un enfant", "child")]

        [Test]

        public void TranslateEngToUkr(string lang_from, string lang_to, string word, string result)
        {
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement LanguageDropDown1 = driver.FindElement(By.XPath("//span[@id='first_lang_selector']")); //first language drop-down menu
            action.Click(LanguageDropDown1).Build().Perform();
            wait.Until(p => driver.FindElement(By.XPath("//div[@id='popup_language_menu_1']/ul[@class='popup_menu']")).Displayed);
            driver.FindElement(By.XPath("//div[@id ='popup_language_menu_1']//a[text()='" + lang_from + "']")).Click(); //choose language to translate from

            IWebElement LanguageDropDown2 = driver.FindElement(By.XPath("//span[@id='second_lang_selector']")); //second language drop-down menu
            action.Click(LanguageDropDown2).Build().Perform();
            wait.Until(p => driver.FindElement(By.XPath("//div[@id='popup_language_menu_1']/ul[@class='popup_menu']")).Displayed);
            driver.FindElement(By.XPath("//div[@id ='popup_language_menu_2']//a[text()='" + lang_to + "']")).Click(); //choose language to translate to

            IWebElement FirstTextArea = driver.FindElement(By.Id("first_textarea"));
            FirstTextArea.SendKeys(word);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click(); //Click Translate button

            IWebElement SecondTextArea = driver.FindElement(By.Id("second_textarea"));
            SecondTextArea.SendKeys(result);
            
        }
        //[TearDown]
        //public void TearDown()
        //{
        //    IWebElement FirstTextArea = driver.FindElement(By.Id("first_textarea"));
        //    FirstTextArea.Clear();
        //}
        //[OneTimeTearDown]
        //public void OneTimeTearDown()
        //{
        //    driver.Quit();
        //}

    }
}
