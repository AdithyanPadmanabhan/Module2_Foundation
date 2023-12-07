Feature: CourseSelection



@tag1
Scenario: Course Selection
    Given User will be on Login page
	When user will enter username '<Username>'
	And user will enter password '<Password>'
	And user will click on submit button
	Then user will be redirected to Homepage
	When User will click on course tab
	And User selects a '<CourseNo>'
	Then user will be redirected to course page
	When user click on enroll button
	Then user will be on payment page

	
Examples: 
    | Username | Password    | CourseNo |
    | student  | Password123 | 1        |
	
