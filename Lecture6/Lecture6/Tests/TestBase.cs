using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture6
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected AccountData account;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver = new InternetExplorerDriver();
            //driver = new EdgeDriver();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            account = new AccountData("123456789", "Rubber Ducks Company", "John", "Smith",
                                      "938 Temple Ave", "1050 Gladys Ave", "90804", "Long Beach",
                                      "United States", "California", "john.smith@mail.com", 
                                      "+15624349600", "password");
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
