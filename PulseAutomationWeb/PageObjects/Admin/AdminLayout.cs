using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.Admin
{
    class AdminLayout
    {
        #region left menu
        private const string usersLinkLocator = "//div[@title='Users']";
        [FindsBy(How = How.XPath, Using = usersLinkLocator)][CacheLookup]
        public IWebElement UsersLink { get; set; }

        private const string emailTemplatesLinkLocator = "//div[@title='Email Templates']";
        [FindsBy(How = How.XPath, Using = emailTemplatesLinkLocator)][CacheLookup]
        public IWebElement emailTemplatesLink { get; set; }

        private const string manageLookupsLinkLocator = "//div[@title='Manage Lookups']";
        [FindsBy(How = How.XPath, Using = manageLookupsLinkLocator)]
        [CacheLookup]
        public IWebElement manageLookupsLink { get; set; }
        #endregion

    }
}
