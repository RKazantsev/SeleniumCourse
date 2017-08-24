using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lecture11
{
    public class Navigation: PageBase
    {
        private string baseURL;

        public Navigation(PageManager manager) : base(manager)
        {
            baseURL = manager.BaseURL;
            PageFactory.InitElements(driver, this);
        }

        public Navigation GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }        
        public Navigation NavigateBackToMainPage()
        {
            driver.Navigate().Back();
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "div#cart a.link")]
        public IWebElement cartButton;

        public Navigation NavigateToCart()
        {
            cartButton.Click();
            return this;
        }
        public Navigation WaitMainPageLoaded()
        {
            manager.WaitDriver.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            return this;
        }
        public Navigation WaitCartPageLoaded()
        {
            manager.WaitDriver.Until(ExpectedConditions.TitleIs("Checkout | My Store"));
            return this;
        }
    }
}