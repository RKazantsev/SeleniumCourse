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
        protected ProductData product;
        
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

            product = new ProductData("enabled", "Yellow Plush Duck", "pd001", "Subcategory", "DefaultCategory",
                "Unisex", "15", "pcs", "3-5 days", "Temporary sold out", "plush-duck.jpg", "01-01-2017", "01-01-2022",
                "ACME Corp.", "Supplier", "ABC", "Plush Duck", "Yellow Plush Duck", "Yellow Plush Duck", "Plush Duck",
                "15", "US Dollars", "", "25", "20");
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
