using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI; //dropdown
using NUnit.Framework;
using System.Threading;
namespace ToolsQA
{
    class DropDown_MultipleSelect
    {
        [Test]
        [Category("DropDown")]
        public void DropDown_Test() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("continents")));
            oSelect.SelectByText("Europe");
            Thread.Sleep(2000);
            oSelect.SelectByIndex(2);
            Thread.Sleep(2000);

            IList<IWebElement> oSize = oSelect.Options;
            for (int i = 0; i < oSize.Count; i++) {
                String value = oSelect.Options.ElementAt(i).Text;
                Console.WriteLine("Value of the select item is : " + value);

                if (value.Equals("Africa")) {
                    oSelect.SelectByIndex(i);
                    break;
                }
            }
            driver.Close();
        }

        [Test]
        [Category("Mutilple_Select")]
        public void Multiple_Select_test() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Name("selenium_commands")));

            oSelection.SelectByIndex(0);
            Thread.Sleep(2000);
            oSelection.SelectByText("Navigation Commands");
            Thread.Sleep(2000);
            oSelection.DeselectByText("Navigation Commands");

            IList<IWebElement> oSize = oSelection.Options;

            for (int i = 0; i < oSize.Count; i++){
                String sValue = oSelection.Options.ElementAt(i).Text;
                Console.WriteLine("Value of the itme is : " + sValue);
                oSelection.SelectByIndex(i);

                Thread.Sleep(2000);
            }

            oSelection.DeselectAll();
            driver.Close();
        }
    }
}
