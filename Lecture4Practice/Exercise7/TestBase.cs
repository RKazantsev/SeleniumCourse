using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exercise7
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);                        
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                wait.Until(d => d.FindElement(locator));
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public bool AreElementsPresent(By locator)
        {
            try
            {
                return driver.FindElements(locator).Count > 0;
            }
            catch (InvalidSelectorException)
            {
                return false;
            }
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
