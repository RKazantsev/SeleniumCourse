using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Lecture11
{
    public class CartPage: PageBase
    {
        public CartPage(PageManager manager) : base(manager)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "td.item")]
        public IList<IWebElement> products;

        [FindsBy(How = How.CssSelector, Using = "button[value = 'Remove']")]
        public IWebElement removeProductButton;

        public CartPage RemoveAllProducts()
        {
            int itemsCount;
            while (IsElementPresent(By.CssSelector("button[value='Remove']")))
            {
                itemsCount = products.Count;
                removeProductButton.Click();               
                manager.WaitDriver.Until(d => products.Count < itemsCount);
            }
            return this;                       
        }           
        public CartPage CheckCartIsEmpty()
        {
            manager.WaitDriver.Until(d => IsElementPresent(By.CssSelector("em")));
            return this;
        }
    }
}