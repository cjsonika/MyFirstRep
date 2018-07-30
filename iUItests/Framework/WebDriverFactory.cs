using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iUItests.Framework
{
    class WebDriverFactory
    {
        private const string chrome = "CH";
        private const string firefox = "FF";
        private const string internetExplorer = "IE";

        private static IWebDriver driver = null;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                TestConfigurations configs = TestConfigurations.GetInstanse();

                if (TestConfigurations.Browser == chrome)
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    string FilePath = @"C:\Users\Sofiya\Documents\Visual Studio 2017\Projects\DOCUMENT_UTILS\Download";
                    chromeOptions.AddUserProfilePreference("download.default_directory", FilePath);
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                    driver = new ChromeDriver(chromeOptions);

                }
                else if (TestConfigurations.Browser == firefox)
                {
                    driver = new FirefoxDriver();
                }
                else if (TestConfigurations.Browser == internetExplorer)
                {
                    driver = new InternetExplorerDriver();
                }
                else
                {
                    throw new Exception("Invalid browser in the settings");
                }
            }
            return driver;
        }

    }
}
