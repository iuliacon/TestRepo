using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace Guru99
{
    public class CSS
    {
        IWebDriver m_driver;

        [Test]
        public void cssDemo()
        {
            m_driver = new ChromeDriver();
            m_driver.Url = "http://demo.guru99.com/test/guru99home/";
            m_driver.Manage().Window.Maximize();
            IWebElement link = m_driver.FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
            link.Click();
            m_driver.Close();
        }

        [Test]
        public void cssDemo2()
        {

            IWebDriver m_driver = new ChromeDriver();
            m_driver.Url = "http://demo.guru99.com/test/guru99home/";


            m_driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            m_driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 10);
            m_driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 15);

            Thread.Sleep(10000);

            IWebElement createWebSite = null;
            IReadOnlyCollection<IWebElement> iframes = m_driver.FindElements(By.TagName("iframe"));

            foreach (IWebElement iframe in iframes)
            {

                Console.WriteLine(iframe.GetAttribute("id"));


                try
                {
                    if (iframe.GetAttribute("id").Length > 2)
                    {
                        Console.WriteLine("Switching..." + iframe.GetAttribute("id"));
                        //     m_driver.SwitchTo().ParentFrame();
                        m_driver.SwitchTo().Frame(iframe);
                    }

                    //createWebSite = m_driver.FindElement(By.XPath(".//div[@class='menu-block']/ul/li[2]/a[contains(text(),'Testing')]"));
                    createWebSite = m_driver.FindElement(By.XPath(".//*[@id='rt - header']/div/div[2]/div/ul/li[2]/a"));

                }
                catch (Exception e) { }

                if (createWebSite != null)
                {
                    Console.WriteLine("Click...");

                    createWebSite.Click();
                }


            }


            m_driver.Close();


        }

        [Test]
        public void cssDemo3()
        {
            IWebDriver browser = new ChromeDriver();
            browser.Url = "http://demo.guru99.com/test/guru99home/";
            //IWebElement testing = browser.FindElement(By.XPath(".//*[@id='rt-header']/div/div[2]/div/ul/li[2]/a"));
            IWebElement testing = browser.FindElement(By.XPath(".//div[@class='menu-block']/ul/li[2]/a[contains(text(),'Testing')]"));
            testing.Click();
            browser.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 10);
            browser.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            IWebElement tutorial = browser.FindElement(By.XPath(".//a[@title='First Steps Test Case Development']"));
            tutorial.Click();
            browser.Manage().Window.Maximize();
          browser.Close();


        }

        

    
       
    }
}
