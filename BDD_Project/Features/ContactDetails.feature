Feature: ContactDetails

A short summary of the feature

@tag1
Scenario: Contact_Details
 Given User will be on Login   page
	When user will enter  username  '<Username>'
	And user will enter  password  '<Password>'
	And user will click  on submit  button
	Then user will be  redirected to Homepage
	When User will click on contact tab
	Then user will be on contact details page
	When user will enter firstname '<Firstname>'
	And user will enter lastname '<Lastname>'
	And user will enter  email'<Emailid>'
	And user will enter Comments <'Comments>'
	And user will click on submit form
	Then user will redirected to contactpage

Examples: 
    | Username | Password    | Firstname | Lastname | Emailid        | Comments |
    | student  | Password123 | Amal      | john     | john@gmail.com | Tester   |
