Feature: TMFeature

As a TurnUp portal admin
I would like to create, edit time and materail records
So that I can manage employees' time and materials successfully

@tag1
Scenario: Create time and materail record with valid details
	Given I logged into tunrup portal successfully 
	When I navigate to Time and Material page
	And I create a new time and material record
	Then The record should be created successfully
	
	Scenario Outline: Edit existing time and material record with valid details
		Given I logged into tunrup portal successfully
		When I navigate to Time and Material page
		And I update '<Description>', '<Code>', '<Price>' on an existing time and material record
		Then The record should have the updated '<Description>', '<Code>', '<Price>'

Examples: 
| Description  | Code     | Price	|
| Time         | text     | $20.00	|
| Materail     | Keyboard | $100.00	|
| EditedRecord | Mouse    | $500.00	|



