using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace iUItests.Framework
{
    class TestConfigurations
    {
        public static string Browser;
        public static string Username;
        public static string Password;
        public static string Environment;

        public static TestConfigurations configs;

        public static string GetConfigFilePath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "MyTestConfigs.xml");
        }

        public static void GetConfigs()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(GetConfigFilePath());
            Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
            // NB Changes
            Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;

        }

        public static TestConfigurations GetInstanse()     
        {
            if (configs == null)
            {
                GetConfigFilePath();
                GetConfigs();
                configs = new TestConfigurations();
            }
            return configs;
        }
    }
}
