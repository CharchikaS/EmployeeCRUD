using Newtonsoft.Json;
using RestSharp;

namespace EmployeeCRUD.Helpers
{
    public class APIRequestDriver
    {
        public RestClient _client;
        public string _baseUrl = "https://crudcrud.com/";        
        public RestRequest _request;

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(_baseUrl, endpoint);
            _client = new RestClient(url);
            return _client;
        }

        public RestRequest CreateGETRequest()
        {
            _request = new RestRequest(Method.GET);
            _request.AddHeader("Accept", "application/json");
            return _request;
        }

        public RestRequest CreatePOSTRequest(dynamic requestBody)
        {
            _request = new RestRequest(Method.POST);
            _request.AddHeader("Accept", "application/json");
            _request.AddParameter("application/json", requestBody, ParameterType.RequestBody);            
            return _request;
        }
        public RestRequest CreatePUTRequest(dynamic requestBody)
        {
            _request = new RestRequest(Method.PUT);
            _request.AddHeader("Accept", "application/json");
            _request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return _request;
        }

        public RestRequest CreateDELETERequest(dynamic requestBody)
        {
            _request = new RestRequest(Method.DELETE);
            _request.AddHeader("Accept", "application/json");
            _request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return _request;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }
        
        public Models GetResponseContent<Models>(IRestResponse response)
        {
            var content = response.Content;
            Models responseContent = JsonConvert.DeserializeObject<Models>(content);
            return responseContent;
        } 
    }
}
