using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lecture10
{
    [TestFixture]
    public class Exercise17
    {
        private EventFiringWebDriver driver;     
        private WebDriverWait wait;        

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference("browser", LogLevel.All);
            options.SetLoggingPreference("performance", LogLevel.All);
            driver = new EventFiringWebDriver(new ChromeDriver(options));

            //driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod + " : finding");
            //driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " : found");
            //driver.ElementClicking += (sender, e) => Console.WriteLine(e.Element + " : clicking");
            //driver.ElementClicked += (sender, e) => Console.WriteLine(e.Element + " : clicked");
            //driver.Navigating += (sender, e) => Console.WriteLine(e.Url + " : navigating");
            //driver.Navigated += (sender, e) => Console.WriteLine(e.Url + " : navigated");
            //driver.NavigatingForward += (sender, e) => Console.WriteLine(e.Url + " : navigating forward");
            //driver.NavigatedForward += (sender, e) => Console.WriteLine(e.Url + " : navigated forward");
            //driver.NavigatingBack += (sender, e) => Console.WriteLine(e.Url + " : navigating back");
            //driver.NavigatedBack += (sender, e) => Console.WriteLine(e.Url + " : navigated back");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        
        [Test]
        public void Test()
        {
            NavigateToAdminPage();
            Login();
            WaitPage("My Store");
            NavigateToCatalog();
            WaitPage("Catalog | My Store");           
            ExpandFolders();
            RunCatalog();
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
        public void NavigateToCatalog()
        {
            driver.FindElement(By.CssSelector("ul#box-apps-menu > li#app-:nth-child(2) a")).Click();          
        }
        public void ExpandFolders()
        {
            bool closeFolderIsPresent;
            int index = 0;            
            do
            {
                IList<IWebElement> rowItems = driver.FindElements(By.CssSelector("tr.row"));
                closeFolderIsPresent = false;
                index = 0;
                do
                {                                     
                    if (rowItems[index].FindElements(By.CssSelector("i.fa-folder")).Count > 0)
                    {
                        rowItems[index].FindElement(By.CssSelector("td:nth-child(3) > a")).Click();                        
                        closeFolderIsPresent = true;
                    }
                    index++;
                } while (!closeFolderIsPresent && (index < rowItems.Count));   
            } while (closeFolderIsPresent);            
        }
        public void RunCatalog()
        {            
            IList<IWebElement> rowItems = driver.FindElements(By.CssSelector("tr.row"));
            for (int index = 2; index < rowItems.Count; index++)
            {
                if (rowItems[index].FindElements(By.CssSelector("td:nth-child(3) > img")).Count > 0)
                {
                    rowItems[index].FindElement(By.CssSelector("td:nth-child(3) > a")).Click();

                    //GetBrowserLogs("Product page : ");
                    //GetPerformanceLogs("Product page : ");

                    driver.Navigate().Back();
                    WaitPage("Catalog | My Store");

                    GetBrowserLogs("Catalog page : ");
                    //GetPerformanceLogs("Catalog page : ");

                    rowItems = driver.FindElements(By.CssSelector("tr.row"));
                }
            }            
        }

        public void GetBrowserLogs(string page)
        {
            foreach (LogEntry logEntry in driver.Manage().Logs.GetLog("browser"))
            {
                Console.WriteLine(page + logEntry);
            }
        }

        public void GetPerformanceLogs(string page)
        {
            foreach (LogEntry logEntry in driver.Manage().Logs.GetLog("performance"))
            {
                Console.WriteLine(page + logEntry);
            }
        }



        public void WaitPage(string page)
        {
            wait.Until(ExpectedConditions.TitleIs(page));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
