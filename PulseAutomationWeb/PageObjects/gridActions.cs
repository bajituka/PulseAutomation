using System.Threading;
using OpenQA.Selenium;
using PulseAutomationWeb.Common;
using OpenQA.Selenium.Support.PageObjects;


namespace PulseAutomationWeb.PageObjects
{
    public class GridActions
    {
        protected const string myContactsCheckboxBaseLocator = "//div[@class='under-grid-top-controls']//dx-check-box[@role='checkbox']";

        protected const string refreshBtnBaseLocator = "//dx-button[@aria-label='iconpulse-refresh']";

        protected const string clearFiltersBtnBaseLocator = "//div[@class='float-left button-without-border grid-clear-filter']";
        protected const string columnChooserBtnBaseLocator = "//div[@aria-label='Column Chooser']";
        protected const string exportBtnBaseLocator = "//div[@aria-label='export-excel-button']";

        protected const string columnChooserListLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[contains(@class, 'dx-datagrid-column-chooser-list')]";
        protected const string columnChooserCloseBtnLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//div[starts-with(@class, 'dx-closebutton')]";

        protected const string saveFilterSelectBaseLocator = "//dx-select-box[@displayexpr='Name']//input[not(@type='hidden')]";
        protected const string saveFilterSelectForClickBaseLocator = "//dx-select-box[@displayexpr='Name']//div[@class='dx-texteditor-container']";

        protected const string saveFilterBtnBaseLocator = "//dx-button[@aria-label='iconpulse-save']";
        protected const string saveFilterNameInputLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//input[@name='templateName']";
        protected const string saveFilterSaveBtnLocator = "//div[starts-with(@class, 'dx-overlay-wrapper')]//dx-button[@aria-label='Save']/div";
        protected const string deleteFilterBtnBaseLocator = "//dx-button[@aria-label='iconpulse-delete-big']";

        protected const string firstRowLocator = "//div[@class='dx-datagrid-content']//tr[@role='row'][not(contains(@class, 'dx-freespace-row'))][1]";

        #region context menu
        protected const string editBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Edit']]";
        [FindsBy(How = How.XPath, Using = editBtnLocator)]
        public IWebElement editBtn { get; set; }

        protected const string deleteBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Delete']]";
        [FindsBy(How = How.XPath, Using = deleteBtnLocator)]
        public IWebElement deleteBtn { get; set; }

        protected const string addToPersonalBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Add to Personal']]";
        [FindsBy(How = How.XPath, Using = addToPersonalBtnLocator)]
        public IWebElement addToPersonalBtn { get; set; }

        protected const string removeFromPersonalBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Remove from Personal']]";
        [FindsBy(How = How.XPath, Using = removeFromPersonalBtnLocator)]
        public IWebElement removeFromPersonalBtn { get; set; }

        protected const string printDetailsBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Print Details']]";
        [FindsBy(How = How.XPath, Using = printDetailsBtnLocator)]
        public IWebElement printDetailsBtn { get; set; }

        protected const string completeBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Complete']]";
        [FindsBy(How = How.XPath, Using = completeBtnLocator)]
        public IWebElement completeBtn { get; set; }

        protected const string duplicateBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Duplicate']]";
        [FindsBy(How = How.XPath, Using = duplicateBtnLocator)]
        public IWebElement duplicateBtn { get; set; }

        protected const string convertToAppointmentBtnLocator = "//div[@class='dx-overlay-wrapper']//div[@role='menuitem'][descendant::span[text()='Convert to Appointment']]";
        [FindsBy(How = How.XPath, Using = convertToAppointmentBtnLocator)]
        public IWebElement convertToAppointmentBtn { get; set; }
        #endregion

        protected void ClearFilters(IWebDriver driver, string parentLocator, IWebElement[] filtersArray)
        {
            string locator = parentLocator + clearFiltersBtnBaseLocator;
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(locator)).Click();
            foreach (IWebElement i in filtersArray)
            {
                Thread.Sleep(1000);
                Waitings.WaitForTextInInput(driver, i, "", 5);
                Thread.Sleep(1000);
            }
        }

        protected void HideColumn(IWebDriver driver, string parentLocator, IWebElement column)
        {
            string locator = parentLocator + columnChooserBtnBaseLocator;
            Waitings.WaitForElementClickable(driver, locator, 5);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementVisible(driver, columnChooserListLocator, 2);
            Thread.Sleep(500);
            IWebElement columnChooserList = driver.FindElement(By.XPath(columnChooserListLocator));
            Utilities.DragNdrop(driver, column, columnChooserList);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(columnChooserCloseBtnLocator)).Click();
            Waitings.WaitForElementNotVisible(driver, columnChooserCloseBtnLocator, 3);
            Thread.Sleep(1000);
        }

        protected void ShowColumn(IWebDriver driver, string parentLocator, string columnName, IWebElement targetElement)
        {
            string locator = parentLocator + columnChooserBtnBaseLocator;
            Waitings.WaitForElementClickable(driver, locator, 5);
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementVisible(driver, columnChooserListLocator, 2);
            Thread.Sleep(500);
            IWebElement column = driver.FindElement(By.XPath("//div[starts-with(@class, 'dx-overlay-wrapper')]//div[text()='" + columnName + "']"));
            Utilities.DragNdrop(driver, column, targetElement);
            Thread.Sleep(500);
            Waitings.WaitForElementStale(driver, column, 5);
            driver.FindElement(By.XPath(columnChooserCloseBtnLocator)).Click();
            Waitings.WaitForElementNotVisible(driver, columnChooserCloseBtnLocator, 3);
            Thread.Sleep(1000);
        }

        protected void SaveViewWithName(IWebDriver driver, string parentLocator, string viewName)
        {
            string locator = parentLocator + saveFilterBtnBaseLocator;
            driver.FindElement(By.XPath(locator)).Click();
            Waitings.WaitForElementVisible(driver, saveFilterNameInputLocator, 2);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(saveFilterNameInputLocator)).SendKeys(viewName);
            driver.FindElement(By.XPath(saveFilterSaveBtnLocator)).Click();
            Waitings.WaitForElementNotVisible(driver, saveFilterSaveBtnLocator, 3);
        }

        protected void SaveView(IWebDriver driver, string parentLocator)
        {
            string locator = parentLocator + saveFilterBtnBaseLocator;
            Waitings.WaitForElementClickable(driver, locator, 2);
            driver.FindElement(By.XPath(locator)).Click();
        }

        protected void DeleteView(IWebDriver driver, string parentLocator)
        {
            string locator = parentLocator + deleteFilterBtnBaseLocator;
            Waitings.WaitForElementClickable(driver, locator, 2);
            driver.FindElement(By.XPath(locator)).Click();
            Utilities.DeleteItem(driver);
        }

        protected void FindEntryByInput(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            filterElement.SendKeys(value);
            filterElement.SendKeys(Keys.Return);
            Waitings.WaitForLoadingEnds(driver);
            Waitings.WaitForTextInElement(driver, rowElement, value, 5);
        }
        protected void FindEntryByDropdown(IWebDriver driver, IWebElement filterElement, IWebElement rowElement, string value)
        {
            Utilities.SelectInDropdown(driver, filterElement, value);
            Waitings.WaitForLoadingEnds(driver);
            Waitings.WaitForTextInElement(driver, rowElement, value, 5);
        }
        protected void OpenEntry(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementClickable(driver, editBtnLocator, 5);
            editBtn.Click();
            Waitings.WaitForElementNotVisible(driver, firstRow, 10);
        }

        protected void OpenEntryLeftClick(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            driver.FindElement(By.XPath(firstRow)).Click();
        }

        protected void DeleteEntry(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, deleteBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, deleteBtnLocator, 5);
            deleteBtn.Click();
            Utilities.DeleteContact(driver);
            Waitings.WaitForElementStale(driver, firstRowEl, 10);
        }

        protected void AddToPersonal(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, addToPersonalBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, addToPersonalBtnLocator, 5);
            addToPersonalBtn.Click();
        }
        protected void RemoveFromPersonal(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, removeFromPersonalBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, removeFromPersonalBtnLocator, 5);
            removeFromPersonalBtn.Click();
        }

        protected void WaitForGridLoaded(IWebDriver driver, params string[] args)
        {
            Waitings.WaitForElementsVisible(driver, 40, args);
        }

        protected void PrintDetails(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, printDetailsBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, printDetailsBtnLocator, 5);
            printDetailsBtn.Click();
        }

        public void Complete(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, completeBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, completeBtnLocator, 5);
            completeBtn.Click();
        }
        public void Duplicate(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, duplicateBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, duplicateBtnLocator, 5);
            duplicateBtn.Click();
        }
        public void ConvertToAppointment(IWebDriver driver, string parentLocator)
        {
            string firstRow = parentLocator + firstRowLocator;
            Utilities.RightClick(driver, firstRow);
            Waitings.WaitForElementVisible(driver, convertToAppointmentBtnLocator, 2);
            IWebElement firstRowEl = driver.FindElement(By.XPath(firstRow));
            Waitings.WaitForElementClickable(driver, convertToAppointmentBtnLocator, 5);
            convertToAppointmentBtn.Click();
        }

    }
}
