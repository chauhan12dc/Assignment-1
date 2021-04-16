using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Data_Binding.Services
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
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            JObject joResponse = JObject.Parse(response.Content);
            JObject ojObject = (JObject)joResponse;
            string token = (string)ojObject["token"];
            return token;
        }
    }
}
