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
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Actions = OpenQA.Selenium.Interactions.Actions;


namespace HT_Design_Pattern.PageObjects
{

    public class SentPage
    {
        public SentPage() 
        {
            PageFactory.InitElements(BaseTest.webDriver, this);
        }
        

        public IWebElement SentField => BaseTest.webDriver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => BaseTest.webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement newTextbox => BaseTest.webDriver.FindElement(By.XPath("//div[@aria-label='Message Body']"));

        public IWebElement newSendField => BaseTest.webDriver.FindElement(By.XPath("//div[text()='Send']"));

        public IWebElement updatedSentMail => BaseTest.webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement NewSentField => BaseTest.webDriver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement moreField => BaseTest.webDriver.FindElement(By.XPath("//span[contains(text(),'More')]"));

        public IWebElement trashField => BaseTest.webDriver.FindElement(By.XPath("//a[contains(text(),'Bin')]"));

        public IWebElement newSentMail => BaseTest.webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement AccountField => BaseTest.webDriver.FindElement(By.XPath("//img[@class='gb_Ia gbii']"));

        public IWebElement SignOut => BaseTest.webDriver.FindElement(By.XPath("//div[text()='Sign out']"));

        WebDriverWait wait = new WebDriverWait(BaseTest.webDriver, TimeSpan.FromSeconds(100));

        public void SendMails(string newMessage)
        {
            Actions action = new Actions(BaseTest.webDriver);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            action.ContextClick(SentMail).Build().Perform();
            action.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            newTextbox.SendKeys(newMessage);
            action.MoveToElement(newSendField).Click().Build().Perform();
           
            NewSentField.Click();
        }

        public void DeleteMail()
        {
            Actions action = new Actions(BaseTest.webDriver);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moreField));
            action.MoveToElement(moreField).Build().Perform();
            action.Click(moreField).Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(trashField));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newSentMail));

            action.DragAndDrop(newSentMail, trashField).Build().Perform();
        }


        public void LogOut()
        {
            //AccountField.Click();
            var AccountButton = new Button(AccountField);
            AccountButton.Click();

            BaseTest.webDriver.SwitchTo().Frame("account");
            Debug.WriteLine("1st phase");
            IWebElement SignoutBtn= wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SignOut));
            var SignOutButton = new Button(SignoutBtn);
            SignOutButton.Click();
            SignOutButton.Click();
            BaseTest.webDriver.SwitchTo().ParentFrame().Dispose();
            Debug.WriteLine("Done");
        }


    }

}
