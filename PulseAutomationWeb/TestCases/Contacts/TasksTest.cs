
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

namespace PulseAutomationWeb.TestCases.Contacts
{
    [TestClass]
    public class TasksTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static ContactsGridPage contactsGridPage = new ContactsGridPage();
        private static ContactsCreationPage contactCreationPage = new ContactsCreationPage();
        private static ContactLayout contactLayout = new ContactLayout();
        private static TasksPage tasksPage = new TasksPage();

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

            string[] testPersons = { "Giovanni" };
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

            int tasksFound = Database.GetTasksCount("script@gmail.com");
            if (tasksFound > 0)
            {
                string deleteTasks = "DELETE FROM dbo.Tasks WHERE AssignedFromId in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteTasks);
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
            PageFactory.InitElements(driver, tasksPage);
            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
          //layout.CloseAllTabs(driver);
           // CleanTests();
            Person giovanni = new Person("Giovanni", "Qataskiani", "Mr.");
            layout.OpenContactsGrid(driver);
            contactsGridPage.OpenCreationFormFor("Person", driver);
            contactCreationPage.CreatePerson(driver, giovanni);
            Thread.Sleep(1000);
            contactLayout.NavigateTo(driver, contactLayout.eventsLink, contactLayout.tasksMenuItem);
            Thread.Sleep(1000);
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

        [TestMethod]
        [Description("Should create, update a task, find it by all filters, then delete it")]
        public void ContactEventsСrudTask()
        {
            string today = Utilities.CurrentDate();

//            contactLayout.NavigateTo(driver, contactLayout.eventsLink, contactLayout.tasksMenuItem);
            Task task = new Task("Test task", "script@gmail.com", "Meeting", "Not Started", null, null, null, today, null, "High", null, "Simple note");
            tasksPage.AddTask(driver, task);
            tasksPage.FindTaskByInput(driver, tasksPage.titleFilter, tasksPage.titleRow, "Test task");
            tasksPage.OpenTask(driver);
            tasksPage.EditTask(driver, "Changed task");
            tasksPage.ClearFilters(driver);
            tasksPage.DeleteTask(driver);
        }

        [TestMethod]
        [Description("Should create a task and find it by all filters")]
        public void ContactEventsFindTask()
        {
            string today = Utilities.CurrentDate();
            tasksPage.ClearFilters(driver);
            Task task = new Task("Changed task", "script@gmail.com", "Meeting", "Not Started", null, null, null, today, null, "High", null, "Simple note");
            tasksPage.AddTask(driver, task);
            //search by default shown filters
            string[] baseValues = { "Changed task", "script@gmail.com", "script@gmail.com", today, "Simple note" };
            IWebElement[] baseFilters = { tasksPage.titleFilter, tasksPage.assigneeFilter, tasksPage.assignorFilter, tasksPage.dueDateFilter, tasksPage.notesFilter };
            IWebElement[] baseFirstRowData = { tasksPage.titleRow, tasksPage.assigneeRow, tasksPage.assignorRow, tasksPage.dueDateRow, tasksPage.notesRow };
            for (int index = 0; index < baseValues.Length; index++)
            {
                tasksPage.FindTaskByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                tasksPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
            }
            //drag a new filter from column chooser, search by it and then hide 
            string[] newColumns = { "Created On" };
            string[] newValues = { today };
            IWebElement[] newFilters = { tasksPage.createdOnFilter };
            IWebElement[] newFirstRowData = { tasksPage.createdOnRow};
            IWebElement[] newHeaders = { tasksPage.createdOnHeader };
            for (int index = 0; index < newValues.Length; index++)
            {
                Thread.Sleep(1000);
                tasksPage.ShowColumn(driver, newColumns[index], tasksPage.notesHeader);
                tasksPage.FindTaskByInput(driver, newFilters[index], newFirstRowData[index], newValues[index]);
                Thread.Sleep(500);
                tasksPage.ClearFilters(driver);
                Thread.Sleep(500);
                Waitings.WaitForLoadingEnds(driver);
                tasksPage.HideColumn(driver, newHeaders[index]);
            }

            //add a dropdown filter, search by it and hide it
            string[] dropdownColumns = { "Importance", "Task Type" };
            string[] dropdownValues = { "High", "Meeting" };
            IWebElement[] dropdownFilters = { tasksPage.importanceFilter, tasksPage.taskTypeFilter };
            IWebElement[] dropdownFirstRowData = { tasksPage.importanceRow,  tasksPage.taskTypeRow };
            IWebElement[] dropdownHeaders = { tasksPage.importanceHeader,  tasksPage.taskTypeHeader };

            for (int index = 0; index < dropdownColumns.Length; index++)
            {
                tasksPage.ShowColumn(driver, dropdownColumns[index], tasksPage.dueDateHeader);
                tasksPage.FindTaskByDropdown(driver, dropdownFilters[index], dropdownFirstRowData[index], dropdownValues[index]);
                tasksPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
                tasksPage.HideColumn(driver, dropdownHeaders[index]);
            }
        }
/*
        [TestMethod]
        [Description("Should create, update a task, find it by all filters, then delete it")]
        public void ContactEventsCompleteTask()
        {
            string today = Utilities.CurrentDate();

            Task task = new Task("Need to make this task completed", "script@gmail.com", "Meeting", "Not Started", null, null, null, today, today, null, "High", "Email", null, "Simple note");
            tasksPage.AddTask(driver, task);
            tasksPage.FindTaskByInput(driver, tasksPage.titleFilter, tasksPage.titleRow, "Need to make this task completed");
            Thread.Sleep(500);
            tasksPage.CompleteTask(driver);
            Utilities.SelectInDropdown(driver, tasksPage.tasksStatusSelect, "Complete");
            Thread.Sleep(1000);
            tasksPage.FindTaskByInput(driver, tasksPage.titleFilter, tasksPage.titleRow, "Need to make this task completed");
            tasksPage.ClearFilters(driver);
            tasksPage.DeleteTask(driver);
        }
        */
    }
}
    