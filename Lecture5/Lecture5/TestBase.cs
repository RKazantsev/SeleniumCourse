using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture5
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string productNameMainPage;
        protected string productRegularPriceMainPage;
        protected string productRegularPriceMainPageTextColor;
        protected string productRegularPriceMainPageTextDecoration;
        protected string productRegularPriceMainPageTextDecorationColor;
        protected string productRegularPriceMainPageFontSize;
        protected string productCampaignPriceMainPage;
        protected string productCampaignPriceMainPageTextColor;
        protected string productCampaignPriceMainPageFontWeight;
        protected string productCampaignPriceMainPageFontSize;
        protected string productNameProductPage;
        protected string productRegularPriceProductPage;
        protected string productRegularPriceProductPageTextColor;
        protected string productRegularPriceProductPageTextDecoration;
        protected string productRegularPriceProductPageTextDecorationColor;
        protected string productRegularPriceProductPageFontSize;
        protected string productCampaignPriceProductPage;
        protected string productCampaignPriceProductPageTextColor;
        protected string productCampaignPriceProductPageFontWeight;
        protected string productCampaignPriceProductPageFontSize;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver = new InternetExplorerDriver();
            //driver = new EdgeDriver();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }        

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
