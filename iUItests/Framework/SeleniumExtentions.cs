using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUItests.Framework
{
    class SeleniumExtentions
    {
        public static void SwitchToLastWindow(IWebDriver driver)
        {
            var Windows = driver.WindowHandles;
            driver.SwitchTo().Window(Windows.Last()); //switch to last window
        }

        public static void SwitchToFirstWindow(IWebDriver driver)
        {
            var Windows = driver.WindowHandles;
            driver.SwitchTo().Window(Windows.First()); //switch to first window
        }

        public static bool IsElementDisplayed(IWebElement element)
        {


            return (true);
        }

    }
}
