using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise7
{
    [TestFixture]
    public class Exercise8 : TestBase  
    {
        [Test]
        public void Exercise8Test()
        {
            driver.Url = "http://localhost/litecart/";
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            int productItemCount = driver.FindElements(By.CssSelector("div#box-most-popular li.product")).Count;
            for (int index = 1; index <= productItemCount; index++)
            {
                int stickerCount = driver.FindElements(By.CssSelector("div#box-most-popular li.product:nth-child(" + index + ") div.sticker")).Count;
                Assert.AreEqual(1, stickerCount);                                        
            }
            productItemCount = driver.FindElements(By.CssSelector("div#box-campaigns li.product")).Count;
            for (int index = 1; index <= productItemCount; index++)
            {
                int stickerCount = driver.FindElements(By.CssSelector("div#box-campaigns li.product:nth-child(" + index + ") div.sticker")).Count;
                Assert.AreEqual(1, stickerCount);                
            }
            productItemCount = driver.FindElements(By.CssSelector("div#box-latest-products li.product")).Count;
            for (int index = 1; index <= productItemCount; index++)
            {
                int stickerCount = driver.FindElements(By.CssSelector("div#box-latest-products li.product:nth-child(" + index + ") div.sticker")).Count;
                Assert.AreEqual(1, stickerCount);                
            }
        }
    }
}