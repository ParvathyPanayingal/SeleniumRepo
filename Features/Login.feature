Feature: Login
User logs in with valid credentials (username,password)
The home page will load after successful login


Scenario: login with valid credentials
	Given User will be on the login page
	When User will enter username
	And User will enter password
	And User will click on login button
	Then User will be redirected to home page
	
Scenario: login with Invalid credentials
	Given User will be on the login page
	When User will enter username
	And User will enter password
	And User will click on login button
	Then Error message for password length will be thrown