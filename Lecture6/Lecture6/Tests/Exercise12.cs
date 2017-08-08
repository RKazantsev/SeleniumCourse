using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Lecture6
{
    [TestFixture]
    public class Exercise12 : TestBase
    {
        [Test]
        public void Ex12Test1()
        {
            NavigateToAdminPage();
            Login();
            NavigateToCatalog();
            AddNewProduct();
            FillGeneralTabForm();
            NavigateToInformationTab();
            FillInformationTabForm();
            NavigateToPricesTab();
            FillPricesTabForm();
            ClickSaveProduct();
            VerifyAddedNewProduct();            
        }

        public void Login()
        {
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
        }

        public void NavigateToAdminPage()
        {
            driver.Url = " http://localhost/litecart/admin/";
            driver.Manage().Window.Maximize();
        }
        public void NavigateToCatalog()
        {
            driver.FindElement(By.CssSelector("ul#box-apps-menu > li#app-:nth-child(2) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
        }
        public void NavigateToInformationTab()
        {
            driver.FindElement(By.CssSelector("td#content ul.index > li:nth-child(2) a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#tab-information")));
        }
        public void NavigateToPricesTab()
        {
            driver.FindElement(By.CssSelector("td#content ul.index > li:nth-child(4) a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#tab-prices")));
        }
        public void AddNewProduct()
        {
            driver.FindElement(By.CssSelector("td#content > div > a:nth-child(2)")).Click();
            wait.Until(ExpectedConditions.TitleIs("Add New Product | My Store"));
        }
        public void FillGeneralTabForm()
        {
            if (product.generalTab.Status == "enabled")
            {
                driver.FindElement(By.CssSelector("div#tab-general label > input[value = '1']")).Click();
            } else if (product.generalTab.Status == "disabled")
            {
                driver.FindElement(By.CssSelector("div#tab-general label > input[value = '0']")).Click();
            }
            driver.FindElement(By.CssSelector("div#tab-general span.input-wrapper > input")).Clear();
            driver.FindElement(By.CssSelector("div#tab-general span.input-wrapper > input")).SendKeys(product.generalTab.Name);
            driver.FindElement(By.CssSelector("div#tab-general input[name='code']")).Clear();
            driver.FindElement(By.CssSelector("div#tab-general input[name='code']")).SendKeys(product.generalTab.Code);
            switch (product.generalTab.Categories)
            {
                case "Rubber Ducks":
                    driver.FindElement(By.CssSelector("div#tab-general td > input[value='0']")).Click();
                    driver.FindElement(By.CssSelector("div#tab-general td > input[value='1']")).Click();
                    break;
                case "Subcategory":
                    driver.FindElement(By.CssSelector("div#tab-general td > input[value='0']")).Click();
                    driver.FindElement(By.CssSelector("div#tab-general td > input[value='2']")).Click();
                    break;
            }
            switch (product.generalTab.Gender)
            {
                case "Female":
                    driver.FindElement(By.CssSelector("input[value='1-2']")).Click();
                    break;
                case "Male":
                    driver.FindElement(By.CssSelector("input[value='1-1']")).Click();
                    break;
                case "Unisex":
                    driver.FindElement(By.CssSelector("input[value='1-3']")).Click();
                    break;
            }
            driver.FindElement(By.CssSelector("input[name='quantity']")).Clear();
            driver.FindElement(By.CssSelector("input[name='quantity']")).SendKeys(product.generalTab.Quantity);
            SelectElement quantityUnitSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='quantity_unit_id']")));
            quantityUnitSelect.SelectByText(product.generalTab.QuantityUnit);
            SelectElement deliveryStatusSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='delivery_status_id']")));
            deliveryStatusSelect.SelectByText(product.generalTab.DeliveryStatus);
            SelectElement soldOutStatusSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='sold_out_status_id']")));
            soldOutStatusSelect.SelectByText(product.generalTab.SoldOutStatus);

            // Change Path to Image file here.
            driver.FindElement(By.CssSelector("input[name='new_images[]']")).SendKeys(Path.GetFullPath(@"C:\\Repos\\SeleniumCourse\\Lecture6\\Lecture6\\plush-duck.jpg"));


            driver.FindElement(By.CssSelector("input[name='date_valid_from']")).SendKeys(product.generalTab.DateValidFrom);
            driver.FindElement(By.CssSelector("input[name='date_valid_to']")).SendKeys(product.generalTab.DateValidTo);
        }
        public void FillInformationTabForm()
        {
            SelectElement manufacturerSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='manufacturer_id']")));
            manufacturerSelect.SelectByText(product.informationTab.Manufacturer);
            //SelectElement supplierSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='supplier_id']")));
            //supplierSelect.SelectByText(product.informationTab.Supplier);
            driver.FindElement(By.CssSelector("input[name='keywords']")).Clear();
            driver.FindElement(By.CssSelector("input[name='keywords']")).SendKeys(product.informationTab.Keywords);
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(4) span.input-wrapper > input")).Clear();
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(4) span.input-wrapper > input")).SendKeys(product.informationTab.ShortDescription);
            driver.FindElement(By.CssSelector("div.trumbowyg-editor")).Clear();
            driver.FindElement(By.CssSelector("div.trumbowyg-editor")).SendKeys(product.informationTab.Description);
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(6) span.input-wrapper > input")).Clear();
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(6) span.input-wrapper > input")).SendKeys(product.informationTab.HeadTitle);
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(7) span.input-wrapper > input")).Clear();
            driver.FindElement(By.CssSelector("div#tab-information tr:nth-child(7) span.input-wrapper > input")).SendKeys(product.informationTab.MetaDescription);
        }
        public void FillPricesTabForm()
        {
            driver.FindElement(By.CssSelector("input[name='purchase_price']")).Clear();
            driver.FindElement(By.CssSelector("input[name='purchase_price']")).SendKeys(product.pricesTab.PurchasePrice);
            SelectElement currencySelect = new SelectElement(driver.FindElement(By.CssSelector("select[name='purchase_price_currency_code']")));
            currencySelect.SelectByText(product.pricesTab.Currency);
            driver.FindElement(By.CssSelector("div#tab-prices table:nth-child(4) input[name='prices[USD]']")).Clear();
            driver.FindElement(By.CssSelector("div#tab-prices table:nth-child(4) input[name='prices[USD]']")).SendKeys(product.pricesTab.PriceUSD);
            driver.FindElement(By.CssSelector("div#tab-prices table:nth-child(4) input[name='prices[EUR]']")).Clear();
            driver.FindElement(By.CssSelector("div#tab-prices table:nth-child(4) input[name='prices[EUR]']")).SendKeys(product.pricesTab.PriceEUR);
        }
        public void ClickSaveProduct()
        {
            driver.FindElement(By.CssSelector("button[name='save']")).Click();
        }
        public void VerifyAddedNewProduct()
        {
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            Assert.AreEqual(driver.FindElement(By.CssSelector("table.dataTable tr:nth-child(7)")).Text, "Yellow Plush Duck");
        }
    }
}