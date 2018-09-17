using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects
{
    class Layout
    {
        #region left menu
        private const string homeLinkLocator = "//div[@title='Home']";
        [FindsBy(How = How.XPath, Using = homeLinkLocator)][CacheLookup]
        public IWebElement homeLink { get; set; }

        private const string contactsLinkLocator = "//div[@title='Contacts']";
        [FindsBy(How = How.XPath, Using = contactsLinkLocator)][CacheLookup]
        public IWebElement contactsLink { get; set; }

        private const string mattersLinkLocator = "//div[@title='Matters']";
        [FindsBy(How = How.XPath, Using = mattersLinkLocator)]
        [CacheLookup]
        public IWebElement mattersLink { get; set; }

        private const string eventsLinkLocator = "//div[@title='Events']";
        [FindsBy(How = How.XPath, Using = eventsLinkLocator)][CacheLookup]
        public IWebElement eventsLink { get; set; }

        private const string calendarLinkLocator = "//div[@title='Calendar']";
        [FindsBy(How = How.XPath, Using = calendarLinkLocator)][CacheLookup]
        public IWebElement calendarLink { get; set; }
        #endregion

        #region add menu
        private const string quickAddBtnLocator = "//header//div[starts-with(@class, 'menu-popover')]";
        [FindsBy(How = How.XPath, Using = quickAddBtnLocator)]
        public IWebElement quickAddBtn{ get; set; }

        private const string notesBtnLocator = "//div[@class='dx-submenu']//span[text()='New Note']";
        [FindsBy(How = How.XPath, Using = notesBtnLocator)]
        public IWebElement notesBtn { get; set; }

        private const string tasksBtnLocator = "//div[@class='dx-submenu']//span[text()='New Task']";
        [FindsBy(How = How.XPath, Using = tasksBtnLocator)]
        public IWebElement tasksBtn { get; set; }

        private const string activitiesBtnLocator = "//div[@class='dx-submenu']//span[text()='New Activity']";
        [FindsBy(How = How.XPath, Using = activitiesBtnLocator)]
        public IWebElement activitiesBtn { get; set; }

        private const string contactsBtnLocator = "//div[@class='dx-submenu']//span[text()='New Contact']";
        [FindsBy(How = How.XPath, Using = contactsBtnLocator)]
        public IWebElement contactsBtn { get; set; }

        private const string personBtnLocator = "//div[@class='dx-overlay-wrapper']/div/div/ul[@class='dx-menu-items-container'][count(li)=5]//span[text()='Person']";
        [FindsBy(How = How.XPath, Using = personBtnLocator)]
        public IWebElement personBtn { get; set; }

        private const string companyBtnLocator = "//div[@class='dx-overlay-wrapper']/div/div/ul[@class='dx-menu-items-container'][count(li)=5]//span[text()='Company']";
        [FindsBy(How = How.XPath, Using = companyBtnLocator)]
        public IWebElement companyBtn { get; set; }

        private const string messagesBtnLocator = "//div[@class='dx-submenu']//span[text()='New Message']";
        [FindsBy(How = How.XPath, Using = messagesBtnLocator)]
        public IWebElement messagesBtn { get; set; }

        private const string userNameBtnLocator = "//dx-menu[starts-with(@class, 'login-menu')][1]";
        [FindsBy(How = How.XPath, Using = userNameBtnLocator)]
        public IWebElement userNameBtn { get; set; }

        private const string signOutBtnLocator = "//div//span[text()='Sign out']";
        [FindsBy(How = How.XPath, Using = signOutBtnLocator)]
        public IWebElement signOutBtn { get; set; }

        public void OpenCreationFormFor(string contactRole, IWebDriver driver)
        {
            quickAddBtn.Click();
            Waitings.WaitForElementVisible(driver, contactsBtnLocator, 2);
            Utilities.MoveToElement(driver, contactsBtn);
            Waitings.WaitForElementVisible(driver, personBtnLocator, 2);
            switch (contactRole)
            {
                case "Person":
                    personBtn.Click();
                    break;
                case "Company":
                    companyBtn.Click();
                    break;
            }
        }
        #endregion

        #region quick add menu note add form
        private const string quickAddNotePrioritySelectLocator = "//pulse-note-information//dx-select-box[preceding::label[text()='Priority']]";
        [FindsBy(How = How.XPath, Using = quickAddNotePrioritySelectLocator)]
        public IWebElement quickAddNotePrioritySelect { get; set; }

        private const string quickAddNoteTextFieldLocator = "//pulse-note-information//div[@class='cke_contents cke_reset']/div";
        [FindsBy(How = How.XPath, Using = quickAddNoteTextFieldLocator)]
        public IWebElement quickAddNoteTextField { get; set; }

        private const string quickAddNoteGlobalRadioBtnLocator = "//pulse-note-information//div[@class='dx-radio-value-container'][following-sibling::div[text()='Global']]";
        [FindsBy(How = How.XPath, Using = quickAddNoteGlobalRadioBtnLocator)]
        public IWebElement quickAddNoteGlobalRadioBtn { get; set; }

        private const string quickAddNotePrivateRadioBtnLocator = "//pulse-note-information//div[@class='dx-radio-value-container'][following-sibling::div[text()='Private']]";
        [FindsBy(How = How.XPath, Using = quickAddNotePrivateRadioBtnLocator)]
        public IWebElement quickAddNotePrivateRadioBtn { get; set; }

        private const string quickAddNoteSaveBtnLocator = "//div[starts-with(@class, 'popup-buttons-pane')]//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = quickAddNoteSaveBtnLocator)]
        public IWebElement quickAddNoteSaveBtn { get; set; }
        #endregion

        private const string activeTabLocator = "//div[@class='dx-item dx-tab dx-tab-selected']";
        [FindsBy(How = How.XPath, Using = activeTabLocator)]
        public IWebElement activeTab { get; set; }

        private const string adminBtnLocator = "//span[text()='Admin']";
        [FindsBy(How = How.XPath, Using = adminBtnLocator)]
        public IWebElement adminBtn { get; set; }

        private const string homeBtnLocator = "//span[text()='Home']";
        [FindsBy(How = How.XPath, Using = homeBtnLocator)]
        public IWebElement homeBtn { get; set; }

        private const string logOutBtnLocator = "//span[text()='Sign out']";
        [FindsBy(How = How.XPath, Using = logOutBtnLocator)]
        public IWebElement logOutBtn { get; set; }

        private const string closeTabsBtnLocator = "//i[@title='Close all tabs']";
        [FindsBy(How = How.XPath, Using = closeTabsBtnLocator)]
        public IWebElement closeTabsBtn { get; set; }

        public const string overlayPopupCloseBtnLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//i[@class='dx-icon dx-icon-close']";
        [FindsBy(How = How.XPath, Using = overlayPopupCloseBtnLocator)]
        public IWebElement overlayPopupCloseBtn { get; set; }

        public void CloseActiveTab(IWebDriver driver)
        {
            string closeActiveTabBtnLocator = activeTabLocator + "//i";
            IWebElement closeActiveTabBtn = driver.FindElement(By.XPath(closeActiveTabBtnLocator));
            Waitings.WaitForElementClickable(driver, closeActiveTabBtnLocator, 2);
            closeActiveTabBtn.Click();
            Waitings.WaitForElementStale(driver, closeActiveTabBtn, 5);
        }

        public void InvokeMethod(Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                //do nothing
            }
        }
        public void CloseAllTabs(IWebDriver driver)
        {
            Waitings.WaitForElementVisible(driver, "//div[@class='dx-tabs-wrapper']/div[2]", 10);
            IWebElement secondTab = driver.FindElement(By.XPath("//div[@class='dx-tabs-wrapper']/div[2]"));
            Thread.Sleep(1000);
            closeTabsBtn.Click();

            InvokeMethod(() => Utilities.UnsavedChangesPopup(driver));
            InvokeMethod(() => Utilities.CloseAllTabsPopup(driver));
            InvokeMethod(() => Utilities.CustomViewPopup(driver));
        }

        public void CleanUpCloseTabs(IWebDriver driver)
        {

                Waitings.WaitForElementVisible(driver, "//div[@class='dx-tabs-wrapper']/div", 10);
                int tabsAmount = driver.FindElements(By.XPath("//div[@class='dx-tabs-wrapper']/div")).Count;

                if (tabsAmount > 1)
                {
                    Waitings.WaitForElementVisible(driver, "//div[@class='dx-tabs-wrapper']/div[2]", 10);
                    IWebElement secondTab = driver.FindElement(By.XPath("//div[@class='dx-tabs-wrapper']/div[2]"));
                    closeTabsBtn.Click();

                    InvokeMethod(() => Utilities.CloseAllTabsPopup(driver));
                    InvokeMethod(() => Utilities.CustomViewPopup(driver));
                    InvokeMethod(() => Utilities.UnsavedChangesPopup(driver));
                    //Waitings.WaitForElementStale(driver, secondTab, 3);
                }
        }

        public void LogOut(IWebDriver driver)
        {
            userNameBtn.Click();
            Waitings.WaitForElementVisible(driver, signOutBtnLocator, 2);
            signOutBtn.Click();
        }

        public void OpenAdminPage(IWebDriver driver)
        {
            userNameBtn.Click();
            Waitings.WaitForElementVisible(driver, adminBtnLocator, 2);
            adminBtn.Click();
        }

        public void OpenContactsGrid(IWebDriver driver)
        {
            Thread.Sleep(5000);
            Waitings.WaitForElementClickable(driver, contactsLinkLocator, 5);
            contactsLink.Click();
            ContactsTab.ContactsGridPage contactsGridPage = new ContactsTab.ContactsGridPage();
            contactsGridPage.WaitForGridLoaded(driver);
        }

        public void OpenMattersPage(IWebDriver driver)
        {
            Waitings.WaitForElementClickable(driver, mattersLinkLocator, 15);
            mattersLink.Click();
        }

        public void OpenEventsPage(IWebDriver driver)
        {
            Waitings.WaitForElementClickable(driver, eventsLinkLocator, 10);
            Thread.Sleep(5000);
            eventsLink.Click();
        }

        public void OpenCalendarPage(IWebDriver driver)
        {
            Waitings.WaitForElementClickable(driver, calendarLinkLocator, 5);
            calendarLink.Click();
        }

        public void AddNoteFromQuickAddMenu(IWebDriver driver, string priorityValue, string text)
        {
            Waitings.WaitForElementClickable(driver, quickAddBtnLocator, 10);
            quickAddBtn.Click();
            Waitings.WaitForElementClickable(driver, notesBtnLocator, 5);
            notesBtn.Click();
            Thread.Sleep(1000);
            Waitings.WaitForElementClickable(driver, quickAddNotePrioritySelectLocator, 10);
            Utilities.SelectInDropdown(driver, quickAddNotePrioritySelect, priorityValue);
            quickAddNoteTextField.SendKeys(text);
            Thread.Sleep(3000);
            quickAddNoteSaveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }
    }
}
    