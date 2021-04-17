using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Assignment.Services
{
    public class NetworkCalls
    {
        public NetworkCalls()
        {
        }

        public string Login(string emailAddress, string password)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"email_address\" : \""+emailAddress+"\",\n    \"password\" : \""+password+"\"\n}", ParameterType.RequestBody);
            Console.WriteLine(request);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                JObject joResponse = JObject.Parse(response.Content);
                JObject ojObject = (JObject)joResponse;
                string token = (string)ojObject["token"];
                return token;
            }
            catch
            {
                return "null";
            }
        }

        public string saveUserPreferences(string token, string emailAddress, string selectedGenres)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/user-preferences");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"email_address\": \""+emailAddress+"\",\"preferences\": [" + selectedGenres + "]}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.StatusCode.ToString();
            }
            catch
            {
                return "null";
            }
        }
    }
}
