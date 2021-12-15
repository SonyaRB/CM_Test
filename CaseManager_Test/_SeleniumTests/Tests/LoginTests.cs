using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using CaseManager_Test._SeleniumTests;
using CaseManager_Test._SeleniumTests.LoginPage;
using CaseManager_Test._SeleniumTests.Tests;


namespace CaseManager_Test._SeleniumTests
{
    public class LoginTests : BaseTest
    {
        private static IWebDriver driver;
        private readonly LoginPOM loginPOM;

        public LoginTests(BrowserTypes browserName) : base(browserName)
        {
            loginPOM = new LoginPOM();
            driver = DriverFactory.GetDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
        }

        [Test]
        public void LogIn_Successful()
        {
            //driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
            driver.FindElement(LoginPOM.loginUsername).SendKeys(PropertiesUI.testUsername);
            driver.FindElement(LoginPOM.loginPassword).SendKeys(PropertiesUI.testPassword);
            driver.FindElement(LoginPOM.loginSubmitButton).Click();
            string loggedUsername = loginPOM.GetTextFrom(LoginPOM.loggedUser);

            Assert.AreEqual(loggedUsername, PropertiesUI.testUsername);
        }

        [Test]
        public void LogIn_wrongCredentials_Unsuccessful()
        {
            //driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
            driver.FindElement(LoginPOM.loginUsername).SendKeys("randomString");
            driver.FindElement(LoginPOM.loginPassword).SendKeys("random string");
            driver.FindElement(LoginPOM.loginSubmitButton).Click(); 
            
            Assert.IsTrue(loginPOM.IsElementDisplayed(LoginPOM.wrongCredentialsAllert));
        }

        [Test]
        public void LogIn_emptyCredentials_Unsuccessful()
        {
            //This test should be updated. If user leaves any of the fields username/pass empty, then there should be a warning message that those fields should not be empty
            //driver.Navigate().GoToUrl(PropertiesUI.baseUrl);
            driver.FindElement(LoginPOM.loginSubmitButton).Click();

            Assert.IsFalse(true);
            //Assert.IsTrue(IsElementDisplayed(LoginPOM.wrongCredentialsAllert));

        }

    }
}
