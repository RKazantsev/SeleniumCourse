using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lecture11
{
    public class MainPage: PageBase
    {
        public MainPage(PageManager manager) : base(manager)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div#box-most-popular li:first-child")]
        public IWebElement productButton;

        public void SelectProduct()
        {
            productButton.Click();
        }
    }
}