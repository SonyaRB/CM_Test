using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CaseManager_Test._SeleniumTests
{
    public abstract class BasePage
    {
        protected WebDriverWait wait;
        protected BasePage()
        {
            wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Wait for specified time in milliseconds
        /// </summary>
        /// <param name="a">An integer representing the waiting time in milliseconds</param
        public static void ExplicitWaitMilliseconds(int a)
        {
            IWebDriver driver = DriverFactory.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
        }

        /// <summary>
        /// Wait for element to be found and click on the element
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public void WaitForElementAndClick(By by)
        {
            wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromMilliseconds(500));
            IWebElement element = null;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    element = wait.Until(driver => driver.FindElement(by)); ;
                    break;
                }
                catch (WebDriverException ex)
                {
                    Console.WriteLine($"Waiting for element to be clickable with locator '{by}'. (attempt {i})"); if (i == 10)
                    {
                        throw new WebDriverException($"Element with locator '{by}' not found on the page.", ex);
                    }
                }
            }
            element.Click();
        }

        /// <summary>
        /// Finds the element described by the provided locator and attempts to click the element. Will wait for the element to be clickable on the page.
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public void Click(By by)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            element.Click();
            Wait.ForDocumentReadyStateComplete(DriverFactory.GetDriver());
        }

        /// <summary>
        /// Finds the element described by the provided locator and returns the text contained in the element. Will wait for the element to exist in the page document.
        /// </summary>
        /// <param name="by">The locator for the element</param>
        /// <returns></returns>
        public string GetTextFrom(By by)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return element.Text;
        }

        /// <summary>
        /// Finds the element described by the provided locator and attempts to type the provided string into the element. Will wait for the element to be clickable on the page.
        /// </summary>
        /// <param name="by">The locator for the element</param>
        /// <param name="text">The text to type into the element</param>
        public void TypeInto(By by, string text)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Finds the element described by the provided locator and returns the current value for a specific html attribute name. Will wait for the element to exist in the page document.
        /// </summary>
        /// <param name="by">The locator for the element</param>
        /// <param name="attributeName">The name of the attribute to look up</param>
        /// <returns></returns>
        protected string GetAttributeFor(By by, string attributeName)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Finds the element described by the provided locator and checks if it is currently selected. Will wait for the element to be clickable on the page.
        /// </summary>
        /// <param name="by">The locator for the element</param>
        /// <returns></returns>
        protected bool CheckSelectionStateOf(By by)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            return element.Selected;
        }

        /// <summary>
        /// Checks if the elment is displayed by waiting until the element is visible
        /// </summary>
        /// <param name="by">The locator for the element</param>        
        /// <returns></returns>
        public bool IsElementDisplayed(By by)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Locator '{by}' is missing!");
                return false;
            }
        }

        /// <summary>
        /// Sends an Escape key command 
        /// </summary>
        public void SendEscape()
        {
            Actions action = new Actions(DriverFactory.GetDriver());
            action.SendKeys(Keys.Escape).Perform();
            Wait.ForDocumentReadyStateComplete(DriverFactory.GetDriver());
            Wait.ForPredefinedTime(500);
        }


        /// <summary>
        /// Refresh current page.
        /// </summary>
        public void Refresh()
        {
            DriverFactory.GetDriver().Navigate().Refresh();
        }

    }
}
