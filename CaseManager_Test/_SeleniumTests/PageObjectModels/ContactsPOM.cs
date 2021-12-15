using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test._SeleniumTests.PageObjectModels
{
    class ContactsPOM : BasePage
    {
        public ContactsPOM() : base()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl(PropertiesUI.baseUrl);
            Wait.ForDocumentReadyStateComplete(DriverFactory.GetDriver());
        }

        public static By contactsSectionLink = By.CssSelector(@"[routerlink='/contacts']");



    }
}
