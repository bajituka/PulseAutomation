using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;

namespace PulseAutomationWeb.PageObjects.ContactsTab
{
    class ContactLayout
    {
        public const string eventsLinkLocator = "//pulse-contact-details//div[@role='menuitem'][descendant::span[text()='Events']]";
        [FindsBy(How = How.XPath, Using = eventsLinkLocator)]
        public IWebElement eventsLink { get; set; }

        public const string notesMenuItemLocator = "//ul[@class='dx-menu-items-container dx-menu-no-icons']//span[text()='Notes']";
        [FindsBy(How = How.XPath, Using = notesMenuItemLocator)]
        public IWebElement notesMenuItem { get; set; }

        public const string tasksMenuItemLocator = "//ul[@class='dx-menu-items-container dx-menu-no-icons']//span[text()='Tasks']";
        [FindsBy(How = How.XPath, Using = tasksMenuItemLocator)]
        public IWebElement tasksMenuItem { get; set; }


        public void NavigateTo(IWebDriver driver, params IWebElement[] element)
        {
            Waitings.WaitForElementClickable(driver, eventsLinkLocator, 10);
            for(int index = 0; index < element.Length; index++)
            {
                Utilities.MoveToElement(driver, element[index]);
               Thread.Sleep(1000);
                element[index].Click();
            }
        }
    }
}
