using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
namespace OnlineStore.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver {
            get {
                if (driver == null)
                    //throw new NullReferenceException("No existing WebDrive, Should first call the method browser");
                    return driver; // Here return driver need discuss - Victor wang 2017/12/26
                return driver;
            }
            private set {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName) {
            switch (browserName) {
                case "Firefox":
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", driver);
                    }
                    break;
                case "IE":
                    /*
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                    }
                    */
                    break;

                case "Chrome":
                    /*
                    if (Driver == null)
                    {
                        driver = new ChromeDriver(@"C:\PathTo\CHDriverServer");
                        Drivers.Add("Chrome", Driver);
                    }
                    */
                    break;
            }
        }

        public static void LoadApplication(string url) {
            Driver.Url = url;
        }

        public static void CloaseAllDrivers() {
            foreach (var key in Drivers.Keys) {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
