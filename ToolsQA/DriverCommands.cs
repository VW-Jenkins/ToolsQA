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
    class DriverCommands
    {
        [Test]
        [Category("DriverComamnds")]
        public void DriverComamnds_Basic() {
            IWebDriver drive = new FirefoxDriver();
            drive.Url = "http://wwww.demoqa.com";

            string Title = drive.Title;
            int TitleLength = drive.Title.Length;

            Console.WriteLine("Title of the page is :" + Title);
            Console.WriteLine("Length of the page is :" + TitleLength);

            String PageURL = drive.Url;
            int URLLength = PageURL.Length;
            Console.WriteLine("URL of the page is :" + PageURL);
            Console.WriteLine("Length of the URL is :" + URLLength);

            string PageSource = drive.PageSource;
            int PageSourceLength = PageSource.Length;
            Console.WriteLine("Page source of the page is :" + PageSource);
            Console.WriteLine("Length of the Upage Source is :" + PageSourceLength);

            drive.Quit();

        }

    }
}
