using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManager_Test.Base
{
    class Properties
    {
        public static string baseUrl = "";
        public static string testUsername = "Aut_test_user";
        public static string testPassword = "Test_123";

        public static JObject authorizationCredentials = new JObject
            {
                { "username", "Aut_test_user" },
                { "password", "Test_123" },
                { "remember", "true" }
            };

        //API USERS
        public static string users = "/api/Users";
        public static string usersLogin = "/api/Users/Login";
        public static string usersList = "/api/Users/List";
        public static string userByTestID = @"/api/Users/f48e28ee-12e8-42d1-bd5d-295aef7ac06b";


        //API CONTACTS 
        
    }
}
