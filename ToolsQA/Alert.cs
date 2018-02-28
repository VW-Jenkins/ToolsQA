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
    class Alert
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup() {
            _driver = new FirefoxDriver();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
            _driver.Url = "http://toolsqa.com/handling-alerts-using-selenium-webdriver/";
        }

        [Test]
        [Category("Alert")]
        public void SimpleAlert() {
            _driver.FindElement(By.XPath("html/body/div[1]/div[5]/div[2]/div/div/p[4]/button")).Click();
            IAlert simpleAlert = _driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert test is " + alertText);
            simpleAlert.Accept();
        }

        [Test]
        [Category("Alert")]
        public void ConfirmAlertTest() {
            _driver.FindElement(By.XPath("html/body/div[1]/div[5]/div[2]/div/div/p[8]/button")).Click(); ;
            IAlert confirmationAlert = _driver.SwitchTo().Alert();
            String alertText = confirmationAlert.Text;
            Console.WriteLine("Alert text is + " + alertText);
            confirmationAlert.Dismiss();
        }

        [Test]
        [Category("Alert")]
        public void PromptAlert() {
            _driver.FindElement(By.XPath("html/body/div[1]/div[5]/div[2]/div/div/p[11]/button")).Click();
            IAlert promptAlert = _driver.SwitchTo().Alert();

            string alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);

            promptAlert.SendKeys("Accept the Alert");
            Thread.Sleep(4000);
            promptAlert.Accept();

        }

        [TearDown]
        public void tearDown() {
            _driver.Quit();
        }
    }
}
