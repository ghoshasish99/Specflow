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

        [FindsBy(How = How.Id, Using = "productsearch")]
        [CacheLookup]
        private IWebElement searchtext;

        [FindsBy(How = How.Id, Using = "searchicon")]
        [CacheLookup]
        private IWebElement searchicon;

        [FindsBy(How = How.XPath, Using = "//h4[@class='MuiTypography-root MuiTypography-h4']")]
        [CacheLookup]
        private IWebElement productHeader;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add to your basket')]")]
        [CacheLookup]
        private IWebElement AddtoBasket;

        [FindsBy(How = How.Id, Using = "basket")]
        [CacheLookup]
        private IWebElement lnkBasket;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Proceed to checkout')]")]
        [CacheLookup]
        private IWebElement CheckOut;

        public void searchproduct(string productname)
        {
            System.Threading.Thread.Sleep(2000);
            searchtext.SendKeys(productname);
            searchicon.Click();
        }
        public void verifyProductListed(string productname)
        {
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.driver.FindElement(By.XPath("//a[contains(text(),'" + productname.Trim() + "')]")).Displayed);
        }

        public void addproducttobasket(String productname)
        {
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'" + productname.Trim() + "')]")).Click();
            AddtoBasket.Click();
        }
        public void viewbasket()
        {
            lnkBasket.Click();
        }
        public void checkout()
        {
            System.Threading.Thread.Sleep(2000);
            CheckOut.Click();
        }
        public void landOnDashboard()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.That(searchtext.Displayed);
            Driver.driver.Quit();
        }
    }
}
