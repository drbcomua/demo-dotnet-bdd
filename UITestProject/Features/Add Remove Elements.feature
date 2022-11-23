@addRemoveElements @all @suite:UI
Feature: Add Remove Elements
	Tests demonstrate features of dynamic UI interaction

Scenario: Add button
	Given I opened Add Remove Elements Page
	When I click Add Elements button
	Then New Delete button appears on page

Scenario: Delete button
	Given I opened Add Remove Elements Page
	And I click Add Elements button
	When I click on Delete button
	Then Delete button disappears