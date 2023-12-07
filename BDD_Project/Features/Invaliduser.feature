Feature: Invaliduser


@tag1
Scenario: Invalid User Login
	Given User will be on Login page
	When user will enter username '<Username>'
	And user will enter password '<Password>'
	And user will click on submit button
	Then Error message for password length should be thrown
Examples: 
    | Username | Password    | 
    | Incorrect  | Password123 | 
