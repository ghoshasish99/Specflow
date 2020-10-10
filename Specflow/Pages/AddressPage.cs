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

        [FindsBy(How = How.Id, Using = "datitle")]
        [CacheLookup]
        private IWebElement title;

        [FindsBy(How = How.Id, Using = "dafirstname")]
        [CacheLookup]
        private IWebElement firstname;

        [FindsBy(How = How.Id, Using = "dalastname")]
        [CacheLookup]
        private IWebElement lastname;

        [FindsBy(How = How.Id, Using = "daaddressline1")]
        [CacheLookup]
        private IWebElement address1;

        [FindsBy(How = How.Id, Using = "daaddressline2")]
        [CacheLookup]
        private IWebElement address2;

        [FindsBy(How = How.Id, Using = "dacity")]
        [CacheLookup]
        private IWebElement city;

        [FindsBy(How = How.Id, Using = "dastateprovinceregion")]
        [CacheLookup]
        private IWebElement province;

        [FindsBy(How = How.Id, Using = "dazippostcode")]
        [CacheLookup]
        private IWebElement postcode;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Next')]")]
        [CacheLookup]
        private IWebElement Next;
        public void filladdressdetails(string titlevalue, string fname, string lname, string adr1, string adr2, string cityvalue, string prov, string post)
        {
            title.SendKeys(titlevalue);
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            address1.SendKeys(adr1);
            address2.SendKeys(adr2);
            city.SendKeys(cityvalue);
            province.SendKeys(prov);
            postcode.SendKeys(post);
        }
        public void clickNext()
        {
            Next.Click();
        }  
    }
}
