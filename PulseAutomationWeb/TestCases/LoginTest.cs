using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PulseAutomationWeb.TestCases
{
    /*
    [TestClass]
    public class TestLoginPage
    {
        private LoginPage loginPage = new LoginPage();
        private Layout layout = new Layout();
        IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);

        [TestInitialize]
        public void getUrl()
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            layout.logOut(driver);
            driver.Quit();
        }

        [TestMethod]
        public void should_login_with_correct_credentials()
        {
            Assert.AreEqual("Pulse", driver.Title);
            loginPage.userNameInput.SendKeys(ConfigurationManager.AppSettings["login"]);
            loginPage.passwordInput.SendKeys(ConfigurationManager.AppSettings["password"]);
            loginPage.loginBtn.Click();
            Waitings.WaitForElementLocated(driver, "//ul[@class='left-menu']/li[1]", 30);
            
        }
        
    }
    */
}
