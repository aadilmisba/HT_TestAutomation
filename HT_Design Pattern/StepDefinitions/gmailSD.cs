using HT_Design_Pattern.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HT_Design_Pattern.StepDefinitions
{
    [Binding]
    public class gmailSD 
    {
        LoginPage loginPo;
        BaseTest baseTest = new BaseTest();
        InboxPage InboxPo;
        DraftPage draftPo;
        SentPage sentPo;

        [Given(@"user in the login page to sign in")]
        public void GivenUserInTheLoginPageToSignIn()
        {
            baseTest.BrowserSetup();
            loginPo = new LoginPage();
        }
        [When(@"user enter (.*) and (.*)")]
        public void WhenUserEnterUsernameAndPassword(string p0, string p1)
        {
            loginPo.Login(p0, p1);
        }

        //[When(@"user enter username '([^']*)' and password '([^']*)'")]
        //public void WhenUserEnterUsernameAndPassword(string p0, string p1)
        //{
        //    loginPo.Login(p0, p1);
        //}

        [Then(@"user will login to the gmail account")]
        public void ThenUserWillLoginToTheGmailAccount()
        {
            loginPo.LoginClick();
            Assert.True(loginPo.MainPage.Displayed, "The login is successful");
        }

        [Given(@"user clicks the compose button")]
        public void GivenUserClicksTheComposeButton()
        {
            InboxPo = new InboxPage();
        }

        [When(@"user enters sender mail, subject, and compose text")]
        public void WhenUserEntersSenderMailSubjectAndComposeText(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            InboxPo.Compose((string)data.Mail, (string)data.Subject, (string)data.Text);
        }

        [When(@"user clicks the close and save button")]
        public void WhenUserClicksTheCloseAndSaveButton()
        {
            InboxPo.SaveCloseClick();
        }

        [Then(@"navigate to draft page and open the draft mail")]
        public void ThenNavigateToDraftPageAndOpenTheDraftMail()
        {
            draftPo = new DraftPage();
            draftPo.DraftMails();            
        }

        [When(@"user clicks the send button")]
        public void WhenUserClicksTheSendButton()
        {
            draftPo.sendMailClick();
        }

        [Then(@"navigate to sent page and verify the mail has been sent")]
        public void ThenNavigateToSentPageAndVerifyTheMailHasBeenSent()
        {
            sentPo = new SentPage();
        }

        [When(@"user clicks the reply button and send the mail")]
        public void WhenUserClicksTheReplyButtonAndSendTheMail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            sentPo.SendMails((string)data.Text);
        }

        [Then(@"user will drag and drop the mail in the trash folder")]
        public void ThenUserWillDragAndDropTheMailInTheTrashFolder()
        {
            sentPo.DeleteMail();
        }

        [When(@"user clicks the account button and clicks the Sign out button")]
        public void WhenUserClicksTheAccountButtonInTheMainPage()
        {
            sentPo.LogOut();
        }

        [Then(@"user will be navigated to login page")]
        public void ThenUserWillBeNavigatedToLoginPage()
        {
            baseTest.Cleanup();
        }




    }
}
