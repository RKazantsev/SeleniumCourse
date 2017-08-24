using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lecture11
{
    public class ProductPage: PageBase
    {
        public ProductPage(PageManager manager) : base(manager)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "select[name='options[Size]']")]
        public IWebElement productSizeSelect;

        public ProductPage SelectProductSize()
        {
            if (IsElementPresent(By.CssSelector("select[name='options[Size]']")))
            {
                SelectElement select = new SelectElement(productSizeSelect);
                select.SelectByIndex(1);
            }
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "button[value='Add To Cart']")]
        public IWebElement addProductButton;

        public ProductPage AddProductClick()
        {
            addProductButton.Click();
            return this;
        }

        public ProductPage WaitProductHeader()
        {
            manager.WaitDriver.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.title")));
            return this;
        }
        public ProductPage CheckCartItemsCount(int productCount)
        {
            manager.WaitDriver.Until(ExpectedConditions
               .TextToBePresentInElementLocated(By.CssSelector("div#cart span.quantity"), productCount.ToString()));
            return this;
        }
    }
}