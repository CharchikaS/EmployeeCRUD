@ignore
Feature: Book Store Application

This feature file contains the feature wise Test scenarios for Book Store Application

#Feature - Login
Scenario: Create New User Account
	Given I am a new User of Book Store
	When I navigate to Login page
	And I click on NewUser Button
	Then I should navigate to registeration page
	When I provide all the required valid inputs
	And click to verify captcha
	And click on Register button
    Then the account should be created successfully
    And I should see a confirmation message

Scenario: Successful Login for registered user
	Given I am a registered user of Book Store
	When I try to login with my valid credentials	
    Then I should be logged in successfully
	And land on profile page

Scenario: Restrict Login for the anonymous user
	Given I am an anonymous user of Book Store
	When I try to login
	Then I should receive an access denied message

#Field Level test cases to validate error messages
Scenario: Error for missing captcha 
	Given I am a new User of Book Store
	When I navigate to Login page
	And I click on NewUser Button
	Then I should navigate to registeration page
	When I provide all the required valid inputs
	And click on Register button
    Then I should see an error message for missing captcha input

Scenario: Error for missing password 
	Given I am a new User of Book Store
	When I navigate to Login page
	And I click on NewUser Button
	Then I should navigate to registeration page
	When I provide all the required valid inputs except password
	And click on Register button
    Then I should see red border for the field password

# similar error validation test cases for verifying - password (length wise, required chars), firstname, lastname & username
Scenario: Password validations - like length wise, required chars
Scenario: firstname and lastname validation - like missing input should show red border
Scenario: username validation - like missing input should show red border

#Feature - Profile
Scenario: search for a book
	Given I am a registered user of Book Store
	When I try to login with my valid credentials	
    Then I should be logged in successfully
	And land on profile page
	Then UserName displayed on the page should be mine
	When I search for book Git Pocket Guide 
	And this book exists in my profile
	Then I should be able to find it
	When I click on the title of the book
	Then I should navigate to details page
	And be able to see the details about the book

Scenario: Delete all Books successfully in a profile - if no books available to delete it should fail
Scenario: Error in deletion of books in a profile - when no books are available 
Scenario: Delete Account successfully
Scenario: Navigate to Book Store
Scenario: Log out


#Feature - Book Store
Scenario: Book list display
	Given I am Logged in successfully
	When I click on the Book Store on the side panel
	Then I should navigate successfully to page books
	And UserName displayed on the page should be mine
	And I should see list of books available
	And the each book entry should display its image title author and publisher

Scenario: navigate to book details page by clicking on the book title link
Scenario: validation of drop down for the display of number of rows - like when its 5 rows , no. of books displayed should be <=5
Scenario: successful navigation to next page by using button Next
Scenario: successful navigation to previous page by using button Previous
Scenario: validation of Page number text field - like should not allow to enter a number > the total number of available pages displayed
Scenario: validation of Page number text field - like should not allow to enter a number < 1
Scenario: Search a book - like should display book(s) that exactly match the search text