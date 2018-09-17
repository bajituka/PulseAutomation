using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;
using PulseAutomationWeb.PageObjects.ContactsTab.Events;

namespace PulseAutomationWeb.PageObjects.Events
{
    class TasksTemplatesPage : GridActions
    {
        private const string tasksGridLocator = "//pulse-events";

        private const string tasksLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Tasks']]";
        [FindsBy(How = How.XPath, Using = tasksLinkLocator)]
        public IWebElement tasksLink { get; set; }

        private const string tasksListMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Tasks List']";
        [FindsBy(How = How.XPath, Using = tasksListMenuItemLocator)]
        public IWebElement tasksListMenuItem { get; set; }

        public const string templateManagementMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Template Management']";
        [FindsBy(How = How.XPath, Using = templateManagementMenuItemLocator)]
        public IWebElement templateManagementMenuItem { get; set; }

        private const string notesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Notes']]";
        [FindsBy(How = How.XPath, Using = notesLinkLocator)]
        public IWebElement notesLink { get; set; }

        private const string activitiesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Activities']]";
        [FindsBy(How = How.XPath, Using = activitiesLinkLocator)]
        public IWebElement activitiesLink { get; set; }

        private const string tasksListLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Tasks List']]";
        [FindsBy(How = How.XPath, Using = tasksListLinkLocator)]
        public IWebElement tasksListLink { get; set; }

        public const string templateManagementLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Template Management']]";
        [FindsBy(How = How.XPath, Using = templateManagementLinkLocator)]
        public IWebElement templateManagementLink { get; set; }

        private const string tasksViewSelectLocator = "//dx-select-box[parent::div[following-sibling::div[@class='menu-popover add-icon']]]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = tasksViewSelectLocator)]
        public IWebElement tasksViewSelect { get; set; }

        private const string addBtnLocator = "//pulse-events//dx-button[@icon='iconpulse-add']"; 
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        private const string addFromTemplateBtnLocator = "//pulse-tasks//dx-menu";
        [FindsBy(How = How.XPath, Using = addFromTemplateBtnLocator)]
        public IWebElement addFromTemplateBtn { get; set; }
        


        #region grid action controls

        private const string refreshBtnLocator = tasksGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        public const string clearFiltersBtnLocator = tasksGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = tasksGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        public const string savedFilterSelectLocator = tasksGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string savedFilterSelectForClickLocator = tasksGridLocator + saveFilterSelectForClickBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectForClickLocator)]
        public IWebElement savedFilterForClickSelect { get; set; }

        private const string saveFiltersBtnLocator = tasksGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = tasksGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string titleHeaderLocator = "//pulse-events//td[@aria-label='Title Column']";
        [FindsBy(How = How.XPath, Using = titleHeaderLocator)]
        public IWebElement titleHeader { get; set; }

        private const string createdOnHeaderLocator = "//pulse-events//td[@aria-label='Created On Column']";
        [FindsBy(How = How.XPath, Using = createdOnHeaderLocator)]
        public IWebElement createdOnHeader { get; set; }

        private const string createdByHeaderLocator = "//pulse-events//td[@aria-label='Created By Column']";
        [FindsBy(How = How.XPath, Using = createdByHeaderLocator)]
        public IWebElement createdByHeader { get; set; }

        private const string descriptionHeaderLocator = "//pulse-events//td[@aria-label='Description Column']";
        [FindsBy(How = How.XPath, Using = descriptionHeaderLocator)]
        public IWebElement descriptionHeader { get; set; }
        #endregion

        #region grid filters
        public const string titleFilterLocator = "//pulse-events//td[@aria-label='Column Title, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleFilterLocator)]
        public IWebElement titleFilter { get; set; }

        private const string createdOnFilterLocator = "//pulse-events//td[@aria-label='Column Created On, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdOnFilterLocator)]
        public IWebElement createdOnFilter { get; set; }

        private const string createdByFilterLocator = "//pulse-events//td[@aria-label='Column Created By, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdByFilterLocator)]
        public IWebElement createdByFilter { get; set; }

        private const string descriptionFilterLocator = "//pulse-events//td[@aria-label='Column Description, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = descriptionFilterLocator)]
        public IWebElement descriptionFilter { get; set; }
        #endregion

        #region first row data
        private const string titleRowLocator = "(//pulse-events//td[contains(@aria-label, 'Column Title, Value')])[1]";
        [FindsBy(How = How.XPath, Using = titleRowLocator)]
        public IWebElement titleRow { get; set; }

        private const string createdOnRowLocator = "(//pulse-events//td[contains(@aria-label, 'Column Created On, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdOnRowLocator)]
        public IWebElement createdOnRow { get; set; }

        private const string createdByRowLocator = "(//pulse-events//td[contains(@aria-label, 'Column Created By, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdByRowLocator)]
        public IWebElement createdByRow { get; set; }

        private const string descriptionRowLocator = "(//pulse-events//td[contains(@aria-label, 'Column Description, Value')])[1]";
        [FindsBy(How = How.XPath, Using = descriptionRowLocator)]
        public IWebElement descriptionRow { get; set; }
        #endregion

        #region task template form

        public const string titleInputLocator = "//div[child::label[text()='Title']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleInputLocator)]
        public IWebElement titleInput { get; set; }

        private const string descriptionFieldLocator = "//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = descriptionFieldLocator)]
        public IWebElement descriptionField { get; set; }

        private const string saveBtnLocator = "//pulse-events//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }
        #endregion

        #region task edit form


        private const string titleTaskInputLocator = "//div[child::label[text()='Title']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleTaskInputLocator)]
        public IWebElement titleTaskInput { get; set; }

        private const string taskTypeSelectLocator = "//pulse-tasks//dx-select-box[preceding::label[1][text()='Task Type']]";
        [FindsBy(How = How.XPath, Using = taskTypeSelectLocator)]
        public IWebElement taskTypeSelect { get; set; }

        private const string statusSelectLocator = "//pulse-tasks//dx-select-box[preceding::label[1][text()='Status']]";
        [FindsBy(How = How.XPath, Using = statusSelectLocator)]
        public IWebElement statusSelect { get; set; }

        private const string clientContactInputLocator = "//input[not(@type='hidden')][preceding::label[1][text()='Client / Contact']]";
        [FindsBy(How = How.XPath, Using = clientContactInputLocator)]
        public IWebElement clientContactInput { get; set; }

        private const string matterInputLocator = "//input[not(@type='hidden')][preceding::label[1][text()='Matter']]";
        [FindsBy(How = How.XPath, Using = matterInputLocator)]
        public IWebElement matterInput { get; set; }

        private const string assigneeInputLocator = "//dx-text-box//input[not(@type='hidden')][preceding::label[1][text()='Assignee']]";
        [FindsBy(How = How.XPath, Using = assigneeInputLocator)]
        public IWebElement assigneeInput { get; set; }

        private const string assignorInputLocator = "//input[not(@type='hidden')][preceding::label[1][text()='Assignor']]";
        [FindsBy(How = How.XPath, Using = assignorInputLocator)]
        public IWebElement assignorInput { get; set; }

        private const string dueDateInputLocator = "//input[@class='dx-texteditor-input'][preceding::label[1][text()='Due Date']]";
        [FindsBy(How = How.XPath, Using = dueDateInputLocator)]
        public IWebElement dueDateInput { get; set; }

        private const string reminderDaysInputLocator = "//div[child::label[text()='Reminder Days']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = reminderDaysInputLocator)]
        public IWebElement reminderDaysInput { get; set; }

        private const string dateCompletedInputLocator = "//dx-date-box[preceding::label[1][text()='Date Completed']]";
        [FindsBy(How = How.XPath, Using = dateCompletedInputLocator)]
        public IWebElement dateCompletedInput { get; set; }

        private const string importanceSelectLocator = "//pulse-tasks//dx-select-box[preceding::label[1][text()='Importance']]";
        [FindsBy(How = How.XPath, Using = importanceSelectLocator)]
        public IWebElement importanceSelect { get; set; }

        private const string dependentTaskInputLocator = "//input[not(@type='hidden')][preceding::label[1][text()='Dependent Task']]";
        [FindsBy(How = How.XPath, Using = dependentTaskInputLocator)]
        public IWebElement dependentTaskInput { get; set; }

        private const string notesFieldLocator = "//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = notesFieldLocator)]
        public IWebElement notesField { get; set; }

        private const string templateSelectLocator = "//pulse-tasks//dx-select-box[preceding::label[1][text()='Template']]";
        [FindsBy(How = How.XPath, Using = templateSelectLocator)]
        public IWebElement templateSelect { get; set; }

        private const string applyBtnLocator = "//pulse-tasks//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = applyBtnLocator)]
        public IWebElement applyBtn { get; set; }
        #endregion
        public void ShowColumn(IWebDriver driver, string columnName, IWebElement targetElement)
        {
            ShowColumn(driver, tasksGridLocator, columnName, targetElement);
        }
        public void HideColumn(IWebDriver driver, IWebElement column)
        {
            HideColumn(driver, tasksGridLocator, column);
        }
        public void AddTaskTemplate(IWebDriver driver, TaskTemplate taskTemplate)
        {
            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Thread.Sleep(200);
            Waitings.WaitForElementClickable(driver, titleInputLocator, 2);
            titleInput.SendKeys(taskTemplate.Title);
            Thread.Sleep(200);
            if (taskTemplate.Text != null) descriptionField.SendKeys(taskTemplate.Text);
            Thread.Sleep(200);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
        public void AddTaskFromTemplatePage(IWebDriver driver, Task task)
        {
            Thread.Sleep(1000);
            Waitings.WaitForElementClickable(driver, addFromTemplateBtnLocator, 10);
            addFromTemplateBtn.Click();
            Thread.Sleep(200);
            Waitings.WaitForElementClickable(driver, statusSelectLocator, 2);
            titleTaskInput.SendKeys(task.Title);
            if (task.TaskType != null) Utilities.SelectInDropdown(driver, taskTypeSelect, task.TaskType);
            Thread.Sleep(300);
            Utilities.SelectInAutocompletePopup(driver, assigneeInput, task.Assignee);
            if (task.Status != null) Utilities.SelectInDropdown(driver, statusSelect, task.Status);
            if (task.ClientContact != null) Utilities.SelectInAutocomplete(driver, clientContactInput, task.ClientContact);
            if (task.Matter != null) Utilities.SelectInAutocomplete(driver, matterInput, task.Matter);
            if (task.Assignor != null)
            {
                assignorInput.Clear();
                Utilities.SelectInAutocomplete(driver, assignorInput, task.Assignor);
            }
            if (task.DueDate != null) dueDateInput.SendKeys(task.DueDate);
            if (task.ReminderDays != null) reminderDaysInput.SendKeys(task.ReminderDays);
            if (task.Importance != null) Utilities.SelectInDropdown(driver, importanceSelect, task.Importance);
            if (task.DependentTask != null) Utilities.SelectInAutocomplete(driver, dependentTaskInput, task.DependentTask);
            Utilities.MoveToElement(driver, notesField);
            if (task.Text != null) notesField.SendKeys(task.Text);
            Thread.Sleep(200);
            applyBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
        public void OpenTaskTemplate(IWebDriver driver)
        {
            OpenEntryLeftClick(driver, tasksGridLocator);
            Thread.Sleep(1000);
        }

        public void FindTaskTemplateByInput(IWebDriver driver, IWebElement taskFilter, IWebElement taskRow, string value)
        {
            FindEntryByInput(driver, taskFilter, taskRow, value);
        }

        public void FindTaskTemplateByDropdown(IWebDriver driver, IWebElement taskFilter, IWebElement taskRow, string value)
        {
            FindEntryByDropdown(driver, taskFilter, taskRow, value);
        }
        public void EditTaskTemplate(IWebDriver driver, string text)
        {
            titleInput.Clear();
            Thread.Sleep(500);
            descriptionField.Click();
            Thread.Sleep(500);
            titleInput.SendKeys(text);
            Thread.Sleep(500);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
        public void DeleteTaskTemplate(IWebDriver driver)
        {
            DeleteEntry(driver, tasksGridLocator);
        }

        public void ClearFilters(IWebDriver driver)
        {
            IWebElement[] filtersArray = { titleFilter, createdOnFilter };
            ClearFilters(driver, tasksGridLocator, filtersArray);
        }
        public void SaveView(IWebDriver driver)
        {
            SaveView(driver, tasksGridLocator);
        }

        public void SaveViewWithName(IWebDriver driver, string viewName)
        {
            SaveViewWithName(driver, tasksGridLocator, viewName);
        }

        public void DeleteView(IWebDriver driver)
        {
            DeleteView(driver, tasksGridLocator);
            Waitings.WaitForTextInInput(driver, savedFilterSelect, "Default", 5);
        }
        public void WaitForGridLoaded(IWebDriver driver)
        {
            WaitForGridLoaded(driver, addBtnLocator, titleHeaderLocator, createdByFilterLocator);
        }

    }
}
