using CaseManager_Test._SeleniumTests.LoginPage;
using CaseManager_Test._SeleniumTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test._SeleniumTests.Tests
{
    class ContactsTests 
    {
        private IWebDriver driver;
        public ContactsPOM contactsPOM = new ContactsPOM();

        public string contactsUrl = PropertiesUI.baseUrl + PropertiesUI.users;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
            driver.FindElement(LoginPOM.loginUsername).SendKeys(PropertiesUI.testUsername);
            driver.FindElement(LoginPOM.loginPassword).SendKeys(PropertiesUI.testPassword);
            driver.FindElement(LoginPOM.loginSubmitButton).Click();

            Wait.ForPredefinedTime(1000 * 5);
            //log in MS
            //If URL contains MS login - perform the login login.live
            if(driver.Url.Contains("login.microsoftonline"))
            {
                driver.FindElement(LoginPOM.msLoginUsername).SendKeys(PropertiesUI.msUsername);
                driver.FindElement(LoginPOM.nextButton).Click();
                driver.FindElement(LoginPOM.msLoginPassword).SendKeys(PropertiesUI.msPassword);
                driver.FindElement(LoginPOM.signInButton).Click();
            }          
        }

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
        }

        [TearDown]
        public void Dispose()
        {
            DriverFactory.DisposeDriver();
        }

        [Test]
        public void ContactsLoginTest()
        {
            Assert.Pass();
        }
    }
}
