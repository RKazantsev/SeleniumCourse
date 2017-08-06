using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Lecture6
{
    [TestFixture]
    public class Exercise11 : TestBase
    {
        [Test]
        public void Ex11Test1()
        {
            GoToMainPage();
            GoToCreateAccountPage();
            FillAccountForm();
            ClickCreateAccountButton();
            Wait();
            Logout();
            Wait();
            Login();
            Wait();
            Logout();
        }

        public void GoToMainPage()
        {
            driver.Url = "http://localhost/litecart/";
            driver.Manage().Window.Maximize();
            Wait();
        }

        public void GoToCreateAccountPage()
        {
            driver.FindElement(By.CssSelector("div#box-account-login tr:nth-child(5) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Create Account | My Store"));
        }

        public void FillAccountForm()
        {
            driver.FindElement(By.Name("tax_id")).Clear();
            driver.FindElement(By.Name("tax_id")).SendKeys(account.TaxID);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(account.Company);
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(account.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(account.LastName);
            driver.FindElement(By.Name("address1")).Clear();
            driver.FindElement(By.Name("address1")).SendKeys(account.Address1);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(account.Address2);
            driver.FindElement(By.Name("postcode")).Clear();
            driver.FindElement(By.Name("postcode")).SendKeys(account.Postcode);
            driver.FindElement(By.Name("city")).Clear();
            driver.FindElement(By.Name("city")).SendKeys(account.City);
            SelectElement countrySelect = new SelectElement(driver.FindElement(By.CssSelector("select.select2-hidden-accessible")));
            countrySelect.SelectByText(account.Country);          
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("select[name=zone_code]")));
            SelectElement stateSelect = new SelectElement(driver.FindElement(By.CssSelector("select[name=zone_code]")));
            stateSelect.SelectByText(account.State);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
            driver.FindElement(By.Name("phone")).Clear();
            driver.FindElement(By.Name("phone")).SendKeys(account.Phone);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("confirmed_password")).Clear();
            driver.FindElement(By.Name("confirmed_password")).SendKeys(account.Password);
        }

        public void ClickCreateAccountButton()
        {
            driver.FindElement(By.CssSelector("button[type=submit]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));          
        }

        public void Logout()
        {            
            driver.FindElement(By.CssSelector("div#box-account li:nth-child(4) a")).Click();
        }

        public void Login()
        {            
            driver.FindElement(By.CssSelector("input[name=email]")).SendKeys(account.Email);
            driver.FindElement(By.CssSelector("input[name=password]")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("button[type=submit]")).Click();
        }

        public void Wait()
        {
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
        }
    }
}
