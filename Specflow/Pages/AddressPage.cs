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
    public class AddressPage
    {
        private WebDriverWait wait;

        public AddressPage()
        {
            wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver.driver, this);
        }

        private IWebElement title()
        {
            return (Driver.driver.FindElement(By.Id("datitle")));
        }

        private IWebElement firstname()
        {
            return (Driver.driver.FindElement(By.Id("dafirstname")));
        }

        private IWebElement lastname()
        {
            return (Driver.driver.FindElement(By.Id("dalastname")));
        }

        private IWebElement address1()
        {
            return (Driver.driver.FindElement(By.Id("daaddressline1")));
        }

        private IWebElement address2()
        {
            return (Driver.driver.FindElement(By.Id("daaddressline2")));
        }

        private IWebElement city()
        {
            return (Driver.driver.FindElement(By.Id("dacity")));
        }

        private IWebElement province()
        {
            return (Driver.driver.FindElement(By.Id("dastateprovinceregion")));
        }

        private IWebElement postcode()
        {
            return (Driver.driver.FindElement(By.Id("dazippostcode")));
        }

        private IWebElement Next()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Next')]")));
        }
        public void filladdressdetails(string titlevalue, string fname, string lname, string adr1, string adr2, string cityvalue, string prov, string post)
        {
            title().SendKeys(titlevalue);
            firstname().SendKeys(fname);
            lastname().SendKeys(lname);
            address1().SendKeys(adr1);
            address2().SendKeys(adr2);
            city().SendKeys(cityvalue);
            province().SendKeys(prov);
            postcode().SendKeys(post);
        }
        public void clickNext()
        {
            Next().Click();
        }  
    }
}
