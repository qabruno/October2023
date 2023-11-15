Feature: TMFeature

As a TurnUp portal user
I would like to create, edit and delete time and material records
So that I can manage employees time and material successfully

@tag1
Scenario: create time record with valid details
	Given I logged into TurnUp portal successfully
	When I navigate to time and material page
	When I create a new time record
	Then the record should be created successfully
