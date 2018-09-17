
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.PageObjects.Calendar;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace PulseAutomationWeb.TestCases.Contacts
{
    [TestClass]
    public class CalendarTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static CalendarPage calendarPage = new CalendarPage();

        private static IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);

        public static void CleanTests()
        {
            try
            {
                layout.CleanUpCloseTabs(driver);
            }
            catch (Exception)
            {
                Waitings.WaitForElementClickable(driver, Layout.overlayPopupCloseBtnLocator, 5);
                layout.overlayPopupCloseBtn.Click();
                ////Thread.Sleep(500);
                layout.CleanUpCloseTabs(driver);
            }
            layout.CleanUpCloseTabs(driver);
        }

        [ClassInitialize]
        public static void getUrl(TestContext testContext)
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
            PageFactory.InitElements(driver, calendarPage);
            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            CleanTests();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CleanTests();
            layout.LogOut(driver);
        }
       
        [TestInitialize]
        public void OpenCalendar()
        {
            //// Thread.Sleep(3000);
            layout.OpenCalendarPage(driver);
            ////Thread.Sleep(3000);
        }

        [TestCleanup]
        public void CloseAllTabs()
        {

        }

        [TestMethod]
        [Description("Should create an appointment")]
        public void CreateAppointment()
        {
            string today = Utilities.CurrentDate();
            layout.OpenCalendarPage(driver);
            Appointment appointment = new Appointment("QA Meeting", null, null, "Alexander.Griciuk@DCTestDomain.com", null, null, null, "Lunch", "(WA) Waveaccess", null, null, null, "10 Emerging Trends in Software Testing", null, null, null);
            calendarPage.AddAppointment(driver, appointment);
        }
        /*
        [TestMethod]
        [Description("Should update an appointment")]
        public void UpdateAppointment()
        {
            Database.ExecuteUpdateAppointment();
            layout.OpenCalendarPage(driver);
            Waitings.WaitForElementClickable(driver, CalendarPage.clearFiltersBtnLocator, 5);
            calendarPage.clearFiltersBtn.Click();
            calendarPage.DeleteAppointment(driver, "TestQA Meeting to Update");
        }
        */

        [TestMethod]
        [Description("Should delete an appointment")]
        public void DeleteAppointment()
        {
            Database.ExecuteDeleteAppointment();
            layout.OpenCalendarPage(driver);
            Waitings.WaitForElementClickable(driver, CalendarPage.clearFiltersBtnLocator, 5);
            calendarPage.clearFiltersBtn.Click();
            Thread.Sleep(7000);
            calendarPage.DeleteAppointment(driver, "TestQA Meeting to Delete");
        }
    }
}
    