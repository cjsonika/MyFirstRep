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
    class StartPage
    {
        public IWebDriver driver;
        public StartPage(IWebDriver driver) => this.driver = driver;

        public IWebElement Form => driver.FindElement(By.Name("lform"));
        public IWebElement LoginField => driver.FindElement(By.Name("login"));
        public IWebElement LoginTextField => driver.FindElement(By.XPath("//p[@class='field_title'][1]"));
        public IWebElement PasswordField => driver.FindElement(By.Name("pass"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Увійти']"));
        public IWebElement PoshtaTopMenu => driver.FindElement(By.XPath("//div[@class='block_gamma_gradient mail_login']//div[3]/h2/a")); //for checkinng post owner
        public IWebElement RemindLink => driver.FindElement(By.LinkText("нагадати"));
        public IWebElement PostSelector => driver.FindElement(By.Name("domn"));
        public IWebElement RememberMeCheckBox => driver.FindElement(By.XPath("//form[@name='lform']//ul/li[2]/label"));
        public IWebElement Registration => driver.FindElement(By.LinkText("Реєстрація"));
        public IWebElement SpecificPostSelector => driver.FindElement(By.XPath("//select[@name='domn']/option[@value='i.ua']")); //Check the domain 
        public IWebElement RememberMe => driver.FindElement(By.XPath("//form[@name='lform']//ul/li[2]/label")); //Check Remember me


        ////////////////////////////////////////////////////////VIGET//////////////////////////////////////////////////

        public IWebElement SearchForm => driver.FindElement(By.XPath("//div[@class='block_gamma_dark header_search']/div[@class='content clear']"));
        public IWebElement SearchField => driver.FindElement(By.Id("searchQ"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//input[@value='Знайти']"));
        public IWebElement SearchFieldText => driver.FindElement(By.XPath("//input[@value='Пошук в розділах']"));
        public IWebElement Partner1Link => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[1]/a"));
        public IWebElement Partner1 => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[1]/a"));
        public IWebElement Partner2Link => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[2]/a"));
        public IWebElement Partner3Link => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[3]/a"));
        public IWebElement Partner4Link => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[4]/a"));
        public IWebElement Partner5Link => driver.FindElement(By.XPath("//div[@class='Search']//ul/li[5]/a"));


        //NB Changes 
        public IWebElement IncorPass => driver.FindElement(By.Id("lform_errCtrl"));


        public void FieldsDisplayed()
        {
            Assert.Multiple(() =>
            {

                Assert.IsTrue(LoginField.Displayed);
                Assert.IsTrue(LoginTextField.Displayed);
                Assert.IsTrue(PasswordField.Displayed);
                Assert.IsTrue(LoginButton.Displayed);
                Assert.IsTrue(PoshtaTopMenu.Displayed);
                Assert.IsTrue(RemindLink.Displayed);
                Assert.IsTrue(PostSelector.Displayed);
                Assert.IsTrue(RememberMeCheckBox.Displayed);
                Assert.IsTrue(Registration.Displayed);

            });
            
        }

        // NB Changes
        public void SelectDomn()
        {
            var selectElement = new SelectElement(PostSelector);
            selectElement.SelectByValue("ua.fm");
        }

        public EmailBox Login()  //Enter your credentials
        {
            LoginField.SendKeys("sofi_mag@i.ua");
            PasswordField.SendKeys("agena123");
            LoginButton.Click();
            return new EmailBox(driver);
        }


    }
}
