using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
namespace ToolsQA
{
    class MutilpleWindow
    {

        private IWebDriver _driver;

        [SetUp]
        public void Setup() {
            _driver = new FirefoxDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2);
            _driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";
        }

        [Test]
        [Category("MultipleWindows")]
        public void Multiple_switch() {
            String parentWindowHandle = _driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle => " + parentWindowHandle);
            IWebElement clickElement = _driver.FindElement(By.Id("button1"));
            for (int i = 0; i < 3; i++) {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            IList<string> lstWindow = _driver.WindowHandles.ToList();
            foreach (var handle in lstWindow) {
                Console.WriteLine("switching to window -> " + handle);
                Console.WriteLine("Navigating to google.com");
                _driver.SwitchTo().Window(handle);
                _driver.Navigate().GoToUrl("http://google.com");
            }
        }

        [TearDown]
        public void TearDown() {
            _driver.Quit();
        }
    }
}
