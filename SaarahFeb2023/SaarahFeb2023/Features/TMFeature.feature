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
		And I update '<Description>' on an existing time and material record
		Then The record should have the updated '<description>'

Examples: 
| Description  |
| Time         |
| Materail     |
| EditedRecord |



