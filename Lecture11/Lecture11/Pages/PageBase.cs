using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lecture11
{
    public class PageBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected PageManager manager;

        public PageBase(PageManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
            wait = manager.WaitDriver;
        }
        public bool IsElementPresent(By locator)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            IList<IWebElement> list = driver.FindElements(locator);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                return list[0].Displayed;
            }
        }
    }
}
