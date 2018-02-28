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
    class SwitchCommand
    {
        private IWebDriver driver;
       
        [SetUp]
       
        public void Setup() {
            driver = new FirefoxDriver();
            //driver.Manage().Window.Maximize();
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
        }

        [Test]
        [Category("SwitchWindow")]
        public void Alert_Test() {
            //Setup();
            var alertButton = driver.FindElement(By.Id("alert"));
            alertButton.Click();
            var alert = driver.SwitchTo().Alert();
            var expectAlertText = "Knowledge increases by sharing but not by saving. Please share " +
        "this website with your friends and in your organization.";
            Assert.AreEqual(expectAlertText, alert.Text);
            //TearDown();

        }

        [Test]
        [Category("SwitchWindow")]
        public void Framework_Test() {
            //driver.SwitchTo().Frame();
            //driver.SwitchTo().ParentFrame();
        }

        [Test]
        [Category("SwitchWindow")]
        public void Windows_test() {
            var newBrowserWindowButton = driver.FindElement(By.Id("button1"));
            Assert.AreEqual(1, driver.WindowHandles.Count);

            string originalWindowTitle = "Demo Windows for practicing Selenium Automation";
            Assert.AreEqual(originalWindowTitle, driver.Title);

            newBrowserWindowButton.Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);

            string newWindowHandle = driver.WindowHandles.Last();
            var newWindow = driver.SwitchTo().Window(newWindowHandle);

            string ExpectedNewWindowTitle = "QA Automation Tools Tutorial";
            Assert.AreEqual(ExpectedNewWindowTitle, newWindow.Title);
        }

        [Test]
        [Category("SwitchWindow")]
        public void NewTab_Test() {
            var alertButton = driver.FindElement(By.XPath("html/body/div[1]/div[5]/div[2]/div/div/p[4]/button"));
            alertButton.Click();

            string originalTabTitle = "Demo Windows for practicing Selenium Automation";
            Assert.AreEqual(originalTabTitle, driver.Title);

            string newTabhandle = driver.WindowHandles.Last();
            var newtab = driver.SwitchTo().Window(newTabhandle);

            var expectedNewTabTitle = "QA Automation Tools Tutorial";
            Assert.AreEqual(expectedNewTabTitle, newtab.Title);

            var originalTab = driver.SwitchTo().Window(driver.WindowHandles.First());
            Assert.AreEqual(originalTabTitle, originalTab.Title);
        }


        [TearDown]
        public void TearDown() {
            driver.Quit();
        }
    }
}
