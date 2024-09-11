using EmployeeCRUD.Models;

namespace EmployeeCRUD.Extensions
{
    public static class DataSharingExtension
    {
        private const string APIUniqueId = "APIUniqueId";
        private const string BaseSalary = "BaseSalary";
        private const string EmployeeId = "EmployeeId";
        private const string FirstName = "FirstName";
        private const string Department = "Department";
        private const string StartDate = "StartDate";
        private const string EmailId = "EmailId";
        private const string Mobile = "Mobile";
        private const string ResponseStatusCode = "ResponseStatusCode";
        private const string ResponseContent = "ResponseContent";
        private const string Employee = "Employee";
        private const string EmployeesResponseContent = "EmployeesResponseContent";
        private const string EmployeesList = "EmployeesList";


        public static void SetAPIUniqueId(this ScenarioContext scenarioContext, string value) => scenarioContext[APIUniqueId] = value;
        public static string GetAPIUniqueId(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(APIUniqueId);
        public static void SetBaseSalary(this ScenarioContext scenarioContext, long value) => scenarioContext[BaseSalary] = value;
        public static long GetBaseSalary(this ScenarioContext scenarioContext) => scenarioContext.Get<long>(BaseSalary);

        public static void SetEmployeeId(this ScenarioContext scenarioContext, string value) => scenarioContext[EmployeeId] = value;
        public static string GetEmployeeId(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(EmployeeId);
        public static void SetDepartment(this ScenarioContext scenarioContext, string value) => scenarioContext[Department] = value;
        public static string GetDepartment(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(Department);
        public static void SetFirstName(this ScenarioContext scenarioContext, string value) => scenarioContext[FirstName] = value;
        public static string GetFirstName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(FirstName);
        public static void SetStartDate(this ScenarioContext scenarioContext, string value) => scenarioContext[StartDate] = value;
        public static string GetStartDate(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(StartDate);
        public static void SetEmailId(this ScenarioContext scenarioContext, string value) => scenarioContext[EmailId] = value;
        public static string GetEmailId(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(EmailId);
        public static void SetMobile(this ScenarioContext scenarioContext, string value) => scenarioContext[Mobile] = value;
        public static string GetMobile(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(Mobile);
        public static void SetEmployee(this ScenarioContext scenarioContext, Employee value) => scenarioContext[Employee] = value;
        public static Employee GetEmployee(this ScenarioContext scenarioContext)
        {
            if (scenarioContext.TryGetValue<Employee>(Employee, out Employee value))
                return value;
            return new Employee();
        }
        public static void SetResponseStatusCode(this ScenarioContext scenarioContext, System.Net.HttpStatusCode value) => scenarioContext[ResponseStatusCode] = value;
        public static System.Net.HttpStatusCode GetResponseStatusCode(this ScenarioContext scenarioContext) => scenarioContext.Get<System.Net.HttpStatusCode>(ResponseStatusCode);
        public static void SetResponseContent(this ScenarioContext scenarioContext, EmployeeResponse value) => scenarioContext[ResponseContent] = value;
        public static EmployeeResponse GetResponseContent(this ScenarioContext scenarioContext) => scenarioContext.Get<EmployeeResponse>(ResponseContent);
        
        public static void SetEmployeesResponseContent(this ScenarioContext scenarioContext, List<EmployeeResponse> value) => scenarioContext[EmployeesResponseContent] = value;
        public static List<EmployeeResponse> GetEmployeesResponseContent(this ScenarioContext scenarioContext) => scenarioContext.Get<List<EmployeeResponse>>(EmployeesResponseContent);
        public static void SetBulkEmployeesList(this ScenarioContext scenarioContext, List<Employee> value) => scenarioContext[EmployeesList] = value;
        public static List<Employee> GetBulkEmployeesList(this ScenarioContext scenarioContext) => scenarioContext.Get<List<Employee>>(EmployeesList);
    }
}
