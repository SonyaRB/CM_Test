using CaseManager_Test.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test._SeleniumTests
{
    class UsersPOM : BasePage
    {
        public UsersPOM() : base()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl(PropertiesUI.baseUrl);
            Wait.ForDocumentReadyStateComplete(DriverFactory.GetDriver());
        }

        public static By usersSectionLink = By.CssSelector(@"[routerlink='/users']");


    }
}
