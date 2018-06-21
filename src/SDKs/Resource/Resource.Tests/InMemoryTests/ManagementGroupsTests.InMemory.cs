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
					'id': '/providers/Microsoft.Management/managementGroups/20000000-0001-0000-0000-000000000000',
					'type': '/providers/Microsoft.Management/managementGroups',
					'name': '20000000-0001-0000-0000-000000000000',
					'properties': {
						'tenantId': '20000000-0000-0000-0000-000000000000',
						'displayName': 'Enrollment 1, under Tenant 1',
						'details': {
							'version': 1,
							'updatedTime': '2017-01-01T00:00:00.00Z',
							'updatedBy': 'Test',
							'parent': {
                                'parentId': '/providers/Microsoft.Management/managementGroups/10000000-e001-0000-0000-000000000000',
                                'displayName': 'Enrollment 1, under Tenant 1'
                            },
							'managementGroupType': 'Department'
						}
					}
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetManagementGroupsApiClient(handler);

            string groupId = "20000000-0001-0000-0000-000000000000";

            var getManagementGroupsResult = client.ManagementGroups.Get(groupId);

            Assert.Equal("/providers/Microsoft.Management/managementGroups/20000000-0001-0000-0000-000000000000", getManagementGroupsResult.Id);
            Assert.Equal("/providers/Microsoft.Management/managementGroups", getManagementGroupsResult.Type);
            Assert.Equal("20000000-0001-0000-0000-000000000000", getManagementGroupsResult.Name.ToString());
            Assert.Equal("20000000-0000-0000-0000-000000000000", getManagementGroupsResult.TenantId.ToString());
            Assert.Equal("Enrollment 1, under Tenant 1", getManagementGroupsResult.DisplayName);
            Assert.Equal(1, getManagementGroupsResult.Details.Version);
            Assert.Equal("Test", getManagementGroupsResult.Details.UpdatedBy);
            Assert.Equal("Department", getManagementGroupsResult.Details.ManagementGroupType);

        }
    }
}
