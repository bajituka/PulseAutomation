using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects.ContactsTab
{

    class ContactsCreationPage : Layout
    {
        
        #region contact information
        private const string prefixSelectLocator = "//div[child::label[text()='Prefix']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = prefixSelectLocator)]
        public IWebElement prefixSelect { get; set; }

        private const string firstNameInputLocator = "//div[child::label[text()='First Name']]//input";
        [FindsBy(How = How.XPath, Using = firstNameInputLocator)]
        public IWebElement firstNameInput { get; set; }

        private const string middleNameInputLocator = "//div[child::label[text()='Middle']]//input";
        [FindsBy(How = How.XPath, Using = middleNameInputLocator)]
        public IWebElement middleNameInput { get; set; }

        private const string lastNameInputInputLocator = "//div[child::label[text()='Last Name']]//input";
        [FindsBy(How = How.XPath, Using = lastNameInputInputLocator)]
        public IWebElement lastNameInput { get; set; }

        private const string suffixSelectInputInputLocator = "//div[child::label[text()='Suffix']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = suffixSelectInputInputLocator)]
        public IWebElement suffixSelect { get; set; }

        private const string contactRoleSelectLocator = "//div[child::label[text()='Contact Role']]//dx-select-box";
        [FindsBy(How = How.XPath, Using = contactRoleSelectLocator)]
        public IWebElement contactRoleSelect { get; set; }

        private const string companyInputLocator = "//pulse-contact-lookup-selector[@title='Company']//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = companyInputLocator)]
        public IWebElement companyInput { get; set; }

        private const string positionInputLocator = "//div[child::label[text()='Position / Title']]//input";
        [FindsBy(How = How.XPath, Using = positionInputLocator)]
        public IWebElement positionInput { get; set; }

        private const string companyNameInputLocator = "//pulse-company-details//div[child::label[text()='Company']]//input";
        [FindsBy(How = How.XPath, Using = companyNameInputLocator)]
        public IWebElement companyNameInput { get; set; }

        private const string socialSecurityInputLocator = "//pulse-person-details//div[child::label[text()='Social Security Number']]//input[not(@type='hidden')]";
        [FindsBy(How = How.XPath, Using = socialSecurityInputLocator)]
        public IWebElement socialSecurityInput { get; set; }
        #endregion

        #region address
        private const string addAddressBtnLocator = "//dx-button[@aria-label='Add Address']";
        [FindsBy(How = How.XPath, Using = addAddressBtnLocator)]
        public IWebElement addAddressBtn { get; set; }

        private const string deleteAddressBtnLocator = "(//pulse-address//span[child::i[@title='Delete address']])";
        [FindsBy(How = How.XPath, Using = deleteAddressBtnLocator)]
        public IWebElement deleteAddressBtn { get; set; }

        private const string addressTypeSelectLocator = "(//pulse-address//dx-select-box[preceding-sibling::label[text()='Address Type']])";
        private const string zipInputLocator = "(//dx-text-box[@placeholder='Zip']//input[not(@type='hidden')])";
        private const string streetInputLocator = "(//dx-text-box[@placeholder='Street1']//input)";
        private const string street2InputLocator = "(//dx-text-box[@placeholder='Street2']//input)";
        private const string cityInputLocator = "(//dx-text-box[@placeholder='City']//input)";
        private const string stateSelectLocator = "(//pulse-address//dx-select-box[preceding-sibling::label[text()='State']]//input[not(@type='hidden')])";
        private const string zipSearchBtnLocator = "(//pulse-address//dx-button[@aria-label='search'])";

        public void AddAddress(IWebDriver driver, Address[] addresses)
        {
            Waitings.WaitForElementVisible(driver, zipInputLocator, 2);
            for (var index = 0; index < addresses.Length; index++)
            {
                IWebElement addressTypeSelect = driver.FindElement(By.XPath(addressTypeSelectLocator + "[" + (index + 1) + "]"));
                IWebElement zipInput = driver.FindElement(By.XPath(zipInputLocator + "[" + (index + 1) + "]"));
                IWebElement zipSearchBtn = driver.FindElement(By.XPath(zipSearchBtnLocator + "[" + (index + 1) + "]"));
                IWebElement streetInput = driver.FindElement(By.XPath(streetInputLocator + "[" + (index + 1) + "]"));
                IWebElement street2Input = driver.FindElement(By.XPath(street2InputLocator + "[" + (index + 1) + "]"));
                IWebElement cityInput = driver.FindElement(By.XPath(cityInputLocator + "[" + (index + 1) + "]"));
                IWebElement stateSelect = driver.FindElement(By.XPath(stateSelectLocator + "[" + (index + 1) + "]"));

                Utilities.ScrollIntoView(driver, addAddressBtn);
                Utilities.SelectInDropdown(driver, addressTypeSelect, addresses[index].AddressType);
                zipInput.SendKeys(Keys.Home + addresses[index].Zip);
                zipSearchBtn.Click();
                Waitings.WaitForTextInInput(driver, cityInput, addresses[index].City, 5);
                Waitings.WaitForTextInInput(driver, stateSelect, addresses[index].State, 2);
                streetInput.SendKeys(addresses[index].Street);
                if (addresses[index].Street2 != null) { street2Input.SendKeys(addresses[index].Street2); }
                if (addresses.Length > 1 && (index + 1) < addresses.Length)
                {
                    Thread.Sleep(500);
                    addAddressBtn.Click();
                }
            }
        }

        public void AddAddress(IWebDriver driver, Address address, int row)
        {
            Waitings.WaitForElementClickable(driver, addAddressBtnLocator, 5);
            Utilities.ScrollIntoView(driver, addAddressBtn);
            addAddressBtn.Click();
            IWebElement addressTypeSelect = driver.FindElement(By.XPath(addressTypeSelectLocator + "[" + row + "]"));
            IWebElement zipInput = driver.FindElement(By.XPath(zipInputLocator + "[" + row + "]"));
            IWebElement zipSearchBtn = driver.FindElement(By.XPath(zipSearchBtnLocator + "[" + row + "]"));
            IWebElement streetInput = driver.FindElement(By.XPath(streetInputLocator + "[" + row + "]"));
            IWebElement street2Input = driver.FindElement(By.XPath(street2InputLocator + "[" + row + "]"));
            IWebElement cityInput = driver.FindElement(By.XPath(cityInputLocator + "[" + row + "]"));
            IWebElement stateSelect = driver.FindElement(By.XPath(stateSelectLocator + "[" + row + "]"));

            Utilities.SelectInDropdown(driver, addressTypeSelect, address.AddressType);
            zipInput.SendKeys(Keys.Home + address.Zip);
            zipSearchBtn.Click();
            Waitings.WaitForTextInInput(driver, cityInput, address.City, 5);
            Waitings.WaitForTextInInput(driver, stateSelect, address.State, 2);
            streetInput.SendKeys(address.Street);
            if (address.Street2 != null) street2Input.SendKeys(address.Street2);
        }
        #endregion

        #region phone
        private const string addPhoneBtnLocator = "//dx-button[@aria-label='Add Phone']";
        [FindsBy(How = How.XPath, Using = addPhoneBtnLocator)]
        public IWebElement addPhoneBtn { get; set; }

        private const string deletePhoneBtnLocator = "(//pulse-phone//span[child::i[@title='Delete phone']])";
        [FindsBy(How = How.XPath, Using = deletePhoneBtnLocator)]
        public IWebElement deletePhoneBtn { get; set; }

        private const string phoneTypeSelectLocator = "(//pulse-phone//dx-select-box)";
        private const string phoneInputLocator = "(//pulse-phone//dx-text-box//input[not(@type='hidden')])";

        public void AddPhone(IWebDriver driver, Phone[] phones)
        {
            Waitings.WaitForElementVisible(driver, phoneTypeSelectLocator, 2);
            for (var index = 0; index < phones.Length; index++)
            {
                IWebElement phoneTypeSelect = driver.FindElement(By.XPath(phoneTypeSelectLocator + "[" + (index + 1) + "]"));
                IWebElement phoneInput = driver.FindElement(By.XPath(phoneInputLocator + "[" + (index + 1) + "]"));
                phoneInput.SendKeys(Keys.Home + phones[index].PhoneNumber);
                Utilities.ScrollIntoView(driver, phoneTypeSelect);
                Utilities.SelectInDropdown(driver, phoneTypeSelect, phones[index].PhoneType);
                if (phones.Length > 1 && (index + 1) < phones.Length)
                    addPhoneBtn.Click();
            }
        }

        public void AddPhone(IWebDriver driver, Phone phone, int row)
        {
            Utilities.ScrollIntoView(driver, addPhoneBtn);
            addPhoneBtn.Click();
            IWebElement phoneTypeSelect = driver.FindElement(By.XPath(phoneTypeSelectLocator + "[" + row + "]"));
            IWebElement phoneInput = driver.FindElement(By.XPath(phoneInputLocator + "[" + row + "]"));
            phoneInput.SendKeys(Keys.Home + phone.PhoneNumber);
            Utilities.SelectInDropdown(driver, phoneTypeSelect, phone.PhoneType);
        }
        #endregion

        #region email
        private const string addEmailBtnLocator = "//dx-button[@aria-label='Add Email']";
        [FindsBy(How = How.XPath, Using = addEmailBtnLocator)]
        public IWebElement addEmailBtn { get; set; }

        private const string deleteEmailBtnLocator = "(//pulse-email//span[child::i[@title='Delete email']])";
        [FindsBy(How = How.XPath, Using = deleteEmailBtnLocator)]
        public IWebElement deleteEmailBtn { get; set; }

        private const string emailTypeSelectLocator = "(//pulse-email//dx-select-box)";
        private const string emailInputLocator = "(//pulse-email//dx-text-box//input[not(@type='hidden')])";

        public void AddEmail(IWebDriver driver, Email[] emails)
        {
            Waitings.WaitForElementVisible(driver, emailTypeSelectLocator, 2);
            for (var index = 0; index < emails.Length; index++)
            {
                IWebElement emailTypeSelect = driver.FindElement(By.XPath(emailTypeSelectLocator + "[" + (index + 1) + "]"));
                IWebElement emailInput = driver.FindElement(By.XPath(emailInputLocator + "[" + (index + 1) + "]"));
                emailInput.SendKeys(emails[index].EmailAddress);
                Utilities.SelectInDropdown(driver, emailTypeSelect, emails[index].EmailType);
                if (emails.Length > 1 && (index + 1) < emails.Length)
                    addEmailBtn.Click();
            }
        }

        public void AddEmail(IWebDriver driver, Email email, int row)
        {
            addEmailBtn.Click();
            IWebElement emailTypeSelect = driver.FindElement(By.XPath(emailTypeSelectLocator + "[" + row + "]"));
            IWebElement emailInput = driver.FindElement(By.XPath(emailInputLocator + "[" + row + "]"));
            emailInput.SendKeys(email.EmailAddress);
            Utilities.SelectInDropdown(driver, emailTypeSelect, email.EmailType);
        }
        #endregion

        #region other fields
        private const string websiteInputBtnLocator = "//div[child::label[text()='Website']]//input";
        [FindsBy(How = How.XPath, Using = websiteInputBtnLocator)]
        public IWebElement websiteInput { get; set; }

        private const string skypeInputLocator = "//div[child::label[text()='Skype']]//input";
        [FindsBy(How = How.XPath, Using = skypeInputLocator)]
        public IWebElement skypeInput { get; set; }

        private const string twitterInputLocator = "//div[child::label[text()='Twitter']]//input";
        [FindsBy(How = How.XPath, Using = twitterInputLocator)]
        public IWebElement twitterInput { get; set; }

        private const string linkedinInputLocator = "//div[child::label[text()='LinkedIn Profile']]//input";
        [FindsBy(How = How.XPath, Using = linkedinInputLocator)]
        public IWebElement linkedinInput { get; set; }

        private const string jurisdictionInputLocator = "//div[child::label[text()='Jurisdiction']]//input";
        [FindsBy(How = How.XPath, Using = jurisdictionInputLocator)]
        public IWebElement jurisdictionInput { get; set; }

        private const string saveAndNewBtnLocator = "//dx-button[@aria-label='Save and New']";
        [FindsBy(How = How.XPath, Using = saveAndNewBtnLocator)]
        public IWebElement saveAndNewBtn { get; set; }

        private const string saveBtnLocator = "//dx-button[@aria-label='Save']";
        [FindsBy(How = How.XPath, Using = saveBtnLocator)]
        public IWebElement saveBtn { get; set; }
        #endregion


        public void CreatePerson(IWebDriver driver, Person person, Address[] addresses = null, Phone[] phones = null, Email[] emails = null)
        {
            Waitings.WaitForElementClickable(driver, firstNameInputLocator, 10);
            if (person.Prefix != null) Utilities.SelectInDropdown(driver, prefixSelect, person.Prefix);
            if (person.MiddleName != null) middleNameInput.SendKeys(person.MiddleName);
            if (person.Suffix != null) Utilities.SelectInDropdown(driver, suffixSelect, person.Suffix);
            if (person.Position != null) positionInput.SendKeys(person.Position);
            if (person.SocialSecurity != null) socialSecurityInput.SendKeys(person.SocialSecurity);
            if (person.Company != null) Utilities.SelectInAutocomplete(driver, companyInput, person.Company);
            if (person.ContactRole != null) Utilities.SelectInDropdown(driver, contactRoleSelect, person.ContactRole);
            if (person.Jurisdiction != null) jurisdictionInput.SendKeys(person.Jurisdiction);
            firstNameInput.SendKeys(person.FirstName);
            lastNameInput.SendKeys(person.LastName);

            if (addresses != null) AddAddress(driver, addresses);
            Thread.Sleep(2000);
            if (phones != null) AddPhone(driver, phones);
            Thread.Sleep(2000);
            if (emails != null) AddEmail(driver, emails);
            if (person.LinkedInProfile != null) linkedinInput.SendKeys(person.LinkedInProfile);
            if (person.Skype != null) skypeInput.SendKeys(person.Skype);
            if (person.Twitter != null) twitterInput.SendKeys(person.Twitter);
            Thread.Sleep(1000);
            saveBtn.Click();
            try
                {
                    SkipDuplicate(driver);
                }
            catch (Exception)
                {

                }
            Waitings.WaitForSavingEnds(driver);
            Waitings.WaitForTextInElement(driver, activeTab, person.FirstName + " " + person.LastName, 10);
        }


        public void CreateCompany(IWebDriver driver, Company company, Address[] addresses = null, Phone[] phones = null, Email[] emails = null)
        {
            Waitings.WaitForElementClickable(driver, companyNameInputLocator, 5);
            companyNameInput.SendKeys(company.Name);
            Thread.Sleep(3000);
            if (addresses != null) AddAddress(driver, addresses);
            if (phones != null) AddPhone(driver, phones);
            if (emails != null) AddEmail(driver, emails);
            if (company.Twitter != null) twitterInput.SendKeys(company.Twitter);
            if (company.Website != null) websiteInput.SendKeys(company.Website);
            if (company.ContactRole != null) Utilities.SelectInDropdown(driver, contactRoleSelect, company.ContactRole);
            if (company.LinkedInProfile != null) linkedinInput.SendKeys(company.LinkedInProfile);
            if (company.Jurisdiction != null) jurisdictionInput.SendKeys(company.Jurisdiction);
            Thread.Sleep(500);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
            Waitings.WaitForTextInElement(driver, activeTab, company.Name, 10);
        }


        public void DeleteCommEntity(IWebDriver driver, string commType, int row)
        {
            IWebElement deleteBtn = null;
            switch (commType)
            {
                case "Address":
                    deleteBtn = driver.FindElement(By.XPath(deleteAddressBtnLocator + "[" + row + "]"));
                    break;
                case "Phone":
                    deleteBtn = driver.FindElement(By.XPath(deletePhoneBtnLocator + "[" + row + "]"));
                    break;
                case "Email":
                    deleteBtn = driver.FindElement(By.XPath(deleteEmailBtnLocator + "[" + row + "]"));
                    break;
            }            
            deleteBtn.Click();
            Utilities.DeleteItem(driver);
            Waitings.WaitForElementStale(driver, deleteBtn, 3);
        }
        

        public void SaveContact(IWebDriver driver)
        {
            Waitings.WaitForElementClickable(driver, saveBtnLocator, 5);
            saveBtn.Click();
            Waitings.WaitForSavingEnds(driver);
        }


        public static void WaitForFormLoaded(IWebDriver driver)
        {
            Waitings.WaitForElementsVisible(driver, 5, jurisdictionInputLocator, saveBtnLocator);
        }


        public void SkipDuplicate(IWebDriver driver)
        {
            string skipBtnLocator = "//span[text()='Skip']";
            Waitings.WaitForLoadingEnds(driver);
            Waitings.WaitForElementClickable(driver, skipBtnLocator, 5);
            IWebElement skipBtn = driver.FindElement(By.XPath(skipBtnLocator));
            skipBtn.Click();
            Waitings.WaitForElementStale(driver, skipBtn, 2);
        }

        public void PopulateFields(IWebDriver driver, IWebElement[] element, string[] text)
        {
            for (int index = 0; index < element.Length; index++)
            {
                if (element[index] == prefixSelect || element[index] == suffixSelect || element[index] == contactRoleSelect)
                    Utilities.SelectInDropdown(driver, element[index], text[index]);

                else if (element[index] == companyInput)
                    Utilities.SelectInAutocomplete(driver, element[index], text[index]);

                else
                    element[index].SendKeys(text[index]);
            }
        }
    }
}
