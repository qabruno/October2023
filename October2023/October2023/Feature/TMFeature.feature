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

Scenario Outline: edit existing time record
	Given I logged into TurnUp portal successfully
	When I navigate to time and material page
	When I update the '<Code>', '<Description>' and '<Price>' of an existing time record
	Then the record should have an updated '<Code>', '<Description>' and '<Price>'

	Examples:
	| Code   | Description  | Price |
	| ABC    | November2023 | 15    |
	| 123    | Bottle       | 1500  |
	| *(&(&) | Laptop       | 145   |
