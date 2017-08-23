using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lecture10
{
    [TestFixture]
    public class Practice10
    {
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();            
            options.SetLoggingPreference("performance", LogLevel.All);
            driver = new EventFiringWebDriver(new ChromeDriver(options));
            driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod + " : finding");
            driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " : found");
            driver.ElementClicking += (sender, e) => Console.WriteLine(e.Element + " : clicking");
            driver.ElementClicked += (sender, e) => Console.WriteLine(e.Element + " : clicked");
            driver.Navigating += (sender, e) => Console.WriteLine(e.Url + " : navigating");
            driver.Navigated += (sender, e) => Console.WriteLine(e.Url + " : navigated");
            driver.NavigatingForward += (sender, e) => Console.WriteLine(e.Url + " : navigating forward");
            driver.NavigatedForward += (sender, e) => Console.WriteLine(e.Url + " : navigated forward");
            driver.ExceptionThrown += (sender, e) => {
                Console.WriteLine(e.ThrownException);
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Repos\\screen.png", ScreenshotImageFormat.Png);
             };
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }   

        [Test]
        public void TestPractice()
        {
            driver.Url = "https://www.google.com/";
            IWebElement element = wait.Until(d => d.FindElement(By.Name("q")));
            element.SendKeys("webdriver" + Keys.Escape);           
            driver.FindElement(By.Name("btnK")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - Пошук Google"));
        }

        [Test]
        public void TestBrowserLog()
        {
            driver.Url = "https://sites.google.com/a/chromium.org/chromedriver/logging/performance-log";
            IList<string> logTypes = driver.Manage().Logs.AvailableLogTypes;
            foreach (string type in logTypes)
            {
                Console.Write(type + " ");
            }
            foreach (LogEntry logEntry in driver.Manage().Logs.GetLog("performance"))
            {
                Console.WriteLine(logEntry);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}

