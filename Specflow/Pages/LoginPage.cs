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
    public class LoginPage
    {
        private WebDriverWait wait;

        public LoginPage()
        {
            wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "menu")]
        [CacheLookup]
        private IWebElement menuIcon;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Login')]")]
        [CacheLookup]
        private IWebElement LoginIcon;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Create Your E-Shop Account')]")]
        [CacheLookup]
        private IWebElement createAccountbutton;

        [FindsBy(How = How.Id, Using = "firstname")]
        [CacheLookup]
        private IWebElement firstname;

        [FindsBy(How = How.Id, Using = "lastname")]
        [CacheLookup]
        private IWebElement lastname;

        [FindsBy(How = How.Id, Using = "registeremail")]
        [CacheLookup]
        private IWebElement registeremail;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "confirmpassword")]
        [CacheLookup]
        private IWebElement confirmpassword;

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement email;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Log In')]")]
        [CacheLookup]
        private IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Customer not found with email')]")]
        [CacheLookup]
        private IWebElement CustomerNotFoundMessage;
      
        public void Login(string emailID, string passwordtext)
        {
            try
            {
                System.Threading.Thread.Sleep(10000);
                menuIcon.Click();
                LoginIcon.Click();
                email.SendKeys(emailID);
                password.SendKeys(passwordtext);
                LoginButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void addaccount(string fname, string lname, string regemail, string passwordtext)
        {
            long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            regemail = regemail.Replace("@", time + "@");
            menuIcon.Click();
            LoginIcon.Click();
            createAccountbutton.Click();
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            registeremail.SendKeys(regemail);
            password.SendKeys(passwordtext);
            confirmpassword.SendKeys(passwordtext);
            clickCreateAccountButton();
        }

        public void customernotfounderror()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.That(CustomerNotFoundMessage.Displayed);
            Driver.driver.Quit();
        }

        public void clickCreateAccountButton()
        {
            System.Threading.Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//span[contains(text(),'Create Your E-Shop Account')]")).Click();
            // ((IJavaScriptExecutor)Driver.driver).ExecuteScript("arguments[0].click()",createAccountbutton);
        }
    }
}
