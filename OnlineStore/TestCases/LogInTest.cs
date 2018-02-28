using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

using OpenQA.Selenium.Support.PageObjects;
using OnlineStore.PageObjects;

using System.Configuration;
using OnlineStore.WrapperFactory;
namespace OnlineStore.TestCases
{
    class LogInTest
    {

        [Test]
        [Category("Store_Login")]
        public void Test()
        {
            //Using Divers/Browser factory
            BrowserFactory.InitBrowser("Firefox");
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
            //IWebDriver driver = new FirefoxDriver();
            //use configurations managem
            //driver.Url = "http://www.store.demoqa.com";
            //

            //driver.Url = ConfigurationManager.AppSettings["URL"];
            /*
            driver.FindElement(By.XPath(".//*[@id='account']/a")).Click();
            driver.FindElement(By.Id("log")).SendKeys("selenium_test");
            driver.FindElement(By.Id("pwd")).SendKeys("selenium_test_pwd_11");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.XPath(".//*[@id='meta']/ul/li[2]/a")).Click();
            driver.Quit();
            */
            // using PageObject Design Pattern (OpenQA.Selenium.Support.PageObjects)	
            /*
            var homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.MyAccount.Click();

            var loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("selenium_test");
            loginPage.Password.SendKeys("selenium_test_pwd_11");
            loginPage.Submit.Click();
            */
            //Optimizing Page Object Model
            //1.Initialize Elements within the Constructor
            //2.Binding methods within the PageObject class

            //Use Page class to Init page
            //var homePage = new HomePage(BrowserFactory.Driver);
            //homePage.ClickOnMyAccount();
            Page.Home.ClickOnMyAccount();
            //var loginPage = new LoginPage(BrowserFactory.Driver);
            //loginPage.LoginToApplication("LogInTest");
            Page.Login.LoginToApplication("LoginTest");
            //driver.Close();
            BrowserFactory.CloaseAllDrivers();
        }

    }
}
