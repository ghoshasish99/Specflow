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
    public class PaymentsPage
    {
        private WebDriverWait wait;

        public PaymentsPage()
        {
            wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "cardnumber")]
        [CacheLookup]
        private IWebElement cardnumber;

        [FindsBy(How = How.Id, Using = "nameoncard")]
        [CacheLookup]
        private IWebElement nameoncard;

        [FindsBy(How = How.Id, Using = "expirymonth")]
        [CacheLookup]
        private IWebElement expirymonth;

        [FindsBy(How = How.Id, Using = "expiryyear")]
        [CacheLookup]
        private IWebElement expiryyear;

        [FindsBy(How = How.Id, Using = "securitycode")]
        [CacheLookup]
        private IWebElement securitycode;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Confirm')]")]
        [CacheLookup]
        private IWebElement ConfirmButton;

        [FindsBy(How = How.XPath, Using = "//h4[contains(text(),'Thanks for your order')]")]
        [CacheLookup]
        private IWebElement ConfirmationMessage;

        public void enterPaymentDetails(string strCardNumber, string strNameOnCard, string strExpiryYear, string strExpiryMonth, string strSecurityCode)
        {
            cardnumber.SendKeys(strCardNumber);
            nameoncard.SendKeys(strNameOnCard);
            expiryyear.SendKeys(strExpiryYear);
            expirymonth.SendKeys(strExpiryMonth);
            securitycode.SendKeys(strSecurityCode);
            ConfirmButton.Click();
        }
        public void verifyOrderConfirmation()
        {
            Assert.That(ConfirmationMessage.Displayed);
        }
    }
}
