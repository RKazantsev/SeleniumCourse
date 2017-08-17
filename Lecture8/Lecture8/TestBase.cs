using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture8
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string AddNewCountryButton
        {
            get
            {
                return "td#content a.button";
            }
        }
        protected string ExternalLinkButton
        {
            get
            {
                return "i.fa-external-link";
            }
        }
        protected string MainPageTitle
        {
            get
            {
                return "My Store";
            }
        }
        protected string CountriesPageTitle
        {
            get
            {
                return "Countries | My Store";
            }
        }
        protected string AddNewCountriesPageTitle
        {
            get
            {
                return "Add New Country | My Store";
            }
        }
        protected string CountriesPageButton
        {
            get
            {
                return "ul#box-apps-menu > li#app-:nth-child(3)";
            }
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();           
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));            
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
