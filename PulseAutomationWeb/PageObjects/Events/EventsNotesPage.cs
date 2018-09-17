using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.Events
{
    class EventsNotesPage : GridActions
    {
        private const string notesGridLocator = "//pulse-notes";

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

        private const string addBtnLocator = "//pulse-notes//dx-button//div[descendant::i[@class='dx-icon dx-icon-iconpulse-add']]";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        #region grid action controls

        private const string refreshBtnLocator = notesGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        public const string clearFiltersBtnLocator = notesGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = notesGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = notesGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string savedFilterSelectForClickLocator = notesGridLocator + saveFilterSelectForClickBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectForClickLocator)]
        public IWebElement savedFilterForClickSelect { get; set; }


        private const string saveFiltersBtnLocator = notesGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = notesGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string privacyHeaderLocator = "//pulse-notes//td[@aria-label='Privacy Column']";
        [FindsBy(How = How.XPath, Using = privacyHeaderLocator)]
        public IWebElement privacyHeader { get; set; }

        private const string priorityHeaderLocator = "//pulse-notes//td[@aria-label='Priority Column']";
        [FindsBy(How = How.XPath, Using = priorityHeaderLocator)]
        public IWebElement priorityHeader { get; set; }

        private const string dateHeaderLocator = "//pulse-notes//td[@aria-label='Date Column']";
        [FindsBy(How = How.XPath, Using = dateHeaderLocator)]
        public IWebElement dateHeader { get; set; }

        private const string createdByHeaderLocator = "//pulse-notes//td[@aria-label='Created By Column']";
        [FindsBy(How = How.XPath, Using = createdByHeaderLocator)]
        public IWebElement createdByHeader { get; set; }

        private const string noteHeaderLocator = "//pulse-notes//td[@aria-label='Note Column']";
        [FindsBy(How = How.XPath, Using = noteHeaderLocator)]
        public IWebElement noteHeader { get; set; }
        #endregion

        #region grid filters
        private const string privacyFilterLocator = "//pulse-notes//td[@aria-label='Column Privacy, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = privacyFilterLocator)]
        public IWebElement privacyFilter { get; set; }

        private const string priorityFilterLocator = "//pulse-notes//td[@aria-label='Column Priority, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = priorityFilterLocator)]
        public IWebElement priorityFilter { get; set; }

        private const string dateFilterLocator = "//pulse-notes//td[@aria-label='Column Date, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = dateFilterLocator)]
        public IWebElement dateFilter { get; set; }

        private const string createdByFilterLocator = "//pulse-notes//td[@aria-label='Column Created By, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdByFilterLocator)]
        public IWebElement createdByFilter { get; set; }

        public const string noteFilterLocator = "//pulse-notes//td[@aria-label='Column Note, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = noteFilterLocator)]
        public IWebElement noteFilter { get; set; }
        #endregion

        #region first row data
        private const string privacyRowLocator = "(//pulse-notes//td[contains(@aria-label, 'Column Privacy, Value')])[1]";
        [FindsBy(How = How.XPath, Using = privacyRowLocator)]
        public IWebElement privacyRow { get; set; }

        private const string priorityRowLocator = "(//pulse-notes//td[contains(@aria-label, 'Column Priority, Value')])[1]";
        [FindsBy(How = How.XPath, Using = priorityRowLocator)]
        public IWebElement priorityRow { get; set; }

        private const string dateRowLocator = "(//pulse-notes//td[contains(@aria-label, 'Column Date, Value')])[1]";
        [FindsBy(How = How.XPath, Using = dateRowLocator)]
        public IWebElement dateRow { get; set; }

        private const string createdByRowLocator = "(//pulse-notes//td[contains(@aria-label, 'Column Created By, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdByRowLocator)]
        public IWebElement createdByRow { get; set; }

        private const string noteRowLocator = "(//pulse-notes//td[contains(@aria-label, 'Column Note, Value')])[1]";
        [FindsBy(How = How.XPath, Using = noteRowLocator)]
        public IWebElement noteRow { get; set; }
        #endregion

        #region note edit form
        private const string prioritySelectLocator = "//pulse-notes//dx-select-box[preceding::label[text()='Priority']]";
        [FindsBy(How = How.XPath, Using = prioritySelectLocator)]
        public IWebElement prioritySelect { get; set; }

        private const string textFieldLocator = "//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = textFieldLocator)]
        public IWebElement textField { get; set; }

        private const string applyBtnLocator = "//pulse-notes//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = applyBtnLocator)]
        public IWebElement applyBtn { get; set; }
        #endregion

        public void AddNote(IWebDriver driver, string priorityValue, string text)
        {
            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Waitings.WaitForElementClickable(driver, prioritySelectLocator, 2);
            Utilities.SelectInDropdown(driver, prioritySelect, priorityValue);
            textField.SendKeys(text);
            Thread.Sleep(2000);
            Waitings.WaitForElementClickable(driver, applyBtnLocator, 5);
            applyBtn.Click();
            Waitings.WaitForSavingEnds(driver);
            Waitings.WaitForSaveButtonDisappear(driver);
        } 

        public void OpenNote(IWebDriver driver)
        {
            OpenEntryLeftClick(driver, notesGridLocator);
        }

        public void EditNote(IWebDriver driver, string priorityValue, string text)
        {
            Waitings.WaitForElementVisible(driver, prioritySelectLocator, 5);
            Utilities.SelectInDropdown(driver, prioritySelect, priorityValue);
            textField.Clear();
            textField.SendKeys(text);
            Thread.Sleep(2000);
            Waitings.WaitForElementClickable(driver, applyBtnLocator, 5);
            applyBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }

        public void FindNoteByInput(IWebDriver driver, IWebElement noteFilter, IWebElement noteRow, string value)
        {
            FindEntryByInput(driver, noteFilter, noteRow, value);
        }
        public void FindNoteByDropdown(IWebDriver driver, IWebElement noteFilter, IWebElement noteRow, string value)
        {
            FindEntryByDropdown(driver, noteFilter, noteRow, value);
        }
        public void DeleteNote(IWebDriver driver)
        {
            DeleteEntry(driver, notesGridLocator);
        }

        public void ClearFilters(IWebDriver driver)
        {
            IWebElement[] filtersArray = { privacyFilter,priorityFilter, dateFilter };
            ClearFilters(driver, notesGridLocator, filtersArray);
        }
        public void SaveView(IWebDriver driver)
        {
            SaveView(driver, notesGridLocator);
        }

        public void SaveViewWithName(IWebDriver driver, string viewName)
        {
            SaveViewWithName(driver, notesGridLocator, viewName);
        }

        public void DeleteView(IWebDriver driver)
        {
            DeleteView(driver, notesGridLocator);
            Waitings.WaitForTextInInput(driver, savedFilterSelect, "Default", 5);
        }
        public void WaitForGridLoaded(IWebDriver driver)
        {
            WaitForGridLoaded(driver, addBtnLocator, noteHeaderLocator, createdByFilterLocator);
        }
    }
}
