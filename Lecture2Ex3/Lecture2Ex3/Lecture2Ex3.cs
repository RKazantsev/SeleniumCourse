using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace Lecture2Ex3
{
    [TestFixture]
    public class Lecture2Ex3
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            //driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            //driver = new EdgeDriver();

            /*New Schema*/
            //driver = new FirefoxDriver();

            /*New Schema In Detail*/
            //FirefoxOptions options = new FirefoxOptions();
            //options.UseLegacyImplementation = false;
            //driver = new FirefoxDriver(options);

            /*Old Schema w\o a Path to Browser for FF up to 47 version (48 not maintained at all) and ESR up to 52*/
            //FirefoxOptions options = new FirefoxOptions();
            //options.UseLegacyImplementation = true;
            //driver = new FirefoxDriver(options);

            /*Old Schema with a Path to Browser for FF up to 47 version (48 not maintained at all) and ESR up to 52*/
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"; // ESR
            driver = new FirefoxDriver(options);
            Actions action = new Actions(driver);

            // New Schema for FF Nightly & Developer Edition
            //FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"C:\Program Files\Nightly\firefox.exe"; // Nightly
            //options.BrowserExecutableLocation = @"C:\Program Files\Firefox Developer Edition\firefox.exe"; // Dev Edition
            //driver = new FirefoxDriver(options);

            //Deprecated Schema
            //FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Nightly\firefox.exe");
            //driver = new FirefoxDriver(binary, new FirefoxProfile());
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Lecture2Ex3Test()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            Thread.Sleep(10000);
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
