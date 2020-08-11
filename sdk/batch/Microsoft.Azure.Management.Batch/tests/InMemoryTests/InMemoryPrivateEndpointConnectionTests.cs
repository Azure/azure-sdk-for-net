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
                            }
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
            Assert.Null(result.PrivateLinkServiceConnectionState.ActionRequired);
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
                                    }
                                }
                            }]
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = (await client.PrivateEndpointConnection.ListByBatchAccountAsync("rg", "myaccount")).ToList();

            // Validate result
            Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, result.Single().ProvisioningState);
            Assert.Equal("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName", result.Single().PrivateEndpoint.Id);
            Assert.Equal(PrivateLinkServiceConnectionStatus.Approved, result.Single().PrivateLinkServiceConnectionState.Status);
            Assert.Equal("Its approved", result.Single().PrivateLinkServiceConnectionState.Description);
            Assert.Null(result.Single().PrivateLinkServiceConnectionState.ActionRequired);
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
                            }
                        }
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = await client.PrivateEndpointConnection.UpdateAsync(
                "rg",
                "myaccount",
                "privateEndpointName",
                new PrivateEndpointConnection(
                    privateLinkServiceConnectionState: new PrivateLinkServiceConnectionState(
                        status: PrivateLinkServiceConnectionStatus.Pending,
                        description: "It's pending")));

            // Validate result
            Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Network/privateEndpoints/privateEndpointName", result.PrivateEndpoint.Id);
            Assert.Equal(PrivateLinkServiceConnectionStatus.Pending, result.PrivateLinkServiceConnectionState.Status);
            Assert.Equal("Its pending", result.PrivateLinkServiceConnectionState.Description);
            Assert.Null(result.PrivateLinkServiceConnectionState.ActionRequired);
        }
    }
}
