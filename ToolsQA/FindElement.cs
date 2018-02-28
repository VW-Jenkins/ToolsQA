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
    class FindElement
    {
        [Test]
        [Category("Ele_Find")]
        public void FindElement_Exercise1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form/";
            driver.FindElement(By.Name("firstname")).SendKeys("Victor");
            driver.FindElement(By.Name("lastname")).SendKeys("Wang");
            driver.FindElement(By.Id("submit")).Click();
            driver.Close();
        }

        [Test]
        public void FindElement_Exercise2() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form/";
            driver.FindElement(By.PartialLinkText("Partial")).Click();
            Console.WriteLine("Partial link Test Pass");

            String sClass = driver.FindElement(By.TagName("button")).ToString();
            Console.WriteLine(sClass);

            driver.FindElement(By.LinkText("Link Test")).Click();
            Console.WriteLine("Link Test Pass");
            driver.Close();
        }
    }
}
