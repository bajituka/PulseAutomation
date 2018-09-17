using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using PulseAutomationWeb.PageObjects.Events;
using PulseAutomationWeb.PageObjects.ContactsTab.Events;

namespace PulseAutomationWeb.TestCases.Events
{
    [TestClass]
    public class EventsTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static EventsActivitiesPage eventsActivitiesPage = new EventsActivitiesPage();
        private static EventsNotesPage eventsNotesPage = new EventsNotesPage();
        private static TasksListPage tasksListPage = new TasksListPage();
        private static TasksTemplatesPage tasksTemplatesPage = new TasksTemplatesPage();
        private static TimeEntryPage timeEntryPage = new TimeEntryPage();

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

            int tasksFound = Database.GetTasksCount("script@gmail.com");
            if (tasksFound > 0)
            {
                string deleteTasks = "DELETE FROM dbo.Tasks WHERE AssignedFromId in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteTasks);
            }

            int notesFound = Database.GetNotesCount("script@gmail.com");
            if (notesFound > 0)
            {
                string deleteNotes = "DELETE FROM dbo.Notes WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteNotes);
            }

            int activitiesFound = Database.GetActivitiesCount("script@gmail.com");
            if (notesFound > 0)
            {
                string deleteNotes = "DELETE FROM dbo.Activities WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteNotes);
            }

            int taskTemplatesFound = Database.GetTaskTemplatesCount("script@gmail.com");
            if (taskTemplatesFound > 0)
            {
                string deleteTaskTemplates = "DELETE FROM dbo.TasksTemplates WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')";
                Database.ExecuteQuery(deleteTaskTemplates);
            }

            layout.CleanUpCloseTabs(driver);
        }
        [ClassInitialize]
        public static void GetUrl(TestContext testContext)
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
            PageFactory.InitElements(driver, eventsActivitiesPage);
            PageFactory.InitElements(driver, eventsNotesPage);
            PageFactory.InitElements(driver, tasksListPage);
            PageFactory.InitElements(driver, tasksTemplatesPage);

            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
           // CleanTests();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CleanTests();
            layout.LogOut(driver);
        }

        [TestInitialize]
        public void OpenEventsPage()
        {
            layout.OpenEventsPage(driver);
            Thread.Sleep(10000);
          //  tasksListPage.WaitForGridLoaded(driver);
        }

        [TestCleanup]
        public void CloseAllTabs()
        {
            layout.CloseAllTabs(driver);
        }

        [TestMethod]
        [Description("In Events - Should create, update a task, find it by all filters, then delete it")]
        public void EventsСreateTask()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 5);
            string today = Utilities.CurrentDate();
            Task task = new Task("New task!", "script@gmail.com", "Meeting", "Not Started", null, null, null, today, null, "High", null, "Simple note");
            tasksListPage.AddTask(driver, task);
            tasksListPage.WaitForGridLoaded(driver);
            Thread.Sleep(5000);
            tasksListPage.clearFiltersBtn.Click();
            Thread.Sleep(3000);
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 15);
            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "New task!");
        }
        /*
            tasksListPage.OpenTask(driver);

            tasksListPage.EditTask(driver, "Changed task!");
            tasksListPage.ClearFilters(driver);
            //search by default shown filters
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 5);
            string[] baseValues = { "Changed task!", "script@gmail.com", "script@gmail.com", today, "Simple note" };
            IWebElement[] baseFilters = { tasksListPage.titleFilter, tasksListPage.assigneeFilter, tasksListPage.assignorFilter, tasksListPage.dueDateFilter, tasksListPage.notesFilter };
            IWebElement[] baseFirstRowData = { tasksListPage.titleRow, tasksListPage.assigneeRow, tasksListPage.assignorRow, tasksListPage.dueDateRow, tasksListPage.notesRow };
            for (int index = 0; index < baseValues.Length; index++)
            {
                tasksListPage.FindTaskByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                tasksListPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
            }
            //drag a new filter from column chooser, search by it and then hide
            string[] newColumns = { "Created On" };
            string[] newValues = { today };
            IWebElement[] newFilters = { tasksListPage.createdOnFilter };
            IWebElement[] newFirstRowData = { tasksListPage.createdOnRow };
            IWebElement[] newHeaders = { tasksListPage.createdOnHeader };
            for (int index = 0; index < newValues.Length; index++)
            {
                tasksListPage.ShowColumn(driver, newColumns[index], tasksListPage.titleHeader);
                tasksListPage.FindTaskByInput(driver, newFilters[index], newFirstRowData[index], newValues[index]);
                tasksListPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
                tasksListPage.HideColumn(driver, newHeaders[index]);
            }

            //add a dropdown filter, search by it and hide it
            string[] dropdownColumns = { "Importance", "Task Type" };
            string[] dropdownValues = { "High", "Meeting" };
            IWebElement[] dropdownFilters = { tasksListPage.importanceFilter, tasksListPage.taskTypeFilter };
            IWebElement[] dropdownFirstRowData = { tasksListPage.importanceRow, tasksListPage.taskTypeRow };
            IWebElement[] dropdownHeaders = { tasksListPage.importanceHeader, tasksListPage.taskTypeHeader };

            for (int index = 0; index < dropdownColumns.Length; index++)
            {
                tasksListPage.ShowColumn(driver, dropdownColumns[index], tasksListPage.dueDateHeader);
                tasksListPage.FindTaskByDropdown(driver, dropdownFilters[index], dropdownFirstRowData[index], dropdownValues[index]);
                tasksListPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
                tasksListPage.HideColumn(driver, dropdownHeaders[index]);
            }

            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "Changed task!");
            tasksListPage.DeleteTask(driver);
        }
        */
        [TestMethod]
        [Description("Should create, update a Task Template and find it by all filters")]
        public void EventsCruTaskTemplate()
        {
            string today = Utilities.CurrentDate();
            TaskTemplate taskTemplate = new TaskTemplate("Test Task Template!", "Task Templates are very useful");
            Task taskOne = new Task("First Task", "script@gmail.com", "Meeting", null, null, null, null, null, null, "High", null, "This is a first task of the template");
            Task taskTwo = new Task("Second Task", "script@gmail.com", "Meeting", null, null, null, null, null, null, "High", null, "This is a second task of the template");
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.templateManagementLinkLocator, 5);
            Thread.Sleep(5000);
            tasksTemplatesPage.templateManagementLink.Click();
            Waitings.WaitForElementClickable(driver, TasksTemplatesPage.clearFiltersBtnLocator, 5);
            tasksTemplatesPage.clearFiltersBtn.Click();
            tasksTemplatesPage.AddTaskTemplate(driver, taskTemplate);

            tasksTemplatesPage.AddTaskFromTemplatePage(driver, taskOne);
            Waitings.WaitForElementClickable(driver, TasksListPage.clearFiltersBtnLocator, 5);
            tasksListPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 5);
            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "First Task");

            tasksTemplatesPage.AddTaskFromTemplatePage(driver, taskTwo);
            tasksListPage.ClearFilters(driver);
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 5);
            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "Second Task");

            Utilities.SwitchToTab("Events", driver);
            tasksTemplatesPage.FindTaskTemplateByInput(driver, tasksTemplatesPage.titleFilter, tasksTemplatesPage.titleRow, "Test Task Template!");
            tasksTemplatesPage.OpenTaskTemplate(driver);
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.titleInputLocator, 15);
            tasksTemplatesPage.EditTaskTemplate(driver, "Changed Test Task Template!");
            Waitings.WaitForElementClickable(driver, TasksTemplatesPage.clearFiltersBtnLocator, 5);
            tasksTemplatesPage.ClearFilters(driver);
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.titleFilterLocator, 5);

            string[] baseValues = { "Changed Test Task Template!", today, "script@gmail.com", "Task Templates are very useful" };
            IWebElement[] baseFilters = { tasksTemplatesPage.titleFilter, tasksTemplatesPage.createdOnFilter, tasksTemplatesPage.createdByFilter, tasksTemplatesPage.descriptionFilter };
            IWebElement[] baseFirstRowData = { tasksTemplatesPage.titleRow, tasksTemplatesPage.createdOnRow, tasksTemplatesPage.createdByRow, tasksTemplatesPage.descriptionRow };
            for (int index = 0; index < baseValues.Length; index++)
            {
                tasksTemplatesPage.FindTaskTemplateByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                tasksTemplatesPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
            }
        }

        [TestMethod]
        [Description("Should create, update and delete a filter view in Events - Template Management")]
        public void EventsTemplateManagementCrudFilterView()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.templateManagementLinkLocator, 5);
            tasksTemplatesPage.templateManagementLink.Click();
            Waitings.WaitForElementClickable(driver, TasksTemplatesPage.clearFiltersBtnLocator, 5);
            tasksTemplatesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.savedFilterSelectLocator, 5);
            Waitings.WaitForTextInInput(driver, tasksTemplatesPage.savedFilterSelect, "Default", 5);
            tasksTemplatesPage.SaveViewWithName(driver, "New Events Filter");
            Waitings.WaitForElementClickable(driver, TasksTemplatesPage.clearFiltersBtnLocator, 5);
            tasksTemplatesPage.ClearFilters(driver);
            Utilities.SelectInDropdown(driver, tasksTemplatesPage.savedFilterForClickSelect, "Default");
            Waitings.WaitForLoadingEnds(driver);
            Utilities.SelectInDropdown(driver, tasksTemplatesPage.savedFilterForClickSelect, "New Events Filter");
            Waitings.WaitForLoadingEnds(driver);
            tasksTemplatesPage.DeleteView(driver);
        }

        [TestMethod]
        [Description("In Events - Should create, update a task from template, find it by all filters, then delete it and delete the template. ")]
        public void EventsСrudTaskFromTemplate()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.tasksListLinkLocator, 5);
            string templateName = "Changed Test Task Template!";
            tasksListPage.tasksListLink.Click();
            tasksListPage.AddTaskFromTemplate(driver, templateName);
            tasksListPage.WaitForGridLoaded(driver);
            Thread.Sleep(5000);
            Waitings.WaitForElementClickable(driver, TasksListPage.clearFiltersBtnLocator, 15);
            Thread.Sleep(5000);
            tasksListPage.clearFiltersBtn.Click();
            Thread.Sleep(5000);
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 5);
            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "First Task");
            tasksListPage.ClearFilters(driver);
            Waitings.WaitForLoadingEnds(driver);

            tasksListPage.FindTaskByInput(driver, tasksListPage.titleFilter, tasksListPage.titleRow, "Second Task");
            tasksListPage.ClearFilters(driver);
            Waitings.WaitForLoadingEnds(driver);

            tasksTemplatesPage.templateManagementLink.Click();
            Waitings.WaitForElementClickable(driver, TasksTemplatesPage.clearFiltersBtnLocator, 5);
            tasksTemplatesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, TasksTemplatesPage.titleFilterLocator, 5);
            tasksTemplatesPage.FindTaskTemplateByInput(driver, tasksTemplatesPage.titleFilter, tasksTemplatesPage.titleRow, "Changed Test Task Template!");
            //tasksTemplatesPage.DeleteTaskTemplate(driver);
        }


        [TestMethod]
        [Description("Should create, update and delete a filter view in Events - Task Templates")]
        public void EventsTaskListCrudFilterView()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.tasksListLinkLocator, 10);
            tasksListPage.tasksListLink.Click();
            Waitings.WaitForElementVisible(driver, TasksListPage.savedFilterSelectLocator, 10);
            Waitings.WaitForTextInInput(driver, tasksListPage.savedFilterSelect , "Default", 10);
            Waitings.WaitForElementVisible(driver, TasksListPage.titleFilterLocator, 10);
            tasksListPage.SaveViewWithName(driver, "New filter-Events-Tasks");
            Waitings.WaitForElementClickable(driver, TasksListPage.clearFiltersBtnLocator, 10);
            tasksListPage.clearFiltersBtn.Click();
            Utilities.SelectInDropdown(driver, tasksListPage.savedFilterForClickSelect, "Default");
            Waitings.WaitForLoadingEnds(driver);
            Utilities.SelectInDropdown(driver, tasksListPage.savedFilterForClickSelect, "New filter-Events-Tasks");
            Waitings.WaitForLoadingEnds(driver);
            tasksListPage.DeleteView(driver);
        }

        [TestMethod]
        [Description("In Events - Should create a note")]
        public void EventsСreateNote()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.notesLinkLocator, 5);
            tasksListPage.notesLink.Click();
            string noteName = "New Note from Events";
            eventsNotesPage.AddNote(driver, "High", noteName);
            Thread.Sleep(5000);
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            Thread.Sleep(1000); //иначе падает
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteName);
        }

        [TestMethod]
        [Description("In Events - Should update a note")]
        public void EventsUpdateNote()
        {
            string createNote = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QAEventsNotetoUpdate</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createNote);
            string noteName = "QAEventsNotetoUpdate";
            string noteNameNew = "QAEventsNotetoUpdateNew";
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.notesLinkLocator, 5);
            tasksListPage.notesLink.Click();
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            Thread.Sleep(1000);
            eventsNotesPage.clearFiltersBtn.Click();
            Thread.Sleep(1000);
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteName);
            Waitings.WaitForLoadingEnds(driver);
            eventsNotesPage.OpenNote(driver);
            eventsNotesPage.EditNote(driver, "Low", noteNameNew);
            Thread.Sleep(5000);
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            Thread.Sleep(3000);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteNameNew);
        }

        [TestMethod]
        [Description("In Events - Should delete a note")]
        public void EventsDeleteNote()
        {
            string createNote = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QAEventsNote</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createNote);
            string noteName = "QAEventsNote";

            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.notesLinkLocator, 5);
            tasksListPage.notesLink.Click();
            Waitings.WaitForElementClickable(driver, EventsNotesPage.clearFiltersBtnLocator, 5);
            eventsNotesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsNotesPage.noteFilterLocator, 5);
            eventsNotesPage.FindNoteByInput(driver, eventsNotesPage.noteFilter, eventsNotesPage.noteRow, noteName);
            Waitings.WaitForLoadingEnds(driver);
            eventsNotesPage.DeleteNote(driver);
        }

        [TestMethod]
        [Description("Should create, update and delete a filter view in Events - Notes")]
        public void EventsNotesCrudFilterView()
        {
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.notesLinkLocator, 5);
            tasksListPage.notesLink.Click();
            eventsNotesPage.WaitForGridLoaded(driver);
            Waitings.WaitForTextInInput(driver, eventsNotesPage.savedFilterSelect, "Default", 5);
            eventsNotesPage.SaveViewWithName(driver, "New filter - Events - Notes");
            Utilities.SelectInDropdown(driver, eventsNotesPage.savedFilterForClickSelect, "Default");
            Waitings.WaitForLoadingEnds(driver);
            Utilities.SelectInDropdown(driver, eventsNotesPage.savedFilterForClickSelect, "New filter - Events - Notes");
            Waitings.WaitForLoadingEnds(driver);
            eventsNotesPage.DeleteView(driver);
        }

        [TestMethod]
        [Description("In Events - Should create an activity")]
        public void EventsСreateActivity()
        {
            TimeEntry timentry = new TimeEntry("script@gmail.com", "CIS", "Tigers", "RG", "(WA) Waveaccess", "0.5", null, null, null, null, null, null, null, null, null, null, null, null, null);
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.activitiesLinkLocator, 5);
            tasksListPage.activitiesLink.Click();
            string activityName = "New Activity from Events";
            eventsActivitiesPage.AddActivity(driver, "Hearing", "RSW", activityName);
            Thread.Sleep(5000);
            Waitings.WaitForElementClickable(driver, EventsActivitiesPage.clearFiltersBtnLocator, 5);
            eventsActivitiesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsActivitiesPage.notesFilterLocator, 5);
            eventsActivitiesPage.FindActivityByInput(driver, eventsActivitiesPage.notesFilter, eventsActivitiesPage.notesRow, activityName);
            Waitings.WaitForLoadingEnds(driver);
        }

        [TestMethod]
        [Description("In Events - Should update an activity")]
        public void EventsUpdateActivity()
        {
            string createActivity = "  INSERT INTO [dbo].[Activities] (CreatedById, ContactId, Notes, CreatedAt, UpdatedById, UpdatedAt, TypeId, MatterId, ActivityDate, ActionCodeId) VALUES((SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), null, '<p>Update QA Activity</p>', '2017-04-13 04:49:40.653', (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '2017-04-13 04:49:40.653', (SELECT Id FROM dbo.Dictionaries WHERE Name = 'Faxed'), null, '2017-11-12 21:00:00.000', 1)";
            Database.ExecuteQuery(createActivity);
            string activityName = "Update QA Activity";
            string activityNameNew = "Updated QA Activity";
            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.activitiesLinkLocator, 5);
            tasksListPage.activitiesLink.Click();
            Waitings.WaitForElementClickable(driver, EventsActivitiesPage.clearFiltersBtnLocator, 5);
            eventsActivitiesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsActivitiesPage.notesFilterLocator, 5);
            eventsActivitiesPage.FindActivityByInput(driver, eventsActivitiesPage.notesFilter, eventsActivitiesPage.notesRow, activityName);
            Waitings.WaitForLoadingEnds(driver);
            eventsActivitiesPage.OpenActivity(driver);
            eventsActivitiesPage.EditActivity(driver, "Meeting", activityNameNew);
            Thread.Sleep(5000);
            eventsActivitiesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsActivitiesPage.notesFilterLocator, 5);
            Thread.Sleep(500);
            eventsActivitiesPage.FindActivityByInput(driver, eventsActivitiesPage.notesFilter, eventsActivitiesPage.notesRow, activityNameNew);
        }

        [TestMethod]
        [Description("In Events - Should delete an activity")]
        public void EventsDeleteActivity()
        {
            string createActivity = "  INSERT INTO [dbo].[Activities] (CreatedById, ContactId, Notes, CreatedAt, UpdatedById, UpdatedAt, TypeId, MatterId, ActivityDate, ActionCodeId) VALUES((SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), null, '<p>Delete QA Activity</p>', '2017-04-13 04:49:40.653', (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '2017-04-13 04:49:40.653', (SELECT Id FROM dbo.Dictionaries WHERE Name = 'Faxed'), null, '2017-11-12 21:00:00.000', 1)";
            Database.ExecuteQuery(createActivity);
            string activityName = "Delete QA Activity";

            layout.OpenEventsPage(driver);
            Waitings.WaitForElementClickable(driver, TasksListPage.activitiesLinkLocator, 5);
            tasksListPage.activitiesLink.Click();
            Waitings.WaitForElementClickable(driver, EventsActivitiesPage.clearFiltersBtnLocator, 5);
            eventsActivitiesPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, EventsActivitiesPage.notesFilterLocator, 5);
            eventsActivitiesPage.FindActivityByInput(driver, eventsActivitiesPage.notesFilter, eventsActivitiesPage.notesRow, activityName);
            Waitings.WaitForLoadingEnds(driver);
            eventsActivitiesPage.DeleteActivity(driver);
        }
    }
}
    