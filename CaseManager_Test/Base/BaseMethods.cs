using CaseManager_Test._SeleniumTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test.Base
{
    public static class BaseMethods
    {
        /// <summary>
        /// Create and return new REST client
        /// </summary>
        public static RestClient NewRestClient(string baseUrl)
        {
            RestClient restClient = new RestClient(baseUrl);
            return restClient;
        }
        /// <summary>
        /// Request for obraining JWT authorization token, so it can be requested once and used by multiple requests
        /// </summary>
        public static string ObtainJWTToken()
        {
            RestClient restClient = NewRestClient(Properties.baseUrl);

            RestRequest restRequest = new RestRequest(Properties.usersLogin, Method.POST);

            //Adding Json body as parameter to the post request
            restRequest.AddParameter("application/json", Properties.authorizationCredentials, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);

            var responseContent = JsonConvert.DeserializeObject(restResponse.Content);
            dynamic resp = JObject.Parse(responseContent.ToString());
            var jwt = resp.token;
            return jwt;
        }
        /// <summary>
        /// Deserializing response
        /// </summary>
        /// <param name="restResponse">IRestResponce to be deserialized</param
        public static dynamic DeserializeResponceToString(IRestResponse restResponse)
        {
            var responseContent = JsonConvert.DeserializeObject(restResponse.Content);
            dynamic resp = JObject.Parse(responseContent.ToString());
            return resp;
        }
    }
}
