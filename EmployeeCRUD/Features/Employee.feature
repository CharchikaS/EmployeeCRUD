Feature: Employee

This feature covers Create Update and Delete actions for the resource "Employee"
Background: 
	Given I have the unique id for my API url

@tag1
Scenario: Create and update New Employee record
	When I request creation of a new employee with base salary <BaseSalary>
	And with firstname <Firstname> and department <Department>
	And with email id <EmailId>
	And with start date <StartDate>
	And with Mobile <Mobile>
	And I send the employee Creation request
	Then this new employee record should be created successfully
	And the response should contain a unique id for this employee
	When I update email id for this employee to <UpdatedEmailId>
	And I fetch the details of this employee
	Then the response should contain updated email id as <UpdatedEmailId> and in the correct format

	Examples: 
	    | Firstname  | Department | EmailId       | StartDate  | Mobile     | BaseSalary | UpdatedEmailId  |
	    | Charchika  | Tech Head  | csp@gmail.com | 1996-03-23 | 0412366875 | 200000     | test1           |
	    | Charchika1 | CEO        | csp@gmail.com | 1992-01-01 | 0412366875 | 500000     | test2@gmail.com |

Scenario: Delete Employee
	When I send the delete request
	Then this Employee should be deleted successfully


#Scenario: Get Employee details with incorrect id
#	When I send the get request with non existent employee id
#	Then I should receive a employee not found error

#
#Scenario: Create New Employee records in bulk using List
#	When I request creation of new Employee(s)
#	And I send the Employee Creation request
#	Then these new Employee accounts should be created successfully

#Scenario: Get all Employees details
#	When I send the get request
#	Then I should get all the details of all the Employees
#
 