using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise7
{
    [TestFixture]
    public class Exercise7 : TestBase  
    {
        [Test]
        public void Exercise7Test()
        {
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            int menuItemCount = driver.FindElements(By.CssSelector("ul#box-apps-menu > li")).Count;
            for(int index = 1; index <= menuItemCount; index++)
            {
                driver.FindElement(By.CssSelector("ul#box-apps-menu > li:nth-child(" + index + ")")).Click();
                if (AreElementsPresent(By.CssSelector("ul.docs")))
                {
                    int submenuItemCount = driver.FindElements(By.CssSelector("ul.docs > li")).Count;
                    if (submenuItemCount >= 2)
                    {
                        for (int indexSubmenu = 2; indexSubmenu <= submenuItemCount; indexSubmenu++)
                        {
                            driver.FindElement(By.CssSelector("ul.docs > li:nth-child(" + indexSubmenu + ")")).Click();
                            Assert.True(IsElementPresent(By.CssSelector("td#content > h1")));
                        }
                    }                    
                }                
            }
        }
    }
}