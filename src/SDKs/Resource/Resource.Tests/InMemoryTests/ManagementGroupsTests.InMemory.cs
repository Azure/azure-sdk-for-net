using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using ResourceGroups.Tests;
using Xunit;

namespace Resource.Tests.InMemoryTests
{
    public class InMemoryManagementGroupsTests
    {

        public ManagementGroupsAPIClient GetManagementGroupsApiClient(RecordedDelegatingHandler handler)
        {
            var groupId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(groupId, "abc123");
            handler.IsPassThrough = false;
            var client = new ManagementGroupsAPIClient(token, handler);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            return client;
        }

        [Fact]
        public void ListGroups()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [{
                        'id': '/providers/Microsoft.Management/managementGroups/10000000-d002-0000-0000-000000000000',
                        'type': '/providers/Microsoft.Management/managementGroups',
                        'name': '10000000-d002-0000-0000-000000000000',
                        'properties': {
                            'tenantId': '10000000-0000-0000-0000-000000000000',
                            'displayName': 'Department 2 under Enrollment 1'
                            }
                       },
                       {
                        'id': '/providers/Microsoft.Management/managementGroups/10000000-a001-0000-0000-000000000000',
                        'type': '/providers/Microsoft.Management/managementGroups',
                        'name': '10000000-a001-0000-0000-000000000000',
                        'properties': {
                            'tenantId': '10000000-0000-0000-0000-000000000000',
                            'displayName': 'Account 1, under Department 1'
                         }
                       }]
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetManagementGroupsApiClient(handler);

            var listManagementGroupsResult = client.ManagementGroups.List();

            Assert.Equal("/providers/Microsoft.Management/managementGroups/10000000-d002-0000-0000-000000000000", listManagementGroupsResult.FirstOrDefault().Id);
            Assert.Equal("/providers/Microsoft.Management/managementGroups", listManagementGroupsResult.FirstOrDefault().Type);
            Assert.Equal("10000000-d002-0000-0000-000000000000", listManagementGroupsResult.FirstOrDefault().Name.ToString());
            Assert.Equal("10000000-0000-0000-0000-000000000000", listManagementGroupsResult.FirstOrDefault().TenantId.ToString());
            Assert.Equal("Department 2 under Enrollment 1", listManagementGroupsResult.FirstOrDefault().DisplayName);
        }

        [Fact]
        public void GetGroup()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
              ""id"": ""/providers/Microsoft.Management/managementGroups/testGroup123"",
              ""type"": ""/providers/Microsoft.Management/managementGroups"",
              ""name"": ""testGroup123"",
              ""properties"": {
                ""tenantId"": ""20000000-0000-0000-0000-000000000000"",
                ""displayName"": ""TestGroup123"",
                ""details"": {
                  ""version"": 1,
                  ""updatedTime"": ""2018-01-30T08:32:23.6425327Z"",
                  ""updatedBy"": ""20000000-0000-0000-0000-000000000000"",
                  ""parent"": {
                    ""parentId"": ""/providers/Microsoft.Management/managementGroups/testGroup1234"",
                    ""displayName"": ""TestGroup1234""
                  }
                }
              }
            }")
            };
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetManagementGroupsApiClient(handler);

            var groupId = "testGroup123Child1";

            var getManagementGroupResult = client.ManagementGroups.Get(groupId);

            Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123", getManagementGroupResult.Id);
            Assert.Equal("/providers/Microsoft.Management/managementGroups", getManagementGroupResult.Type);
            Assert.Equal("testGroup123", getManagementGroupResult.Name.ToString());
            Assert.Equal("20000000-0000-0000-0000-000000000000", getManagementGroupResult.TenantId.ToString());
            Assert.Equal("TestGroup123", getManagementGroupResult.DisplayName);
            Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup1234", getManagementGroupResult.Details.Parent.ParentId);
            Assert.Equal("TestGroup1234", getManagementGroupResult.Details.Parent.DisplayName);
        }


        [Fact]
        public void GetGroupWithExpand()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
              ""id"": ""/providers/Microsoft.Management/managementGroups/testGroup123"",
              ""type"": ""/providers/Microsoft.Management/managementGroups"",
              ""name"": ""testGroup123"",
              ""properties"": {
                ""tenantId"": ""20000000-0000-0000-0000-000000000000"",
                ""displayName"": ""TestGroup123"",
                ""details"": {
                  ""version"": 1,
                  ""updatedTime"": ""2018-01-30T08:32:23.6425327Z"",
                  ""updatedBy"": ""20000000-0000-0000-0000-000000000000"",
                  ""parent"": {
                    ""parentId"": ""/providers/Microsoft.Management/managementGroups/testGroup1234"",
                    ""displayName"": ""TestGroup1234""
                  }
                },
               ""children"": [
                  {
                    ""childType"": ""/managementGroup"",
                    ""childId"": ""/providers/Microsoft.Management/managementGroups/testGroup123Child1"",
                    ""displayName"": ""TestGroup123Child1""
                  }
                ]
                }
            }")
            };
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetManagementGroupsApiClient(handler);

            var groupId = "testGroup123Child1";

            var getManagementGroupResult = client.ManagementGroups.Get(groupId, "children");

            Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123", getManagementGroupResult.Id);
            Assert.Equal("/providers/Microsoft.Management/managementGroups", getManagementGroupResult.Type);
            Assert.Equal("testGroup123", getManagementGroupResult.Name.ToString());
            Assert.Equal("20000000-0000-0000-0000-000000000000", getManagementGroupResult.TenantId.ToString());
            Assert.Equal("TestGroup123", getManagementGroupResult.DisplayName);
            Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup1234", getManagementGroupResult.Details.Parent.ParentId);
            Assert.Equal("TestGroup1234", getManagementGroupResult.Details.Parent.DisplayName);
            Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123Child1", getManagementGroupResult.Children.FirstOrDefault().ChildId);
            Assert.Equal("TestGroup123Child1", getManagementGroupResult.Children.FirstOrDefault().DisplayName);
        }
    }
}

