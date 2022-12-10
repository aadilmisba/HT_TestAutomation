Feature: Gmail_email_feature

Scenario Outline: login
    Given user in the login page to sign in
	When user enter <username> and <password>
	Then user will login to the gmail account
	Examples: 
		| username                   | password |
		| aadilmuhammadu@gmail.com   | Test@123 |


@tag1
Scenario: verify user can send a mail
	Given user clicks the compose button
	When user enters sender mail, subject, and compose text
	    | Mail                   | Subject        | Text      |
	    | aadilmisba3@gmail.com  | Sample Subject | Test Mail |
	When user clicks the close and save button
	Then navigate to draft page and open the draft mail
	When user clicks the send button 
	Then navigate to sent page and verify the mail has been sent
	When user clicks the reply button and send the mail
	| Text        |
	|   Updated   |
	Then user will drag and drop the mail in the trash folder
	When user clicks the account button and clicks the Sign out button
	Then user will be navigated to login page

