using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUItests.Framework
{
    static class DocumentUtils
    {

        public static void Upload(this IWebDriver driver, string FilePath)
        {
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(FilePath);             
        }

        public static void Download(this IWebDriver driver, string FileName)
        {
            driver.FindElement(By.LinkText(FileName)).Click();
        }

        public static string Screenshots(this IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @"C:\Users\Sofiya\Documents\Visual Studio 2017\Projects\DOCUMENT_UTILS\Screenshots";

            string fullFilePath = filePath + runname + ".jpg";
            ss.SaveAsFile(fullFilePath, ScreenshotImageFormat.Jpeg);

            return fullFilePath;
        }
    }
}
