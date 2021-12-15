using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CaseManager_Test._SeleniumTests
{
    public class DriverFactory
    {
        private static IWebDriver driver;
        private static BrowserTypes browserTypes;


        public static IWebDriver BrowserSetUp(BrowserTypes browserTypes)
        {
            switch (browserTypes)
            {
                case BrowserTypes.Chrome:
                   return driver = new ChromeDriver();
                case BrowserTypes.IEdge:
                    return driver = new EdgeDriver();
                case BrowserTypes.Firefox:
                    return driver = new FirefoxDriver();
                //case BrowserType.Safari:
                //return new SafariDriver();  
                default: throw new ArgumentOutOfRangeException();
            }           
        }
        private static IWebDriver BuildDriver()
        {
            
            driver = BrowserSetUp(browserTypes);
            return driver;
        }
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = BuildDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void DisposeDriver()
        {
            Wait.ForPredefinedTime(1000 * 2);

            GetDriver().Dispose();
            //Wait is added due to sequential execution of tests. 
            Wait.ForPredefinedTime(1000 * 5);

            driver = null;
        }

        public static void TakesScreenshot()
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        }
    }
}
