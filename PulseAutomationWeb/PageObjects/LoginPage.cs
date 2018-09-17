using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PulseAutomationWeb.Common;
using System.Threading;

namespace PulseAutomationWeb.PageObjects
{
    class LoginPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        public IWebElement userNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement passwordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Login']")]
        public IWebElement loginBtn { get; set; }

        public void Authorize(IWebDriver driver, string login, string password)
        {

            string addUserToDbAndGivePermissions = (@"
declare @id uniqueidentifier = null;
declare @roleId uniqueidentifier = null;

SELECT top(1) @id = Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com';

IF @id is null
BEGIN
    set @id = newid();
    INSERT INTO dbo.AspNetUsers (Id, PasswordHash, SecurityStamp, UserName, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
    VALUES (@id, 'ADs93LnFos4eJ5RAdokNPa+KNCNsJCDpGaC68/oB6UNbHBjCaWmPl1gsGhTJvOpNhg==', '01018acf-da2f-4130-8abb-f6ca8d225166', 'script@gmail.com', 0, 0, 0, 0, 0)
END

select top(1) @roleId = [Id]
from [dbo].[AspNetRoles]
where [Name] = 'Delete Contact'

if not exists (select top(1) [UserId] from [dbo].[AspNetUserRoles] where [UserId] = @id and [RoleId] = @roleId)
begin
    INSERT INTO dbo.AspNetUserRoles
    VALUES (@id, @roleId)
end
");

            IWebElement loginBtnEl = driver.FindElement(By.XPath("//span[text()='Login']"));
            userNameInput.SendKeys(login);
            passwordInput.SendKeys(password);
            Database.ExecuteQuery(addUserToDbAndGivePermissions);
            Thread.Sleep(500);
            loginBtnEl.Click();
            Waitings.WaitForElementStale(driver, loginBtnEl, 20);
        }

        public void ClearFields(IWebDriver driver)
        {
            userNameInput.Clear();
            passwordInput.Clear();
        }
    }
}