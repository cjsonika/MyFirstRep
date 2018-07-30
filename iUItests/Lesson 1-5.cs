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

namespace iUItests
{
    public class HomePageSmoke
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void DemoTest1()
        {
            IWebElement Form = driver.FindElement(By.Name("lform"));
            Assert.IsTrue(Form.Displayed);
        }

        [Test]
        public void DemoTest2()
        {
            Assert.AreEqual("І.UA - твоя пошта ", driver.Title);
        }

        [Test]
        public void DemoTest3()
        {           
            IWebElement LoginField = driver.FindElement(By.Name("login"));
            Assert.IsTrue(LoginField.Displayed);   
        }

        [Test]
        public void DemoTest4()
        {
            IWebElement LoginTextField = driver.FindElement(By.XPath("//p[@class='field_title'][1]"));
            Assert.IsTrue(LoginTextField.Displayed);
        }

        [Test]
        public void DemoTest5()
        {
            IWebElement PasswordField = driver.FindElement(By.Name("pass"));
            Assert.IsTrue(PasswordField.Displayed);
        }

        [Test]
        public void DemoTest6()
        {
            IWebElement PasswordTextField = driver.FindElement(By.XPath("//p[@class='field_title'][2]"));
            Assert.IsTrue(PasswordTextField.Displayed);
        }

        [Test]
        public void DemoTest7()
        {          
            IWebElement LoginBtn = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            Assert.IsTrue(LoginBtn.Displayed);     
        }

        [Test]
        public void DemoTest8()
        {
            IWebElement PoshtaTopMenu = driver.FindElement(By.XPath("//div[@class='block_gamma_gradient mail_login']//div[3]/h2/a"));
            Assert.IsTrue(PoshtaTopMenu.Displayed);
        }

        [Test]
        public void DemoTest9()
        {
            IWebElement Remind = driver.FindElement(By.LinkText("нагадати"));
            Assert.IsTrue(Remind.Displayed);
        }
        
        [Test]
        public void DemoTest10()
        {
            IWebElement PostSelector = driver.FindElement(By.Name("domn"));
            Assert.IsTrue(PostSelector.Displayed);
        }

        [Test]
        public void DemoTest11()
        {
            IWebElement RememberMe = driver.FindElement(By.XPath("//form[@name='lform']//ul/li[2]/label"));
            Assert.IsTrue(RememberMe.Displayed);
        }

        [Test]
        public void DemoTest12()
        {
            IWebElement Registration = driver.FindElement(By.LinkText("Реєстрація"));
            Assert.IsTrue(Registration.Displayed);
        }

        /////////////////////////////Viget/////////////////////////////

        [Test]
        public void DemoTest20()
        {
            IWebElement SearchForm = driver.FindElement(By.XPath("//div[@class='block_gamma_dark header_search']/div[@class='content clear']"));
            Assert.IsTrue(SearchForm.Displayed);
        }

        [Test]
        public void DemoTest21()
        {
            IWebElement SearchField = driver.FindElement(By.Id("searchQ"));
            Assert.IsTrue(SearchField.Displayed);
        }

        [Test]
        public void DemoTest22()
        {
            IWebElement SearchButton = driver.FindElement(By.XPath("//input[@value='Знайти']"));
            Assert.IsTrue(SearchButton.Displayed);
        }

        [Test]
        public void DemoTest23()
        {
            IWebElement SearchFieldText = driver.FindElement(By.XPath("//input[@value='Пошук в розділах']"));
            Assert.IsTrue(SearchFieldText.Displayed);
        }
        

        [Test]
        public void DemoTest24()
        {
            IWebElement Partner1 = driver.FindElement(By.XPath("//div[@class='Search']//ul/li[1]/a"));
            Assert.IsTrue(Partner1.Displayed);
        }

        [Test]
        public void DemoTest25()
        {
            IWebElement Partner2 = driver.FindElement(By.XPath("//div[@class='Search']//ul/li[2]/a"));
            Assert.IsTrue(Partner2.Displayed);
        }
        
        [Test]
        public void DemoTest26()
        {
            IWebElement Partner3 = driver.FindElement(By.XPath("//div[@class='Search']//ul/li[3]/a"));
            Assert.IsTrue(Partner3.Displayed);
        }

        [Test]
        public void DemoTest27()
        {
            IWebElement Partner4 = driver.FindElement(By.XPath("//div[@class='Search']//ul/li[4]/a"));
            Assert.IsTrue(Partner4.Displayed);
        }

        [Test]
        public void DemoTest28()
        {
            IWebElement Partner5 = driver.FindElement(By.XPath("//div[@class='Search']//ul/li[5]/a"));
            Assert.IsTrue(Partner5.Displayed);
        }
                       
    }

    public class LoginTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
        [Test]
        public void DemoTest31() //Elements Enabled
        {
            IWebElement LoginField = driver.FindElement(By.Name("login"));
            Assert.IsTrue(LoginField.Enabled);
          
            IWebElement PasswordField = driver.FindElement(By.Name("pass"));
            Assert.IsTrue(PasswordField.Enabled);

            IWebElement PostSelector = driver.FindElement(By.Name("domn"));
            Assert.IsTrue(PostSelector.Enabled);

            IWebElement RememberMe = driver.FindElement(By.XPath("//form[@name='lform']//ul/li[2]/label"));
            Assert.IsTrue(RememberMe.Enabled);
        }
        
        [Test]
        public void LogInMail()  
        {
            //Enter your credentials
            IWebElement LoginField = driver.FindElement(By.Name("login"));
            LoginField.SendKeys("sofi_mag@i.ua");
            IWebElement PasswordField = driver.FindElement(By.Name("pass"));
            PasswordField.SendKeys("agena123");  
            Assert.Multiple(() =>   //Check credentias values
            { 
            Assert.AreEqual("sofi_mag@i.ua", LoginField.GetAttribute("value"));
            Assert.AreEqual("agena123", PasswordField.GetAttribute("value"));
            });        
            IWebElement PostSelector = driver.FindElement(By.XPath("//select[@name='domn']/option[@value='i.ua']")); //Check the domain 
            Assert.AreEqual("i.ua", PostSelector.GetAttribute("value"));
            IWebElement RememberMe = driver.FindElement(By.XPath("//form[@name='lform']//ul/li[2]/label")); //Check Remember me
            Assert.IsFalse(RememberMe.Selected);
            IWebElement LoginBtn = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginBtn.Click(); //Submit login
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            IWebElement MailOwner = driver.FindElement(By.XPath("//span[@class='sn_menu_title']")); 
            Assert.AreEqual("sofi_mag@i.ua", MailOwner.Text);//Inside login check
            IWebElement NativeMail = driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[3]/a/span[3]/span")); //Native mails check
            Assert.AreEqual("Ласкаво просимо на I.UA!", NativeMail.Text);
            Actions action = new Actions(driver);            
            IWebElement Popup = driver.FindElement(By.XPath("//div[@id='prflpudvmbox']")); //Pop-up check
            action.MoveToElement(Popup).Build().Perform();
            string blocktext = Popup.Text;
            Assert.IsTrue(Popup.Text.Contains("Шановний користувач"));
        }
    }
}

public class LetterDelete
{
    IWebDriver driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://www.i.ua/");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
    }

    public void Login()  //Enter your credentials
    {
        IWebElement LoginField = driver.FindElement(By.Name("login"));
        LoginField.SendKeys("sofi_mag@i.ua");
        IWebElement PasswordField = driver.FindElement(By.Name("pass"));
        PasswordField.SendKeys("agena123");
        IWebElement LoginBtn = driver.FindElement(By.XPath("//input[@value='Увійти']"));
        LoginBtn.Click();
    }

    public void ClickLetterCheckbox(string name)  // Click checkbox with a letter to choose which to delete
    {
        Actions action = new Actions(driver);
        string xpath = "//span[text()='" + name + "']/ancestor::div[@class='row new']//input";
        IWebElement CheckBox = driver.FindElement(By.XPath(xpath));
        action.Click(CheckBox).Build().Perform();
        Assert.IsTrue(CheckBox.Selected);
    }

    public void ClickDeleteBtn()  // Click Delete
    {
        Actions action = new Actions(driver);
        IWebElement Delete = driver.FindElement(By.XPath("//div[@id='fieldset1']//span[@class='button l_r del']"));
        action.Click(Delete).Build().Perform();
    }

    public void AcceptDismissPopUp()  // Yes/No Popup
    {
        Actions action = new Actions(driver);
        IAlert alert = driver.SwitchTo().Alert();
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
        IWebElement LogOut = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a"));
        action.Click(LogOut).Build().Perform();
    }
    

    [Test]
    public void CheckLetterDelete()
    {
        Login();
        try
        {
            ClickLetterCheckbox("Видалення");
            string xpath = "//span[text()='" + "Видалення" + "']/ancestor::div[@class='row new']//input";  //!!! name??
            if (driver.FindElement(By.XPath(xpath)).Displayed)
            {
                IWebElement CheckBox = driver.FindElement(By.XPath(xpath));
                ClickDeleteBtn();
                Actions action = new Actions(driver);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                CheckLetterPresense("Видалення");
            }
        }
        catch(NoSuchElementException exception)
        {
            Console.WriteLine("Sorry, we couldn't find a proper element");
        }
    }

    [Test]
    public void WorkWithWindows()
    {
        Login();
        IWebElement Main = driver.FindElement(By.XPath("//a[text()='Головна']"));
        Main.SendKeys(Keys.Control + Keys.Return);
        Assert.AreEqual(2, driver.WindowHandles.Count);
        var Windows = driver.WindowHandles;
        driver.SwitchTo().Window(Windows.Last()); //switch to last window
        LogOut();
        driver.SwitchTo().Window(Windows.First());
        driver.Navigate().Refresh();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        IWebElement Vhid = driver.FindElement(By.XPath("//a[text()='Вхід']"));
        Assert.IsTrue(Vhid.Text.Contains("Вхід"));
    }

}

public class WorkWithFrames
{
    IWebDriver driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tinymce");
        IWebElement MyFrame = driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']"));
        MyFrame.Clear();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void DemoTest50()  //Clean the form
    {
        Actions action = new Actions(driver);
        IWebElement MyFrame = driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']"));
        driver.SwitchTo().Frame("mce_0_ifr");
        action.Click(MyFrame);
        MyFrame.SendKeys("Any text");
    }  

}


