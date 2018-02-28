using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
//using extension commands
using OnlineStore.Extensions;
namespace OnlineStore.PageObjects
{
    public class HomePage
    {
        //private IWebDriver driver;

        [FindsBy(How =How.Id,Using = "account")]
        [CacheLookup]
        private IWebElement MyAccount { get; set; }

        //Using the Page Generator, T -> Pager class
        /*
        public HomePage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        */
        public void ClickOnMyAccount() {
            //MyAccount.Click();
            MyAccount.ClickOnIt("Login Account");
        }
    }
}
