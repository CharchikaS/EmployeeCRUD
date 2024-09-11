using Newtonsoft.Json;
using NUnit.Framework;
using EmployeeCRUD.Helpers;
using EmployeeCRUD.Models;
using RestSharp;

namespace EmployeeCRUD.Extensions
{
    public static class EmployeeExtension
    {
        public static Employee AddFirstName(this Employee employee, string firstname)
        {
            employee.FirstName = firstname;
            return employee;
        }
        public static Employee AddDepartment(this Employee employee, string department)
        {
            employee.Department = department;
            return employee;
        }
        public static Employee AddStartDate(this Employee employee, string startDate)
        {
            employee.StartDate = DateTime.Parse(startDate);
            return employee;
        }
        public static Employee AddEmail(this Employee employee, string email)
        {
            employee.Email = email;
            return employee;
        }
        public static Employee AddMobile(this Employee employee, string mobile)
        {
            employee.Mobile = mobile;
            return employee;
        }
        public static Employee AddBaseSalary(this Employee employee, long baseSalary)
        {
            employee.BaseSalary= baseSalary;
            return employee;
        }
        public static Employee InitializeNewemployee(this Employee employee)
        {
            employee.FirstName = "DefaultName";
            employee.Department = "Automation";
            employee.StartDate = System.DateTime.Now;
            employee.Email = "email@gmail.com";
            employee.Mobile = TestContext.CurrentContext.Random.GetString();
            employee.BaseSalary = 150000;
            return employee;
        }
        public static IRestResponse SendEmployeeCreationRequest(this Employee newEmployee, string apiId)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("api/" + apiId + "/Employee");
            var jsonRequestBody = JsonConvert.SerializeObject(newEmployee, Formatting.Indented);
            Console.WriteLine(jsonRequestBody);
            var request = driver.CreatePOSTRequest(jsonRequestBody);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Employee Creation response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendGetEmployeeDetailsRequest(this Employee employee,string empId, string apiId)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("api/" + apiId + "/Employee/{empId}");
            var request = driver.CreateGETRequest();
            Console.WriteLine("empId:" + empId);
            request.AddUrlSegment("empId", empId);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Get Employee response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendUpdateEmployeeDetailsRequest(this Employee employee, string empId, string apiId)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("api/" + apiId + "/Employee/{empId}");
            var jsonRequestBody = JsonConvert.SerializeObject(employee);
            var request = driver.CreatePUTRequest(jsonRequestBody);
            request.AddUrlSegment("empId", empId);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Update Employee response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendDeleteEmployeeRequest(this Employee employee, string empId, string apiId)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("api/" + apiId + "/Employee/{empId}");
            var jsonRequestBody = JsonConvert.SerializeObject(employee);
            var request = driver.CreateDELETERequest(jsonRequestBody);
            request.AddUrlSegment("empId", empId);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Delete Employee response code: {response.StatusCode}");
            return response;
        }       
    }
}
