Feature: BuyProduct

A short summary of the feature

@EndToEnd
Scenario Outline: Searching and Buying a product
	Given User is on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
	Then The heading should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page is loaded
	When User selects '<size>' and clicks on Add to Cart Button
	Then The product should be present inside the cart
	When User clicks on Proceed to buy button
	Then The login modal should display
Examples:
	| searchtext | productno | size |
	| Sandals    | 2         | 1    |
         