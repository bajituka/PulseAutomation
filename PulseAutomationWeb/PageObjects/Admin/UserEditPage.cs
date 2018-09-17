using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.Admin
{
    class UserEditPage : GridActions

    {
        private const string saveBtnLocator = "//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }

        #region user info
        private const string selectPhotoLinkLocator = "//div[@aria-label='Select a photo']";
        [FindsBy(How = How.XPath, Using = selectPhotoLinkLocator)]
        public IWebElement selectPhotoLink { get; set; }

        private const string firstNameInputLocator = "//div[child::label[text()='First Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = firstNameInputLocator)]
        public IWebElement firstNameInput { get; set; }

        private const string middleNameInputLocator = "//div[child::label[text()='Middle Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = middleNameInputLocator)]
        public IWebElement middleNameInput { get; set; }

        private const string lastNameInputLocator = "//div[child::label[text()='Last Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = lastNameInputLocator)]
        public IWebElement lastNameInput { get; set; }

        private const string birthdayInputLocator = "//div[child::label[text()='Birthday']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = birthdayInputLocator)]
        public IWebElement birthdayInput { get; set; }

        private const string homeAddressInputLocator = "//div[child::label[text()='Home Address']]//dx-text-area[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = homeAddressInputLocator)]
        public IWebElement homeAddressInput { get; set; }

        private const string homePhoneInputLocator = "//div[child::label[text()='Home Phone']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = homePhoneInputLocator)]
        public IWebElement homePhoneInput { get; set; }

        private const string cellPhoneInputLocator = "//div[child::label[text()='Cell Phone']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = cellPhoneInputLocator)]
        public IWebElement cellPhoneInput { get; set; }

        private const string personalEmailAddressInputLocator = "//div[child::label[text()='Personal Email Address']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = personalEmailAddressInputLocator)]
        public IWebElement personalEmailAddressInput { get; set; }

        private const string emergencyContactNameInputLocator = "//div[child::label[text()='Emergency Contact Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = emergencyContactNameInputLocator)]
        public IWebElement emergencyContactNameInput { get; set; }

        private const string emergencyContactPhoneInputLocator = "//div[child::label[text()='Emergency Contact Phone']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = emergencyContactPhoneInputLocator)]
        public IWebElement emergencyContactPhoneInput { get; set; }

        private const string languagesInputLocator = "//div[child::label[text()='Languages']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = languagesInputLocator)]
        public IWebElement languagesInput { get; set; }

        private const string barAdmissionsInputLocator = "//div[child::label[text()='Bar Admissions']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = barAdmissionsInputLocator)]
        public IWebElement barAdmissionsInput { get; set; }

        private const string locationInTheFirmInputLocator = "//div[child::label[text()='Location In The Firm']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = locationInTheFirmInputLocator)]
        public IWebElement locationInTheFirmInput { get; set; }
        #endregion

        #region expertise profile
        private const string industryExperienceInputLocator = "//div[child::label[text()='Industry Experience']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = industryExperienceInputLocator)]
        public IWebElement industryExperienceInput { get; set; }

        private const string judgeClerkshipsInputLocator = "//div[child::label[text()='Judge Clerkships']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = judgeClerkshipsInputLocator)]
        public IWebElement judgeClerkshipsInput { get; set; }

        private const string personalityTypesInputLocator = "//div[child::label[text()='Personality Types']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = personalityTypesInputLocator)]
        public IWebElement personalityTypesInput { get; set; }

        private const string previousLawFirmExperienceInputLocator = "//div[child::label[text()='Previous law firm experience']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = previousLawFirmExperienceInputLocator)]
        public IWebElement previousLawFirmExperienceInput { get; set; }

        private const string boardMembershipsInputLocator = "//div[child::label[text()='Board Memberships']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = boardMembershipsInputLocator)]
        public IWebElement boardMembershipsInput { get; set; }

        private const string proBonoInputLocator = "//div[child::label[text()='Pro Bono']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = proBonoInputLocator)]
        public IWebElement proBonoInput { get; set; }

        private const string areaOfFocusInputLocator = "//div[child::label[text()='Area of Focus']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = areaOfFocusInputLocator)]
        public IWebElement areaOfFocusInput { get; set; }

        private const string clientsInputLocator = "//div[child::label[text()='Clients']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = clientsInputLocator)]
        public IWebElement clientsInput { get; set; }

        private const string technologyInputLocator = "//div[child::label[text()='Technology']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = technologyInputLocator)]
        public IWebElement technologyInput { get; set; }

        private const string mattersTheyHaveWorkedOnInputLocator = "//div[child::label[text()='Matters they have worked on']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = mattersTheyHaveWorkedOnInputLocator)]
        public IWebElement mattersTheyHaveWorkedOnInput { get; set; }
        #endregion

        #region user rights
        private const string fullAdminCheckboxLocator = "//dx-check-box[@ng-reflect-text='Full Admin']";
        [FindsBy(How = How.XPath, Using = fullAdminCheckboxLocator)]
        public IWebElement fullAdminCheckbox { get; set; }

        private const string accessSocialSecurityCheckboxLocator = "//dx-check-box[@ng-reflect-text='Access Social Security']";
        [FindsBy(How = How.XPath, Using = accessSocialSecurityCheckboxLocator)]
        public IWebElement accessSocialSecurityCheckbox { get; set; }

        private const string applyMatterSecurityCheckboxLocator = "//dx-check-box[@ng-reflect-text='Apply Matter Security']";
        [FindsBy(How = How.XPath, Using = applyMatterSecurityCheckboxLocator)]
        public IWebElement applyMatterSecurityCheckbox { get; set; }

        private const string createAssignmentsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Create Assignments']";
        [FindsBy(How = How.XPath, Using = createAssignmentsCheckboxLocator)]
        public IWebElement createAssignmentsCheckbox { get; set; }

        private const string createContactsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Create Contacts']";
        [FindsBy(How = How.XPath, Using = createContactsCheckboxLocator)]
        public IWebElement createContactsCheckbox { get; set; }

        private const string createEditWorkflowCheckboxLocator = "//dx-check-box[@ng-reflect-text='Create/Edit Workflow']";
        [FindsBy(How = How.XPath, Using = createEditWorkflowCheckboxLocator)]
        public IWebElement createEditWorkflowCheckbox { get; set; }

        private const string dmsCheckboxLocator = "//dx-check-box[@ng-reflect-text='DMS']";
        [FindsBy(How = How.XPath, Using = dmsCheckboxLocator)]
        public IWebElement dmsCheckbox { get; set; }

        private const string deleteActivitiesCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Activities']";
        [FindsBy(How = How.XPath, Using = deleteActivitiesCheckboxLocator)]
        public IWebElement deleteActivitiesCheckbox { get; set; }

        private const string deleteAppointmentsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Appointments']";
        [FindsBy(How = How.XPath, Using = deleteAppointmentsCheckboxLocator)]
        public IWebElement deleteAppointmentsCheckbox { get; set; }

        private const string deleteContactsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Contacts']";
        [FindsBy(How = How.XPath, Using = deleteContactsCheckboxLocator)]
        public IWebElement deleteContactsCheckbox { get; set; }

        private const string deleteDocumentsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Documents']";
        [FindsBy(How = How.XPath, Using = deleteDocumentsCheckboxLocator)]
        public IWebElement deleteDocumentsCheckbox { get; set; }

        private const string deleteNotesCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Notes']";
        [FindsBy(How = How.XPath, Using = deleteNotesCheckboxLocator)]
        public IWebElement deleteNotesCheckbox { get; set; }

        private const string deleteTaskTemplatesCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Task Templates']";
        [FindsBy(How = How.XPath, Using = deleteTaskTemplatesCheckboxLocator)]
        public IWebElement deleteTaskTemplatesCheckbox { get; set; }

        private const string deleteTasksCheckboxLocator = "//dx-check-box[@ng-reflect-text='Delete Tasks']";
        [FindsBy(How = How.XPath, Using = deleteTasksCheckboxLocator)]
        public IWebElement deleteTasksCheckbox { get; set; }

        private const string editContactsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Edit Contacts']";
        [FindsBy(How = How.XPath, Using = editContactsCheckboxLocator)]
        public IWebElement editContactsCheckbox { get; set; }

        private const string lpmCalendarAppointmentsCheckboxLocator = "//dx-check-box[@ng-reflect-text='LPM Calendar Appointments']";
        [FindsBy(How = How.XPath, Using = lpmCalendarAppointmentsCheckboxLocator)]
        public IWebElement lpmCalendarAppointmentsCheckbox { get; set; }

        private const string newMatterIntakeCheckboxLocator = "//dx-check-box[@ng-reflect-text='New Matter Intake']";
        [FindsBy(How = How.XPath, Using = newMatterIntakeCheckboxLocator)]
        public IWebElement newMatterIntakeCheckbox { get; set; }

        private const string offlineSyncCheckboxLocator = "//dx-check-box[@ng-reflect-text='Offline Sync']";
        [FindsBy(How = How.XPath, Using = offlineSyncCheckboxLocator)]
        public IWebElement offlineSyncCheckbox { get; set; }

        private const string performExportsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Perform Exports']";
        [FindsBy(How = How.XPath, Using = performExportsCheckboxLocator)]
        public IWebElement performExportsCheckbox { get; set; }

        private const string performImportsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Perform Imports']";
        [FindsBy(How = How.XPath, Using = performImportsCheckboxLocator)]
        public IWebElement performImportsCheckbox { get; set; }

        private const string runDuplicateCheckManuallyCheckboxLocator = "//dx-check-box[@ng-reflect-text='Run Duplicate Check Manually']";
        [FindsBy(How = How.XPath, Using = runDuplicateCheckManuallyCheckboxLocator)]
        public IWebElement runDuplicateCheckManuallyCheckbox { get; set; }

        private const string secureContactCheckboxLocator = "//dx-check-box[@ng-reflect-text='Secure Contact']";
        [FindsBy(How = How.XPath, Using = secureContactCheckboxLocator)]
        public IWebElement secureContactCheckbox { get; set; }

        private const string secureContactFieldsCheckboxLocator = "//dx-check-box[@ng-reflect-text='Secure Contact Fields']";
        [FindsBy(How = How.XPath, Using = secureContactFieldsCheckboxLocator)]
        public IWebElement secureContactFieldsCheckbox { get; set; }

        private const string sendTextMessageCheckboxLocator = "//dx-check-box[@ng-reflect-text='Send Text Message']";
        [FindsBy(How = How.XPath, Using = sendTextMessageCheckboxLocator)]
        public IWebElement sendTextMessageCheckbox { get; set; }
        #endregion
    }
}
