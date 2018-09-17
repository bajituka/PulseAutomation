using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using PulseAutomationWeb.PageObjects;
using PulseAutomationWeb.PageObjects.ContactsTab;
using PulseAutomationWeb.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using PulseAutomationWeb.PageObjects.ContactsTab.Events;

namespace PulseAutomationWeb.TestCases.Contacts
{
    [TestClass]
    public class ContactsTest
    {
        private static LoginPage loginPage = new LoginPage();
        private static Layout layout = new Layout();
        private static ContactsGridPage contactsGridPage = new ContactsGridPage();
        private static ContactsCreationPage contactCreationPage = new ContactsCreationPage();
        private static ContactLayout contactLayout = new ContactLayout();
        private static NotesPage notesPage = new NotesPage();

        private static IWebDriver driver = BrowserFactory.getBrowser(ConfigurationManager.AppSettings["browser"]);
 
       public static void CleanTests()
       {
            Thread.Sleep(3000);
            //layout.overlayPopupCloseBtn.Click();
            layout.CleanUpCloseTabs(driver);
       }
                
        [ClassInitialize]
        public static void GetUrl(TestContext testContext)
        {
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["environment"];
            PageFactory.InitElements(driver, loginPage);
            PageFactory.InitElements(driver, layout);
            PageFactory.InitElements(driver, contactsGridPage);
            PageFactory.InitElements(driver, contactCreationPage);
            PageFactory.InitElements(driver, contactLayout);
            PageFactory.InitElements(driver, notesPage);

            loginPage.Authorize(driver, ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            Thread.Sleep(3000);
            CleanTests();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            layout.CloseAllTabs(driver);
            layout.LogOut(driver);
        }

        [TestInitialize]
        public void OpenContactsGrid()
        {
            CleanTests();
            layout.OpenContactsGrid(driver);
            contactsGridPage.WaitForGridLoaded(driver);
        }

        [TestCleanup]
        public void CloseAllTabs()
        {
            layout.CloseAllTabs(driver);
        }

        [TestMethod]
        [Description("Should add a company with all fields populated and two communications entities of each type. The contact created is then used in tests below.")]
        public void AddСompanyWithCommEntities()
        {
            Company qagoogle = new Company("Qagoogle", "Defendant", "www.twitter.com/google", "www.linkedin.com/company/google", "California", "www.google.com");
            Address california = new Address("Business", "94043", "1600 Amphitheatre Parkway", "Room 42", "Mountain View", "California");
            Address miami = new Address("Other", "33317", "842 W Broward Blvd", "Apt. 22", "Fort Lauderdale", "Florida");
            Address[] addresses = { california, miami };
            Phone businessPhone = new Phone("Business", "7897897897");
            Phone mobilePhone = new Phone("Mobile", "6546546547");
            Phone[] phones = { businessPhone, mobilePhone };
            Email businessEmail = new Email("Business", "noreply@google.com");
            Email homeEmail = new Email("Home", "s.brin@gmail.com");
            Email[] emails = { businessEmail, homeEmail };
            Thread.Sleep(1000);
            contactsGridPage.ClearFilters(driver);
            Thread.Sleep(1000);
            Waitings.WaitForLoadingEnds(driver);
            contactsGridPage.OpenCreationFormFor("Company", driver);
            contactCreationPage.CreateCompany(driver, qagoogle, addresses, phones, emails);
        }
        
        [TestMethod]
        [Description("Should add a person with only required fields populated, then fill all fields, having created two records for comm entities, and delete the last comm entities.")]
        public void AddPersonAndFillAllFields()
        {
            string createCompany = "INSERT INTO dbo.Contacts (IsPrivate, Name, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QACompany', '2', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createCompany);
            Person keiraQametz = new Person("Keira", "Qametz", null, null, null, null, null, null, null, null, null, null, "426328959");
            contactsGridPage.OpenCreationFormFor("Person", driver);
            contactCreationPage.CreatePerson(driver, keiraQametz);

            Person keiraQametzFull = new Person("Keira", "Qametz", "Mr.", "Client", "QACompany", "QA Engineer", "Junior", "Van", "twitter.com/myaccount", "California", "myskype", "linkedin.com/myaccount", "426328959");
            IWebElement[] elements = { contactCreationPage.prefixSelect, contactCreationPage.companyInput, contactCreationPage.positionInput, contactCreationPage.suffixSelect, contactCreationPage.middleNameInput, contactCreationPage.twitterInput, contactCreationPage.jurisdictionInput, contactCreationPage.skypeInput, contactCreationPage.linkedinInput };
            string[] values = { keiraQametzFull.Prefix, keiraQametzFull.Company, keiraQametzFull.Position, keiraQametzFull.Suffix, keiraQametzFull.MiddleName, keiraQametzFull.Twitter, keiraQametzFull.Jurisdiction, keiraQametzFull.Skype, keiraQametzFull.LinkedInProfile };
            contactCreationPage.PopulateFields(driver, elements, values);

            Address compton = new Address("Business", "90220", "Grove St.", "Storey 2", "Compton", "California");
            Phone mobilePhone = new Phone("Mobile", "3213213211");
            Email homeEmail = new Email("Home", "k.metz@gmail.com");
            Phone businessPhone = new Phone("Business", "6546546547");
            Email businessEmail = new Email("Business", "hello@company.com");

            contactCreationPage.AddAddress(driver, compton, 1);
            contactCreationPage.AddPhone(driver, mobilePhone, 1);
            contactCreationPage.AddEmail(driver, homeEmail, 1);

            //string isDisabled = contactCreationPage.socialSecurityInput.GetAttribute("disabled");
            //Assert.AreEqual("true", isDisabled);
            contactCreationPage.AddAddress(driver, compton, 2);
            contactCreationPage.AddPhone(driver, businessPhone, 2);
            contactCreationPage.AddEmail(driver, businessEmail, 2);
            contactCreationPage.SaveContact(driver);
            Thread.Sleep(5000);
            contactCreationPage.DeleteCommEntity(driver, "Address", 2);
            contactCreationPage.DeleteCommEntity(driver, "Phone", 2);
            contactCreationPage.DeleteCommEntity(driver, "Email", 2);
            contactCreationPage.SaveContact(driver);
        }

        [TestMethod]
        [Description("Should add a person, skip the duplicate check")]
        public void AddPersonSkipDuplicateCheck()
        {
            Person zeusQametz = new Person("Zeus", "Qametz");
            contactsGridPage.OpenCreationFormFor("Person", driver);
            contactCreationPage.CreatePerson(driver, zeusQametz);
        }
        /* 
        [TestMethod]
        [Description("Should add a person, pass the duplicate check")]
        public void AddPersonPassDuplicateCheck()
        {
            Person zeusMetz = new Person("Zeus", "Metz");
            contactsGridPage.OpenCreationFormFor("Person", driver);
            contactCreationPage.CreatePerson(driver, zeusMetz);
        }
         /*    
        [TestMethod]
        [Description("Should find a contact by all drawn columns.")]
        public void FindContactByFilters()
        {
            //search by default shown filters
            string[] baseValues = { "Keira", "Metz", "(321) 321-3211", "k.metz@gmail.com" };
            IWebElement[] baseFilters = { contactsGridPage.firstNameFilter, contactsGridPage.lastNameFilter, contactsGridPage.phoneFilter, contactsGridPage.emailFilter };
            IWebElement[] baseFirstRowData = { contactsGridPage.firstNameRow, contactsGridPage.lastNameRow, contactsGridPage.phoneRow, contactsGridPage.emailRow };
            contactsGridPage.ClearFilters(driver);
            for (int index = 0; index < baseValues.Length; index++)
            {
                contactsGridPage.FindContactByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                contactsGridPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
            }

            //drag a new filter from column chooser, search by it and then hide
            string[] newColumns = { "Twitter", "Skype", "LinkedIn Profile", "Jurisdiction", "City", "Address Line 1", "Address Line 2", "Zip", "Title"};
            string[] newValues = { "twitter.com/myaccount", "myskype", "linkedin.com/myaccount", "California", "Compton", "Grove St.", "Storey 2", "90220", "QA Engineer"};
            IWebElement[] newFilters = { contactsGridPage.twitterFilter, contactsGridPage.skypeFilter, contactsGridPage.linkedinFilter, contactsGridPage.jurisdictionFilter, contactsGridPage.cityFilter,
            contactsGridPage.addressLine1Filter,contactsGridPage.addressLine2Filter, contactsGridPage.zipFilter, contactsGridPage.titleFilter};
            IWebElement[] newFirstRowData = { contactsGridPage.twitterRow, contactsGridPage.skypeRow, contactsGridPage.linkedinRow, contactsGridPage.jurisdictionRow, contactsGridPage.cityRow,
            contactsGridPage.addressLine1Row,contactsGridPage.addressLine2Row, contactsGridPage.zipRow, contactsGridPage.titleRow};
            IWebElement[] newHeaders = { contactsGridPage.twitterHeader, contactsGridPage.skypeHeader, contactsGridPage.linkedinHeader, contactsGridPage.jurisdictionHeader, contactsGridPage.cityHeader,
            contactsGridPage.addressLine1Header, contactsGridPage.addressLine2Header, contactsGridPage.zipHeader, contactsGridPage.titleHeader };
            for (int index = 0; index < newValues.Length; index++)
            {
                contactsGridPage.ShowColumn(driver, newColumns[index], contactsGridPage.companyHeader);
                contactsGridPage.FindContactByInput(driver, newFilters[index], newFirstRowData[index], newValues[index]);
                contactsGridPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
                contactsGridPage.HideColumn(driver, newHeaders[index]);
            }

            //add a dropdown filter, search by it and hide it
            string[] dropdownColumns = { "Phone Type", "Email Type", "Address Type", "State", "Suffix", "Prefix" };
            string[] dropdownValues = { "Mobile", "Home", "Business", "California", "Junior", "Mr." };
            IWebElement[] dropdownFilters = { contactsGridPage.phoneTypeFilter, contactsGridPage.emailTypeFilter, contactsGridPage.prefixFilter, contactsGridPage.suffixFilter, contactsGridPage.stateFilter, contactsGridPage.addressTypeFilter };
            IWebElement[] dropdownHeaders = { contactsGridPage.phoneTypeHeader, contactsGridPage.emailTypeHeader, contactsGridPage.prefixHeader, contactsGridPage.suffixHeader, contactsGridPage.stateHeader, contactsGridPage.addressTypeHeader };
            IWebElement[] dropdownFirstRowData = { contactsGridPage.phoneTypeRow, contactsGridPage.emailTypeRow, contactsGridPage.prefixRow, contactsGridPage.suffixRow, contactsGridPage.stateRow, contactsGridPage.addressTypeRow };
            for (int index = 0; index < dropdownColumns.Length; index++)
            {
                contactsGridPage.ShowColumn(driver, dropdownColumns[index], contactsGridPage.companyHeader);
                contactsGridPage.FindContactByDropdown(driver, dropdownFilters[index], dropdownFirstRowData[index], dropdownValues[index]);
                contactsGridPage.ClearFilters(driver);
                Waitings.WaitForLoadingEnds(driver);
                contactsGridPage.HideColumn(driver, dropdownHeaders[index]);
            }
        }
              
      
              [TestMethod]
              [Description("Should find a company by all drawn columns.")]
              public void FindCompanyByFilters()
              {
                  //search by default shown filters
                  string[] baseValues = { "Google", "(789) 789-7897", "noreply@google.com" };
                  IWebElement[] baseFilters = { contactsGridPage.companyFilter, contactsGridPage.phoneFilter, contactsGridPage.emailFilter};
                  IWebElement[] baseFirstRowData = { contactsGridPage.companyRow, contactsGridPage.phoneRow, contactsGridPage.emailRow};
                  contactsGridPage.ClearFilters(driver);
                  for (int index = 0; index < baseValues.Length; index++)
                  {
                      contactsGridPage.FindContactByInput(driver, baseFilters[index], baseFirstRowData[index], baseValues[index]);
                      contactsGridPage.ClearFilters(driver);
                      Waitings.WaitForLoadingEnds(driver);
                  }

                  //drag a new filter from column chooser, search by it and then hide
                  string[] newColumns = { "Twitter", "LinkedIn Profile", "Jurisdiction", "City", "Address Line 1", "Address Line 2", "Zip", "www.google.com" };
                  string[] newValues = { "www.twitter.com/google", "www.linkedin.com/company/google", "California", "Mountain View", "1600 Amphitheatre Parkway", "Room 42", "94043" };
                  IWebElement[] newFilters = { contactsGridPage.twitterFilter, contactsGridPage.linkedinFilter, contactsGridPage.jurisdictionFilter, contactsGridPage.cityFilter,
                  contactsGridPage.addressLine1Filter,contactsGridPage.addressLine2Filter, contactsGridPage.zipFilter, contactsGridPage.websiteFilter};
                  IWebElement[] newFirstRowData = { contactsGridPage.twitterRow, contactsGridPage.linkedinRow, contactsGridPage.jurisdictionRow, contactsGridPage.cityRow,
                  contactsGridPage.addressLine1Row, contactsGridPage.addressLine2Row, contactsGridPage.zipRow, contactsGridPage.websiteRow};
                  IWebElement[] newHeaders = { contactsGridPage.twitterHeader, contactsGridPage.linkedinHeader, contactsGridPage.jurisdictionHeader, contactsGridPage.cityHeader,
                  contactsGridPage.addressLine1Header, contactsGridPage.addressLine2Header, contactsGridPage.zipHeader, contactsGridPage.websiteHeader};
                  for (int index = 0; index < newValues.Length; index++)
                  {
                      contactsGridPage.ShowColumn(driver, newColumns[index], contactsGridPage.companyHeader);
                      contactsGridPage.FindContactByInput(driver, newFilters[index], newFirstRowData[index], newValues[index]);
                      contactsGridPage.ClearFilters(driver);
                      Waitings.WaitForLoadingEnds(driver);
                      contactsGridPage.HideColumn(driver, newHeaders[index]);
                  }

                  //add a dropdown filter, search by it and hide it
                  string[] dropdownColumns = { "Phone Type", "Email Type", "State", "Address Type" };
                  string[] dropdownValues = { "Business", "Business", "California", "Business" };
                  IWebElement[] dropdownFilters = { contactsGridPage.phoneTypeFilter, contactsGridPage.emailTypeFilter, contactsGridPage.stateFilter, contactsGridPage.addressTypeFilter };
                  IWebElement[] dropdownHeaders = { contactsGridPage.phoneTypeHeader, contactsGridPage.emailTypeHeader, contactsGridPage.stateHeader, contactsGridPage.addressTypeHeader };
                  IWebElement[] dropdownFirstRowData = { contactsGridPage.phoneTypeRow, contactsGridPage.emailTypeRow, contactsGridPage.stateRow, contactsGridPage.addressTypeRow };
                  for (int index = 0; index < dropdownColumns.Length; index++)
                  {
                      contactsGridPage.ShowColumn(driver, dropdownColumns[index], contactsGridPage.companyHeader);
                      contactsGridPage.FindContactByDropdown(driver, dropdownFilters[index], dropdownFirstRowData[index], dropdownValues[index]);
                      contactsGridPage.ClearFilters(driver);
                      Waitings.WaitForLoadingEnds(driver);
                      contactsGridPage.HideColumn(driver, dropdownHeaders[index]);
                  }
              }
      */
        [TestMethod]
        [Description("Should create a filter view")]
        public void CreateFilterView()
        {
            string createContact = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstName', 'QALastName', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            string contactName = "QAFirstName";

            Database.ExecuteQuery(createContact);

            contactsGridPage.clearFiltersBtn.Click();
            Waitings.WaitForTextInInput(driver, contactsGridPage.savedFilterSelect, "Default", 3);
            Waitings.WaitForElementVisible(driver, ContactsGridPage.firstNameFilterLocator, 5);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, contactName);
            Waitings.WaitForTextInElement(driver, contactsGridPage.firstNameRow, contactName, 5);
            contactsGridPage.SaveViewWithName(driver, contactName);
            Waitings.WaitForElementClickable(driver, ContactsGridPage.clearFiltersBtnLocator, 5);
            contactsGridPage.clearFiltersBtn.Click();
            Thread.Sleep(3000);
            Utilities.SelectInDropdown(driver, contactsGridPage.savedFilterForClickSelect, contactName);
            Waitings.WaitForElementVisible(driver, ContactsGridPage.firstNameRowLocator, 5);
            Waitings.WaitForTextInElement(driver, contactsGridPage.firstNameRow, contactName, 5);
        }
/*
        [TestMethod]
        [Description("Should update  a filter view")]
        public void UpdateFilterView()
        {
            string createFilterView = " INSERT INTO dbo.GridSessions (GridName, TemplateName, GridState, UserId, IsDefault) VALUES('ContactsGrid', 'QATemplate', '{\"__zone_symbol__state\":null,\"__zone_symbol__value\":[],\"columns\":[{\"visibleIndex\":0,\"dataField\":\"CompanyName\",\"dataType\":\"string\",\"width\":\"20%\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":1,\"dataField\":\"PersonFirstName\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":2,\"dataField\":\"PersonLastName\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":3,\"dataField\":\"Phone\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":4,\"dataField\":\"Email\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":5,\"dataField\":\"Url\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":6,\"dataField\":\"PhoneType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":7,\"dataField\":\"EmailType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":8,\"dataField\":\"Prefix\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":9,\"dataField\":\"Suffix\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":10,\"dataField\":\"Twitter\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":11,\"dataField\":\"Skype\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":12,\"dataField\":\"LinkedInProfile\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":13,\"dataField\":\"Jurisdiction\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":14,\"dataField\":\"AddressCity\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":15,\"dataField\":\"AddressStateId\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":16,\"dataField\":\"AddressStreet1\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":17,\"dataField\":\"AddressStreet2\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":18,\"dataField\":\"AddressType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":19,\"dataField\":\"AddressZip\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":20,\"dataField\":\"ClientCode\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":21,\"dataField\":\"ClientGroup\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":22,\"dataField\":\"ClientStatus\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":23,\"dataField\":\"IsPrivate\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":24,\"dataField\":\"Position\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":25,\"dataField\":\"MainContactName\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"}],\"searchText\":\"\",\"pageIndex\":0,\"pageSize\":25,\"allowedPageSizes\":[25,50,100],\"customFilters\":[]}', 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '0')";
            string createContact = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstName', 'QALastName', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            string contactName = "QAFirstName";
            string templateName = "QATemplate";
            Database.ExecuteQuery(createFilterView);
            Database.ExecuteQuery(createContact);

            contactsGridPage.ClearFilters(driver);

            Waitings.WaitForTextInInput(driver, contactsGridPage.savedFilterSelect, "Default", 3);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, contactName);
            Waitings.WaitForTextInElement(driver, contactsGridPage.firstNameRow, contactName, 5);
            contactsGridPage.SaveViewWithName(driver, contactName);
            Thread.Sleep(1000);
            contactsGridPage.ClearFilters(driver);
            Thread.Sleep(1000);
            Utilities.SelectInDropdown(driver, contactsGridPage.savedFilterSelect, "Default");
            Waitings.WaitForLoadingEnds(driver);
            Utilities.SelectInDropdown(driver, contactsGridPage.savedFilterSelect, contactName);
            Thread.Sleep(1000);
            Waitings.WaitForLoadingEnds(driver);
            Waitings.WaitForTextInElement(driver, contactsGridPage.companyRow, templateName, 5);

            Utilities.SelectInDropdown(driver, contactsGridPage.savedFilterSelect, contactName);
            Waitings.WaitForLoadingEnds(driver);
        }
*/
        [TestMethod]
        [Description("Should delete a filter view")]
        public void DeleteFilterView()
        {
            string createFilterView = " INSERT INTO dbo.GridSessions (GridName, TemplateName, GridState, UserId, IsDefault) VALUES('ContactsGrid', 'QATemplate', '{\"__zone_symbol__state\":null,\"__zone_symbol__value\":[],\"columns\":[{\"visibleIndex\":0,\"dataField\":\"CompanyName\",\"dataType\":\"string\",\"width\":\"20%\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":1,\"dataField\":\"PersonFirstName\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":2,\"dataField\":\"PersonLastName\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":3,\"dataField\":\"Phone\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":4,\"dataField\":\"Email\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":5,\"dataField\":\"Url\",\"dataType\":\"string\",\"visible\":true,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":6,\"dataField\":\"PhoneType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":7,\"dataField\":\"EmailType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":8,\"dataField\":\"Prefix\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":9,\"dataField\":\"Suffix\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":10,\"dataField\":\"Twitter\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":11,\"dataField\":\"Skype\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":12,\"dataField\":\"LinkedInProfile\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":13,\"dataField\":\"Jurisdiction\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":14,\"dataField\":\"AddressCity\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":15,\"dataField\":\"AddressStateId\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":16,\"dataField\":\"AddressStreet1\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":17,\"dataField\":\"AddressStreet2\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":18,\"dataField\":\"AddressType\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":19,\"dataField\":\"AddressZip\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":20,\"dataField\":\"ClientCode\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":21,\"dataField\":\"ClientGroup\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":22,\"dataField\":\"ClientStatus\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":23,\"dataField\":\"IsPrivate\",\"visible\":false,\"selectedFilterOperation\":\"=\"},{\"visibleIndex\":24,\"dataField\":\"Position\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"},{\"visibleIndex\":25,\"dataField\":\"MainContactName\",\"dataType\":\"string\",\"visible\":false,\"selectedFilterOperation\":\"contains\"}],\"searchText\":\"\",\"pageIndex\":0,\"pageSize\":25,\"allowedPageSizes\":[25,50,100],\"customFilters\":[]}', 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '0')";
            Database.ExecuteQuery(createFilterView);

            contactsGridPage.DeleteView(driver);
        }

        [TestMethod]
        [Description("Should Add a User to Personal and then remove from it")]
        public void AddToPersonalRemoveFromPersonal()
        {
            contactsGridPage.ClearFilters(driver);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, "Keira");
            contactsGridPage.AddToPersonal(driver);
            contactsGridPage.SwitchToPersonalContacts(driver);
            Waitings.WaitForTextInElement(driver, contactsGridPage.firstNameRow, "Keira", 5);
            contactsGridPage.RemoveFromPersonal(driver);
        }

        [TestMethod]
        [Description("Should Print Details of a client")]
        public void PrintDetails()
        {
            string createContact = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstNameFoPrint', 'QALastNameForPrint', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createContact);

            contactsGridPage.ClearFilters(driver);
            Waitings.WaitForElementVisible(driver, ContactsGridPage.lastNameFilterLocator, 5);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.lastNameFilter, contactsGridPage.lastNameRow, "QALastNameForPrint");
            contactsGridPage.PrintDetails(driver);
            Waitings.WaitForNoErrorMsg(driver);
        }

        [TestMethod]
        [Description("Should open a person, change the name, go back to the grid, find the contact with the new name and delete it")]
        public void ChangePersonNameAndDelete()
        {
            string createContact = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstName', 'QALastName', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            Database.ExecuteQuery(createContact);
            string contactName = "QAFirstName";

            contactsGridPage.ClearFilters(driver);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, contactName);
            contactsGridPage.OpenContact(driver);
            Utilities.ReplaceWithValue(driver, contactCreationPage.firstNameInput, "QAFirstNameNew");
            contactCreationPage.SaveContact(driver);
            Utilities.SwitchToTab("Contacts", driver);
            contactsGridPage.WaitForGridLoaded(driver);
            contactsGridPage.ClearFilters(driver);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, "QAFirstNameNew");
        }

        [TestMethod]
        [Description("Should add a company with only required fields populated.")]
        public void AddCompanyWoCommEntities()
        {
            Company qaakella = new Company("Qaakella");
            contactsGridPage.OpenCreationFormFor("Company", driver);
            contactCreationPage.CreateCompany(driver, qaakella);
        }

        [TestMethod]
        [Description("Should open a company, change the name, find it in the grid and delete it.")]
        public void ChangeNameOfCompany()
        {
            string createCompany = "INSERT INTO dbo.Contacts (IsPrivate, Name, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QACompany', '2', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            string companyName = "QACompany";
            Database.ExecuteQuery(createCompany);

            contactsGridPage.ClearFilters(driver);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.companyFilter, contactsGridPage.companyRow, companyName);
            contactsGridPage.OpenContact(driver);
            Utilities.ReplaceWithValue(driver, contactCreationPage.companyNameInput, "QacompanyNameNew");
            contactCreationPage.SaveContact(driver);
            Waitings.WaitForTextInElement(driver, contactCreationPage.activeTab, "QacompanyNameNew", 5);
            Utilities.SwitchToTab("Contacts", driver);
            contactsGridPage.WaitForGridLoaded(driver);
            Utilities.ReplaceWithValue(driver, contactsGridPage.companyFilter, "QacompanyNameNew");
            Waitings.WaitForTextInElement(driver, contactsGridPage.companyRow, "QacompanyNameNew", 5);
            contactsGridPage.ClearFilters(driver);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.companyFilter, contactsGridPage.companyRow, "QacompanyNameNew");
        }

        [TestMethod]
        [Description("Should switch between grid views")]
        public void SwitchViews()
        {
            contactsGridPage.SelectGridView(driver, "Persons");
            Waitings.WaitForLoadingEnds(driver);
            contactsGridPage.SelectGridView(driver, "Companies");
            Waitings.WaitForLoadingEnds(driver);
            contactsGridPage.SelectGridView(driver, "Created By Me");
            Waitings.WaitForLoadingEnds(driver);
            contactsGridPage.SelectGridView(driver, "All Contacts");
            Waitings.WaitForLoadingEnds(driver);
        }

        [TestMethod]
        [Description("Should not delete a person with existing note")]
        public void CantDeletePersonWithNote()
        {
            string createContact = "INSERT INTO dbo.Contacts (IsPrivate, FirstName, LastName, ContactClass, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('0', 'QAFirstNameDeleteNote', 'QALastName', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            string createNote = "INSERT INTO dbo.Notes (Value, IsPrivate, Importance, OwnedById, CreatedById, CreatedAt, UpdatedById, UpdatedAt) VALUES('<p>QANote</p>', '0', '1', '388808B0-1DAE-4430-9200-E052D212C979', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653', '388808B0-1DAE-4430-9200-E052D212C979', '2017-04-13 04:49:40.653')";
            string noteUpdate = "Update dbo.Notes set ContactId = (select max(id) from dbo.Contacts) where Value = '<p>QANote</p>'";
            Database.ExecuteQuery(createContact);
            Database.ExecuteQuery(createNote);
            Database.ExecuteQuery(noteUpdate);
            string contactName = "QAFirstNameDeleteNote";

            layout.OpenContactsGrid(driver);

            contactsGridPage.clearFiltersBtn.Click();
            Waitings.WaitForElementClickable(driver, ContactsGridPage.clearFiltersBtnLocator, 5);
            contactsGridPage.clearFiltersBtn.Click();
            Waitings.WaitForElementVisible(driver, ContactsGridPage.firstNameFilterLocator, 5);
            contactsGridPage.FindContactByInput(driver, contactsGridPage.firstNameFilter, contactsGridPage.firstNameRow, contactName);
            try
            {
            contactsGridPage.DeleteContact(driver);
            }
            catch (Exception)
            {
            Console.WriteLine("Sucessfully not deleted");
            }
        }
    }
}