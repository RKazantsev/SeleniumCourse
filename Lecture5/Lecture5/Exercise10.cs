using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Lecture5
{
    [TestFixture]
    public class Exercise10 : TestBase
    {
        [Test]
        public void Exercise10Test()
        {
            GoToMainPage();
            GetMainPageAttributes();
            GoToProductPage();
            GetProductPageAttributes();
            VerifyProductName();
            VerifyProductPrice();
            VerifyPriceColor();
            VerifyLineThroughText();
            VerifyFontWeight();
            VerifyFontSize();            
        }

        public void GoToMainPage()
        {
            driver.Url = "http://localhost/litecart/";
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
        }

        public void GoToProductPage()
        {
            driver.FindElement(By.CssSelector("div#box-campaigns li:first-child")).Click();
            wait.Until(ExpectedConditions.TitleIs(productNameMainPage + " | Subcategory | Rubber Ducks | My Store"));
        }

        public void GetMainPageAttributes()
        {
            productNameMainPage = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child div.name")).Text;
            productRegularPriceMainPage = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).Text;
            productRegularPriceMainPageTextColor = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).GetCssValue("color");
            productRegularPriceMainPageTextDecoration = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).GetCssValue("text-decoration-line");
            productRegularPriceMainPageTextDecorationColor = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).GetCssValue("text-decoration-color");
            productRegularPriceMainPageFontSize = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).GetCssValue("font-size");
            productCampaignPriceMainPage = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong.campaign-price")).Text;
            productCampaignPriceMainPageTextColor = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong.campaign-price")).GetCssValue("color");
            productCampaignPriceMainPageFontWeight = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong.campaign-price")).GetCssValue("font-weight");
            productCampaignPriceMainPageFontSize = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong.campaign-price")).GetCssValue("font-size");
        }

        public void GetProductPageAttributes()
        {
            productNameProductPage = driver.FindElement(By.CssSelector("h1.title")).Text;
            productRegularPriceProductPage = driver.FindElement(By.CssSelector("s.regular-price")).Text;
            productRegularPriceProductPageTextColor = driver.FindElement(By.CssSelector("s.regular-price")).GetCssValue("color");
            productRegularPriceProductPageTextDecoration = driver.FindElement(By.CssSelector("s.regular-price")).GetCssValue("text-decoration-line");
            productRegularPriceProductPageTextDecorationColor = driver.FindElement(By.CssSelector("s.regular-price")).GetCssValue("text-decoration-color");
            productRegularPriceProductPageFontSize = driver.FindElement(By.CssSelector("s.regular-price")).GetCssValue("font-size");
            productCampaignPriceProductPage = driver.FindElement(By.CssSelector("strong.campaign-price")).Text;
            productCampaignPriceProductPageTextColor = driver.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("color");
            productCampaignPriceProductPageFontWeight = driver.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("font-weight");
            productCampaignPriceProductPageFontSize = driver.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("font-size");
        }

        public string IdentifyColor(string color)
        {           
            string redIndex;
            string greenIndex;
            string blueIndex;

            if (color == "")
            {
                return "null";
            } else if (color.Contains("rgba"))
            {
                int openParenth = color.IndexOf("(");
                int comma = color.IndexOf(",");
                redIndex = color.Substring(openParenth + 1, comma - openParenth - 1);
                color = color.Substring(comma + 2);
                comma = color.IndexOf(",");
                greenIndex = color.Substring(0, comma);
                color = color.Substring(comma + 2);
                comma = color.IndexOf(",");
                blueIndex = color.Substring(0, comma);                
            }
            else
            {
                int openParenth = color.IndexOf("(");
                int comma = color.IndexOf(",");
                redIndex = color.Substring(openParenth + 1, comma - openParenth - 1);
                color = color.Substring(comma + 2);
                comma = color.IndexOf(",");
                greenIndex = color.Substring(0, comma);
                color = color.Substring(comma + 2);
                int closeParenth = color.IndexOf(")");
                blueIndex = color.Substring(0, closeParenth);                
            }
            if ((redIndex == greenIndex) & (redIndex == blueIndex))
            {
                return "gray";
            }
            else if (greenIndex == blueIndex)
            {
                return "red";
            }
            else return "null";            
        }

        public void VerifyProductName()
        {
            Assert.AreEqual(productNameMainPage, productNameProductPage);
        }

        public void VerifyProductPrice()
        {
            Assert.AreEqual(productRegularPriceMainPage, productRegularPriceProductPage);
            Assert.AreEqual(productCampaignPriceMainPage, productCampaignPriceProductPage);
        }

        public void VerifyPriceColor()
        {
            Assert.AreEqual(IdentifyColor(productRegularPriceMainPageTextColor), "gray");
            Assert.AreEqual(IdentifyColor(productCampaignPriceMainPageTextColor), "red");
            Assert.AreEqual(IdentifyColor(productRegularPriceProductPageTextColor), "gray");
            Assert.AreEqual(IdentifyColor(productCampaignPriceProductPageTextColor), "red");
        }

        public void VerifyLineThroughText()
        {
            switch (driver.GetType().ToString())
            {
                case "OpenQA.Selenium.IE.InternetExplorerDriver":
                case "OpenQA.Selenium.Edge.EdgeDriver":                
                    Assert.AreEqual(productRegularPriceMainPageTextDecoration, "");
                    Assert.AreEqual(productRegularPriceProductPageTextDecoration, "");
                    Assert.AreEqual(productRegularPriceMainPageTextDecorationColor, "");
                    Assert.AreEqual(productRegularPriceProductPageTextDecorationColor, "");
                    break;
                case "OpenQA.Selenium.Chrome.ChromeDriver":
                case "OpenQA.Selenium.Firefox.FirefoxDriver":
                    Assert.AreEqual(productRegularPriceMainPageTextDecoration, "line-through");
                    Assert.AreEqual(productRegularPriceProductPageTextDecoration, "line-through");
                    Assert.AreEqual(IdentifyColor(productRegularPriceMainPageTextDecorationColor), "gray");
                    Assert.AreEqual(IdentifyColor(productRegularPriceProductPageTextDecorationColor), "gray");
                    break;
            }
        }

        public void VerifyFontWeight()
        {
            switch (driver.GetType().ToString())
            {
                case "OpenQA.Selenium.Chrome.ChromeDriver":
                    Assert.AreEqual(productCampaignPriceMainPageFontWeight, "bold");
                    Assert.AreEqual(productCampaignPriceProductPageFontWeight, "bold");
                    break;
                case "OpenQA.Selenium.Edge.EdgeDriver":
                    Assert.AreEqual(productCampaignPriceMainPageFontWeight, "700"); 
                    Assert.AreEqual(productCampaignPriceMainPageFontWeight, "700");
                    break;
                case "OpenQA.Selenium.IE.InternetExplorerDriver":
                case "OpenQA.Selenium.Firefox.FirefoxDriver" :
                    Assert.AreEqual(productCampaignPriceMainPageFontWeight, "900");
                    Assert.AreEqual(productCampaignPriceMainPageFontWeight, "900");
                    break;                
            }             
        }

        public void VerifyFontSize()
        {
            Assert.LessOrEqual(productRegularPriceMainPageFontSize, productCampaignPriceMainPageFontSize);
            Assert.LessOrEqual(productRegularPriceProductPageFontSize, productCampaignPriceProductPageFontSize);
        }
    }
}
