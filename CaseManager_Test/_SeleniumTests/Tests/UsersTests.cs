using CaseManager_Test._SeleniumTests.LoginPage;
using CaseManager_Test._SeleniumTests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test._SeleniumTests
{
    class UsersTests : BaseTest
    {
        private IWebDriver driver;
        public UsersPOM usersPOM;
        public UsersTests(BrowserTypes browserName) : base(browserName)
        {
            usersPOM = new UsersPOM();
            driver = DriverFactory.GetDriver();
        }

        public string usersUrl = PropertiesUI.baseUrl + PropertiesUI.users;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
            driver.FindElement(LoginPOM.loginUsername).SendKeys(PropertiesUI.testUsername);
            driver.FindElement(LoginPOM.loginPassword).SendKeys(PropertiesUI.testPassword);
            driver.FindElement(LoginPOM.loginSubmitButton).Click();
        }


        [Test]
        public void VerifyElements()
        {
            usersPOM.WaitForElementAndClick(UsersPOM.usersSectionLink);
        }

    }
}
