using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OnlineStore.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;
namespace OnlineStore.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new() {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        //Page class need public level
        public static HomePage Home
        {
            get {return GetPage<HomePage>(); }
        }
        public static LoginPage Login {
            get { return GetPage<LoginPage>(); }
        }
    }
}
