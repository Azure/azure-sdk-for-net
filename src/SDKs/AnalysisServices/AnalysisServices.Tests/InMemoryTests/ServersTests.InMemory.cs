// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Provisioning", "Provisioning"))
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded", "Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesServer analysisServicesResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();

            var result = Task.Factory.StartNew(() => client.Servers.CreateAsync(
                AnalysisServicesTestUtilities.DefaultResourceGroup,
                AnalysisServicesTestUtilities.DefaultServerName,
                analysisServicesResource
                )).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
           
            Assert.Equal("Succeeded", result.ProvisioningState);
            Assert.Equal("Succeeded", result.State);
            Assert.Equal(2, result.Tags.Count);
        }

        [Fact]
        public void ServerCreateSyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Provisioning", "Provisioning"))
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded", "Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesServer analysisServicesResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();

            var result = client.Servers.Create(
                AnalysisServicesTestUtilities.DefaultResourceGroup,
                AnalysisServicesTestUtilities.DefaultServerName,
                analysisServicesResource
                );

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal("Succeeded", result.ProvisioningState);
            Assert.Equal("Succeeded", result.State);
            Assert.Equal(2, result.Tags.Count);
            Assert.Equal(result.BackupBlobContainerUri, AnalysisServicesTestUtilities.DefaultBackupBlobContainerUri);
        }

        [Fact]
        public void ServerCreateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Create(null, "bar", new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("foo", null, new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("foo", "bar", null));
            Assert.Throws<ValidationException>(() => client.Servers.Create("invalid+", "server", new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("rg", "invalid%", new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("rg", "/invalid", new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("rg", "s", new AnalysisServicesServer()));
            Assert.Throws<ValidationException>(() => client.Servers.Create("rg", "account_name_that_is_too_long", new AnalysisServicesServer()));
        }

        [Fact]
        public void ServerUpdateValidateMessage()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(AnalysisServicesTestUtilities.GetDefaultCreatedResponse("Succeeded", "Succeeded"))
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
            {
                Sku = AnalysisServicesTestUtilities.DefaultSku,
                Tags = AnalysisServicesTestUtilities.DefaultTags,
                AsAdministrators = new ServerAdministrators(AnalysisServicesTestUtilities.DefaultAdministrators),
                BackupBlobContainerUri = AnalysisServicesTestUtilities.DefaultBackupBlobContainerUri
            };

            var result = client.Servers.Update(
                AnalysisServicesTestUtilities.DefaultResourceGroup,
                AnalysisServicesTestUtilities.DefaultServerName,
                updateParameters
                );

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(new HttpMethod("PATCH"), handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(result.Location, AnalysisServicesTestUtilities.DefaultLocation);
            Assert.NotEmpty(result.ServerFullName);
            Assert.Equal("Succeeded", result.ProvisioningState);
            Assert.Equal("Succeeded", result.State);
            Assert.Equal(2, result.Tags.Count);
            Assert.Equal(result.BackupBlobContainerUri, AnalysisServicesTestUtilities.DefaultBackupBlobContainerUri);
        }

        [Fact]
        public void ServerUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Update(null, "bar", new AnalysisServicesServerUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Servers.Update("foo",  null, new AnalysisServicesServerUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Servers.Update("foo", "bar", null));
            Assert.Throws<ValidationException>(() => client.Servers.Update("rg", "invalid%", new AnalysisServicesServerUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Servers.Update("rg", "/invalid", new AnalysisServicesServerUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Servers.Update("rg", "s", new AnalysisServicesServerUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Servers.Update("rg", "server_name_that_is_too_long", new AnalysisServicesServerUpdateParameters()));
        }

        [Fact]
        public void ServerDeleteValidateMessage()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            client.Servers.Delete("resGroup", "server");

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

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = Assert.Throws<CloudException>(() => Task.Factory.StartNew(() =>
                client.Servers.DeleteWithHttpMessagesAsync(
                "resGroup",
                "server")).Unwrap().GetAwaiter().GetResult());

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

            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);
            client.Servers.Delete("resGroup", "server");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
        }

        [Fact]
        public void ServerDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.Delete("foo", null));
            Assert.Throws<ValidationException>(() => client.Servers.Delete(null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("invalid+", "server"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.Servers.Delete("rg", "/invalid"));
        }

        [Fact]
        public void ServerGetDetailsThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("foo", null));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails(null, "bar"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("invalid+", "server"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.Servers.GetDetails("rg", "/invalid"));
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
                                        'state': 'Succeeded',
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server1',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        },
                                        'backupBlobContainerUri' : 'https://aassdk1.blob.core.windows.net/server1?dummykey1'
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
                                        'state': 'Succeeded',
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server2',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        },
                                        'backupBlobContainerUri' : 'https://aassdk1.blob.core.windows.net/server2?dummykey2'
                                    }
                                }
                                ]
                            }")
            };

            serverDetailsResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(serverDetailsResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

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
                                        'state': 'Succeeded',
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server1',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        },
                                        'backupBlobContainerUri' : 'https://aassdk1.blob.core.windows.net/azsdktest?dummykey1'
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
                                        'state': 'Succeeded',
                                        'provisioningState': 'Succeeded',
                                        'serverFullName': 'asazure://stabletest.asazure-int.windows.net/server2',
                                        'asAdministrators': {
                                            'members': [
                                                'aztest0@stabletest.ccsctp.net',
                                                'aspaasteam@microsoft.com'
                                            ]
                                        },
                                        'backupBlobContainerUri' : 'https://aassdk1.blob.core.windows.net/azsdktest2?dummykey2'
                                    }
                                }
                                ]
                            }")
            };

            serverDetailsResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(serverDetailsResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

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

        [Fact]
        public void OperationCheckNameAvailabilityValidateMessage()
        {
            var checknameResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                                'nameAvailable': true
                                            }")
            };

            checknameResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(checknameResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.CheckNameAvailability("West US", new CheckServerNameAvailabilityParameters("azsdktest", "Microsoft.AnalysisServices/servers"));

            // Validate headers
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.True(result.NameAvailable);
        }

        [Fact]
        public void OperationCheckNameNotAvailableValidateMessage()
        {
            var checknameResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                                'nameAvailable': false,
                                                'reason': 'The name is not available.',
                                                'message': 'The name is not available in the region.'
                                            }")
            };

            checknameResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(checknameResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.CheckNameAvailability("West US", new CheckServerNameAvailabilityParameters("azsdktest", "Microsoft.AnalysisServices/servers"));

            // Validate headers
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.False(result.NameAvailable);
            Assert.NotEmpty(result.Message);
            Assert.NotEmpty(result.Reason);
        }

        [Fact]
        public void OperationStatusesValidateMessage()
        {
            var opearationStatusesResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                                'id': '/subscriptions/id/locations/westus/operationstatuses/testoperationid',
                                                'name': 'testoperationid',
                                                'startTime': '2017-01-01T13:13:13.933Z',
                                                'status': 'Running'
                                            }")
            };

            opearationStatusesResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(opearationStatusesResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.ListOperationStatuses("West US", "/subscriptions/id/locations/westus/operationstatuses/testoperationid");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal("/subscriptions/id/locations/westus/operationstatuses/testoperationid", result.Id);
            Assert.NotEmpty(result.Name);
            Assert.NotEmpty(result.StartTime);
            Assert.NotEmpty(result.Status);
        }

        [Fact]
        public void OperationStatusesFailedValidateMessage()
        {
            var opearationStatusesResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                                'id': '/subscriptions/id/locations/westus/operationstatuses/testoperationid',
                                                'name': 'testoperationid',
                                                'startTime': '2017-01-01T13:13:13.933Z',
                                                'endTime': '2017-01-01T13:13:13.933Z',
                                                'status': 'Failed',
                                                'error': {
                                                   'code': 'Test error code',
                                                   'message': 'Running out of memory.'
                                                }
                                            }")
            };

            opearationStatusesResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(opearationStatusesResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            var result = client.Servers.ListOperationStatuses("West US", "/subscriptions/id/locations/westus/operationstatuses/testoperationid");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal("/subscriptions/id/locations/westus/operationstatuses/testoperationid", result.Id);
            Assert.NotEmpty(result.Name);
            Assert.NotEmpty(result.StartTime);
            Assert.NotEmpty(result.Status);
            Assert.Equal("Failed", result.Status);
            Assert.NotNull(result.Error);
            Assert.NotEmpty(result.Error.Code);
            Assert.NotEmpty(result.Error.Message);
        }

        [Fact]
        public void OperationResultCompletedValidateMessage()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            okResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(okResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            client.Servers.ListOperationResults("West US", "/subscriptions/id/locations/westus/operationstatuses/testoperationid");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal(HttpStatusCode.OK, handler.StatusCodeToReturn);
        }

        [Fact]
        public void OperationResultRunningValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(acceptedResponse) { StatusCodeToReturn = HttpStatusCode.Accepted };
            AnalysisServicesManagementClient client = AnalysisServicesTestUtilities.GetAnalysisServicesClient(handler);

            client.Servers.ListOperationResults("West US", "/subscriptions/id/locations/westus/operationstatuses/testoperationid");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal(HttpStatusCode.Accepted, handler.StatusCodeToReturn);
        }

        private static void VerifyServersEqual(AnalysisServicesServer createdResource, AnalysisServicesServer referenceResource)
        {
            Assert.Equal(createdResource.Tags, referenceResource.Tags);
            Assert.Equal(createdResource.Sku, referenceResource.Sku);
            Assert.Equal(createdResource.Location, referenceResource.Location);
            Assert.Equal(createdResource.Name, referenceResource.Name);
            Assert.Equal(createdResource.Id, referenceResource.Id);
            Assert.Equal(createdResource.Type, referenceResource.Type);
            Assert.Equal(createdResource.ProvisioningState, referenceResource.ProvisioningState);
            Assert.Equal(createdResource.State, referenceResource.State);
            Assert.Equal(createdResource.ServerFullName, referenceResource.ServerFullName);
            Assert.Equal(createdResource.AsAdministrators, referenceResource.AsAdministrators);
        }

        private static void VerifyServerCreationSuccess(AnalysisServicesServer createdResource)
        {
            AnalysisServicesServer defaultResource = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();
            VerifyServersEqual(createdResource, defaultResource);
        }

        private static void VerifyServerUpdated(AnalysisServicesServer updatedResource, Dictionary<string, string> newTags, ServerAdministrators serverAdministrators)
        {
        }
    }
}
