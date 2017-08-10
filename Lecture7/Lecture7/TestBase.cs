using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture7
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver = new InternetExplorerDriver();
            //driver = new EdgeDriver();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));            
            driver.Url = "http://localhost/litecart/";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}