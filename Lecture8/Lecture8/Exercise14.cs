using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture8
{
    [TestFixture]
    public class Exercise14 : TestBase
    {
        [Test]
        public void Test()
        {
            NavigateToAdminPage();
            WaitPage(MainPageTitle);
            Login();
            WaitPage(MainPageTitle);
            NavigateToCountriesPage();
            WaitPage(CountriesPageTitle);
            NavigateToAddNewCountryPage();
            WaitPage(AddNewCountriesPageTitle);
            CheckExternalLinks();            
        }        
        public void NavigateToAdminPage()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.Manage().Window.Maximize();            
        }
        public void Login()
        {            
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();                     
        }
        public void NavigateToCountriesPage()
        {
            driver.FindElement(By.CssSelector(CountriesPageButton)).Click();            
        }
        public void NavigateToAddNewCountryPage()
        {          
            driver.FindElement(By.CssSelector(AddNewCountryButton)).Click();
        }
        public void WaitPage(string page)
        {
            wait.Until(ExpectedConditions.TitleIs(page));
        }
        public void CheckExternalLinks()
        {
            string mainWindow = driver.CurrentWindowHandle;
            IList<string> oldWindowsList = driver.WindowHandles;
            IList<IWebElement> externalLinks = driver.FindElements(By.CssSelector(ExternalLinkButton));
            foreach (IWebElement link in externalLinks)
            {
                link.Click();
                wait.Until(d => d.WindowHandles.Count > oldWindowsList.Count);
                IList<string> newWindowsList = driver.WindowHandles;
                IEnumerable<string> diffWindowsList = newWindowsList.Except(oldWindowsList, StringComparer.OrdinalIgnoreCase);
                driver.SwitchTo().Window(diffWindowsList.First());
                System.Threading.Thread.Sleep(1500);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
            }
        }
    }
}
