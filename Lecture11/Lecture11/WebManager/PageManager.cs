using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lecture11
{
    public class PageManager
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;
        protected MainPage main;
        protected Navigation navigation;
        protected ProductPage product;
        protected CartPage cart;

        public PageManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://localhost/litecart/";
            main = new MainPage(this);
            navigation = new Navigation(this);
            product = new ProductPage(this);
            cart = new CartPage(this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public WebDriverWait WaitDriver
        {
            get
            {
                return wait;
            }
        }
        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }
        public MainPage Store
        {
            get
            {
                return main;
            }
        }
        public Navigation Navigator
        {
            get
            {
                return navigation;
            }
        }
        public ProductPage Product
        {
            get
            {
                return product;
            }
        }
        public CartPage Cart
        {
            get
            {
                return cart;
            }
        }
        public void Stop()
        {        
            driver.Quit();
            driver = null;
        }
    }
}