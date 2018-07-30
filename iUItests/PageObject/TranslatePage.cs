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

namespace iUItests.PageObject
{
    class TranslatePage 
    {
        public IWebDriver driver;
        public TranslatePage(IWebDriver driver) => this.driver = driver;
        //first and second language drop-down button
        public IWebElement LeftLangMenu => driver.FindElement(By.Id("first_lang_selector"));
        public IWebElement RightLangMenu => driver.FindElement(By.Id("second_lang_selector"));
        //popup with all available languages
        public IWebElement LeftPopup => driver.FindElement(By.XPath("//div[@id='popup_language_menu_1']/ul[@class='popup_menu']"));
        public IWebElement RightPopup => driver.FindElement(By.XPath("//div[@id='popup_language_menu_2']/ul[@class='popup_menu']"));
        //Input/Output fields
        public IWebElement FirstTextArea => driver.FindElement(By.Id("first_textarea"));
        public IWebElement SecondTextArea => driver.FindElement(By.Id("second_textarea"));
        //Click Translate button
        public IWebElement TranslateButton => driver.FindElement(By.Name("commit"));


        public void LanguageSelect1(string langFrom)
        {
            //choose language to translate from
            IWebElement LanguageLink = driver.FindElement(By.XPath("//div[@id ='popup_language_menu_1']//a[text()='" + langFrom + "']"));
            LanguageLink.Click(); 
        }

        public void LanguageSelect2(string langTo)
        {
            //choose language to translate from
            IWebElement LanguageLink = driver.FindElement(By.XPath("//div[@id ='popup_language_menu_2']//a[text()='" + langTo + "']"));
            LanguageLink.Click();
        }

        public void Translate(string lang_from, string lang_to, string word, string result)
        {
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            LeftLangMenu.Click();
            wait.Until(p => LeftPopup.Displayed); // Waiting for popup with languages list
            
            LanguageSelect1(lang_from); //choose language to translate from

            RightLangMenu.Click();
            wait.Until(p => RightPopup.Displayed); // Waiting for popup with languages list
            LanguageSelect2(lang_to); //choose language to translate to

            FirstTextArea.SendKeys(word);
            TranslateButton.Click(); //Click Translate button


        }
    }
}