﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authorization.Tests
{
    internal class GraphManagementClient : ServiceClient<GraphManagementClient>
    {
        private const string DefaultUserDomain = "@aad191.ccsctp.net";

        private const string DefaultTenantId = "e80a6e61-8b40-4a0b-9c90-fdc4db897423";
        
        private const string GraphApiVersion = "1.42-previewInternal";

        private const string GraphUriFormatter = @"{0}{1}/{2}?api-version={3}";

        private const string GraphUsersSuffix = "users";

        private const string GraphGroupsSuffix = "groups";

        private const string CreateUserJsonFormatter = @"{0}
    ""accountEnabled"": true,
    ""displayName"": ""{2}"",
    ""mailNickname"": ""{2}"",
    ""passwordProfile"": {0} ""password"" : ""Test1234"", ""forceChangePasswordNextLogin"": false {1},
    ""userPrincipalName"": ""{2}{3}""
{1}";

    private const string CreateGroupJsonFormatter = @"{0}
  ""displayName"":""{2}"",
  ""mailNickname"":""{2}"",
  ""mailEnabled"":false,
  ""securityEnabled"":true
{1}";
        private TestEnvironment testEnvironment;

        public string UserDomain { get; private set; }

        public GraphManagementClient(TestEnvironment testEnv)
            : base()
        {
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);

            if (testEnv == null)
            {
                throw new Exception("Test Environment should be set properly. It cannot be null.");
            }

            this.testEnvironment = testEnv;
            if (testEnv.AuthorizationContext != null)
            {
                var atIndex = this.testEnvironment.AuthorizationContext.UserId.IndexOf("@");

                if (atIndex != -1 &&
                    atIndex != this.testEnvironment.AuthorizationContext.UserId.Length - 1)
                {
                    this.UserDomain = this.testEnvironment.AuthorizationContext.UserId.Substring(atIndex);
                }
            }
            else
            {
                this.UserDomain = GraphManagementClient.DefaultUserDomain;
            }
        }  
        

        public override GraphManagementClient WithHandler(DelegatingHandler handler)
        {
            return (GraphManagementClient)WithHandler(new GraphManagementClient(this.testEnvironment), handler);
        }

        public Guid CreateUser(string userName)
        {
            var createBody = string.Format(
                GraphManagementClient.CreateUserJsonFormatter, 
                "{",
                "}",
                userName,
                this.UserDomain);

            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphUsersSuffix),
                    HttpMethod.Post,
                    createBody);

            var response = this.CallServerSync(request);

            return Guid.Parse(DeserializeJsonResponse(response)["objectId"].ToString());
        }

        public void DeleteUser(Guid userPrincipalName)
        {
            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphUsersSuffix + "/" + userPrincipalName),
                    HttpMethod.Delete,
                    null);

            var response = this.CallServerSync(request);
        }

        public IEnumerable<Guid> ListUsers(string userNameFilter = null)
        {
            var returnValue = new List<Guid>();
            
            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphUsersSuffix),
                    HttpMethod.Get,
                    null);

            var response = this.CallServerSync(request);
            
            var responseBody = DeserializeJsonResponse(response);

            var values = responseBody["value"];
            if (values is IEnumerable<object>)
            {
                foreach (JToken value in values as IEnumerable<object>)
                {
                    if (!string.IsNullOrEmpty(userNameFilter) &&
                       !value["displayName"].ToString().Contains(userNameFilter))
                    {
                        // if filter was passed in and returned object does not contain filter value skip it
                        continue;
                    }

                    returnValue.Add(Guid.Parse(value["objectId"].ToString()));
                }
            }

            return returnValue;
        }
        
        public string CreateGroup(string groupName)
        {
            var createBody = string.Format(
                GraphManagementClient.CreateGroupJsonFormatter,
                "{",
                "}",
                groupName);

            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphGroupsSuffix),
                    HttpMethod.Post,
                    createBody);

            var response = this.CallServerSync(request);

            return DeserializeJsonResponse(response)["objectId"].ToString();
        }

        public void DeleteGroup(string groupName)
        {
            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphGroupsSuffix + "/" + groupName),
                    HttpMethod.Delete,
                    null);

            var response = this.CallServerSync(request);
        }
        
        public IEnumerable<string> ListGroups(string groupNameFilter = null)
        {
            var returnValue = new List<string>();

            var request = this.CreateRequest(
                    this.GetGraphUriString(GraphManagementClient.GraphGroupsSuffix),
                    HttpMethod.Get,
                    null);

            var response = this.CallServerSync(request);

            var responseBody = DeserializeJsonResponse(response);

            var values = responseBody["value"];
            if (values is IEnumerable<object>)
            {
                foreach (JToken value in values as IEnumerable<object>)
                {
                    if (!string.IsNullOrEmpty(groupNameFilter) &&
                       !value["displayName"].ToString().Contains(groupNameFilter))
                    {
                        // if filter was passed in and returned object does not contain filter value skip it
                        continue;
                    }

                    returnValue.Add(value["objectId"].ToString());
                }
            }

            return returnValue;
        }

        private string GetGraphUriString(string suffix)
        {
            return string.Format(
                GraphUriFormatter,
                this.testEnvironment.Endpoints.GraphUri.ToString(),
                this.testEnvironment.AuthorizationContext == null ?
                GraphManagementClient.DefaultTenantId :
                    this.testEnvironment.AuthorizationContext.TenatId,
                suffix,
                GraphManagementClient.GraphApiVersion);
        }

        private HttpRequestMessage CreateRequest(string uri, HttpMethod method, string body)
        {
            var httpRequest = new HttpRequestMessage(method, uri);
            
            // Set Headers
            httpRequest.Headers.Add("x-ms-version", GraphManagementClient.GraphApiVersion);
            httpRequest.Headers.Add("Accept", "application/json;odata=minimalmetadata");


            if (this.testEnvironment.AuthorizationContext != null)
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue(
                                                this.testEnvironment.AuthorizationContext.AccessTokenType,
                                                this.testEnvironment.AuthorizationContext.AccessToken);
            }

            if(body != null)
            {
                httpRequest.Content = new StringContent(body, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpRequest;
        }

        private string CallServerSync(HttpRequestMessage request)
        {
            var httpResponse = Task.Factory.StartNew(
                                    (object s) =>
                                        {
                                            return ((HttpClient)s).SendAsync(request);
                                        }, 
                                    this.HttpClient, 
                                    CancellationToken.None, 
                                    TaskCreationOptions.None, 
                                    TaskScheduler.Default)
                                .Unwrap().GetAwaiter().GetResult();

            if (httpResponse.Content == null)
            {
                return null;
            }

            return httpResponse.Content.ReadAsStringAsync().Result;
        }

        private Dictionary<string, object> DeserializeJsonResponse(string response)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }
           
    }
}
