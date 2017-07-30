using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;

namespace Lecture4Practice
{
    [TestFixture]
    public class TestCasesJS : TestBase
    {
        [Test]
        public void TestCasesJSTest()
        {
            driver.Url = "https://selenium2.ru/";
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;

            IList<IWebElement> links = new List<IWebElement>();
            links = (List<IWebElement>) js.ExecuteScript("return $$('a:contains(Webdriver)')");
            string str = (string) js.ExecuteScript("return document.title");
            driver.FindElement(By.Id("mod-search-searchword")).SendKeys(str);
            Thread.Sleep(10000);

             
        }        
    }
}
