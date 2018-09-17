using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.ContactsTab
{
    class ContactsGridPage : GridActions
    {
        private const string contactsGridLocator = "//pulse-contacts-grid";

        private const string gridViewSelectLocator = "//dx-select-box[parent::div[following-sibling::div[@class='menu-popover add-icon']]]//div[@class='dx-texteditor-container']";
        [FindsBy(How = How.XPath, Using = gridViewSelectLocator)]
        public IWebElement gridViewSelect { get; set; }

        #region add contact menu
        private const string addBtnLocator = "//pulse-contacts-grid//dx-menu[@role='menubar']";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        private const string addPersonBtnLocator = "//div[@class='dx-overlay-wrapper']/div/div/ul[@class='dx-menu-items-container'][count(li)=2]//span[text()='Person']";
        [FindsBy(How = How.XPath, Using = addPersonBtnLocator)]
        public IWebElement addPersonBtn { get; set; }

        private const string addCompanyBtnLocator = "//div[@class='dx-overlay-wrapper']/div/div/ul[@class='dx-menu-items-container'][count(li)=2]//span[text()='Company']";
        [FindsBy(How = How.XPath, Using = addCompanyBtnLocator)]
        public IWebElement addCompanyBtn { get; set; }
        #endregion

        #region grid action controls
        private const string myContactsCheckboxLocator = contactsGridLocator + myContactsCheckboxBaseLocator;
        [FindsBy(How = How.XPath, Using = myContactsCheckboxLocator)]
        public IWebElement myContactsCheckbox { get; set; }

        private const string refreshBtnLocator = contactsGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        public const string clearFiltersBtnLocator = contactsGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = contactsGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = contactsGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string savedFilterSelectForClickLocator = contactsGridLocator + saveFilterSelectForClickBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectForClickLocator)]
        public IWebElement savedFilterForClickSelect { get; set; }


        private const string saveFiltersBtnLocator = contactsGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = contactsGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }

        private const string selectRolesFilterLocator = "//dx-tag-box[@placeholder='Select Roles']";
        [FindsBy(How = How.XPath, Using = selectRolesFilterLocator)]
        public IWebElement selectRolesFilter { get; set; }

        private const string selectRolesOkButtonLocator = "//div[@aria-label='OK']";
        [FindsBy(How = How.XPath, Using = selectRolesOkButtonLocator)]
        public IWebElement selectRolesOkButton { get; set; }

        private const string selectRolesCancelButtonLocator = "//div[@aria-label='Cancel']";
        [FindsBy(How = How.XPath, Using = selectRolesCancelButtonLocator)]
        public IWebElement selectRolesCancelButton { get; set; }
        #endregion

        #region grid headers
        private const string firstNameHeaderLocator = "//td[@aria-label='First Name Column']";
        [FindsBy(How = How.XPath, Using = firstNameHeaderLocator)]
        public IWebElement firstNameHeader { get; set; }

        private const string lastNameHeaderLocator = "//td[@aria-label='Last Name Column']";
        [FindsBy(How = How.XPath, Using = lastNameHeaderLocator)]
        public IWebElement lastNameHeader { get; set; }

        private const string companyHeaderLocator = "//td[@aria-label='Company Column']";
        [FindsBy(How = How.XPath, Using = companyHeaderLocator)]
        public IWebElement companyHeader { get; set; }

        private const string phoneHeaderLocator = "//td[@aria-label='Phone Column']";
        [FindsBy(How = How.XPath, Using = phoneHeaderLocator)]
        public IWebElement phoneHeader { get; set; }

        private const string emailHeaderLocator = "//td[@aria-label='Email Column']";
        [FindsBy(How = How.XPath, Using = emailHeaderLocator)]
        public IWebElement emailHeader { get; set; }
        
        private const string phoneTypeHeaderLocator = "//td[@aria-label='Phone Type Column']";
        [FindsBy(How = How.XPath, Using = phoneTypeHeaderLocator)]
        public IWebElement phoneTypeHeader { get; set; }

        private const string emailTypeHeaderLocator = "//td[@aria-label='Email Type Column']";
        [FindsBy(How = How.XPath, Using = emailTypeHeaderLocator)]
        public IWebElement emailTypeHeader { get; set; }

        private const string prefixHeaderLocator = "//td[@aria-label='Prefix Column']";
        [FindsBy(How = How.XPath, Using = prefixHeaderLocator)]
        public IWebElement prefixHeader { get; set; }

        private const string suffixHeaderLocator = "//td[@aria-label='Suffix Column']";
        [FindsBy(How = How.XPath, Using = suffixHeaderLocator)]
        public IWebElement suffixHeader { get; set; }

        private const string twitterHeaderLocator = "//td[@aria-label='Twitter Column']";
        [FindsBy(How = How.XPath, Using = twitterHeaderLocator)]
        public IWebElement twitterHeader { get; set; }

        private const string websiteHeaderLocator = "//td[@aria-label='Website Column']";
        [FindsBy(How = How.XPath, Using = websiteHeaderLocator)]
        public IWebElement websiteHeader { get; set; }

        private const string skypeHeaderLocator = "//td[@aria-label='Skype Column']";
        [FindsBy(How = How.XPath, Using = skypeHeaderLocator)]
        public IWebElement skypeHeader { get; set; }

        private const string linkedinHeaderLocator = "//td[@aria-label='LinkedIn Profile Column']";
        [FindsBy(How = How.XPath, Using = linkedinHeaderLocator)]
        public IWebElement linkedinHeader { get; set; }

        private const string jurisdictionHeaderLocator = "//td[@aria-label='Jurisdiction Column']";
        [FindsBy(How = How.XPath, Using = jurisdictionHeaderLocator)]
        public IWebElement jurisdictionHeader { get; set; }

        private const string cityHeaderLocator = "//td[@aria-label='City Column']";
        [FindsBy(How = How.XPath, Using = cityHeaderLocator)]
        public IWebElement cityHeader { get; set; }

        private const string stateHeaderLocator = "//td[@aria-label='State Column']";
        [FindsBy(How = How.XPath, Using = stateHeaderLocator)]
        public IWebElement stateHeader { get; set; }

        private const string addressLine1HeaderLocator = "//td[@aria-label='Address Line 1 Column']";
        [FindsBy(How = How.XPath, Using = addressLine1HeaderLocator)]
        public IWebElement addressLine1Header { get; set; }

        private const string addressLine2HeaderLocator = "//td[@aria-label='Address Line 2 Column']";
        [FindsBy(How = How.XPath, Using = addressLine2HeaderLocator)]
        public IWebElement addressLine2Header { get; set; }

        private const string addressTypeHeaderLocator = "//td[@aria-label='Address Type Column']";
        [FindsBy(How = How.XPath, Using = addressTypeHeaderLocator)]
        public IWebElement addressTypeHeader { get; set; }

        private const string zipHeaderLocator = "//td[@aria-label='Zip Column']";
        [FindsBy(How = How.XPath, Using = zipHeaderLocator)]
        public IWebElement zipHeader { get; set; }

        private const string titleHeaderLocator = "//td[@aria-label='Title Column']";
        [FindsBy(How = How.XPath, Using = titleHeaderLocator)]
        public IWebElement titleHeader { get; set; }

        private const string mainContactHeaderLocator = "//td[@aria-label='Main Contact Column']";
        [FindsBy(How = How.XPath, Using = mainContactHeaderLocator)]
        public IWebElement mainContactHeader { get; set; }

        #endregion

        #region grid filters
        public const string firstNameFilterLocator = "//td[@aria-label='Column First Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = firstNameFilterLocator)]
        public IWebElement firstNameFilter { get; set; }

        public const string lastNameFilterLocator = "//td[@aria-label='Column Last Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = lastNameFilterLocator)]
        public IWebElement lastNameFilter { get; set; }

        private const string companyFilterLocator = "//td[@aria-label='Column Company, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = companyFilterLocator)]
        public IWebElement companyFilter { get; set; }

        private const string phoneFilterLocator = "//td[@aria-label='Column Phone, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = phoneFilterLocator)]
        public IWebElement phoneFilter { get; set; }

        private const string emailFilterLocator = "//td[@aria-label='Column Email, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = emailFilterLocator)]
        public IWebElement emailFilter { get; set; }

        private const string phoneTypeFilterLocator = "//td[@aria-label='Column Phone Type, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = phoneTypeFilterLocator)]
        public IWebElement phoneTypeFilter { get; set; }

        private const string emailTypeFilterLocator = "//td[@aria-label='Column Email Type, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = emailTypeFilterLocator)]
        public IWebElement emailTypeFilter { get; set; }

        private const string prefixFilterLocator = "//td[@aria-label='Column Prefix, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = prefixFilterLocator)]
        public IWebElement prefixFilter { get; set; }

        private const string suffixFilterLocator = "//td[@aria-label='Column Suffix, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = suffixFilterLocator)]
        public IWebElement suffixFilter { get; set; }

        private const string twitterFilterLocator = "//td[@aria-label='Column Twitter, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = twitterFilterLocator)]
        public IWebElement twitterFilter { get; set; }

        private const string websiteFilterLocator = "//td[@aria-label='Column Website, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = websiteFilterLocator)]
        public IWebElement websiteFilter { get; set; }

        private const string skypeFilterLocator = "//td[@aria-label='Column Skype, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = skypeFilterLocator)]
        public IWebElement skypeFilter { get; set; }

        private const string linkedinFilterLocator = "//td[@aria-label='Column LinkedIn Profile, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = linkedinFilterLocator)]
        public IWebElement linkedinFilter { get; set; }

        private const string jurisdictionFilterLocator = "//td[@aria-label='Column Jurisdiction, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = jurisdictionFilterLocator)]
        public IWebElement jurisdictionFilter { get; set; }

        private const string cityFilterLocator = "//td[@aria-label='Column City, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = cityFilterLocator)]
        public IWebElement cityFilter { get; set; }

        private const string stateFilterLocator = "//td[@aria-label='Column State, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = stateFilterLocator)]
        public IWebElement stateFilter { get; set; }

        private const string addressLine1FilterLocator = "//td[@aria-label='Column Address Line 1, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = addressLine1FilterLocator)]
        public IWebElement addressLine1Filter { get; set; }

        private const string addressLine2FilterLocator = "//td[@aria-label='Column Address Line 2, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = addressLine2FilterLocator)]
        public IWebElement addressLine2Filter { get; set; }

        private const string addressTypeFilterLocator = "//td[@aria-label='Column Address Type, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = addressTypeFilterLocator)]
        public IWebElement addressTypeFilter { get; set; }

        private const string zipFilterLocator = "//td[@aria-label='Column Zip, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = zipFilterLocator)]
        public IWebElement zipFilter { get; set; }

        private const string titleFilterLocator = "//td[@aria-label='Column Title, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = titleFilterLocator)]
        public IWebElement titleFilter { get; set; }
        #endregion

        #region first row data
        public const string firstNameRowLocator = "(//td[contains(@aria-label, 'Column First Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = firstNameRowLocator)]
        public IWebElement firstNameRow { get; set; }

        private const string lastNameRowLocator = "(//td[contains(@aria-label, 'Column Last Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = lastNameRowLocator)]
        public IWebElement lastNameRow { get; set; }

        private const string companyRowLocator = "(//td[contains(@aria-label, 'Column Company, Value')])[1]";
        [FindsBy(How = How.XPath, Using = companyRowLocator)]
        public IWebElement companyRow { get; set; }

        private const string phoneRowLocator = "(//td[contains(@aria-label, 'Column Phone, Value')])[1]";
        [FindsBy(How = How.XPath, Using = phoneRowLocator)]
        public IWebElement phoneRow { get; set; }

        private const string emailRowLocator = "(//td[contains(@aria-label, 'Column Email, Value')])//div[1]";
        [FindsBy(How = How.XPath, Using = emailRowLocator)]
        public IWebElement emailRow { get; set; }

        private const string phoneTypeRowLocator = "(//td[contains(@aria-label, 'Column Phone Type, Value')])[1]";
        [FindsBy(How = How.XPath, Using = phoneTypeRowLocator)]
        public IWebElement phoneTypeRow { get; set; }

        private const string emailTypeRowLocator = "(//td[contains(@aria-label, 'Column Email Type, Value')])[1]";
        [FindsBy(How = How.XPath, Using = emailTypeRowLocator)]
        public IWebElement emailTypeRow { get; set; }

        private const string prefixRowLocator = "(//td[contains(@aria-label, 'Column Prefix, Value')])[1]";
        [FindsBy(How = How.XPath, Using = prefixRowLocator)]
        public IWebElement prefixRow { get; set; }

        private const string suffixRowLocator = "(//td[contains(@aria-label, 'Column Suffix, Value')])[1]";
        [FindsBy(How = How.XPath, Using = suffixRowLocator)]
        public IWebElement suffixRow { get; set; }

        private const string twitterRowLocator = "(//td[contains(@aria-label, 'Column Twitter, Value')])[1]";
        [FindsBy(How = How.XPath, Using = twitterRowLocator)]
        public IWebElement twitterRow { get; set; }

        private const string websiteRowLocator = "(//td[contains(@aria-label, 'Column Website, Value')])[1]";
        [FindsBy(How = How.XPath, Using = websiteRowLocator)]
        public IWebElement websiteRow { get; set; }

        private const string skypeRowLocator = "(//td[contains(@aria-label, 'Column Skype, Value')])[1]";
        [FindsBy(How = How.XPath, Using = skypeRowLocator)]
        public IWebElement skypeRow { get; set; }

        private const string linkedinRowLocator = "(//td[contains(@aria-label, 'Column LinkedIn Profile, Value')])[1]";
        [FindsBy(How = How.XPath, Using = linkedinRowLocator)]
        public IWebElement linkedinRow { get; set; }

        private const string jurisdictionRowLocator = "(//td[contains(@aria-label, 'Column Jurisdiction, Value')])[1]";
        [FindsBy(How = How.XPath, Using = jurisdictionRowLocator)]
        public IWebElement jurisdictionRow { get; set; }

        private const string cityRowLocator = "(//td[contains(@aria-label, 'Column City, Value')])[1]";
        [FindsBy(How = How.XPath, Using = cityRowLocator)]
        public IWebElement cityRow { get; set; }

        private const string stateRowLocator = "(//td[contains(@aria-label, 'Column State, Value')])[1]";
        [FindsBy(How = How.XPath, Using = stateRowLocator)]
        public IWebElement stateRow { get; set; }

        private const string addressLine1RowLocator = "(//td[contains(@aria-label, 'Column Address Line 1, Value')])[1]";
        [FindsBy(How = How.XPath, Using = addressLine1RowLocator)]
        public IWebElement addressLine1Row { get; set; }

        private const string addressLine2RowLocator = "(//td[contains(@aria-label, 'Column Address Line 2, Value')])[1]";
        [FindsBy(How = How.XPath, Using = addressLine2RowLocator)]
        public IWebElement addressLine2Row { get; set; }

        private const string addressTypeRowLocator = "(//td[contains(@aria-label, 'Column Address Type, Value')])[1]";
        [FindsBy(How = How.XPath, Using = addressTypeRowLocator)]
        public IWebElement addressTypeRow { get; set; }

        private const string zipRowLocator = "(//td[contains(@aria-label, 'Column Zip, Value')])[1]";
        [FindsBy(How = How.XPath, Using = zipRowLocator)]
        public IWebElement zipRow { get; set; }

        private const string titleRowLocator = "(//td[contains(@aria-label, 'Column Title, Value')])[1]";
        [FindsBy(How = How.XPath, Using = titleRowLocator)]
        public IWebElement titleRow { get; set; }
        #endregion

        public void SelectGridView(IWebDriver driver, string value)
        {
            Utilities.SelectInDropdown(driver, gridViewSelect, value);
            switch (value)
            {
                case "Persons":
                    Waitings.WaitForElementsVisible(driver, 20, firstNameHeaderLocator, lastNameHeaderLocator, companyHeaderLocator, emailHeaderLocator, phoneHeaderLocator);
                    break;
                case "Companies":
                    Waitings.WaitForElementsVisible(driver, 20, companyHeaderLocator, phoneHeaderLocator, websiteHeaderLocator, mainContactHeaderLocator);
                    break;
                default:
                    Waitings.WaitForElementsVisible(driver, 20, companyHeaderLocator, firstNameHeaderLocator, lastNameHeaderLocator, phoneHeaderLocator, emailHeaderLocator);
                    break;
            }
        }

        public void OpenCreationFormFor(string contactRole, IWebDriver driver)
        {
            addBtn.Click();
            Waitings.WaitForElementsVisible(driver, 2, addPersonBtnLocator, addCompanyBtnLocator);
            Thread.Sleep(500);
            switch (contactRole)
            {
                case "Person":
                    addPersonBtn.Click();
                    break;
                case "Company":
                    addCompanyBtn.Click();
                    break;
            }
            Thread.Sleep(5000);
        }

        public void ClearFilters(IWebDriver driver)
        {
            IWebElement[] filtersArray = { companyFilter, firstNameFilter, lastNameFilter,  phoneFilter, emailFilter};
            ClearFilters(driver, contactsGridLocator, filtersArray);
            Waitings.WaitForLoadingEnds(driver);
        }

        public void HideColumn(IWebDriver driver, IWebElement column)
        {
            HideColumn(driver, contactsGridLocator, column);
        }

        public void ShowColumn(IWebDriver driver, string columnName, IWebElement targetElement)
        {
            ShowColumn(driver, contactsGridLocator, columnName, targetElement);
        }

        public void SaveViewWithName(IWebDriver driver, string viewName)
        {
            SaveViewWithName(driver, contactsGridLocator, viewName);
        }

        public void SaveView(IWebDriver driver)
        {
            SaveView(driver, contactsGridLocator);
        }

        public void DeleteView(IWebDriver driver)
        {
            DeleteView(driver, contactsGridLocator);
            Waitings.WaitForTextInInput(driver, savedFilterSelect, "Default", 5);
        }

        public void OpenContact(IWebDriver driver)
        {
            OpenEntry(driver, contactsGridLocator);
            ContactsCreationPage.WaitForFormLoaded(driver);
        }

        public void FindContactByInput(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            FindEntryByInput(driver, filterElement, rowElement, value);
        }
        public void FindContactByDropdown(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            FindEntryByDropdown(driver, filterElement, rowElement, value);
        }

        public void ChooseRole(IWebDriver driver, IWebElement filterElement, string value)
        {
            filterElement.Click();
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[text()='" + value + "']";
            Waitings.WaitForElementLocated(driver, locator, 5);
            Thread.Sleep(200);
            IWebElement element = driver.FindElement(By.XPath(locator));
            Utilities.MoveToElement(driver, element);
            Thread.Sleep(400);
            element.Click();
            selectRolesOkButton.Click();
            Waitings.WaitForLoadingEnds(driver);
        }

        public void DeleteContact(IWebDriver driver)
        {
            DeleteEntry(driver, contactsGridLocator);
        }

        public void WaitForGridLoaded(IWebDriver driver)
        {
            WaitForGridLoaded(driver, addBtnLocator, firstNameHeaderLocator, firstNameFilterLocator);
        }

        public void AddToPersonal(IWebDriver driver)
        {
            AddToPersonal(driver, contactsGridLocator);
        }

        public void RemoveFromPersonal(IWebDriver driver)
        {
            RemoveFromPersonal(driver, contactsGridLocator);
        }

        public void SwitchToPersonalContacts(IWebDriver driver)
        {
            myContactsCheckbox.Click();
            Waitings.WaitForLoadingEnds(driver);
        }

        public void PrintDetails(IWebDriver driver)
        {
           PrintDetails(driver, contactsGridLocator);
        }
    }
}
