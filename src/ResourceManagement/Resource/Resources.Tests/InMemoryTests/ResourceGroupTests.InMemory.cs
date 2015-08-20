//
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

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceGroupTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new ResourceManagementClient(token).WithHandler(handler);
        }
        
        [Fact]
        public void ResourceGroupCreateOrUpdateValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.CreateOrUpdate("foo", new ResourceGroup
            {
                Location = "WestEurope",
                Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
            });

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("WestEurope", json["location"].Value<string>());
            Assert.Equal("finance", json["tags"]["department"].Value<string>());
            Assert.Equal("tagvalue", json["tags"]["tagname"].Value<string>());

            // Validate response
            Assert.Equal("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.ResourceGroup.Id);
            Assert.Equal("Succeeded", result.ResourceGroup.ProvisioningState);
            Assert.Equal("foo", result.ResourceGroup.Name);
            Assert.Equal("finance", result.ResourceGroup.Tags["department"]);
            Assert.Equal("tagvalue", result.ResourceGroup.Tags["tagname"]);
            Assert.Equal("WestEurope", result.ResourceGroup.Location);
        }

        [Fact]
        public void ResourceGroupCreateOrUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.CreateOrUpdate(null,  new ResourceGroup()));
            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.CreateOrUpdate("foo",  null));
        }

        [Fact]
        public void ResourceGroupExistsReturnsTrue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.NoContent };

            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.CheckExistence("foo");

             // Validate payload
            Assert.Empty(handler.Request);

            // Validate response
            Assert.True(result.Exists);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void ResourceGroupExistsReturnsFalse()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.NotFound };

            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.CheckExistence(Guid.NewGuid().ToString());

            // Validate payload
            Assert.Empty(handler.Request);

            // Validate response
            Assert.False(result.Exists);
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void ResourceGroupExistsThrowsException()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.BadRequest };

            var client = GetResourceManagementClient(handler);

            Assert.Throws<CloudException>(() => client.ResourceGroups.CheckExistence("foo"));
        }

        [Fact]
        public void ResourceGroupPatchValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'subscriptionId': '123456',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'properties': {
                        'provisioningState': 'Succeeded'
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);


            var result = client.ResourceGroups.Patch("foo", new ResourceGroup
            {
                Location = "WestEurope",
            });

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal("patch", handler.Method.Method.Trim().ToLower());
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("WestEurope", json["location"].Value<string>());

            // Validate response
            Assert.Equal("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.ResourceGroup.Id);
            Assert.Equal("Succeeded", result.ResourceGroup.ProvisioningState);
            Assert.Equal("foo", result.ResourceGroup.Name);
            Assert.Equal("WestEurope", result.ResourceGroup.Location);
        }

        [Fact]
        public void ResourceGroupUpdateStateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.Patch(null, new ResourceGroup()));
            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.Patch("foo", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.ResourceGroups.Patch("~`123", new ResourceGroup()));
        }

        [Fact]
        public void ResourceGroupGetValidateMessage()
        { 
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'properties': {
                        'provisioningState': 'Succeeded'
                     }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            ResourceGroupGetResult result = client.ResourceGroups.Get("foo");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.ResourceGroup.Id);
            Assert.Equal("WestEurope", result.ResourceGroup.Location);
            Assert.Equal("foo", result.ResourceGroup.Name);
            Assert.Equal("Succeeded", result.ResourceGroup.ProvisioningState);
            Assert.True(result.ResourceGroup.Properties.Contains("provisioningState"));
        }

        [Fact]
        public void ResourceGroupNameAcceptsAllAllowableCharacters()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'properties': {
                        'provisioningState': 'Succeeded'
                     }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            client.ResourceGroups.Get("foo-123_bar");
        }

        [Fact]
        public void ResourceGroupGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.Get(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.ResourceGroups.Get("~`123"));
        }

        [Fact]
        public void ResourceGroupListAllValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 
                'value': [{ 
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'myresourcegroup1',
                    'location': 'westus',
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                    }, 
                    { 
                    'id': '/subscriptions/abc123/resourcegroups/fdfdsdsf',
                    'name': 'myresourcegroup2',
                    'location': 'eastus', 
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                    } 
                ], 
                'nextLink': 'https://wa/subscriptions/subId/resourcegroups?api-version=1.0&$skiptoken=662idk',
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(2, result.ResourceGroups.Count);
            Assert.Equal("myresourcegroup1", result.ResourceGroups[0].Name);
            Assert.Equal("Succeeded", result.ResourceGroups[0].ProvisioningState);
            Assert.Equal("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.ResourceGroups[0].Id);
            Assert.Equal("https://wa/subscriptions/subId/resourcegroups?api-version=1.0&$skiptoken=662idk", result.NextLink.ToString());
        }

        [Fact]
        public void ResourceGroupListAllWorksForEmptyLists()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{'value': []}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(0, result.ResourceGroups.Count);
        }

        [Fact]
        public void ResourceDeploymentGetDeleteOperationStatusValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            response.Headers.Add("Location", "http://foo");

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.OK
            };

            var client = GetResourceManagementClient(handler);

            var result = client.GetLongRunningOperationStatus("http://test");

            // Validate headers
            Assert.Equal(HttpStatusCode.Accepted, result.StatusCode);
            Assert.Equal(OperationStatus.InProgress, result.Status);

            result = client.GetLongRunningOperationStatus("http://test");

            // Validate headers
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(OperationStatus.Succeeded, result.Status);
        }

        [Fact]
        public void ResourceGroupListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 
                'value': [{ 
                    'name': 'myresourcegroup1',
                    'location': 'westus', 
                    'locked': 'true'
                    }, 
                    { 
                    'name': 'myresourcegroup2',
                    'location': 'eastus', 
                    'locked': 'false' 
                    } 
                ], 
                'nextLink': 'https://wa/subscriptions/subId/resourcegroups?api-version=1.0&$skiptoken=662idk',
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.ResourceGroups.List(new ResourceGroupListParameters
                {
                    Top = 5,
                });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.True(handler.Uri.ToString().Contains("$top=5"));

            // Validate result
            Assert.Equal(2, result.ResourceGroups.Count);
            Assert.Equal("myresourcegroup1", result.ResourceGroups[0].Name);
            Assert.Equal("https://wa/subscriptions/subId/resourcegroups?api-version=1.0&$skiptoken=662idk", result.NextLink.ToString());
        }

        [Fact]
        public void ResourceGroupDeleteValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            response.Headers.Add("Location", "http://foo");

            var handler = new RecordedDelegatingHandler(response)
                {
                    StatusCodeToReturn = HttpStatusCode.Accepted,
                    SubsequentStatusCodeToReturn = HttpStatusCode.OK
                };
            var client = GetResourceManagementClient(handler);


            var result = client.ResourceGroups.Delete("foo");

            // Validate headers
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void ResourceGroupDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.ResourceGroups.Delete(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.ResourceGroups.Delete("~`123"));
        }
    }
}
