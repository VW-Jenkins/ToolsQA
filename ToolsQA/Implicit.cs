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
    class Implicit
    {
        [Test]
        [Category("Wait")]
        public void Implicit_TimneOut_Test() {
            IWebDriver driver = new FirefoxDriver();

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";
            IWebElement element = driver.FindElement(By.Id("target"));
            driver.Close();
        }
    }
}
