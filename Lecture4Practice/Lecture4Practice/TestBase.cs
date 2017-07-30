using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture4Practice
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.google.com.ua/";
            driver.Manage().Window.Maximize();

        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                wait.Until(d => d.FindElement(locator));
                //driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
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
