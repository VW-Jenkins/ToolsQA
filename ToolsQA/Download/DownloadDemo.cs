using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;
using System.IO.Compression;

namespace ToolsQA.Download
{
    class DownloadDemo
    {
        string currentFile = string.Empty;
        string name = string.Empty;
        bool result = false;

        private IWebDriver _driver;

        [SetUp]
       
        public void Initialize() {
            _driver = new ChromeDriver();
           
        }

        [Test]
        [Category("Download_demo")]
        public void Download_Demo() {
            _driver.Navigate().GoToUrl("file:///C:/Users/v-victw/Desktop/ToolsQA/ToolsQA/Files/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            name = _driver.FindElement(By.LinkText("Sample.zip")).Text;
            _driver.FindElement(By.LinkText("Sample.zip")).Click();
            Task.Delay(5000).Wait();
            string path = @"C:\Users\v-victw\Desktop\ToolsQA\ToolsQA\Files";
            if (Directory.Exists(path))
            {
                bool result = CheckFile(name);
                if (result == true)
                {
                    ExtractFiles();
                }
                else
                {
                    Assert.Fail("The file does not exist");
                }
            }
            else {
                Assert.Fail("The directory or folder does not exist");
            }
        }

        public bool CheckFile(string name) {
            currentFile = @"C:\Users\v-victw\Downloads\" + name;
            if (File.Exists(currentFile))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public void ExtractFiles() {
            string newExtractFolder = @"C:\Users\v-victw\Downloads";
            ZipFile.ExtractToDirectory(currentFile, newExtractFolder);
            VerifyFiles(newExtractFolder);
        }

        public void VerifyFiles(string newExtractFolder) {
            string[] fileEntries = Directory.GetFiles(newExtractFolder);
            List<string> listItemsName = new List<string>();
            for (int i = 0; i < fileEntries.Length; i++) {
                string[] split = fileEntries[i].Split('\\');
                listItemsName.Add(split.Last());
            }
            List<string> originalList = new List<string> { "Sample_1.txt", "Sample_2.txt" };
            //result = originalList.Count == listItemsName.Count && originalList.All(listItemsName.Contains);
            result =  originalList.All(listItemsName.Contains);
            if (result == true)
            {
                Console.WriteLine("The expected files are present.");
                for (int i = 0; i < listItemsName.Count; i++) {
                    currentFile = @"C:\Users\v-victw\Downloads\" + listItemsName[i];
                    File.Delete(currentFile);
                }
                Assert.Pass("The expected files are present");
            }
            else {
                Console.WriteLine("The expected file are not present");
                DeleteFilesAndDirectory();
                Assert.Fail("The expected fiels are not present");

            }
        }

        public void DeleteFilesAndDirectory() {
            if (File.Exists(currentFile)) {
                File.Delete(currentFile);
            }
        }

        [TearDown]
        public void TearDown() {
            _driver.Quit();
        }
    }
}
