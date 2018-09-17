using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.Admin
{
    class EmailTemplatesGridPage : GridActions

    {
        private const string emailTemplatesGridLocator = "//pulse-email-template-list";

        private const string addBtnLocator = "//pulse-email-template-list//dx-button//div[descendant::i[@class='dx-icon dx-icon-iconpulse-add']]";
        [FindsBy(How = How.XPath, Using = addBtnLocator)]
        public IWebElement addBtn { get; set; }

        #region grid action controls

        private const string refreshBtnLocator = emailTemplatesGridLocator + refreshBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = refreshBtnLocator)]
        public IWebElement refreshBtn { get; set; }

        private const string clearFiltersBtnLocator = emailTemplatesGridLocator + clearFiltersBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = clearFiltersBtnLocator)]
        public IWebElement clearFiltersBtn { get; set; }

        private const string exportBtnLocator = emailTemplatesGridLocator + exportBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = exportBtnLocator)]
        public IWebElement exportBtn { get; set; }

        private const string savedFilterSelectLocator = emailTemplatesGridLocator + saveFilterSelectBaseLocator;
        [FindsBy(How = How.XPath, Using = savedFilterSelectLocator)]
        public IWebElement savedFilterSelect { get; set; }

        private const string saveFiltersBtnLocator = emailTemplatesGridLocator + saveFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = saveFiltersBtnLocator)]
        public IWebElement saveFiltersBtn { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterNameInputLocator)]
        public IWebElement saveFilterNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = saveFilterSaveBtnLocator)]
        public IWebElement saveFilterSaveBtn { get; set; }

        private const string deleteFilterBtnLocator = emailTemplatesGridLocator + deleteFilterBtnBaseLocator;
        [FindsBy(How = How.XPath, Using = deleteFilterBtnLocator)]
        public IWebElement deleteFilterBtn { get; set; }
        #endregion

        #region grid headers
        private const string nameHeaderLocator = "//pulse-email-template-list//td[@aria-label='Name Column']";
        [FindsBy(How = How.XPath, Using = nameHeaderLocator)]
        public IWebElement nameHeader { get; set; }

        private const string subjectLineHeaderLocator = "//pulse-email-template-list//td[@aria-label='Subject Line Column']";
        [FindsBy(How = How.XPath, Using = subjectLineHeaderLocator)]
        public IWebElement subjectLineHeader { get; set; }

        private const string bodyHeaderLocator = "//pulse-email-template-list//td[@aria-label='Body Column']";
        [FindsBy(How = How.XPath, Using = bodyHeaderLocator)]
        public IWebElement bodyHeader { get; set; }
        #endregion

        #region grid filters
        private const string nameFilterLocator = "//pulse-email-template-list//td[@aria-label='Column Name, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = nameFilterLocator)]
        public IWebElement nameFilter { get; set; }

        private const string subjectLineFilterLocator = "//pulse-email-template-list//td[@aria-label='Column Subject Line, Filter cell']//input";
        [FindsBy(How = How.XPath, Using = subjectLineFilterLocator)]
        public IWebElement subjectLineFilter { get; set; }

        private const string bodyFilterLocator = "//pulse-email-template-list//td[@aria-label='Column Body, Filter cell']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = bodyFilterLocator)]
        public IWebElement bodyFilter { get; set; }
        #endregion

        #region first row data
        private const string nameRowLocator = "(//pulse-email-template-list//td[contains(@aria-label, 'Column Name, Value')])[1]";
        [FindsBy(How = How.XPath, Using = nameRowLocator)]
        public IWebElement privacyRow { get; set; }

        private const string subjectLineRowLocator = "(//pulse-email-template-list//td[contains(@aria-label, 'Column Subject Line, Value')])[1]";
        [FindsBy(How = How.XPath, Using = subjectLineRowLocator)]
        public IWebElement priorityRow { get; set; }

        private const string bodyRowLocator = "(//pulse-email-template-list//td[contains(@aria-label, 'Column Body, Value')])[1]";
        [FindsBy(How = How.XPath, Using = bodyRowLocator)]
        public IWebElement bodyRow { get; set; }
        #endregion

        #region email template edit form
        private const string nameInputLocator = "//div[child::label[text()='Name']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = nameInputLocator)]
        public IWebElement nameInput { get; set; }

        private const string subjectInputLocator = "//div[child::label[text()='Subject']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = subjectInputLocator)]
        public IWebElement subjectInput { get; set; }

        private const string subjectTokenSelectLocator = "//pulse-email-template-list//dx-select-box[preceding::label[text()='Subject Token']]";
        [FindsBy(How = How.XPath, Using = subjectTokenSelectLocator)]
        public IWebElement subjectTokenSelect { get; set; }

        private const string bodyFieldLocator = "//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = bodyFieldLocator)]
        public IWebElement bodyField { get; set; }

        private const string saveBtnLocator = "//pulse-email-template-list///dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }
        #endregion
    }
}
