using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guru99Demo
{
    class Guru99Demo
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
           IWebDriver driver = new ChromeDriver();
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.google.com";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
