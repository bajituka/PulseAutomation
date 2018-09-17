using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.Calendar
{

    class CalendarPage : GridActions
    {
        private const string calendarPageLocator = "//pulse-calendar";

        private const string appointmentContentLocator = "//div[@class='dx-item-content dx-scheduler-appointment-content']";
        [FindsBy(How = How.XPath, Using = appointmentContentLocator)]
        public IWebElement appointmentContent { get; set; }

        #region add Appointment menu
        private const string addBtnLocator = "//pulse-calendar//i[@class='iconpulse-add pointer']";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        public const string clearFiltersBtnLocator = "//pulse-calendar//dx-button[@aria-label='iconpulse-clear-filters-small']";
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string settingsBtnLocator = "//pulse-calendar//i[@title='Open settings']";
        [FindsBy(How = How.XPath, Using = settingsBtnLocator)]
        public IWebElement settingsBtn { get; set; }

        private const string exportBtnLocator = calendarPageLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = calendarPageLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = calendarPageLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = calendarPageLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region left menu
        private const string officeSelectLocator = "//div[child::label[text()='Office']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = officeSelectLocator)]
        public IWebElement officeSelect { get; set; }

        private const string appearingAttorneyInputLocator = "//div[child::label[text()='Appearing Attorney']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = appearingAttorneyInputLocator)]
        public IWebElement appearingAttorneyInput { get; set; }

        private const string meCheckboxLocator = "//div[child::span[text()='Me']]";
        [FindsBy(How = How.XPath, Using = meCheckboxLocator)]
        public IWebElement meCheckbox { get; set; }

        private const string matterInputLocator = "//div[child::label[text()='Matter']]//input";
        [FindsBy(How = How.XPath, Using = matterInputLocator)]
        public IWebElement matterInput { get; set; }

        private const string venueSelectLocator = "//div[child::label[text()='Venue']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = venueSelectLocator)]
        public IWebElement venueSelect { get; set; }

        private const string appointmentTypeSelectLocator = "//div[child::label[text()='Appointment Type']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = appointmentTypeSelectLocator)]
        public IWebElement appointmentTypeSelect { get; set; }

        private const string appearanceTypeSelectLocator = "//div[child::label[text()='Appearance Type']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = appearanceTypeSelectLocator)]
        public IWebElement appearanceTypeSelect { get; set; }
        #endregion

        #region upper menu
        private const string startDateInputLocator = "//div[@class='as-inline-block']";
        [FindsBy(How = How.XPath, Using = startDateInputLocator)]
        public IWebElement startDateInput { get; set; }

        private const string endDateInputLocator = "/div[@class='as-inline-block margin-left-5']";
        [FindsBy(How = How.XPath, Using = endDateInputLocator)]
        public IWebElement endDateInput { get; set; }

        private const string searchInputLocator = "//input[following-sibling::div[@data-dx_placeholder='Search for meeting subject...']]";
        [FindsBy(How = How.XPath, Using = searchInputLocator)]
        public IWebElement searchInput { get; set; }

        private const string agendaTabLocator = "//span[text()='Agenda']";
        [FindsBy(How = How.XPath, Using = agendaTabLocator)]
        public IWebElement agendaTab { get; set; }

        private const string monthTabLocator = "//span[text()='Month']";
        [FindsBy(How = How.XPath, Using = monthTabLocator)]
        public IWebElement monthTab { get; set; }

        private const string weekTabLocator = "//span[text()='Week']";
        [FindsBy(How = How.XPath, Using = weekTabLocator)]
        public IWebElement weekTab { get; set; }

        private const string workWeekTabLocator = "//span[text()='Work Week']";
        [FindsBy(How = How.XPath, Using = workWeekTabLocator)]
        public IWebElement workWeekTab { get; set; }

        private const string dayTabLocator = "//span[text()='Day']";
        [FindsBy(How = How.XPath, Using = dayTabLocator)]
        public IWebElement dayTab { get; set; }
        #endregion

        #region appointment creation form
        private const string recipientsInputLocator = "//div[child::label[text()='Recipients']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = recipientsInputLocator)]
        public IWebElement recipientsInput { get; set; }

        private const string appearingAttorneyAddInputLocator = "//dx-text-box//input[not(@type='hidden')][preceding::label[1][text()='Appearing Attorney']]";
        [FindsBy(How = How.XPath, Using = appearingAttorneyAddInputLocator)]
        public IWebElement appearingAttorneyAddInput { get; set; }

        private const string meetingSubjectInputLocator = "//div[child::label[text()='Meeting Subject']]//input";
        [FindsBy(How = How.XPath, Using = meetingSubjectInputLocator)]
        public IWebElement meetingSubjectInput { get; set; }

        private const string clientContactInputLocator = "//div[@class='dx-popup-content']//dx-text-box//input[not(@type='hidden')][preceding::label[1][text()='Client / Contact']]";
        [FindsBy(How = How.XPath, Using = clientContactInputLocator)]
        public IWebElement clientContactInput { get; set; }

        private const string appointmentTypeAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Appointment Type']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = appointmentTypeAddSelectLocator)]
        public IWebElement appointmentTypeAddSelect { get; set; }

        private const string matterAddInputLocator = "//div[@class='dx-popup-content']//pulse-selectbox-grid[child::label[text()='Matter']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = matterAddInputLocator)]
        public IWebElement matterAddInput { get; set; }

        private const string appearanceTypeAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Appearance Type']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = appearanceTypeAddSelectLocator)]
        public IWebElement appearanceTypeAddSelect { get; set; }

        private const string venueAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Venue']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = venueAddSelectLocator)]
        public IWebElement venueAddSelect { get; set; }

        private const string officeAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Office']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = officeAddSelectLocator)]
        public IWebElement officeAddSelect { get; set; }


        private const string startOnInputLocator = "//dx-date-box[@ng-reflect-type='datetime'][preceding-sibling::label[text()='Start On']]";
        [FindsBy(How = How.XPath, Using = startOnInputLocator)]
        public IWebElement startOnInput { get; set; }

        private const string endOnInputLocator = "//dx-date-box[@ng-reflect-type='datetime'][preceding-sibling::label[text()='End On']]";
        [FindsBy(How = How.XPath, Using = endOnInputLocator)]
        public IWebElement endOnInput { get; set; }

        private const string dueDateInputLocator = "//dx-date-box[@ng-reflect-type='date']";
        [FindsBy(How = How.XPath, Using = dueDateInputLocator)]
        public IWebElement dueDateInput { get; set; }

        private const string commentsFieldLocator = "//div[@class='dx-template-wrapper']//textarea";
        [FindsBy(How = How.XPath, Using = commentsFieldLocator)]
        public IWebElement commentsField { get; set; }
        //repeat
        private const string repeatOnSwitchLocator = "//div[@class='dx-recurrence-switch dx-switch dx-swipeable dx-widget']//div[@class='dx-switch-inner']";
        [FindsBy(How = How.XPath, Using = repeatOnSwitchLocator)]
        public IWebElement repeatOnSwitch { get; set; }

        //block repeat
        private const string dailyRadioButtonLocator = "//div[@class='dx-radio-value-container'][following-sibling::div[text()='Daily']]";
        [FindsBy(How = How.XPath, Using = dailyRadioButtonLocator)]
        public IWebElement dailyRadioButton { get; set; }

        private const string weeklyRadioButtonLocator = "//div[@class='dx-radio-value-container'][following-sibling::div[text()='Weekly']]";
        [FindsBy(How = How.XPath, Using = weeklyRadioButtonLocator)]
        public IWebElement weeklyRadioButton { get; set; }

        private const string monthlyRadioButtonLocator = "//div[@class='dx-radio-value-container'][following-sibling::div[text()='Monthly']]";
        [FindsBy(How = How.XPath, Using = monthlyRadioButtonLocator)]
        public IWebElement monthlyRadioButton { get; set; }

        private const string yearlyRadioButtonLocator = "//div[@class='dx-radio-value-container'][following-sibling::div[text()='Yearly']]";
        [FindsBy(How = How.XPath, Using = yearlyRadioButtonLocator)]
        public IWebElement yearlyRadioButton { get; set; }

        private const string reminderAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Reminder']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = reminderAddSelectLocator)]
        public IWebElement reminderAddSelect { get; set; }

        private const string categoryAddSelectLocator = "//div[@class='dx-template-wrapper']//div[child::label[text()='Category']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = categoryAddSelectLocator)]
        public IWebElement categoryAddSelect { get; set; }

        private const string saveAndNewBtnLocator = "//div[@class='dx-button-content']/span[text()='Save and New']";
        [FindsBy(How = How.XPath, Using = saveAndNewBtnLocator)]
        public IWebElement saveAndNewBtn { get; set; }

        private const string saveBtnLocator = "//div[@class='dx-button-content']/span[text()='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }

        private const string cancelBtnLocator = "//div[@class='dx-button-content']/span[text()='Cancel']";
        [FindsBy(How = How.XPath, Using = cancelBtnLocator)]
        public IWebElement cancelBtn { get; set; }

        #endregion

        #region appointment action form
        private const string openAppointmentBtnLocator = "//span[text()='Open appointment']";
        [FindsBy(How = How.XPath, Using = openAppointmentBtnLocator)]
        public IWebElement openAppointmentBtn { get; set; }

        private const string deleteAppointmentBtnLocator = "//dx-button[@aria-label='trash']";
        [FindsBy(How = How.XPath, Using = deleteAppointmentBtnLocator)]
        public IWebElement deleteAppointmentBtn { get; set; }
        #endregion

        public static void ConfirmDeletingOfAppointment(IWebDriver driver)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Yes'][preceding::div[text()='Are you sure you want to delete the appointment?']]";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }

        public void AddAppointment(IWebDriver driver, Appointment appointment )
        {
            Waitings.WaitForElementClickable(driver, addBtnLocator, 10);
            addBtn.Click();
            Waitings.WaitForElementClickable(driver, recipientsInputLocator, 3);
            meetingSubjectInput.SendKeys(appointment.MeetingSubject);

            if (appointment.AppearanceType != null) Utilities.SelectInDropdown(driver, appearanceTypeAddSelect, appointment.AppearanceType);
            if (appointment.Venue != null) Utilities.SelectInDropdown(driver, venueAddSelect, appointment.Venue);
            if (appointment.Recipients != null) Utilities.SelectInAutocomplete(driver, recipientsInput, appointment.Recipients);
            if (appointment.AppearingAttorney != null) Utilities.SelectInAutocompletePopup(driver, appearingAttorneyAddInput, appointment.AppearingAttorney);
            if (appointment.ClientContact != null) Utilities.SelectInAutocompletePopup(driver, clientContactInput, appointment.ClientContact);
            if (appointment.Matter != null) Utilities.SelectInAutocompletePopup(driver, matterAddInput, appointment.Matter);
            if (appointment.AppointmentType != null) Utilities.SelectInDropdown(driver, appointmentTypeAddSelect, appointment.AppointmentType);
            if (appointment.Office != null) Utilities.SelectInDropdown(driver, officeAddSelect, appointment.Office);
            if (appointment.StartOn != null) startOnInput.SendKeys(appointment.StartOn);
            if (appointment.EndOn != null) endOnInput.SendKeys(appointment.EndOn);
            if (appointment.DueDate != null) dueDateInput.SendKeys( appointment.DueDate);
            //if (appointment.Comments != null) commentsField.SendKeys(appointment.Comments);
            if (appointment.Repeat != null) repeatOnSwitch.Click();
            if (appointment.Reminder != null) Utilities.SelectInDropdown(driver, reminderAddSelect, appointment.Reminder);
            if (appointment.Category != null) Utilities.SelectInDropdown(driver, categoryAddSelect, appointment.Category);
            Waitings.WaitForElementClickable(driver, saveBtnLocator, 5);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }

        public void OpenAppointment(IWebDriver driver, string appointmentName)
        {
            Waitings.WaitForElementClickable(driver, clearFiltersBtnLocator, 10);
            clearFiltersBtn.Click();
            Waitings.WaitForElementClickable(driver, agendaTabLocator, 10);
            agendaTab.Click();
            Waitings.WaitForElementVisible(driver, searchInputLocator, 5);
            searchInput.SendKeys(appointmentName);
            Waitings.WaitForElementVisible(driver, "//div[@title='" + appointmentName + "']", 3);
            driver.FindElement(By.XPath("//div[@title='" + appointmentName + "']")).Click();
            Waitings.WaitForElementClickable(driver, openAppointmentBtnLocator, 10);
            openAppointmentBtn.Click();
        }

        public void DeleteAppointment(IWebDriver driver, string appointmentName)
        {
            Waitings.WaitForElementClickable(driver, agendaTabLocator, 10);
            agendaTab.Click();
            Waitings.WaitForElementVisible(driver, searchInputLocator, 5);
            searchInput.SendKeys(appointmentName);
            Waitings.WaitForElementVisible(driver, "//div[@title='"+ appointmentName +"']", 3);
            driver.FindElement(By.XPath("//div[@title='" + appointmentName + "']")).Click();
            Waitings.WaitForElementClickable(driver, deleteAppointmentBtnLocator, 5);
            deleteAppointmentBtn.Click();
            ConfirmDeletingOfAppointment(driver);
        }

        public void EditAppointment(IWebDriver driver, string appointmentName)
        {
            Waitings.WaitForElementClickable(driver, agendaTabLocator, 10);
            agendaTab.Click();
            Waitings.WaitForElementVisible(driver, searchInputLocator, 5);
            searchInput.SendKeys(appointmentName);
            Waitings.WaitForElementVisible(driver, "//div[@title='" + appointmentName + "']", 3);
            driver.FindElement(By.XPath("//div[@title='" + appointmentName + "']")).Click();
            Waitings.WaitForElementClickable(driver, deleteAppointmentBtnLocator, 5);
            openAppointmentBtn.Click();
        }

    }
}

