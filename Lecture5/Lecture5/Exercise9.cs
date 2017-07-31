using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Lecture5
{
    [TestFixture]
    public class Exercise9 : TestBase
    {
        [Test]
        public void Exercise9Test1()
        {
            Init();
            Login();
            NavigateToCountries();
            VerifyCountriesIsSorted();            
        }

        [Test]
        public void Exercise9Test2()
        {
            Init();
            Login();
            NavigateToCountries();
            VerifyZonesIsSorted();
        }

        [Test]
        public void Exercise9Test3()
        {
            Init();
            Login();
            NavigateToGeoZones();
            VerifyGeoZonesIsSorted();
        }

        public void Init()
        {
            driver.Url = " http://localhost/litecart/admin/";
            driver.Manage().Window.Maximize();
        }

        public void Login()
        {
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
        }

        public void NavigateToCountries()
        {
            driver.FindElement(By.CssSelector("ul#box-apps-menu > li#app-:nth-child(3) span.name")).Click();
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
        }

        public void NavigateToGeoZones()
        {
            driver.FindElement(By.CssSelector("ul#box-apps-menu > li#app-:nth-child(6) span.name")).Click();
            wait.Until(ExpectedConditions.TitleIs("Geo Zones | My Store"));
        }

        public void NavigateToEditGeoZones(int index)
        {
            driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (index + 1) + ") > td:nth-child(3) > a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Edit Geo Zone | My Store"));
        }

        public void VerifyCountriesIsSorted()
        {
            int countriesCount = driver.FindElements(By.CssSelector("table.dataTable tbody > tr.row")).Count;
            for (int index = 2; index <= countriesCount; index++)
            {
                string countryCurrent = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + index + ") > td:nth-child(5) > a")).Text;
                string countryNext = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (index + 1) + ") > td:nth-child(5) > a")).Text;
                Assert.LessOrEqual(countryCurrent, countryNext);
            }
        }

        public void VerifyZonesIsSorted()
        {
            int countriesCount = driver.FindElements(By.CssSelector("table.dataTable tbody > tr.row")).Count;
            for (int index = 1; index <= countriesCount; index++)
            {
                IWebElement zone = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (index + 1) + ") > td:nth-child(6)"));
                string zoneCount = zone.Text;
                if (zoneCount != "0")
                {
                    driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (index + 1) + ") > td:nth-child(5) > a")).Click();
                    wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));

                    int zonesCount = driver.FindElements(By.CssSelector("table.dataTable tbody > tr.row")).Count;
                    for (int indexZone = 2; indexZone <= zonesCount; indexZone++)
                    {
                        string zoneCurrent = driver.FindElement(By.CssSelector("table#table-zones tbody > tr.row:nth-child(" + indexZone + ") > td:nth-child(3)")).Text;
                        string zoneNext = driver.FindElement(By.CssSelector("table.dataTable tbody > tr.row:nth-child(" + (indexZone + 1) + ") > td:nth-child(3)")).Text;
                        Assert.LessOrEqual(zoneCurrent, zoneNext);
                    }
                    driver.Navigate().Back();
                }
            }
        }

        public void VerifyGeoZonesIsSorted()
        {
            int countriesCount = driver.FindElements(By.CssSelector("table.dataTable tbody > tr.row")).Count;
            for (int index = 1; index <= countriesCount; index++)
            {
                NavigateToEditGeoZones(index);

                int geoZonesCount = driver.FindElements(By.CssSelector("table#table-zones > tbody > tr > td:nth-child(3) > select")).Count;
                for (int indexZone = 2; indexZone <= geoZonesCount; indexZone++)
                {
                    string zoneCurrent = driver.FindElement(By.CssSelector("table#table-zones tbody > tr:nth-child(" + indexZone + ") > td:nth-child(3) > select > option[selected = 'selected']")).Text;
                    string zoneNext = driver.FindElement(By.CssSelector("table#table-zones tbody > tr:nth-child(" + (indexZone + 1) + ") > td:nth-child(3) > select > option[selected = 'selected']")).Text;
                    Assert.LessOrEqual(zoneCurrent, zoneNext);
                }                
                NavigateToGeoZones();
            }
        }


    }
}