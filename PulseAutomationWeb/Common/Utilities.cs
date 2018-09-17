using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Globalization;

namespace PulseAutomationWeb.Common
{
    class Waitings
    {
        public static void WaitForElementLocated(IWebDriver driver, string locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
        }

        public static void WaitForElementVisible(IWebDriver driver, string locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        public static void WaitForElementsVisible(IWebDriver driver, int seconds, params string[] args)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            for (var i = 0; i < args.Length; i++)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(args[i])));
        }

        public static void WaitForElementClickable(IWebDriver driver, string locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        }

        public static void WaitForElementStale(IWebDriver driver, IWebElement element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public static void WaitForElementNotVisible(IWebDriver driver, string locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locator)));
        }

        public static void WaitForTextInInput(IWebDriver driver, IWebElement element, string text, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
        }

        public static void WaitForTextInElement(IWebDriver driver, IWebElement element, string text, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public static void WaitForTextInElementLocated(IWebDriver driver, By locator, string text, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public static void WaitForLoadingEnds(IWebDriver driver)
        {
            string locator = "//pulse-shell//div[@class='dx-loadpanel-message'][text()='Loading...']";
            try
            {
                WaitForElementVisible(driver, locator, 1);
            }
            catch (Exception)
            {
                //do nothing
            }
            WaitForElementNotVisible(driver, locator, 20);
            Thread.Sleep(1000);
        }

        public static void WaitForSavingEnds(IWebDriver driver)
        {
            string locator = "//pulse-shell//div[text()='Saving...']";
            try
            {
                WaitForElementVisible(driver, locator, 1);
            }
            catch (Exception)
            {
                //do nothing
            }
            WaitForElementNotVisible(driver, locator, 20);
        }

        public static void WaitForSaveButtonDisappear(IWebDriver driver)
        {
            string locator = "//dx-button[@aria-label='Save']";
            try
            {
                WaitForElementVisible(driver, locator, 1);
            }
            catch (Exception)
            {
                //do nothing
            }
            WaitForElementNotVisible(driver, locator, 20);
        }

        public static void WaitForSuccessMsg(IWebDriver driver)
        {
            string successMsg = "//div[@class='dx-overlay-content dx-toast-success dx-toast-content dx-resizable']";
            WaitForElementVisible(driver, successMsg, 2);
            WaitForElementNotVisible(driver, successMsg, 5);
        }

        public static void WaitForNoErrorMsg(IWebDriver driver)
        {
            string errorMsg = "//div[@class='dx-overlay-content dx-toast-error dx-toast-content dx-resizable']";
                for (var i = 0; i < 5; i++)
                {
                    WaitForElementNotVisible(driver, errorMsg, 3);
                }
        }
    }
    
    class Utilities
    {
        public static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void DragNdrop(IWebDriver driver, IWebElement elementSource, IWebElement elementTarget)
        {
            Actions actions = new Actions(driver);
            actions.DragAndDrop(elementSource, elementTarget);
            actions.Perform();
        }

        public static void ReplaceWithValue(IWebDriver driver, IWebElement element, string value)
        {
            Waitings.WaitForTextInInput(driver, element, "", 1);
            element.Clear();
            element.SendKeys(value);
        }

        public static void SelectInAutocomplete(IWebDriver driver, IWebElement autoCompleteElement, string value)
        {
            autoCompleteElement.SendKeys(value);
            string resultLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[text()='" + value + "']";
            Waitings.WaitForElementClickable(driver, resultLocator, 5);
            driver.FindElement(By.XPath(resultLocator)).Click();
            Waitings.WaitForElementNotVisible(driver, resultLocator, 2);
        }

        public static void SelectInAutocompletePopup(IWebDriver driver, IWebElement autoCompleteElement, string value)
        {
            autoCompleteElement.SendKeys(value);
            string resultLocator = "//div[@class='pulse-selectbox-grid-popup-content dx-template-wrapper']//td[text()='" + value + "']";
            Waitings.WaitForElementClickable(driver, resultLocator, 5);
            driver.FindElement(By.XPath(resultLocator)).Click();
            Waitings.WaitForElementNotVisible(driver, resultLocator, 2);
        }

        public static void SelectInDropdown(IWebDriver driver, IWebElement dropdownElement, string value)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[text()='" + value + "']";
            dropdownElement.Click();
            Waitings.WaitForElementLocated(driver, locator, 5);
            Thread.Sleep(200);
            IWebElement element = driver.FindElement(By.XPath(locator));
            MoveToElement(driver, element);
            Thread.Sleep(500);
            element.Click();
            Waitings.WaitForElementNotVisible(driver, locator, 5);
        }
        public static void SelectInHoverMenu(IWebDriver driver, IWebElement hoverElement, IWebElement menuItem)
        {
            MoveToElement(driver, hoverElement);
            Thread.Sleep(500);
            menuItem.Click();
        }
        public static void DeleteContact(IWebDriver driver)
        {
            // string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Yes'][preceding::div[text()='Are you sure you want to delete contact?']]";
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Yes']";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }
        public static void CloseAllTabsPopup(IWebDriver driver)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Yes'][preceding::div[text()='Are you sure you want to close all tabs?']]";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }
        public static void CustomViewPopup(IWebDriver driver)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='No'][preceding::div[text()='Do you want to save a filter as a custom view?']]";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }
        public static void UnsavedChangesPopup(IWebDriver driver)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='No'][preceding::div[contains(text(), 'Unsaved changes')]]";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }
        public static void DeleteItem(IWebDriver driver)
        {
            string locator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Yes']";
            Waitings.WaitForElementVisible(driver, locator, 3);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementNotVisible(driver, locator, 3);
        }

        public static void RightClick(IWebDriver driver, string locator)
        {
            IWebElement element = driver.FindElement(By.XPath(locator));
            Actions actions = new Actions(driver);
            actions.ContextClick(element);
            actions.Perform();
        }

        public static void SwitchToTab(string tabName, IWebDriver driver)
        {
            Waitings.WaitForElementClickable(driver, "//pulse-tabs//span[text()='" + tabName + "']", 5);
            driver.FindElement(By.XPath("//pulse-tabs//span[text()='" + tabName + "']")).Click();
        }

        public static string CurrentDate()
        {
            return DateTime.Now.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
        }
        public static string CurrentDateSql()
        {
            return DateTime.Now.ToString("s", CultureInfo.InvariantCulture);
        }
    }
}
