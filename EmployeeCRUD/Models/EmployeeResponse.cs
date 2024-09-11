using Newtonsoft.Json;

namespace EmployeeCRUD.Models
{
    public class EmployeeResponse
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("BaseSalary")]
        public long BaseSalary { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}


