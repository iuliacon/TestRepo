using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Guru99
{
    class Program
    {
       
        static void Main(string[] args)
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

                    createWebSite = m_driver.FindElement(By.XPath(".//*[contains(text(),'Home')]"));
                }
                catch (Exception e) { }

                if (createWebSite != null)
                {
                    Console.WriteLine("Click...");

                    createWebSite.Click();
                }




            }







            // m_driver.Close();
        }
    }
}
