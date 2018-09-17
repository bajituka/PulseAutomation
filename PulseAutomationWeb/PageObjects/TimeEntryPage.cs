using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects
{
    class TimeEntryPage
    {
        #region timeentry form
        private const string entryDateInputLocator = "//dx-date-box[@ng-reflect-type='date'][preceding-sibling::label[text()='Entry Date']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = entryDateInputLocator)]
        public IWebElement entryDateInput { get; set; }

        private const string timeKeeperInputLocator = "//div[child::label[text()='Time Keeper']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = timeKeeperInputLocator)]
        public IWebElement timeKeeperInput { get; set; }

        private const string clientInputLocator = "//pulse-selectbox-grid[@ng-reflect-title='Client']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = clientInputLocator)]
        public IWebElement clientInput { get; set; }

        private const string matterInputLocator = "//pulse-selectbox-grid[@ng-reflect-title='Matter']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = matterInputLocator)]
        public IWebElement matterInput { get; set; }

        private const string officeSelectLocator = "//pulse-dropdown[@name='office']//dx-select-box//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = officeSelectLocator)]
        public IWebElement officeSelect { get; set; }

        private const string baseHrsMinsInputLocator = "//div[child::label[text()='Base Hrs Mins']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = baseHrsMinsInputLocator)]
        public IWebElement baseHrsMinsInput { get; set; }

        private const string typedByInputLocator = "//pulse-lookup-selector[@title='Typed by']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = typedByInputLocator)]
        public IWebElement typedByInput { get; set; }

        private const string typeSelectLocator = "//pulse-dropdown[@name='types']//dx-select-box//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = typeSelectLocator)]
        public IWebElement typeSelect { get; set; }

        private const string closeButtonLocator = "//i[@title='Close time entry']";
        [FindsBy(How = How.XPath, Using = closeButtonLocator)]
        public IWebElement closeButton { get; set; }


        #region optional_controls
        private const string documentInputLocator = "//dx-select-box[@ng-reflect-placeholder='Select document...']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = documentInputLocator)]
        public IWebElement documentInput { get; set; }

        private const string activityInputLocator = "//pulse-lookup-selector[@title='Activity']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = activityInputLocator)]
        public IWebElement activityInput { get; set; }

        private const string taskInputLocator = "//pulse-lookup-selector[@title='Task']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = taskInputLocator)]
        public IWebElement taskInput { get; set; }
        #endregion

        private const string actionCodeInputLocator = "//pulse-lookup-selector[@title='Action Code']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = actionCodeInputLocator)]
        public IWebElement actionCodeInput { get; set; }

        private const string narrativeTextFieldLocator = "//dx-text-area[preceding-sibling::label[text()='Narrative text']]//textarea";
        [FindsBy(How = How.XPath, Using = narrativeTextFieldLocator)]
        public IWebElement narrativeTextField { get; set; }

        private const string billingCommentsTextFieldLocator = "//dx-text-area[preceding-sibling::label[text()='Billing Comments']]//textarea";
        [FindsBy(How = How.XPath, Using = narrativeTextFieldLocator)]
        public IWebElement billingCommentsTextField { get; set; }

        private const string meCheckboxLocator = "//div[child::span[text()='Me']]";
        [FindsBy(How = How.XPath, Using = meCheckboxLocator)]
        public IWebElement meCheckbox { get; set; }

        private const string noServiceChargeCheckboxLocator = "//dx-check-box[descendant::span[text()='No service charge']]";
        [FindsBy(How = How.XPath, Using = noServiceChargeCheckboxLocator)]
        public IWebElement noServiceChargeCheckbox { get; set; }

        private const string emailEntryCheckboxLocator = "//dx-check-box[descendant::span[text()='Email entry']]";
        [FindsBy(How = How.XPath, Using = emailEntryCheckboxLocator)]
        public IWebElement emailEntryCheckbox { get; set; }

        private const string doNotTransferCheckboxLocator = "//dx-check-box[descendant::span[text()='Do not transfer']]";
        [FindsBy(How = How.XPath, Using = doNotTransferCheckboxLocator)]
        public IWebElement doNotTransferCheckbox { get; set; }

        private const string briefSubjectCheckboxLocator = "//dx-check-box[descendant::span[text()='Brief subject matter description']]";
        [FindsBy(How = How.XPath, Using = briefSubjectCheckboxLocator)]
        public IWebElement briefSubjectCheckbox { get; set; }

        private const string billingCommentsCheckboxLocator = "//dx-check-box[descendant::span[text()='Billing Comments']]";
        [FindsBy(How = How.XPath, Using = billingCommentsCheckboxLocator)]
        public IWebElement billingCommentsCheckbox { get; set; }

        private const string saveAndСommitBtnLocator = "//div[@class='dx-button-content']/span[text()='Save and Commit']";
        [FindsBy(How = How.XPath, Using = saveAndСommitBtnLocator)]
        public IWebElement saveAndСommitBtn { get; set; }

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

        public void AddTimeEntry(IWebDriver driver, TimeEntry timeentry)
        {
            Waitings.WaitForElementClickable(driver, saveAndСommitBtnLocator, 10);
            Thread.Sleep(2000);
            //entryDateInput.SendKeys(timeentry.EntryDate);
            Utilities.SelectInAutocompletePopup(driver, timeKeeperInput, timeentry.TimeKeeper);
            Utilities.SelectInAutocompletePopup(driver, clientInput, timeentry.Client);
            Utilities.SelectInAutocompletePopup(driver, matterInput, timeentry.Matter);
            Utilities.SelectInDropdown(driver, officeSelect, timeentry.Office);
            baseHrsMinsInput.SendKeys(timeentry.BaseHrsMins);
            Utilities.SelectInAutocomplete(driver, actionCodeInput, timeentry.ActionCode);

            if (timeentry.TypedBy != null) Utilities.SelectInAutocomplete(driver, typedByInput, timeentry.TypedBy);
            if (timeentry.Type != null) Utilities.SelectInDropdown(driver, typeSelect, timeentry.Type);
            if (timeentry.NarrativeText != null) narrativeTextField.SendKeys(timeentry.NarrativeText);
            if (timeentry.BillingComments!= null) billingCommentsTextField.SendKeys(timeentry.BillingComments);

            Waitings.WaitForElementClickable(driver, saveBtnLocator, 5);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
    }
}
