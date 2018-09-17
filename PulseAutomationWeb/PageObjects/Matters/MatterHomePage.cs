using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.ContactsTab
{
    class MatterHomePage : Layout
    {

        private const string matter360TextLocator = "//div[@class='page-header clearfix']/h1";
        [FindsBy(How = How.XPath, Using = matter360TextLocator)]
        public IWebElement matter360Text { get; set; }

        private const string refreshPanelsBtnLocator = "//pulse-matter-component//div[@title='Refresh Panels']";
        [FindsBy(How = How.XPath, Using = refreshPanelsBtnLocator)]
        public IWebElement refreshPanelsBtn { get; set; }

        private const string editPanelsBtnLocator = "//pulse-matter-component//div[@title='Edit Panels']";
        [FindsBy(How = How.XPath, Using = editPanelsBtnLocator)]
        public IWebElement editPanelsBtn { get; set; }

        public static void WaitForPageLoaded(IWebDriver driver)
        {
            Waitings.WaitForElementsVisible(driver, 5, refreshPanelsBtnLocator, matter360TextLocator);
        }

    }
}
