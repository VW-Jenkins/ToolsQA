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
    class NunitTest
    {
        /*
        public void TestApp() {
            IWebDriver drive = new FirefoxDriver();
            drive.Url = "http://www.demoqa.com";
            drive.Close();
        }
        */
        IWebDriver drive;

        [SetUp]
        public void Initialize() {
            drive = new FirefoxDriver();
        }

        [Test]
        public void OpenAppTest() {
            drive.Url = "http://www.demoqa.com";
          
        }

        [TearDown]
        public void EndTest() {
            drive.Close();
        }
    }
}
