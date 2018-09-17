using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.PageObjects.Admin;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace PulseAutomationWeb.TestCases.Admin.DictionariesTests
{
    class ContactTypesTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static AdminLayout admin = new AdminLayout();

        private static IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);

        [ClassInitialize]
        public static void getUrl(TestContext testContext)
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
            PageFactory.InitElements(driver, admin);
            loginPage.Authorize(driver, ConfigurationManager.AppSettings["adminLogin"], ConfigurationManager.AppSettings["password"]);
            layout.CloseAllTabs(driver);
            layout.OpenAdminPage(driver);
        }

        [ClassCleanup]
        public static void Cleanup()
        {


        }

        [TestInitialize]
        public void OpenContactsGrid()
        {

        }

        [TestCleanup]
        public void CloseAllTabs()
        {

        }
    }
}
