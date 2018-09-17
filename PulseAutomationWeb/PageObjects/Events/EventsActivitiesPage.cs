using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;
using PulseAutomationWeb.PageObjects;

namespace PulseAutomationWeb.PageObjects.Events
{
    class EventsActivitiesPage : GridActions
    {
        private static TimeEntryPage timeEntryPage = new TimeEntryPage();
        private const string activitiesGridLocator = "//pulse-activities";

        private const string tasksLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Tasks']]";
        [FindsBy(How = How.XPath, Using = tasksLinkLocator)]
        public IWebElement tasksLink { get; set; }

        private const string tasksListMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Tasks List']";
        [FindsBy(How = How.XPath, Using = tasksListMenuItemLocator)]
        public IWebElement tasksListMenuItem { get; set; }

        private const string templateManagementMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Template Management']";
        [FindsBy(How = How.XPath, Using = templateManagementMenuItemLocator)]
        public IWebElement templateManagementMenuItem { get; set; }

        private const string notesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Notes']]";
        [FindsBy(How = How.XPath, Using = notesLinkLocator)]
        public IWebElement notesLink { get; set; }

        private const string activitiesLinkLocator = "//pulse-events//div[@role='menuitem'][descendant::span[text()='Activities']]";
        [FindsBy(How = How.XPath, Using = activitiesLinkLocator)]
        public IWebElement activitiesLink { get; set; }


        private const string addBtnLocator = "//pulse-activities//dx-button//div[descendant::i[@class='dx-icon dx-icon-iconpulse-add']]";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        #region grid action controls

        private const string refreshBtnLocator = activitiesGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        public const string clearFiltersBtnLocator = activitiesGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = activitiesGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = activitiesGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = activitiesGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = activitiesGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string activityTypeHeaderLocator = "//pulse-notes//td[@aria-label='Activity Type Column']";
        [FindsBy(How = How.XPath, Using = activityTypeHeaderLocator)]
        public IWebElement activityTypeHeader { get; set; }

        private const string dateOfActivityHeaderLocator = "//pulse-notes//td[@aria-label='Date Of Activity Column']";
        [FindsBy(How = How.XPath, Using = dateOfActivityHeaderLocator)]
        public IWebElement dateOfActivityHeader { get; set; }

        private const string createdByHeaderLocator = "//pulse-notes//td[@aria-label='Created By Column']";
        [FindsBy(How = How.XPath, Using = createdByHeaderLocator)]
        public IWebElement createdByHeader { get; set; }

        private const string notesHeaderLocator = "//pulse-notes//td[@aria-label='Notes Column']";
        [FindsBy(How = How.XPath, Using = notesHeaderLocator)]
        public IWebElement notesHeader { get; set; }

        private const string clientContactHeaderLocator = "//pulse-notes//td[@aria-label='Client / Contact Name Column']";
        [FindsBy(How = How.XPath, Using = clientContactHeaderLocator)]
        public IWebElement clientContactHeader { get; set; }

        private const string matterHeaderLocator = "//pulse-notes//td[@aria-label='Matter Column']";
        [FindsBy(How = How.XPath, Using = matterHeaderLocator)]
        public IWebElement matterHeader { get; set; }
        #endregion

        #region grid filters
        private const string activityTypeFilterLocator = "//td[@aria-label='Column Activity Type, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = activityTypeFilterLocator)]
        public IWebElement activityTypeFilter { get; set; }

        private const string dateOfActivityFilterLocator = "//td[@aria-label='Column Date Of Activity, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = dateOfActivityFilterLocator)]
        public IWebElement dateOfActivityilter { get; set; }

        private const string createdByFilterLocator = "//td[@aria-label='Column Created By, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdByFilterLocator)]
        public IWebElement createdByFilter { get; set; }

        public const string notesFilterLocator = "//td[@aria-label='Column Notes, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = notesFilterLocator)]
        public IWebElement notesFilter { get; set; }

        private const string clientContactFilterLocator = "//td[@aria-label='Column Client / Contact Name, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = clientContactFilterLocator)]
        public IWebElement clientContactFilter { get; set; }

        private const string matterFilterLocator = "//td[@aria-label='Column Matter, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = matterFilterLocator)]
        public IWebElement matterFilter { get; set; }
        #endregion

        #region first row data
        private const string activityTypeRowLocator = "(//td[contains(@aria-label, 'Column Activity Type, Value')])[1]";
        [FindsBy(How = How.XPath, Using = activityTypeRowLocator)]
        public IWebElement activityTypeRow { get; set; }

        private const string dateOfActivityRowLocator = "(//td[contains(@aria-label, 'Column Date Of Activity, Value')])[1]";
        [FindsBy(How = How.XPath, Using = dateOfActivityRowLocator)]
        public IWebElement dateOfActivityRow { get; set; }

        private const string createdByRowLocator = "(//td[contains(@aria-label, 'Column Created By, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdByRowLocator)]
        public IWebElement createdByRow { get; set; }

        private const string notesRowLocator = "(//td[contains(@aria-label, 'Column Notes, Value')])[1]";
        [FindsBy(How = How.XPath, Using = notesRowLocator)]
        public IWebElement notesRow { get; set; }

        private const string clientContactRowLocator = "(//td[contains(@aria-label, 'Column Client / Contact Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = clientContactRowLocator)]
        public IWebElement clientContactRow { get; set; }

        private const string matterRowLocator = "(//td[contains(@aria-label, 'Column Matter, Value')])[1]";
        [FindsBy(How = How.XPath, Using = matterRowLocator)]
        public IWebElement matterRow { get; set; }

        #endregion

        #region activity edit form
        private const string typeSelectLocator = "//pulse-activities//dx-select-box[preceding::label[text()='Type']]";
        [FindsBy(How = How.XPath, Using = typeSelectLocator)]
        public IWebElement typeSelect { get; set; }

        private const string actionCodeInputLocator = "//dx-select-box[preceding::label[1][text()='Action Code']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = actionCodeInputLocator)]
        public IWebElement actionCodeInput { get; set; }

        private const string textFieldLocator = "//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = textFieldLocator)]
        public IWebElement textField { get; set; }

        private const string applyBtnLocator = "//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = applyBtnLocator)]
        public IWebElement applyBtn { get; set; }
        #endregion

        public void AddActivity(IWebDriver driver, string typeValue, string actionCode, string text)
        {
            TimeEntry timeEntry = new TimeEntry("script@gmail.com", "CIS", "Tigers", "RG", "(WA) Waveaccess", "0.5", null, null, null, null, null, null, null, null, null, null, null, null, null);
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='No'][preceding::div[contains(text(), 'Unsaved changes')]]";
            //Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            //driver.FindElement(By.XPath(locator)).Click();

            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Waitings.WaitForElementClickable(driver, typeSelectLocator, 2);
            Utilities.SelectInDropdown(driver, typeSelect, typeValue);
            Utilities.SelectInAutocomplete(driver, actionCodeInput, actionCode);
            textField.SendKeys(text);
            Thread.Sleep(1000);
            applyBtn.Click();
            Thread.Sleep(1000);
            Waitings.WaitForSavingEnds(driver);
            driver.FindElement(By.XPath("//i[@title='Close time entry']")).Click();
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            // timeEntryPage.AddTimeEntry(driver, timeEntry);
        }
    
        public void OpenActivity(IWebDriver driver)
        {
            OpenEntryLeftClick(driver, activitiesGridLocator);
            Thread.Sleep(500);
        }

        public void EditActivity(IWebDriver driver, string typeValue, string text)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='No'][preceding::div[contains(text(), 'Unsaved changes')]]";
            Utilities.SelectInDropdown(driver, typeSelect, typeValue);
            textField.Clear();
            textField.SendKeys(text);
            Thread.Sleep(1000);
            applyBtn.Click();
            Thread.Sleep(1000);
            Waitings.WaitForSavingEnds(driver);
            driver.FindElement(By.XPath("//i[@title='Close time entry']")).Click();
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
        }
        public void FindActivityByInput(IWebDriver driver, IWebElement activityFilter, IWebElement activityRow, string value)
        {
            FindEntryByInput(driver, activityFilter, activityRow, value);
        }
        public void DeleteActivity(IWebDriver driver)
        {
            DeleteEntry(driver, activitiesGridLocator);
        }

    }
    
}
