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


        private IWebElement cardnumber()
        {
            return (Driver.driver.FindElement(By.Id("cardnumber")));
        }


        private IWebElement nameoncard()
        {
            return (Driver.driver.FindElement(By.Id("nameoncard")));
        }


        private IWebElement expirymonth()
        {
            return (Driver.driver.FindElement(By.Id("expirymonth")));
        }


        private IWebElement expiryyear()
        {
            return (Driver.driver.FindElement(By.Id("expiryyear")));
        }


        private IWebElement securitycode()
        {
            return Driver.driver.FindElement(By.Id("securitycode"));
        }


        private IWebElement ConfirmButton()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Confirm')]")));
        }


        private IWebElement ConfirmationMessage()
        {
            return (Driver.driver.FindElement(By.XPath("//h4[contains(text(),'Thanks for your order')]")));
        }

        public void enterPaymentDetails(string strCardNumber, string strNameOnCard, string strExpiryYear, string strExpiryMonth, string strSecurityCode)
        {
            cardnumber().SendKeys(strCardNumber);
            nameoncard().SendKeys(strNameOnCard);
            expiryyear().SendKeys(strExpiryYear);
            expirymonth().SendKeys(strExpiryMonth);
            securitycode().SendKeys(strSecurityCode);
            ConfirmButton().Click();
        }
        public void verifyOrderConfirmation()
        {
            Assert.That(ConfirmationMessage().Displayed);
        }
    }
}
