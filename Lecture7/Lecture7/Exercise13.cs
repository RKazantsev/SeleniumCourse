using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Lecture7
{
    [TestFixture]
    public class Exercise13 : TestBase
    {
        [Test]
        public void Test()
        {
            Wait("Online Store | My Store");
            AddProductToCart(3);            
            NavigateToCart();
            RemoveAllProducts();                               
        }

        public void AddProductToCart(int productTotalNumber)
        {
            for (int stepNumber = 1; stepNumber <= productTotalNumber; stepNumber++)
            {
                driver.FindElement(By.CssSelector("div#box-most-popular li:first-child")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.title")));

                if (IsElementPresent(By.CssSelector("select[name='options[Size]']")))
                {
                    SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("select[name='options[Size]']")));
                    select.SelectByIndex(1);
                }

                driver.FindElement(By.CssSelector("button[value='Add To Cart']")).Click();
                wait.Until(ExpectedConditions
                    .TextToBePresentInElementLocated(By.CssSelector("div#cart span.quantity"), stepNumber.ToString()));
                NavigateBackToMainPage();
            }
        }

        public void RemoveAllProducts()
        {
            int itemsCount;            
            while (IsElementPresent(By.CssSelector("button[value='Remove']")))
            {
                itemsCount = driver.FindElements(By.CssSelector("td.item")).Count;
                driver.FindElement(By.CssSelector("button[value='Remove']")).Click();
                wait.Until(d => d.FindElements(By.CssSelector("td.item")).Count < itemsCount);
            }
            wait.Until(d => IsElementPresent(By.CssSelector("em")));            
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

        public void NavigateBackToMainPage()
        {
            driver.Navigate().Back();
            Wait("Online Store | My Store");
        }

        public void NavigateToCart()
        {
            driver.FindElement(By.CssSelector("div#cart a.link")).Click();
            Wait("Checkout | My Store");
        }

        public void Wait(string title)
        {
            wait.Until(ExpectedConditions.TitleIs(title));
        }
    }
}