using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace CaseManager_Test._SeleniumTests.Tests
{
    [TestFixture(BrowserTypes.Chrome)]
    //[TestFixture(BrowserTypes.Firefox)]
    //[TestFixture(BrowserTypes.IEdge)]
    //[TestFixture(BrowserTypes.Safari)]
    public class BaseTest
    {
        public BaseTest(BrowserTypes browserName)
        {
            DriverFactory.BrowserSetUp(browserName);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverFactory.DisposeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }
        }

        /// <summary>
        /// Method takes screenshot of the browser at test failure.
        /// </summary>
        private void TakeScreenshot()
        {
            string solution_dir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var testName = TestContext.CurrentContext.Test.Name;
            var screenshot = ((ITakesScreenshot)DriverFactory.GetDriver()).GetScreenshot();
            var file = string.Format("{0}_{1}.png", testName, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            screenshot.SaveAsFile(Path.Combine(solution_dir, file), ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(Path.Combine(solution_dir, file), "Screenshot from failed test.");
        }

    }
}
