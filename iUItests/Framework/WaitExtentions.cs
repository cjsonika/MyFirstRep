using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUItests.Framework
{
    public static class WaitExtentions
    {
        public static void WaitForElementDisplayed(this IWebDriver driver, IWebElement element, double timeSpan = 3)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(p => element.Displayed);
        }

        public static void PageLoadWait(this IWebDriver driver)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80.00));
            wait.Until(p => ((IJavaScriptExecutor)driver).ExecuteScript("return document.ready state").Equals("complete"));
        }

    }
}
