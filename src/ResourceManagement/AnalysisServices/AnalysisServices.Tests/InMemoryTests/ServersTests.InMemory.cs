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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using AnalysisServices.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace AnalysisServices.Tests.InMemoryTests
{
    public class InMemoryServersTests
    {
        [Fact]
        public void ServerCreateAsyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("InProgress"))
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesResource analysisServicesResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();

            var result = Task.Factory.StartNew(() => client.Servers.CreateAsync(
                analysisServicesResource,
                AnalysisServicesTestUtilities.DefaultServerName,
                AnalysisServicesTestUtilities.DefaultResourceGroup
                )).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal(result.ProvisioningState, "Succeeded");
            Assert.Equal(result.Tags.Count, 2);
        }

        [Fact]
        public void ServerCreateSyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("InProgress"))
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesResource analysisServicesResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();

            var result = client.Servers.Create(
                analysisServicesResource,
                AnalysisServicesTestUtilities.DefaultServerName,
                AnalysisServicesTestUtilities.DefaultResourceGroup
                );

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal(result.ProvisioningState, "Succeeded");
            Assert.Equal(result.Tags.Count, 2);
        }

        [Fact]
        public void ServerCreateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "foo", null));
            Assert.Throws<ValidationException>(() => client.Servers.Create(null, "foo", "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "invalid+", "account"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "rg", "/invalid"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "rg", "s"));
            Assert.Throws<ValidationException>(() => client.Servers.Create(new AnalysisServicesResource(), "rg", "account_name_that_is_too_long"));
        }

        [Fact]
        public void ServerUpdateValidateMessage()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesResourceUpdateParameters updateParameters = new AnalysisServicesResourceUpdateParameters()
            {
                Sku = AnalysisServicesTestUtilities.DefaultSku,
                Tags = AnalysisServicesTestUtilities.DefaultTags,
                AsAdministrators = new ServerAdministrators(AnalysisServicesTestUtilities.DefaultAdministrators)
            };

            var result = client.Servers.Update(
                AnalysisServicesTestUtilities.DefaultServerName,
                updateParameters,
                AnalysisServicesTestUtilities.DefaultResourceGroup
                );

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(new HttpMethod("PATCH"), handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal(result.ProvisioningState, "Succeeded");
            Assert.Equal(result.Tags.Count, 2);
        }

        [Fact]
        public void ServerUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Update(null, new AnalysisServicesResourceUpdateParameters(), "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Update("foo", new AnalysisServicesResourceUpdateParameters(), null));
            Assert.Throws<ValidationException>(() => client.Servers.Update("foo", null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Update("invalid%", new AnalysisServicesResourceUpdateParameters(), "rg"));
            Assert.Throws<ValidationException>(() => client.Servers.Update("/invalid", new AnalysisServicesResourceUpdateParameters(), "rg"));
            Assert.Throws<ValidationException>(() => client.Servers.Update("s", new AnalysisServicesResourceUpdateParameters(), "rg"));
            Assert.Throws<ValidationException>(() => client.Servers.Update("server_name_that_is_too_long", new AnalysisServicesResourceUpdateParameters(), "rg"));
        }

        [Fact]
        public void ServerDeleteValidateMessage()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            client.Servers.Delete("server", "resGroup");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
        }

        [Fact]
        public void ServerDeleteNotFoundValidateMessage()
        {
            var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { notFoundResponse });

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = Assert.Throws<CloudException>(() => Task.Factory.StartNew(() =>
                client.Servers.DeleteWithHttpMessagesAsync(
                "server",
                "resGroup")).Unwrap().GetAwaiter().GetResult());

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal(HttpStatusCode.NotFound, result.Response.StatusCode);
        }

        [Fact]
        public void ServerDeleteNoContentValidateMessage()
        {
            var noContentResponse = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(@"")
            };

            noContentResponse.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(noContentResponse);

            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            client.Servers.Delete("server", "resGroup");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
        }

        [Fact]
        public void ServerDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Delete("foo", null));
            Assert.Throws<ValidationException>(() => client.Servers.Delete(null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("invalid+", "server"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("rg", "/invalid"));
        }

        [Fact]
        public void ServerGetDetailsValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded"))
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultServerName, AnalysisServicesTestUtilities.DefaultResourceGroup);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, result.Location);
            Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, result.Name);
            Assert.Equal(
                string.Format(
                    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.AnalysisServices/servers/{0}", AnalysisServicesTestUtilities.DefaultServerName), 
                    result.Id);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal(result.ProvisioningState, "Succeeded");
            Assert.Equal(result.Tags.Count, 2);
            Assert.True(result.Tags.ContainsKey("key1"));
            Assert.Equal(result.AsAdministrators.Members.Count, 2);
        }

        [Fact]
        public void ServerGetDetailsThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("foo", null));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails(null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("server", "invalid+"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("invalid%", "rg"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("/invalid", "rg"));
        }

        [Fact]
        public void ServerListValidateMessage()
        {
            var serverDetailsResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'value': [
                                {
                                    'id': '/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server1',
                                    'name': 'server1',
                                    'type': 'Microsoft.AnalysisServices/servers',
                                    'location': 'West US',
                                    'sku': {
                                        'name': 'S1',
                                        'tier': 'Standard'
                                    },
                                    'tags': {
                                        'Key1': 'Value1',
                                        'Key2': 'Value2'
                                    },
                                    'properties': {
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server1',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        }
                                    }
                                },
                                {
                                    'id': '/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server2',
                                    'name': 'server2',
                                    'type': 'Microsoft.AnalysisServices/servers',
                                    'location': 'West US',
                                    'sku': {
                                        'name': 'S1',
                                        'tier': 'Standard'
                                    },
                                    'tags': {
                                        'Key1': 'Value1',
                                        'Key2': 'Value2'
                                    },
                                    'properties': {
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server2',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        }
                                    }
                                }
                                ]
                            }")
            };

            serverDetailsResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(serverDetailsResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.List();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(2, result.Count());

            var server1 = result.ElementAt(0);
            Assert.Equal("West US", server1.Location);
            Assert.Equal("server1", server1.Name);
            Assert.Equal("/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server1", server1.Id);
            Assert.NotEmpty(server1.ServerFullName);
            Assert.True(server1.Tags.ContainsKey("Key1"));

            var server2 = result.ElementAt(1);
            Assert.Equal("West US", server1.Location);
            Assert.Equal("server1", server1.Name);
            Assert.Equal("/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server2", server2.Id);
            Assert.NotEmpty(server2.ServerFullName);
            Assert.True(server2.Tags.ContainsKey("Key1"));
        }

        [Fact]
        public void ServerListByResourceGroupValidateMessage()
        {
            var serverDetailsResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'value': [
                                {
                                    'id': '/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server1',
                                    'name': 'server1',
                                    'type': 'Microsoft.AnalysisServices/servers',
                                    'location': 'West US',
                                    'sku': {
                                        'name': 'S1',
                                        'tier': 'Standard'
                                    },
                                    'tags': {
                                        'Key1': 'Value1',
                                        'Key2': 'Value2'
                                    },
                                    'properties': {
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server1',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        }
                                    }
                                },
                                {
                                    'id': '/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server2',
                                    'name': 'server2',
                                    'type': 'Microsoft.AnalysisServices/servers',
                                    'location': 'West US',
                                    'sku': {
                                        'name': 'S1',
                                        'tier': 'Standard'
                                    },
                                    'tags': {
                                        'Key1': 'Value1',
                                        'Key2': 'Value2'
                                    },
                                    'properties': {
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server2',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        }
                                    }
                                }
                                ]
                            }")
            };

            serverDetailsResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(serverDetailsResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.ListByResourceGroup(AnalysisServicesTestUtilities.DefaultResourceGroup);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(2, result.Count());

            var server1 = result.ElementAt(0);
            Assert.Equal("West US", server1.Location);
            Assert.Equal("server1", server1.Name);
            Assert.Equal("/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server1", server1.Id);
            Assert.NotEmpty(server1.ServerFullName);
            Assert.True(server1.Tags.ContainsKey("Key1"));

            var server2 = result.ElementAt(1);
            Assert.Equal("West US", server1.Location);
            Assert.Equal("server1", server1.Name);
            Assert.Equal("/subscriptions/613192d9-5973f-477a-9cfe-4efc3ee2bd60/resourceGroups/TestRG/providers/Microsoft.AnalysisServices/servers/server2", server2.Id);
            Assert.NotEmpty(server2.ServerFullName);
            Assert.True(server2.Tags.ContainsKey("Key1"));
        }


        //[Fact]
        //public void ServersCreateTest()
        //{
        //    var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
        //    var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

        //    using (MockContext context = MockContext.Start(this.GetType().FullName))
        //    {
        //        // Create clients
        //        var analysisServicesClient = AnalysisServicesTestUtilities.GetAnalysisServicesClient(context, handler1);
        //        var resourcesClient = AnalysisServicesTestUtilities.GetResourceManagementClient(context, handler2);

        //        // Create resource group
        //        var resourceGroupName = AnalysisServicesTestUtilities.CreateResourceGroup(resourcesClient);

        //        // Create a standard AS instance
        //        string serveName = TestUtilities.GenerateName("AAS");
        //        AnalysisServicesResource analysisServicesResource = AnalysisServicesTestUtilities.CreateAnalysisServicesInstance(analysisServicesClient, resourceGroupName);

        //        VerifyServerCreationSuccess(analysisServicesResource);

        //        // Delete resource group
        //        AnalysisServicesTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
        //    }
        //}

        private static void VerifyServersEqual(AnalysisServicesResource createdResource, AnalysisServicesResource referenceResource)
        {
            Assert.Equal(createdResource.Tags, referenceResource.Tags);
            Assert.Equal(createdResource.Sku, referenceResource.Sku);
            Assert.Equal(createdResource.Location, referenceResource.Location);
            Assert.Equal(createdResource.Name, referenceResource.Name);
            Assert.Equal(createdResource.Id, referenceResource.Id);
            Assert.Equal(createdResource.Type, referenceResource.Type);
            Assert.Equal(createdResource.ProvisioningState, referenceResource.ProvisioningState);
            Assert.Equal(createdResource.ServerFullName, referenceResource.ServerFullName);
            Assert.Equal(createdResource.AsAdministrators, referenceResource.AsAdministrators);
        }

        private static void VerifyServerCreationSuccess(AnalysisServicesResource createdResource)
        {
            AnalysisServicesResource defaultResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();
            VerifyServersEqual(createdResource, defaultResource);
        }

        private static void VerifyServerUpdated(AnalysisServicesResource updatedResource, Dictionary<string, string> newTags, ServerAdministrators serverAdministrators)
        {
        }
    }
}
