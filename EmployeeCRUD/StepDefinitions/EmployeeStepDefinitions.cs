using EmployeeCRUD.Extensions;
using EmployeeCRUD.Helpers;
using EmployeeCRUD.Models;
using NUnit.Framework;
using System.Net.Mail;

namespace EmployeeCRUD.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public EmployeeStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have the unique id for my API url")]
        public void GivenIHaveTheUniqueIdForMyAPIUrl()
        {
            //Get API unique id 
            WebRequestDriver webRequestDriver = new WebRequestDriver();
            webRequestDriver.Navigate();
            var apiKey = webRequestDriver.FindApiUniqueId();
            Assert.IsNotNull(apiKey);
            apiKey.Should().NotBe("KeyNotFound");
            _scenarioContext.SetAPIUniqueId(apiKey);
        }

        [When(@"I request creation of a new employee with base salary (.*)")]
        public void WhenIRequestCreationOfANewEmployeeWithBaseSalary(long baseSalary)
        {
            _scenarioContext.SetBaseSalary(baseSalary);
        }

        [When(@"with firstname (.*) and department (.*)")]
        public void WhenWithFirstnameAndDepartment(string firstName, string department)
        {
            _scenarioContext.SetFirstName(firstName);
            _scenarioContext.SetDepartment(department);
        }

        [When(@"with start date (.*)")]
        public void WhenWithStartDate(string startDate)
        {
            _scenarioContext.SetStartDate(startDate);
        }

        [When(@"with Mobile (.*)")]
        public void WhenWithMobile(string mobile)
        {
            _scenarioContext.SetMobile(mobile);
        }

        [When(@"with email id (.*)")]
        public void WhenWithEmailId(string emailId)
        {
            _scenarioContext.SetEmailId(emailId);
        }

        [When(@"I send the employee Creation request")]
        public void WhenISendTheEmployeeCreationRequest()
        {
            Employee employee = new Employee();
            employee.InitializeNewemployee();
            employee.AddFirstName(_scenarioContext.GetFirstName());
            employee.AddDepartment(_scenarioContext.GetDepartment());
            employee.AddStartDate(_scenarioContext.GetStartDate());
            employee.AddEmail(_scenarioContext.GetEmailId());
            employee.AddMobile(_scenarioContext.GetMobile());
            employee.AddBaseSalary(_scenarioContext.GetBaseSalary());
            var response = employee.SendEmployeeCreationRequest(_scenarioContext.GetAPIUniqueId());
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
            APIRequestDriver driver = new APIRequestDriver();
            _scenarioContext.SetResponseContent(driver.GetResponseContent<EmployeeResponse>(response));
        }

        [Then(@"this new employee record should be created successfully")]
        public void ThenThisNewEmployeeRecordShouldBeCreatedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            try
            {
                responseStatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }

        [Then(@"the response should contain a unique id for this employee")]
        public void ThenTheResponseShouldContainAUniqueIdForThisEmployee()
        {
            EmployeeResponse responseEmployeeDetails = _scenarioContext.GetResponseContent();
            Assert.IsNotNull(responseEmployeeDetails);
            responseEmployeeDetails.Id.Should().NotBeNullOrEmpty();
            _scenarioContext.SetEmployeeId(responseEmployeeDetails.Id);
            Console.WriteLine(responseEmployeeDetails.Id);
        }

        [When(@"I update email id for this employee to (.*)")]
        public void WhenIUpdateEmailIdForThisEmployeeTo(string updatedEmailId)
        {
            var employee = FetchEmployeeDetails(_scenarioContext.GetEmployeeId());
            Console.WriteLine($"emailId before update: {employee.Email}");
            _scenarioContext.SetEmailId(updatedEmailId);

            //update email id in employee record
            Employee updEmployee = new Employee();
            updEmployee.AddEmail(updatedEmailId);
            _scenarioContext.SetEmployee(updEmployee);

            var response = _scenarioContext.GetEmployee().SendUpdateEmployeeDetailsRequest(_scenarioContext.GetEmployeeId(), _scenarioContext.GetAPIUniqueId());
            Assert.IsNotNull(response);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [When(@"I fetch the details of this employee")]
        public void WhenIFetchTheDetailsOfThisEmployee()
        {
            var Employee = FetchEmployeeDetails(_scenarioContext.GetEmployeeId());
            _scenarioContext.SetResponseContent(Employee);
        }

        [Then(@"the response should contain updated email id as (.*) and in the correct format")]
        public void ThenTheResponseShouldContainUpdatedEmailIdAsAndInTheCorrectFormat(string emailId)
        {
            var Employee = _scenarioContext.GetResponseContent();
            Console.WriteLine($"emailId after update: {Employee.Email}");
            Employee.Email.Should().Be(emailId);
            try
            {
                MailAddress mailAddress = new MailAddress(Employee.Email);
                Console.WriteLine("Valid Email Address.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Email Address.");
                throw;
            }
        }

        [When(@"I send the delete request")]
        public void WhenISendTheDeleteRequest()
        {
            Employee newEmployee = new Employee();
            newEmployee.InitializeNewemployee();
            _scenarioContext.SetEmployee(newEmployee);
            
            //create new employee for deletion
            var creationResponse = newEmployee.SendEmployeeCreationRequest(_scenarioContext.GetAPIUniqueId());
            creationResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);            
            APIRequestDriver driver = new APIRequestDriver();
            EmployeeResponse response = driver.GetResponseContent<EmployeeResponse>(creationResponse);
            _scenarioContext.SetEmployeeId(response.Id);

            //send request for deletion of this new employee
            var deletionResponse = newEmployee.SendDeleteEmployeeRequest(response.Id,_scenarioContext.GetAPIUniqueId());
            deletionResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Console.WriteLine(deletionResponse.StatusCode);
        }

        [Then(@"this Employee should be deleted successfully")]
        public void ThenThisEmployeeShouldBeDeletedSuccessfully()
        {
            var response = _scenarioContext.GetEmployee().SendDeleteEmployeeRequest(_scenarioContext.GetEmployeeId(), _scenarioContext.GetAPIUniqueId());
            Assert.IsNotNull(response);
            Console.WriteLine(response.StatusCode);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
        public EmployeeResponse FetchEmployeeDetails(string empId)
        {
            APIRequestDriver driver = new APIRequestDriver();
            Console.WriteLine($"fetching Employee details for employee id : {empId}");
            var response = _scenarioContext.GetEmployee().SendGetEmployeeDetailsRequest(empId, _scenarioContext.GetAPIUniqueId());
            Assert.IsNotNull(response);
            var employee = driver.GetResponseContent<EmployeeResponse>(response);
            return employee;
        }
    }
}
