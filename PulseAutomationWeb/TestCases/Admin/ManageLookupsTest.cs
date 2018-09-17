
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.PageObjects.ContactsTab;
using PulseAutomationWeb.PageObjects.ContactsTab.Events;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using PulseAutomationWeb.PageObjects.Events;

namespace PulseAutomationWeb.TestCases.Contacts
{
    [TestClass]
    public class ManageLookupsTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static ContactsGridPage contactsGridPage = new ContactsGridPage();
        private static ContactsCreationPage contactCreationPage = new ContactsCreationPage();
        private static ContactLayout contactLayout = new ContactLayout();
        private static EventsNotesPage eventsNotesPage = new EventsNotesPage();
        private static TasksListPage tasksListPage = new TasksListPage();

        private static IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);

        public static void CleanTests()
        {
            try
            {
                layout.CleanUpCloseTabs(driver);
            }
            catch (Exception)
            {
                Thread.Sleep(500);
                layout.overlayPopupCloseBtn.Click();
                Thread.Sleep(500);
                layout.CleanUpCloseTabs(driver);
            }

            string[] testPersons = { "Marquise" };
            foreach (string key in testPersons)
            {
                int personsFound = Database.GetPersonsCount(key);
                if (personsFound > 0)
                {
                    layout.OpenContactsGrid(driver);
                    contactsGridPage.ClearFilters(driver);
                    contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, key);
                    while (personsFound != 0)
                    {
                        contactsGridPage.DeleteContact(driver);
                        personsFound--;
                    }
                }
            }

            int notesFound = Database.GetNotesCount("script@gmail.com");
            if (notesFound > 0)
            {
                string deleteNotes = "DELETE FROM dbo.Notes WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteNotes);
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
            PageFactory.InitElements(driver, contactsGridPage);
            PageFactory.InitElements(driver, contactCreationPage);
            PageFactory.InitElements(driver, contactLayout);
            PageFactory.InitElements(driver, eventsNotesPage);
            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            layout.CleanUpCloseTabs(driver);
            CleanTests();
            Person marquise = new Person("Marquise", "Desanto", "Mr.");
            layout.OpenContactsGrid(driver);
            contactsGridPage.OpenCreationFormFor("Person", driver);
            contactCreationPage.CreatePerson(driver, marquise);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CleanTests();
            layout.LogOut(driver);
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
