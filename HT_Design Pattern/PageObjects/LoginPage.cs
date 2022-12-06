using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Actions = OpenQA.Selenium.Interactions.Actions;


namespace HT_Design_Pattern.PageObjects
{
    public class LoginPage
    {
        public LoginPage() 
        {
            PageFactory.InitElements(BaseTest.webDriver, this);
        }

        public IWebElement UsernameField => BaseTest.webDriver.FindElement(By.Id("identifierId"));

        public IWebElement NextButton => BaseTest.webDriver.FindElement(By.Id("identifierNext"));
        public IWebElement PasswordField => BaseTest.webDriver.FindElement(By.XPath("//*[@id='password']//input"));

        public WebDriverWait wait = new WebDriverWait(BaseTest.webDriver, TimeSpan.FromSeconds(50));
        
        public IWebElement LoginButton => BaseTest.webDriver.FindElement(By.Id("passwordNext"));

        public IWebElement MainPage => BaseTest.webDriver.FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {
            //username = "aadilmuhammadu@gmail.com";
            //password = "Test@123";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest.webDriver;
            WebDriverWait wait = new WebDriverWait(BaseTest.webDriver, TimeSpan.FromSeconds(50));
            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", UsernameField);

            //pass this value from test
            UsernameField.SendKeys(username); 
            jsExecutor.ExecuteScript("arguments[0].click();", NextButton);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));

            //pass this value from test
            PasswordField.SendKeys(password); 

        }

        public void LoginClick()
        {
            var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();
        }

        public void ViewMainPage()
        {
            MainPage.Click();
        }

    }
}