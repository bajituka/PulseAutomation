using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.Admin
{
    class ManageLookups : GridActions

    {
        private const string manageLookupsGridLocator = "//pulse-manage-dictionary";

        #region Appointments
        private const string appointmentsLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Appointments']]";
        [FindsBy(How = How.XPath, Using = appointmentsLinkLocator)]
        public IWebElement appointmentsLink { get; set; }

        private const string appearanceTypesMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Appearance Types']";
        [FindsBy(How = How.XPath, Using = appearanceTypesMenuItemLocator)]
        public IWebElement appearanceTypesMenuItem { get; set; }

        private const string appointmentTypesMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Appointment Types']";
        [FindsBy(How = How.XPath, Using = appointmentTypesMenuItemLocator)]
        public IWebElement appointmentTypesMenuItem { get; set; }

        private const string venuesMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Venues']";
        [FindsBy(How = How.XPath, Using = appointmentTypesMenuItemLocator)]
        public IWebElement venuesMenuItem { get; set; }
        #endregion

        #region ContactRoles
        private const string contactRolesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Contact Roles']]";
        [FindsBy(How = How.XPath, Using = contactRolesLinkLocator)]
        public IWebElement contactRolesLink { get; set; }

        private const string companyRolesMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Company Roles']";
        [FindsBy(How = How.XPath, Using = companyRolesMenuItemLocator)]
        public IWebElement companyRolesMenuItem { get; set; }

        private const string personRolesMenuItemLocator = "//div[@class='dx-submenu']//span[text()='Person Roles']";
        [FindsBy(How = How.XPath, Using = personRolesMenuItemLocator)]
        public IWebElement personRolesMenuItem { get; set; }
        #endregion

        private const string officesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Offices']]";
        [FindsBy(How = How.XPath, Using = officesLinkLocator)]
        public IWebElement officesLink { get; set; }

        private const string activitiesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Activities']]";
        [FindsBy(How = How.XPath, Using = activitiesLinkLocator)]
        public IWebElement activitiesLink { get; set; }

        private const string zipCodesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Zip Codes']]";
        [FindsBy(How = How.XPath, Using = zipCodesLinkLocator)]
        public IWebElement zipCodesLink { get; set; }

        private const string taskTypesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Task Types']]";
        [FindsBy(How = How.XPath, Using = taskTypesLinkLocator)]
        public IWebElement taskTypesLink { get; set; }

        private const string holidaysLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Holidays']]";
        [FindsBy(How = How.XPath, Using = holidaysLinkLocator)]
        public IWebElement holidaysLink { get; set; }

        private const string specialtiesLinkLocator = "//pulse-manage-dictionary//div[@role='menuitem'][descendant::span[text()='Specialties']]";
        [FindsBy(How = How.XPath, Using = specialtiesLinkLocator)]
        public IWebElement specialtiesLink { get; set; }



        private const string addBtnLocator = "//pulse-manage-dictionary//dx-button//div[descendant::i[@class='dx-icon dx-icon-iconpulse-add']]";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        #region grid action controls

        private const string refreshBtnLocator = manageLookupsGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        private const string clearFiltersBtnLocator = manageLookupsGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = manageLookupsGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = manageLookupsGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = manageLookupsGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = manageLookupsGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string nameHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Name Column']";
        [FindsBy(How = How.XPath, Using = nameHeaderLocator)]
        public IWebElement nameHeader { get; set; }

        private const string activeHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Active']";
        [FindsBy(How = How.XPath, Using = activeHeaderLocator)]
        public IWebElement activeHeader { get; set; }

        private const string createdOnHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Created On']";
        [FindsBy(How = How.XPath, Using = createdOnHeaderLocator)]
        public IWebElement createdOnHeader { get; set; }

        private const string createdByHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Created By']";
        [FindsBy(How = How.XPath, Using = createdByHeaderLocator)]
        public IWebElement createdByHeader { get; set; }

        private const string systemHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='System']";
        [FindsBy(How = How.XPath, Using = systemHeaderLocator)]
        public IWebElement systemHeader { get; set; }

        private const string abbreviationHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Abbreviation']";
        [FindsBy(How = How.XPath, Using = abbreviationHeaderLocator)]
        public IWebElement abbreviationHeader { get; set; }

        private const string managerHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Manager']";
        [FindsBy(How = How.XPath, Using = managerHeaderLocator)]
        public IWebElement managerHeader { get; set; }

        private const string managingPartnerHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Managing Partner']";
        [FindsBy(How = How.XPath, Using = managingPartnerHeaderLocator)]
        public IWebElement managingPartnerHeader { get; set; }

        private const string zipCodeHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Zip Code']";
        [FindsBy(How = How.XPath, Using = zipCodeHeaderLocator)]
        public IWebElement zipCodeHeader { get; set; }

        private const string cityHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='City']";
        [FindsBy(How = How.XPath, Using = cityHeaderLocator)]
        public IWebElement cityHeader { get; set; }

        private const string countyHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='County']";
        [FindsBy(How = How.XPath, Using = countyHeaderLocator)]
        public IWebElement countyHeader { get; set; }

        private const string stateHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='State']";
        [FindsBy(How = How.XPath, Using = stateHeaderLocator)]
        public IWebElement stateHeader { get; set; }

        private const string dayHeaderLocator = "//pulse-manage-dictionary//td[@aria-label='Day']";
        [FindsBy(How = How.XPath, Using = dayHeaderLocator)]
        public IWebElement dayHeader { get; set; }
        #endregion

        #region grid filters
        private const string nameFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = nameFilterLocator)]
        public IWebElement nameFilter { get; set; }

        private const string activeFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Active, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = activeFilterLocator)]
        public IWebElement activeFilter { get; set; }

        private const string createdOnFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Created On, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdOnFilterLocator)]
        public IWebElement createdOnFilter { get; set; }

        private const string createdByFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Created By, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = createdByFilterLocator)]
        public IWebElement createdByFilter { get; set; }

        private const string systemFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column System, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = systemFilterLocator)]
        public IWebElement systemFilter { get; set; }

        private const string abbreviationFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Abbreviation, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = abbreviationFilterLocator)]
        public IWebElement abbreviationFilter { get; set; }

        private const string managerFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Manager, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = managerFilterLocator)]
        public IWebElement managerFilter { get; set; }

        private const string managingPartnerFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Managing Partner, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = managingPartnerFilterLocator)]
        public IWebElement managingPartnerFilter { get; set; }

        private const string zipCodeFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Zip Code, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = zipCodeFilterLocator)]
        public IWebElement zipCodeFilter { get; set; }

        private const string cityFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column City, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = cityFilterLocator)]
        public IWebElement cityFilter { get; set; }

        private const string countyFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column County, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = countyFilterLocator)]
        public IWebElement countyFilter { get; set; }

        private const string stateFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column State, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = stateFilterLocator)]
        public IWebElement stateFilter { get; set; }

        private const string dayFilterLocator = "//pulse-manage-dictionary//td[@aria-label='Column Day, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = dayFilterLocator)]
        public IWebElement dayFilter { get; set; }
        #endregion

        #region first row data
        private const string nameRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = nameRowLocator)]
        public IWebElement nameRow { get; set; }

        private const string activeRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Active, Value')])[1]";
        [FindsBy(How = How.XPath, Using = activeRowLocator)]
        public IWebElement activeRow { get; set; }

        private const string createdOnRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Created On, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdOnRowLocator)]
        public IWebElement createdOnRow { get; set; }

        private const string createdByRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Created By, Value')])[1]";
        [FindsBy(How = How.XPath, Using = createdByRowLocator)]
        public IWebElement createdByRow { get; set; }

        private const string systemRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column System, Value')])[1]";
        [FindsBy(How = How.XPath, Using = systemRowLocator)]
        public IWebElement systemRow { get; set; }

        private const string abbreviationRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Abbreviation, Value')])[1]";
        [FindsBy(How = How.XPath, Using = abbreviationRowLocator)]
        public IWebElement abbreviationRow { get; set; }

        private const string managerRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Manager, Value')])[1]";
        [FindsBy(How = How.XPath, Using = managerRowLocator)]
        public IWebElement managerRow { get; set; }

        private const string managingPartnerRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Managing Partner, Value')])[1]";
        [FindsBy(How = How.XPath, Using = managingPartnerRowLocator)]
        public IWebElement managingPartnerRow { get; set; }

        private const string zipCodeRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Zip Code, Value')])[1]";
        [FindsBy(How = How.XPath, Using = zipCodeRowLocator)]
        public IWebElement zipCodeRow { get; set; }

        private const string cityRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column City, Value')])[1]";
        [FindsBy(How = How.XPath, Using = cityRowLocator)]
        public IWebElement cityRow { get; set; }

        private const string countyRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column County, Value')])[1]";
        [FindsBy(How = How.XPath, Using = countyRowLocator)]
        public IWebElement countyRow { get; set; }

        private const string stateRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column State, Value')])[1]";
        [FindsBy(How = How.XPath, Using = stateRowLocator)]
        public IWebElement stateRow { get; set; }

        private const string dayRowLocator = "(//pulse-manage-dictionary//td[contains(@aria-label, 'Column Day, Value')])[1]";
        [FindsBy(How = How.XPath, Using = dayRowLocator)]
        public IWebElement dayRow { get; set; }
        #endregion

        #region Appointment, Contact Role, Activity, Task Types, Specialities edit form

        private const string nameInputLocator = "//div[child::label[text()='Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = nameInputLocator)]
        public IWebElement nameInput { get; set; }

        private const string activeCheckboxLocator = "//dx-check-box//span[@class='dx-checkbox-icon']";
        [FindsBy(How = How.XPath, Using = activeCheckboxLocator)]
        public IWebElement activeCheckbox { get; set; }

        private const string saveAndNewBtnLocator = "//pulse-email-template-list///dx-button[@aria-label='Save and New']";
        [FindsBy(How = How.XPath, Using = saveAndNewBtnLocator)]
        public IWebElement saveAndNewBtn { get; set; }

        private const string saveBtnLocator = "//pulse-email-template-list///dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }

        private const string cancelBtnLocator = "//pulse-email-template-list///dx-button[@aria-label='Cancel']";
        [FindsBy(How = How.XPath, Using = cancelBtnLocator)]
        public IWebElement cancelBtn { get; set; }

        #endregion
    }
}
