using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lecture4Ex7
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com.ua/";

        }

        [Test]
        public void TestMethod1()
        {
            driver.FindElement(By.CssSelector("#lst-ib")).SendKeys("Jeep Grand Cherokee");
            driver.FindElement(By.CssSelector(""))


        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

    }
}
