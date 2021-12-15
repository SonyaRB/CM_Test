using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using CaseManager_Test.Base;
using System.Net;
using CaseManager_Test._SeleniumTests;

namespace CaseManager_Test
{
    public class UsersTests
    {
        public static RestClient restClient;
        public static string jwt;
        [SetUp]
        public void Setup()
        {
            restClient = BaseMethods.NewRestClient(Properties.baseUrl);
            jwt = BaseMethods.ObtainJWTToken();
        }

        [Test]
        public void Users_GetAllUsers_Successfully()
        {
            RestRequest restRequest = new RestRequest(Properties.users, Method.GET);
            
            //Adding Json Authorization header to the post request
            restRequest.AddHeader("Authorization", "Bearer " + jwt);

            IRestResponse restResponse = restClient.Execute(restRequest);

            //Assert status code is equal to expected 200 OK and not null
            Assert.Multiple(() =>
            {
                Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
                Assert.IsNotNull(restResponse.Content);
            });
        }

        [Test]
        public void Users_GetUsersList_Successfully()
        {
            RestRequest restRequest = new RestRequest(Properties.usersList, Method.GET);
            
            //Adding Json Authorization header to the post request
            restRequest.AddHeader("Authorization", "Bearer " + jwt);

            IRestResponse restResponse = restClient.Execute(restRequest);

            //Assert status code is equal to expected 200 OK and not null
            Assert.Multiple(() =>
            {
                Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
                Assert.IsNotNull(restResponse.Content);
            });
        }

        [Test]
        public void Users_GetUserByID_Successfully()
        {
            RestRequest restRequest = new RestRequest(Properties.userByTestID, Method.GET);

            //Adding Json Authorization header to the post request
            restRequest.AddHeader("Authorization", "Bearer " + jwt);

            IRestResponse restResponse = restClient.Execute(restRequest);
            var response = BaseMethods.DeserializeResponceToString(restResponse);
            var userId = (string)response.id;

            //Assert status code is equal to expected 200 OK and not null
            Assert.Multiple(() =>
            {
                Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
                Assert.AreEqual(userId, "f48e28ee-12e8-42d1-bd5d-295aef7ac06b");
                Assert.IsNotNull(restResponse.Content);
            });
        }

    }
}