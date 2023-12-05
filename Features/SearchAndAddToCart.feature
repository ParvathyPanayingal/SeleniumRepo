Feature: SearchAndAddToCart

A short summary of the feature

@E2E-Search_And_Add_To_Cart
Scenario Outline: Search for products
	Given User will be on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext |
	| water      |