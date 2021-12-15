using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test._SeleniumTests
{
    public class Wait
    {
        public static void ForDocumentReadyStateComplete(IWebDriver driver)
        {
            (new WebDriverWait(driver, TimeSpan.FromSeconds(10))).Until((wd) => {
                return ((IJavaScriptExecutor)wd).ExecuteScript("return document.readyState", new Object[0]).Equals("complete");
            });
        }

        public static void ForPredefinedTime(int milliseconds)
        {
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromMilliseconds(milliseconds));
            var now = DateTime.Now;
            if (milliseconds < 0 || milliseconds > 10000)
            {
                throw new Exception("Waiting time should be between 0 and 10000 milliseconds");
            }
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromMilliseconds(milliseconds) > TimeSpan.Zero);
        }

        public static void ForElementToBeDisplayed(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

        }

        public static void ForElementToNotBeDisplayed(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void ForElementToBeClickable(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void ForElementToBeClickable(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
