using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.PageObjects.ContactsTab;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace PulseAutomationWeb.TestCases.Contacts
{
    [TestClass]
    public class MatterTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static MattersGridPage mattersGridPage = new MattersGridPage();
        private static MatterHomePage matterHomePagee = new MatterHomePage();

        private static IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);

        public static void CleanTests()
        {
            try
            {
                layout.CleanUpCloseTabs(driver);
            }
            catch (Exception)
            {
                //layout.overlayPopupCloseBtn.Click();
               //// Thread.Sleep(2000);
                layout.CleanUpCloseTabs(driver);
            }

            string deleteMatter = "delete FROM [dbo].[Matters] where Name = 'QATest'";
            string deleteTasks = "delete FROM [dbo].[Tasks] where Title like '%qa%'";
            string deleteAppointments = "delete FROM [dbo].[Appointments] where MeetingSubject like '%QA%'";
            string deleteContacts = "delete FROM [dbo].[Contacts] where DeletedAt is null and LastName like '%QA%'";
            string deleteCompanies = "delete FROM [dbo].[Contacts] where DeletedAt is null and Name like '%QA%'";
            string deleteNotes = "delete FROM [dbo].[Notes] where Value like '%QA%'";
            string deleteActivities = "delete FROM [dbo].[Activities] where Notes like '%QA%'";
            Database.ExecuteQuery(deleteMatter);
            Database.ExecuteQuery(deleteTasks);
            Database.ExecuteQuery(deleteAppointments);
            Database.ExecuteQuery(deleteNotes);
            Database.ExecuteQuery(deleteActivities);
            Database.ExecuteQuery(deleteContacts);
            Database.ExecuteQuery(deleteCompanies);
        }


        [ClassInitialize]
        public static void GetUrl(TestContext testContext)
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
            PageFactory.InitElements(driver, mattersGridPage);

            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            //CleanTests();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CleanTests();
            layout.LogOut(driver);
        }

        [TestInitialize]
        public void OpenContactsGrid()
        {
            string createMatter = "insert into [dbo].[Matters] (Name, ContactId, CreatedById, CreatedAt, UpdatedById, UpdatedAt, Status, OwnedById, IsPrivate, HandlingAttorneyId, Number)  values ('QATest', (select max(id) from dbo.Contacts), (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '2017-04-04 07:51:53.127', (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '2017-04-04 07:51:53.127', '1', (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '0', (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com'), '777')";
            Database.ExecuteQuery(createMatter);
            layout.OpenMattersPage(driver);
            mattersGridPage.WaitForGridLoaded(driver);
        }

        [TestCleanup]
        public void CloseAllTabs()
        {
            ////Thread.Sleep(5000);
            layout.CloseAllTabs(driver);
        }

        [TestMethod]
        [Description("Should find a matter by all filters")]
        public void FindMatterByFilters()
        {
            mattersGridPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, MattersGridPage.matterNameFilterLocator, 5);
            //search by default shown filters
            string[] baseValues = { "QATest", "777" };
            IWebElement[] baseFilters = { mattersGridPage.matterNameFilter, mattersGridPage.matterCodeFilter };
            IWebElement[] baseFirstRowData = { mattersGridPage.matterNameRow, mattersGridPage.matterCodeRow };
            //mattersGridPage.ClearFilters(driver);
            for (int index = 0; index < baseValues.Length; index++)
            {
                mattersGridPage.FindMatterByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                mattersGridPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
            }
        }

        [TestMethod]
        [Description("Open a matter")]
        public void OpenMatter()
        {
            string matterName = "QATest";
            mattersGridPage.clearFiltersBtn.Click();
            mattersGridPage.FindMatterByInput(driver, mattersGridPage.matterNameFilter, mattersGridPage.matterNameRow, matterName);
            mattersGridPage.OpenMatter(driver);
        }

    }
}