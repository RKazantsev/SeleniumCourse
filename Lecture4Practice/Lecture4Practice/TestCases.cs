using NUnit.Framework;
using OpenQA.Selenium;

namespace Lecture4Practice
{
    [TestFixture]
    public class TestCases : TestBase
    {
        [Test]
        public void TestCasesTest()
        {
            driver.Url = "https://www.google.com.ua/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Name("btnK")).Click();
            Assert.IsTrue(IsElementPresent(By.CssSelector(".rc")));                  
        }        
    }
}
