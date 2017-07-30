using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Lecture5
{
    [TestFixture]
    public class Exercise10 : TestBase
    {
        [Test]
        public void Exercise10Test()
        {
            driver.Url = " http://localhost/litecart/admin/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            driver.FindElement(By.CssSelector("ul#box-apps-menu > li#app-:nth-child(3) span.name")).Click();
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
            int countriesCount = driver.FindElements(By.CssSelector("table.dataTable tbody > tr.row")).Count;
            for (int index = 2; index <= countriesCount; index++)
            {
                string countryCurrent = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + index + ") > td:nth-child(5) > a")).Text;
                string countryNext = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (index + 1) + ") > td:nth-child(5) > a")).Text;
                Assert.LessOrEqual(countryCurrent, countryNext);
            }
        }
    }
}
