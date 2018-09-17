using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.ContactsTab
{
    class MattersGridPage : GridActions
    {
        private const string mattersGridLocator = "//pulse-matters-grid";

        private const string matterStatusSelectLocator = "//div[@class='float-left group-status-filter']//dx-select-box//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = matterStatusSelectLocator)]
        public IWebElement matterStatusSelect { get; set; }

        #region grid action controls
        private const string refreshBtnLocator = mattersGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        private const string clearFiltersBtnLocator = mattersGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = mattersGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = mattersGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = mattersGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = mattersGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }

        private const string selectStatusFilterLocator = "//dx-tag-box[@ng-reflect-placeholder='Select Status']";
        [FindsBy(How = How.XPath, Using = selectStatusFilterLocator)]
        public IWebElement selectStatusFilter { get; set; }

        private const string selectStatusesOkButtonLocator = "//div[@aria-label='OK']";
        [FindsBy(How = How.XPath, Using = selectStatusesOkButtonLocator)]
        public IWebElement selectStatusesOkButton { get; set; }

        private const string selectStatusesCancelButtonLocator = "//div[@aria-label='Cancel']";
        [FindsBy(How = How.XPath, Using = selectStatusesCancelButtonLocator)]
        public IWebElement selectStatusesCancelButton { get; set; }
        #endregion

        #region grid headers
        private const string matterNameHeaderLocator = "//td[@aria-label='Matter Name Column']";
        [FindsBy(How = How.XPath, Using = matterNameHeaderLocator)]
        public IWebElement matterNameHeader { get; set; }

        private const string matterCodeHeaderLocator = "//td[@aria-label='Matter Code Column']";
        [FindsBy(How = How.XPath, Using = matterCodeHeaderLocator)]
        public IWebElement matterCodeHeader { get; set; }

        private const string clientNameHeaderLocator = "//td[@aria-label='Company Client Name']";
        [FindsBy(How = How.XPath, Using = clientNameHeaderLocator)]
        public IWebElement clientNameHeader { get; set; }

        private const string clientCodeHeaderLocator = "//td[@aria-label='Client Code Column']";
        [FindsBy(How = How.XPath, Using = clientCodeHeaderLocator)]
        public IWebElement clientCodeHeader { get; set; }

        private const string openDateHeaderLocator = "//td[@aria-label='Open Date Column']";
        [FindsBy(How = How.XPath, Using = openDateHeaderLocator)]
        public IWebElement openDateHeader { get; set; }
        
        private const string typeOfClientHeaderLocator = "//td[@aria-label='Type of Client Column']";
        [FindsBy(How = How.XPath, Using = typeOfClientHeaderLocator)]
        public IWebElement typeOfClientHeader { get; set; }

        private const string dwcVenueHeaderLocator = "//td[@aria-label='DWC Venue Column']";
        [FindsBy(How = How.XPath, Using = dwcVenueHeaderLocator)]
        public IWebElement dwcVenueHeader { get; set; }

        private const string handlingAttorneyInitialsHeaderLocator = "//td[@aria-label='Handling Attorney Initials Column']";
        [FindsBy(How = How.XPath, Using = handlingAttorneyInitialsHeaderLocator)]
        public IWebElement handlingAttorneyInitialsHeader { get; set; }

        private const string officeHeaderLocator = "//td[@aria-label='Office Column']";
        [FindsBy(How = How.XPath, Using = officeHeaderLocator)]
        public IWebElement officeHeader { get; set; }

        private const string applicantAttorneyHeaderLocator = "//td[@aria-label='Applicant Attorney Column']";
        [FindsBy(How = How.XPath, Using = applicantAttorneyHeaderLocator)]
        public IWebElement applicantAttorneyHeader { get; set; }

        private const string applicantNameHeaderLocator = "//td[@aria-label='Applicant Name Column']";
        [FindsBy(How = How.XPath, Using = applicantNameHeaderLocator)]
        public IWebElement applicantNameHeader { get; set; }

        private const string handlingAttorneyHeaderLocator = "//td[@aria-label='Handling Attorney Column']";
        [FindsBy(How = How.XPath, Using = handlingAttorneyHeaderLocator)]
        public IWebElement handlingAttorneyHeader { get; set; }

        private const string walkThroughHeaderLocator = "//td[@aria-label='Walk Through Column']";
        [FindsBy(How = How.XPath, Using = walkThroughHeaderLocator)]
        public IWebElement walkThroughHeader { get; set; }
        #endregion

        #region grid filters
        public const string matterNameFilterLocator = "//td[@aria-label='Column Matter Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = matterNameFilterLocator)]
        public IWebElement matterNameFilter { get; set; }

        private const string matterCodeFilterLocator = "//td[@aria-label='Column Matter Code, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = matterCodeFilterLocator)]
        public IWebElement matterCodeFilter { get; set; }

        private const string clientNameFilterLocator = "//td[@aria-label='Column Client Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = clientNameFilterLocator)]
        public IWebElement clientNameFilter { get; set; }

        private const string clientCodeFilterLocator = "//td[@aria-label='Column Client Code, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = clientCodeFilterLocator)]
        public IWebElement clientCodeFilter { get; set; }

        private const string openDateFilterLocator = "//td[@aria-label='Column Open Date, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = openDateFilterLocator)]
        public IWebElement openDateFilter { get; set; }

        private const string typeOfClientFilterLocator = "//td[@aria-label='Column Type of Client, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = typeOfClientFilterLocator)]
        public IWebElement typeOfClientFilter { get; set; }

        private const string dwcVenueFilterLocator = "//td[@aria-label='Column DWC Venue, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = dwcVenueFilterLocator)]
        public IWebElement dwcVenueFilter { get; set; }

        private const string handlingAttorneyInitialsFilterLocator = "//td[@aria-label='Column Handling Attorney Initials, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = handlingAttorneyInitialsFilterLocator)]
        public IWebElement handlingAttorneyInitialsFilter { get; set; }

        private const string officeFilterLocator = "//td[@aria-label='Column Office, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = officeFilterLocator)]
        public IWebElement officeFilter { get; set; }

        private const string applicantAttorneyFilterLocator = "//td[@aria-label='Column Applicant Attorney, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = applicantAttorneyFilterLocator)]
        public IWebElement applicantAttorneyFilter { get; set; }

        private const string applicantNameFilterLocator = "//td[@aria-label='Column Applicant Name, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = applicantNameFilterLocator)]
        public IWebElement applicantNameFilter { get; set; }

        private const string handlingAttorneyFilterLocator = "//td[@aria-label='Column Handling Attorney, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = handlingAttorneyFilterLocator)]
        public IWebElement handlingAttorneyFilter { get; set; }

        private const string walkThroughFilterLocator = "//td[@aria-label='Column Walk-Through, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = walkThroughFilterLocator)]
        public IWebElement walkThroughFilter { get; set; }
        #endregion

        #region first row data
        private const string matterNameRowLocator = "(//td[contains(@aria-label, 'Column Matter Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = matterNameRowLocator)]
        public IWebElement matterNameRow { get; set; }

        private const string matterCodeRowLocator = "(//td[contains(@aria-label, 'Column Matter Code, Value')])[1]";
        [FindsBy(How = How.XPath, Using = matterCodeRowLocator)]
        public IWebElement matterCodeRow { get; set; }

        private const string clientNameRowLocator = "(//td[contains(@aria-label, 'Column Client Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = clientNameRowLocator)]
        public IWebElement clientNameRow { get; set; }

        private const string clientCodeLocator = "(//td[contains(@aria-label, 'Column Client Code, Value')])[1]";
        [FindsBy(How = How.XPath, Using = clientCodeLocator)]
        public IWebElement clientCodeRow { get; set; }

        private const string openDateRowLocator = "(//td[contains(@aria-label, 'Column Open Date, Value')])//div[1]";
        [FindsBy(How = How.XPath, Using = openDateRowLocator)]
        public IWebElement openDateRow { get; set; }

        private const string typeOfClientRowLocator = "(//td[contains(@aria-label, 'Column Type Of Client, Value')])[1]";
        [FindsBy(How = How.XPath, Using = typeOfClientRowLocator)]
        public IWebElement typeOfClientRow { get; set; }

        private const string dwcVenueRowLocator = "(//td[contains(@aria-label, 'Column DWC Venue, Value')])[1]";
        [FindsBy(How = How.XPath, Using = dwcVenueRowLocator)]
        public IWebElement dwcVenueTypeRow { get; set; }

        private const string handlingAttorneyInitialsRowLocator = "(//td[contains(@aria-label, 'Column Handling Attorney Initials, Value')])[1]";
        [FindsBy(How = How.XPath, Using = handlingAttorneyInitialsRowLocator)]
        public IWebElement handlingAttorneyInitialsRow { get; set; }

        private const string officeRowLocator = "(//td[contains(@aria-label, 'Column Office, Value')])[1]";
        [FindsBy(How = How.XPath, Using = officeRowLocator)]
        public IWebElement officeRow { get; set; }

        private const string applicantAttorneyRowLocator = "(//td[contains(@aria-label, 'Column Applicant Attorney, Value')])[1]";
        [FindsBy(How = How.XPath, Using = applicantAttorneyRowLocator)]
        public IWebElement applicantAttorneyRow { get; set; }

        private const string applicantNameRowLocator = "(//td[contains(@aria-label, 'Column Applicant Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = applicantNameRowLocator)]
        public IWebElement applicantNameRow { get; set; }

        private const string handlingAttorneyRowLocator = "(//td[contains(@aria-label, 'Column Handling Attorney, Value')])[1]";
        [FindsBy(How = How.XPath, Using = handlingAttorneyRowLocator)]
        public IWebElement handlingAttorneyRow { get; set; }

        private const string walkThroughRowLocator = "(//td[contains(@aria-label, 'Column Walk-Through Profile, Value')])[1]";
        [FindsBy(How = How.XPath, Using = walkThroughRowLocator)]
        public IWebElement walkThroughRow { get; set; }
        #endregion

        public void ClearFilters(IWebDriver driver)
        {
            IWebElement[] filtersArray = { matterNameFilter, matterCodeFilter, clientNameFilter,  clientCodeFilter};
            ClearFilters(driver, mattersGridLocator, filtersArray);
            Waitings.WaitForLoadingEnds(driver);
        }

        public void HideColumn(IWebDriver driver, IWebElement column)
        {
            HideColumn(driver, mattersGridLocator, column);
        }

        public void ShowColumn(IWebDriver driver, string columnName, IWebElement targetElement)
        {
            ShowColumn(driver, mattersGridLocator, columnName, targetElement);
        }

        public void SaveViewWithName(IWebDriver driver, string viewName)
        {
            SaveViewWithName(driver, mattersGridLocator, viewName);
        }

        public void SaveView(IWebDriver driver)
        {
            SaveView(driver, mattersGridLocator);
        }

        public void DeleteView(IWebDriver driver)
        {
            DeleteView(driver, mattersGridLocator);
            Waitings.WaitForTextInInput(driver, savedFilterSelect, "Default", 5);
        }

        public void OpenMatter(IWebDriver driver)
        {
            OpenEntry(driver, mattersGridLocator);
            MatterHomePage.WaitForPageLoaded(driver);
        }

        public void FindMatterByInput(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            FindEntryByInput(driver, filterElement, rowElement, value);
        }
        public void FindContactByDropdown(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            FindEntryByDropdown(driver, filterElement, rowElement, value);
        }

        public void ChooseStatus(IWebDriver driver, IWebElement filterElement, string value)
        {
            filterElement.Click();
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[text()='" + value + "']";
            Waitings.WaitForElementLocated(driver, locator, 5);
            Thread.Sleep(200);
            IWebElement element = driver.FindElement(By.XPath(locator));
            Utilities.MoveToElement(driver, element);
            Thread.Sleep(400);
            element.Click();
            selectStatusesOkButton.Click();
            Waitings.WaitForLoadingEnds(driver);
        }

        public void WaitForGridLoaded(IWebDriver driver)
        {
            WaitForGridLoaded(driver, matterNameHeaderLocator, matterNameFilterLocator);
        }

        public void PrintDetails(IWebDriver driver)
        {
           PrintDetails(driver, mattersGridLocator);
        }
    }
}
