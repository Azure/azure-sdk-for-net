// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryPrivateEndpointConnectionTests
    {
        [Fact]
        public async Task PrivateEndpointConnectionGet()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'properties': {
                            'provisioningState': 'Succeeded',
                            'privateEndpoint': {
                                'id': '/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName'
                            },
                            'privateLinkServiceConnectionState': {
                                'status': 'Approved',
                                'description': 'Its approved'
                            },
                            'groupIds': [ 'abc123' ]
                        }
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = await client.PrivateEndpointConnection.GetAsync("rg", "myaccount", "privateEndpointName");

            // Validate result
            Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName", result.PrivateEndpoint.Id);
            Assert.Equal(PrivateLinkServiceConnectionStatus.Approved, result.PrivateLinkServiceConnectionState.Status);
            Assert.Equal("Its approved", result.PrivateLinkServiceConnectionState.Description);
            Assert.Equal(1, result.GroupIds.Count);
            Assert.Equal("abc123", result.GroupIds[0]);
            Assert.Null(result.PrivateLinkServiceConnectionState.ActionsRequired);
        }

        [Fact]
        public async Task PrivateEndpointConnectionList()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'value': 
                            [{
                                'properties': {
                                    'provisioningState': 'Succeeded',
                                    'privateEndpoint': {
                                        'id': '/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName'
                                    },
                                    'privateLinkServiceConnectionState': {
                                        'status': 'Approved',
                                        'description': 'Its approved'
                                    },
                                    'groupIds': [ 'abc123' ]
                                }
                            }]
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = (await client.PrivateEndpointConnection.ListByBatchAccountAsync("rg", "myaccount")).ToList().Single();

            // Validate result
            Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName", result.PrivateEndpoint.Id);
            Assert.Equal(PrivateLinkServiceConnectionStatus.Approved, result.PrivateLinkServiceConnectionState.Status);
            Assert.Equal("Its approved", result.PrivateLinkServiceConnectionState.Description);
            Assert.Equal(1, result.GroupIds.Count);
            Assert.Equal("abc123", result.GroupIds[0]);
            Assert.Null(result.PrivateLinkServiceConnectionState.ActionsRequired);
        }

        [Fact]
        public async Task PrivateEndpointConnectionUpdate()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'properties': {
                            'provisioningState': 'Succeeded',
                            'privateEndpoint': {
                                'id': '/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName'
                            },
                            'privateLinkServiceConnectionState': {
                                'status': 'Pending',
                                'description': 'Its pending'
                            },
                            'groupIds': [ 'abc123' ]
                        }
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            PrivateEndpointConnection result = await client.PrivateEndpointConnection.UpdateAsync(
                "rg",
                "myaccount",
                "privateEndpointName"
            );

            // Validate result
            Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName", result.PrivateEndpoint.Id);
            Assert.Equal(PrivateLinkServiceConnectionStatus.Pending, result.PrivateLinkServiceConnectionState.Status);
            Assert.Equal("Its pending", result.PrivateLinkServiceConnectionState.Description);
            Assert.Null(result.PrivateLinkServiceConnectionState.ActionsRequired);
        }
    }
}
