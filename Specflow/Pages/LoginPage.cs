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


        private IWebElement menuIcon()
        {
            return (Driver.driver.FindElement(By.Id("menu")));
        }

        private IWebElement LoginIcon()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Login')]")));
        }


        private IWebElement createAccountbutton()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Create Your E-Shop Account')]")));
        }


        private IWebElement firstname()
        {
            return (Driver.driver.FindElement(By.Id("firstname")));
        }


        private IWebElement lastname()
        {
            return (Driver.driver.FindElement(By.Id("lastname")));
        }


        private IWebElement registeremail()
        {
            return (Driver.driver.FindElement(By.Id("registeremail")));
        }


        private IWebElement password()
        {
            return (Driver.driver.FindElement(By.Id("password")));
        }


        private IWebElement confirmpassword()
        {
            return (Driver.driver.FindElement(By.Id("confirmpassword")));
        }


        private IWebElement email()
        {
            return (Driver.driver.FindElement(By.Id("email")));
        }


        private IWebElement LoginButton()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Log In')]")));
        }


        private IWebElement CustomerNotFoundMessage()
        {
            return (Driver.driver.FindElement(By.XPath("//span[contains(text(),'Customer not found with email')]")));
        }

        public void Login(string emailID, string passwordtext)
        {
            try
            {
             
                menuIcon().Click();
                LoginIcon().Click();
                email().SendKeys(emailID);
                password().SendKeys(passwordtext);
                LoginButton().Click();
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
            menuIcon().Click();
            LoginIcon().Click();
            createAccountbutton().Click();
            firstname().SendKeys(fname);
            lastname().SendKeys(lname);
            registeremail().SendKeys(regemail);
            password().SendKeys(passwordtext);
            confirmpassword().SendKeys(passwordtext);
            createAccountbutton().Click();
        }

        public void customernotfounderror()
        {
            System.Threading.Thread.Sleep(5000);
            Assert.That(CustomerNotFoundMessage().Displayed);
            Driver.driver.Quit();
        }

    }
}
