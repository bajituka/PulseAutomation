
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
    public class NotesTest
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
                Waitings.WaitForElementClickable(driver, Layout.overlayPopupCloseBtnLocator, 5);
                layout.overlayPopupCloseBtn.Click();
                layout.CleanUpCloseTabs(driver);
            }

            string[] testPersons = { "QAFirstNameForNotes", "QAFirstName", "QAFirstNameNew", "QAFirstNameNew", "QAFirstNameFoPrint", "QAFirstNameDeleteNote" };
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
            layout.CleanUpCloseTabs(driver);

            int notesFound = Database.GetNotesCount("script@gmail.com");
            if (notesFound > 0)
            {
                string deleteNotes = "DELETE FROM dbo.Notes WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteNotes);
            }
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
            PageFactory.InitElements(driver, tasksListPage);
            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            //layout.CleanUpCloseTabs(driver);
           // CleanTests();

            string createUserForNotesTest = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstNameForNotes', 'QALastNameForNotes', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createUserForNotesTest);
            string createNoteForUpdating = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QA Contacts Note to be updated</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createNoteForUpdating);
            string noteUpdate1 = "Update dbo.Notes set ContactId = (select max(id) from dbo.Contacts) where Value = '<p>QA Contacts Note to be updated</p>'";
            Database.ExecuteQuery(noteUpdate1);
            string createNoteForDeleting = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QA Contacts Note to be deleted</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createNoteForDeleting);
            string noteUpdate2 = "Update dbo.Notes set ContactId = (select max(id) from dbo.Contacts) where Value = '<p>QA Contacts Note to be deleted</p>'";
            Database.ExecuteQuery(noteUpdate2);
            string createNoteForFinding = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QA Contacts Note to be found</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createNoteForFinding);
            string noteUpdate3 = "Update dbo.Notes set ContactId = (select max(id) from dbo.Contacts) where Value = '<p>QA Contacts Note to be found</p>'";
            Database.ExecuteQuery(noteUpdate3);

            string contactName = "Notes";

            layout.OpenContactsGrid(driver);
            Waitings.WaitForElementClickable(driver, ContactsGridPage.clearFiltersBtnLocator, 5);
            contactsGridPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, ContactsGridPage.firstNameFilterLocator, 5);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, contactName);
            contactsGridPage.OpenContact(driver);
            Waitings.WaitForElementVisible(driver, ContactLayout.eventsLinkLocator, 5);
            contactLayout.NavigateTo(driver, contactLayout.eventsLink, contactLayout.notesMenuItem);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CleanTests();
            layout.LogOut(driver);
        }
        
        [TestInitialize]
        public void OpenNotesPage()
        {

        }

        [TestCleanup]
        public void CloseAllTabs()
        {

        }

        [TestMethod]
        [Description("Should create note from a contact")]
        public void ContactEventsCreateNote()
        {
            string noteText = "QA Contacts Note to be created";
            string today = Utilities.CurrentDate();

            eventsNotesPage.AddNote(driver, "Low", noteText);
            Thread.Sleep(3000);
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteText);
        }

        [TestMethod]
        [Description("Should create update note from a contact")]
        public void ContactEventsUpdateNote()
        {
            string noteText = "QA Contacts Note to be updated";
            string noteTextNew = "QA Contacts Note that was updated";
            string today = Utilities.CurrentDate();

            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteText);
            eventsNotesPage.OpenNote(driver);
            eventsNotesPage.EditNote(driver, "Medium", noteTextNew);
            Thread.Sleep(1000);
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.ClearFilters(driver);
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteTextNew);
        }

        [TestMethod]
        [Description("Should delete a note from a contacts")]
        public void ContactEventsDeleteNote()
        {
            string noteText = "QA Contacts Note to be deleted";
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteText);
            eventsNotesPage.DeleteNote(driver);
        }

        [TestMethod]
        [Description("Should find a note by all filters in a contact")]
        public void ContactEventsFindNote()
        {
            string noteText = "QA Contacts Note to be found";
            string authorName = "script@gmail.com";
            //string today = Utilities.CurrentDate();
            IWebElement[] dropdownFilters = { eventsNotesPage.privacyFilter, eventsNotesPage.priorityFilter };
            IWebElement[] dropdownFirstRowData = { eventsNotesPage.privacyRow, eventsNotesPage.priorityRow };
            IWebElement[] inputFilters = {  eventsNotesPage.createdByFilter, eventsNotesPage.noteFilter };
            IWebElement[] inputFirstRowData = { eventsNotesPage.createdByRow, eventsNotesPage.noteRow };
            string[] dropdownValues = { "Global", "Medium" };
            string[] inputValues = { authorName, noteText };

            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            for (int index = 0; index < dropdownValues.Length; index++)
            {
                eventsNotesPage.clearFiltersBtn.Click();
                eventsNotesPage.FindNoteByDropdown(driver, dropdownFilters[index], dropdownFirstRowData[index], dropdownValues[index]);
                Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
                eventsNotesPage.clearFiltersBtn.Click();
                Waitings.WaitForLoadingEnds(driver);
            }
            for (int index = 0; index < inputValues.Length; index++)
            {
                eventsNotesPage.clearFiltersBtn.Click();
                eventsNotesPage.FindNoteByInput(driver, inputFilters[index], inputFirstRowData[index], inputValues[index]);
                Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
                eventsNotesPage.clearFiltersBtn.Click();
                Waitings.WaitForLoadingEnds(driver);
            }
        }

        [TestMethod]
        [Description("Should create a note from Quick Add Menu")]
        public void CreateNoteFromQuickAddMenu()
        {
            string noteText = "QA this note was created from Quick Add Menu";
            layout.AddNoteFromQuickAddMenu(driver, "Low", noteText);
            Waitings.WaitForSuccessMsg(driver);
        }
    }
}
