using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.Admin
{
    class UserListGridPage : GridActions

    {
        private const string userListGridLocator = "//pulse-user-list";

        #region grid action controls

        private const string refreshBtnLocator = userListGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        private const string clearFiltersBtnLocator = userListGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = userListGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = userListGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = userListGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = userListGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string userNameHeaderLocator = "//pulse-email-template-list//td[@aria-label='Username Column']";
        [FindsBy(How = How.XPath, Using = userNameHeaderLocator)]
        public IWebElement userNameHeader { get; set; }

        private const string firstNameHeaderLocator = "//pulse-email-template-list//td[@aria-label='First Name Column']";
        [FindsBy(How = How.XPath, Using = firstNameHeaderLocator)]
        public IWebElement firstNameHeader { get; set; }

        private const string lastNameHeaderLocator = "//pulse-email-template-list//td[@aria-label='Last Name Column']";
        [FindsBy(How = How.XPath, Using = lastNameHeaderLocator)]
        public IWebElement lastNameHeader { get; set; }

        private const string birthdayHeaderLocator = "//pulse-email-template-list//td[@aria-label='Birthday Column']";
        [FindsBy(How = How.XPath, Using = birthdayHeaderLocator)]
        public IWebElement birthdayHeader { get; set; }

        private const string cellPhoneHeaderLocator = "//pulse-email-template-list//td[@aria-label='Cell Phone Column']";
        [FindsBy(How = How.XPath, Using = birthdayHeaderLocator)]
        public IWebElement cellPhoneHeader { get; set; }

        private const string personalEmailHeaderLocator = "//pulse-email-template-list//td[@aria-label='Personal Email Column']";
        [FindsBy(How = How.XPath, Using = personalEmailHeaderLocator)]
        public IWebElement personalEmailHeader { get; set; }

        private const string barAdmissionsHeaderLocator = "//pulse-email-template-list//td[@aria-label='Bar Admissions Column']";
        [FindsBy(How = How.XPath, Using = barAdmissionsHeaderLocator)]
        public IWebElement barAdmissionsHeader { get; set; }

        private const string emergencyContactNameHeaderLocator = "//pulse-email-template-list//td[@aria-label='Emergency Contact Name Column']";
        [FindsBy(How = How.XPath, Using = emergencyContactNameHeaderLocator)]
        public IWebElement emergencyContactNameHeader { get; set; }

        private const string emergencyContactPhoneHeaderLocator = "//pulse-email-template-list//td[@aria-label='Emergency Contact Phone Column']";
        [FindsBy(How = How.XPath, Using = emergencyContactPhoneHeaderLocator)]
        public IWebElement emergencyContactPhoneHeader { get; set; }

        private const string homeAddressHeaderLocator = "//pulse-email-template-list//td[@aria-label='Home Address Column']";
        [FindsBy(How = How.XPath, Using = homeAddressHeaderLocator)]
        public IWebElement homeAddressHeader { get; set; }

        private const string homePhoneHeaderLocator = "//pulse-email-template-list//td[@aria-label='Home Phone Column']";
        [FindsBy(How = How.XPath, Using = homePhoneHeaderLocator)]
        public IWebElement homePhoneHeader { get; set; }

        private const string languagesHeaderLocator = "//pulse-email-template-list//td[@aria-label='Languages Column']";
        [FindsBy(How = How.XPath, Using = languagesHeaderLocator)]
        public IWebElement languagesHeader { get; set; }

        private const string locationsInTheFirmHeaderLocator = "//pulse-email-template-list//td[@aria-label='Locations In The Firm Column']";
        [FindsBy(How = How.XPath, Using = locationsInTheFirmHeaderLocator)]
        public IWebElement locationsInTheFirmHeader { get; set; }

        private const string middleNameHeaderLocator = "//pulse-email-template-list//td[@aria-label='Middle Name Column']";
        [FindsBy(How = How.XPath, Using = middleNameHeaderLocator)]
        public IWebElement middleNameHeader { get; set; }
        #endregion

        #region grid filters
        private const string usernameFilterLocator = "//pulse-user-list//td[@aria-label='Column Username, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = usernameFilterLocator)]
        public IWebElement usernameFilter { get; set; }

        private const string firstNameFilterLocator = "//pulse-user-list//td[@aria-label='Column First Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = firstNameFilterLocator)]
        public IWebElement firstNameFilter { get; set; }

        private const string lastNameFilterLocator = "//pulse-user-list//td[@aria-label='Column Last Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = lastNameFilterLocator)]
        public IWebElement lastNameFilter { get; set; }

        private const string birthdayFilterLocator = "//pulse-user-list//td[@aria-label='Column Birthday, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = birthdayFilterLocator)]
        public IWebElement birthdayFilter { get; set; }

        private const string cellPhoneFilterLocator = "//pulse-user-list//td[@aria-label='Column Cell Phone, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = cellPhoneFilterLocator)]
        public IWebElement cellPhoneFilter { get; set; }

        private const string personalEmailFilterLocator = "//pulse-user-list//td[@aria-label='Column Personal Email, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = personalEmailFilterLocator)]
        public IWebElement personalEmailFilter { get; set; }

        private const string barAdmissionsFilterLocator = "//pulse-user-list//td[@aria-label='Column Bar Admissions, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = barAdmissionsFilterLocator)]
        public IWebElement barAdmissionsFilter { get; set; }

        private const string emergencyContactNameFilterLocator = "//pulse-user-list//td[@aria-label='Column Emergency Contact Name, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = emergencyContactNameFilterLocator)]
        public IWebElement emergencyContactNameFilter { get; set; }

        private const string emergencyContactPhoneFilterLocator = "//pulse-user-list//td[@aria-label='Column Emergency Contact Phone, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = emergencyContactPhoneFilterLocator)]
        public IWebElement emergencyContactPhoneFilter { get; set; }

        private const string homeAddressFilterLocator = "//pulse-user-list//td[@aria-label='Column Home Address, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = homeAddressFilterLocator)]
        public IWebElement homeAddressFilter { get; set; }

        private const string homePhoneFilterLocator = "//pulse-user-list//td[@aria-label='Column Home Phone, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = homePhoneFilterLocator)]
        public IWebElement homePhoneFilter { get; set; }

        private const string languagesFilterLocator = "//pulse-user-list//td[@aria-label='Column Languages, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = homePhoneFilterLocator)]
        public IWebElement languagesFilter { get; set; }

        private const string locationInTheFirmFilterLocator = "//pulse-user-list//td[@aria-label='Column Location In The Firm, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = locationInTheFirmFilterLocator)]
        public IWebElement locationInTheFirmFilter { get; set; }

        private const string middleNameFilterLocator = "//pulse-user-list//td[@aria-label='Column Middle Name, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = middleNameFilterLocator)]
        public IWebElement middleNameFilter { get; set; }
        #endregion

        #region first row data
        private const string usernameRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Username, Value')])[1]";
        [FindsBy(How = How.XPath, Using = usernameRowLocator)]
        public IWebElement usernameRow { get; set; }

        private const string firstNameRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column First Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = firstNameRowLocator)]
        public IWebElement firstNameRow { get; set; }

        private const string lastNameRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Last Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = lastNameRowLocator)]
        public IWebElement lastNameRow { get; set; }

        private const string birthdayRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Birthday, Value')])[1]";
        [FindsBy(How = How.XPath, Using = birthdayRowLocator)]
        public IWebElement birthdayRow { get; set; }

        private const string cellPhoneRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Cell Phone, Value')])[1]";
        [FindsBy(How = How.XPath, Using = cellPhoneRowLocator)]
        public IWebElement cellPhoneRow { get; set; }

        private const string personalEmailRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Personal Email, Value')])[1]";
        [FindsBy(How = How.XPath, Using = personalEmailRowLocator)]
        public IWebElement personalEmailRow { get; set; }

        private const string barAdmissionsRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Bar Admissions, Value')])[1]";
        [FindsBy(How = How.XPath, Using = barAdmissionsRowLocator)]
        public IWebElement barAdmissionsRow { get; set; }

        private const string emergencyContactNameRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Emergency Contact Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = emergencyContactNameRowLocator)]
        public IWebElement emergencyContactNameRow { get; set; }

        private const string emergencyContactPhoneRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column Emergency Contact Phone, Value')])[1]";
        [FindsBy(How = How.XPath, Using = emergencyContactPhoneRowLocator)]
        public IWebElement emergencyContactPhoneRow { get; set; }

        private const string homeAddressRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column  Home Address, Value')])[1]";
        [FindsBy(How = How.XPath, Using = homeAddressRowLocator)]
        public IWebElement homeAddressRow { get; set; }

        private const string homePhoneRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column  Home Phone, Value')])[1]";
        [FindsBy(How = How.XPath, Using = homePhoneRowLocator)]
        public IWebElement homePhoneRow { get; set; }

        private const string languagesRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column  Languages, Value')])[1]";
        [FindsBy(How = How.XPath, Using = languagesRowLocator)]
        public IWebElement languagesRow { get; set; }

        private const string locationInTheFirmRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column  Location In The Firm, Value')])[1]";
        [FindsBy(How = How.XPath, Using = locationInTheFirmRowLocator)]
        public IWebElement locationInTheFirmRow { get; set; }

        private const string middleNameRowLocator = "(//pulse-user-list//td[contains(@aria-label, 'Column  Middle Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = middleNameRowLocator)]
        public IWebElement middleNameRow { get; set; }
        #endregion
    }
}
