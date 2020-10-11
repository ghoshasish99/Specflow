using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Runtime.CompilerServices;
using AzureWorkshop.Utilities;

namespace AzureWorkshop.Pages
{
    public class ProductsPage
    {
        private WebDriverWait wait;

        public ProductsPage()
        {
            wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(50));
            PageFactory.InitElements(Driver.driver, this);
        }

        private IWebElement searchtext()
        {
            return (Driver.driver.FindElement(By.Id("productsearch")));
        }

        private IWebElement searchicon()
        {
            return (Driver.driver.FindElement(By.Id("searchicon")));
        }

        private IWebElement productHeader()
        {
            return (Driver.driver.FindElement(By.XPath("//h4[@class='MuiTypography-root MuiTypography-h4']")));
        }

        private IWebElement AddtoBasket()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Add to your basket')]")));
        }

        private IWebElement lnkBasket()
        {
            return (Driver.driver.FindElement(By.Id("basket")));
        }

        private IWebElement CheckOut()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Proceed to checkout')]")));
        }

        public void searchproduct(string productname)
        {
            System.Threading.Thread.Sleep(2000);
            searchtext().SendKeys(productname);
            searchicon().Click();
        }
        public void verifyProductListed(string productname)
        {
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.driver.FindElement(By.XPath("//a[contains(text(),'" + productname.Trim() + "')]")).Displayed);
        }

        public void addproducttobasket(String productname)
        {
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'" + productname.Trim() + "')]")).Click();
            AddtoBasket().Click();
        }
        public void viewbasket()
        {
            lnkBasket().Click();
        }
        public void checkout()
        {
            System.Threading.Thread.Sleep(2000);
            CheckOut().Click();
        }
        public void landOnDashboard()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.That(searchtext().Displayed);
            Driver.driver.Quit();
        }
    }
}
