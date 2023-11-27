Feature: GoogleSearch

To perform search operation on google home page
@tag1
Scenario: To perform search with Google search button
	Given Google home page should be loaded
	When Type "hp laptop" in the search input box
	And Click on the google search button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"
