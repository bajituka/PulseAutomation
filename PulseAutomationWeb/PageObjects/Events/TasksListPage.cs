using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;
using PulseAutomationWeb.PageObjects.ContactsTab.Events;

namespace PulseAutomationWeb.PageObjects.Events
{
    class TasksListPage : GridActions
    {
        private const string tasksGridLocator = "//pulse-tasks";

        private const string tasksLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Notes']]";
        [FindsBy(How = How.XPath, Using = tasksLinkLocator)]
        public IWebElement tasksLink { get; set; }

        private const string tasksListMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Tasks List']";
        [FindsBy(How = How.XPath, Using = tasksListMenuItemLocator)]
        public IWebElement tasksListMenuItem { get; set; }

        private const string templateManagementMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Template Management']";
        [FindsBy(How = How.XPath, Using = templateManagementMenuItemLocator)]
        public IWebElement templateManagementMenuItem { get; set; }

        public const string notesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Notes']]";
        [FindsBy(How = How.XPath, Using = notesLinkLocator)]
        public IWebElement notesLink { get; set; }

        public const string activitiesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Activities']]";
        [FindsBy(How = How.XPath, Using = activitiesLinkLocator)]
        public IWebElement activitiesLink { get; set; }

        public const string tasksListLinkLocator = "//pulse-events//div[@class='case-top-menu']//div[@role='menuitem'][descendant::span[text()='Tasks']]";
        [FindsBy(How = How.XPath, Using = tasksListLinkLocator)]
        public IWebElement tasksListLink { get; set; }

        private const string templateManagementLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Template Management']]";
        [FindsBy(How = How.XPath, Using = templateManagementLinkLocator)]
        public IWebElement templateManagementLink { get; set; }

        private const string tasksViewSelectLocator = "//dx-select-box[parent::div[following-sibling::div[@class='menu-popover add-icon']]]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = tasksViewSelectLocator)]
        public IWebElement tasksViewSelect { get; set; }

        private const string tasksStatusSelectLocator = "//dx-select-box[@ng-reflect-value='2']//div[@class='dx-dropdowneditor-input-wrapper dx-selectbox-container']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = tasksStatusSelectLocator)]
        public IWebElement tasksStatusSelect { get; set; }

        private const string addBtnLocator = "//pulse-tasks//dx-menu[descendant::span[text()='Add']]";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        private const string newBtnLocator = "//div[@class='dx-submenu']//div[@class='dx-item-content dx-menu-item-content'][descendant::span[text()='New']]";
        [FindsBy(How = How.XPath, Using = newBtnLocator)]
        public IWebElement newBtn { get; set; }

        private const string newFromTemplateBtnLocator = "//div[@class='dx-submenu']//div[@class='dx-item-content dx-menu-item-content'][descendant::span[text()='New From Template']]";
        [FindsBy(How = How.XPath, Using = newFromTemplateBtnLocator)]
        public IWebElement newFromTemplateBtn { get; set; }

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
        private const string titleHeaderLocator = "//pulse-tasks//td[@aria-label='Title Column']";
        [FindsBy(How = How.XPath, Using = titleHeaderLocator)]
        public IWebElement titleHeader { get; set; }

        private const string assigneeHeaderLocator = "//pulse-tasks//td[@aria-label='Assignee Column']";
        [FindsBy(How = How.XPath, Using = assigneeHeaderLocator)]
        public IWebElement assigneeHeader { get; set; }

        private const string assignorHeaderLocator = "//pulse-tasks//td[@aria-label='Assignor Column']";
        [FindsBy(How = How.XPath, Using = assignorHeaderLocator)]
        public IWebElement assignorHeader { get; set; }

        private const string dueDateHeaderLocator = "//pulse-tasks//td[@aria-label='Due Date Column']";
        [FindsBy(How = How.XPath, Using = dueDateHeaderLocator)]
        public IWebElement dueDateHeader { get; set; }

        private const string notesHeaderLocator = "//pulse-tasks//td[@aria-label='Notes Column']";
        [FindsBy(How = How.XPath, Using = notesHeaderLocator)]
        public IWebElement notesHeader { get; set; }

        private const string createdOnHeaderLocator = "//pulse-tasks//td[@aria-label='Created On Column']";
        [FindsBy(How = How.XPath, Using = createdOnHeaderLocator)]
        public IWebElement createdOnHeader { get; set; }

        private const string importanceHeaderLocator = "//pulse-tasks//td[@aria-label='Importance Column']";
        [FindsBy(How = How.XPath, Using = importanceHeaderLocator)]
        public IWebElement importanceHeader { get; set; }

        private const string reminderDaysHeaderLocator = "//pulse-tasks//td[@aria-label='Reminder Days Column']";
        [FindsBy(How = How.XPath, Using = reminderDaysHeaderLocator)]
        public IWebElement reminderDaysHeader { get; set; }

        private const string statusHeaderLocator = "//pulse-tasks//td[@aria-label='Status Column']";
        [FindsBy(How = How.XPath, Using = statusHeaderLocator)]
        public IWebElement statusHeader { get; set; }

        private const string taskTypeHeaderLocator = "//pulse-tasks//td[@aria-label='Task Type Column']";
        [FindsBy(How = How.XPath, Using = taskTypeHeaderLocator)]
        public IWebElement taskTypeHeader { get; set; }

        #endregion

        #region grid filters
        private const string orderFilterLocator = "//pulse-tasks//td[@aria-label='Column Order, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = orderFilterLocator)]
        public IWebElement orderFilter { get; set; }

        public const string titleFilterLocator = "//pulse-tasks//td[@aria-label='Column Title, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleFilterLocator)]
        public IWebElement titleFilter { get; set; }

        private const string assigneeFilterLocator = "//pulse-tasks//td[@aria-label='Column Assignee, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = assigneeFilterLocator)]
        public IWebElement assigneeFilter { get; set; }

        private const string assignorFilterLocator = "//pulse-tasks//td[@aria-label='Column Assignor, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = assignorFilterLocator)]
        public IWebElement assignorFilter { get; set; }

        private const string dueDateFilterLocator = "//pulse-tasks//td[@aria-label='Column Due Date, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = dueDateFilterLocator)]
        public IWebElement dueDateFilter { get; set; }

        private const string notesFilterLocator = "//pulse-tasks//td[@aria-label='Column Notes, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = notesFilterLocator)]
        public IWebElement notesFilter { get; set; }

        private const string createdOnFilterLocator = "//pulse-tasks//td[@aria-label='Column Created On, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdOnFilterLocator)]
        public IWebElement createdOnFilter { get; set; }

        private const string importanceFilterLocator = "//pulse-tasks//td[@aria-label='Column Importance, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = importanceFilterLocator)]
        public IWebElement importanceFilter { get; set; }

        private const string reminderDaysFilterLocator = "//pulse-tasks//td[@aria-label='Column Reminder Days, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = reminderDaysFilterLocator)]
        public IWebElement reminderDaysFilter { get; set; }

        private const string statusFilterLocator = "//pulse-tasks//td[@aria-label='Column Status, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = statusFilterLocator)]
        public IWebElement statusFilter { get; set; }

        private const string taskTypeFilterLocator = "//pulse-tasks//td[@aria-label='Column Task Type, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = taskTypeFilterLocator)]
        public IWebElement taskTypeFilter { get; set; }
        #endregion

        #region first row data
        private const string orderRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Order, Value')])[1]";
        [FindsBy(How = How.XPath, Using = orderRowLocator)]
        public IWebElement orderRow { get; set; }

        private const string titleRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Title, Value')])[1]";
        [FindsBy(How = How.XPath, Using = titleRowLocator)]
        public IWebElement titleRow { get; set; }

        private const string assigneeRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Assignee, Value')])[1]";
        [FindsBy(How = How.XPath, Using = assigneeRowLocator)]
        public IWebElement assigneeRow { get; set; }

        private const string assignorRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Assignor, Value')])[1]";
        [FindsBy(How = How.XPath, Using = assignorRowLocator)]
        public IWebElement assignorRow { get; set; }

        private const string dueDateRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Due Date, Value')])[1]";
        [FindsBy(How = How.XPath, Using = dueDateRowLocator)]
        public IWebElement dueDateRow { get; set; }

        private const string notesRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Notes, Value')])[1]";
        [FindsBy(How = How.XPath, Using = notesRowLocator)]
        public IWebElement notesRow { get; set; }

        private const string createdOnRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Created On, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdOnRowLocator)]
        public IWebElement createdOnRow { get; set; }

        private const string importanceRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Importance, Value')])[1]";
        [FindsBy(How = How.XPath, Using = importanceRowLocator)]
        public IWebElement importanceRow { get; set; }

        private const string reminderDaysRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Reminder Days, Value')])[1]";
        [FindsBy(How = How.XPath, Using = reminderDaysRowLocator)]
        public IWebElement reminderDaysRow { get; set; }

        private const string statusRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Status, Value')])[1]";
        [FindsBy(How = How.XPath, Using = statusRowLocator)]
        public IWebElement statusRow { get; set; }

        private const string taskTypeRowLocator = "(//pulse-tasks//td[contains(@aria-label, 'Column Task Type, Value')])[1]";
        [FindsBy(How = How.XPath, Using = taskTypeRowLocator)]
        public IWebElement taskTypeRow { get; set; }
        #endregion

        #region task edit form


        private const string titleInputLocator = "//div[child::label[text()='Title']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleInputLocator)]
        public IWebElement titleInput { get; set; }

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

        private const string templateSelectLocator = "//pulse-tasks//dx-select-box[@ng-reflect-display-expr='Title']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = templateSelectLocator)]
        public IWebElement templateSelect { get; set; }

        private const string applyBtnLocator = "//pulse-tasks//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = applyBtnLocator)]
        public IWebElement applyBtn { get; set; }
        #endregion

        public void AddTask(IWebDriver driver, Task task)
        {
            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Thread.Sleep(400);
            newBtn.Click();
            Thread.Sleep(400);
            Waitings.WaitForElementClickable(driver, statusSelectLocator, 10);
            Thread.Sleep(400);
            titleInput.SendKeys(task.Title);
            Thread.Sleep(500);
            Utilities.SelectInAutocompletePopup(driver, assigneeInput, task.Assignee);
            Thread.Sleep(500);
            if (task.TaskType != null) Utilities.SelectInDropdown(driver, taskTypeSelect, task.TaskType);
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
            Thread.Sleep(500);
            applyBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }

        public void AddTaskFromTemplate(IWebDriver driver, string templateName)
        {
            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Thread.Sleep(2000);
            newFromTemplateBtn.Click();
            Thread.Sleep(2000);
            Waitings.WaitForElementClickable(driver, templateSelectLocator, 2);
            Utilities.SelectInAutocomplete(driver, templateSelect, templateName);
            Thread.Sleep(2000);
            applyBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
        public void ShowColumn(IWebDriver driver, string columnName, IWebElement targetElement)
        {
            ShowColumn(driver, tasksGridLocator, columnName, targetElement);
        }
        public void HideColumn(IWebDriver driver, IWebElement column)
        {
            HideColumn(driver, tasksGridLocator, column);
        }
        public void OpenTask(IWebDriver driver)
        {
            OpenEntryLeftClick(driver, tasksGridLocator);
        }

        public void EditTask(IWebDriver driver, string text)
        {
            Utilities.ReplaceWithValue(driver, titleInput, text);
            Thread.Sleep(3000);
            applyBtn.Click();
            Thread.Sleep(5000);
            Waitings.WaitForSavingEnds(driver);
        }

        public void FindTaskByInput(IWebDriver driver, IWebElement taskFilter, IWebElement taskRow, string value)
        {
            FindEntryByInput(driver, taskFilter, taskRow, value);
        }

        public void FindTaskByDropdown(IWebDriver driver, IWebElement taskFilter, IWebElement taskRow, string value)
        {
            FindEntryByDropdown(driver, taskFilter, taskRow, value);
        }

        public void DeleteTask(IWebDriver driver)
        {
            DeleteEntry(driver, tasksGridLocator);
        }

        public void ClearFilters(IWebDriver driver)
        {
            IWebElement[] filtersArray = { titleFilter, assigneeFilter, assignorFilter};
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
            WaitForGridLoaded(driver, addBtnLocator, titleHeaderLocator, assigneeFilterLocator);
        }
    }
}
