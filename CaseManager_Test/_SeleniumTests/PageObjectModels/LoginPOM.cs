using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace CaseManager_Test._SeleniumTests.LoginPage
{
    public class LoginPOM : BasePage
    {
        public LoginPOM() : base()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl(PropertiesUI.baseUrl);
            Wait.ForDocumentReadyStateComplete(DriverFactory.GetDriver());
        }

        public static By loginUsername = By.Id("userName");
        public static By loginPassword = By.Id("userPassword");
        public static By loginSubmitButton = By.CssSelector(@"[type='submit']");
        public static By loggedUser = By.CssSelector(@"div[class='Root']");
        public static By wrongCredentialsAllert = By.XPath(@"//div[contains(text(), 'Invalid username or password')]");

        //MS Login locators
        public static By msLoginUsername = By.CssSelector(@"[name='loginfmt']");
        public static By nextButton = By.Id(@"idSIButton9");
        public static By remainSignedInButton = By.XPath(@"//a[text()='Remain signed in with this account.']");
        public static By signInButton = By.Id(@"idSIButton9");
        public static By msLoginPassword = By.CssSelector(@"[name='passwd']");
        


    }
}
