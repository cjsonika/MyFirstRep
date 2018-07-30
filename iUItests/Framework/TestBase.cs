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

namespace iUItests.Framework
{
    public class TestBase
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            ExtendedOneTimeSetUp();

        }

        public virtual void ExtendedOneTimeSetUp()
        {

        }

        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine("_____________________________");
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
            ExtendedSetUp();
        }

        public virtual void ExtendedSetUp()
        {

        }

        [TearDown]
        public void BaseTearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status.ToString());
            ExtendedTearDown();
            Console.WriteLine("_____________________________");
        }

        public virtual void ExtendedTearDown()
        {

        }
        
        [OneTimeTearDown]
        public void BaseOneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
