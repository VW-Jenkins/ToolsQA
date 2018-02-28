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
    class DriverCommands_2
    {
        [Test]
        [Category("DriverComamnds")]
        public void DriverCommands_2Test() {

            IWebDriver drive = new FirefoxDriver();
            drive.Url = "http://demoqa.com/frames-and-windows/";

            drive.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a")).Click();


            //drive.Close();
            drive.Quit();


        }
    }
}
