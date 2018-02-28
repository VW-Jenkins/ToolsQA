using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace ToolsQA
{
    class BroswerNavigate
    {
        [Test]
        [Category("Browser_Navigate")]
        public void Browser_Navigate_Test() {
            IWebDriver drive = new FirefoxDriver();
            drive.Navigate().GoToUrl("http://demoqa.com");
            drive.FindElement(By.XPath(".//*[@id='menu-item-374']/a")).Click();
            drive.Navigate().Back();
            drive.Navigate().Forward();
            drive.Navigate().Refresh();
            drive.Close();
        }
    }
}
