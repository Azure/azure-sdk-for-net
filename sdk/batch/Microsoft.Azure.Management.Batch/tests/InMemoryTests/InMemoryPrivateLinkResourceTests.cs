// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryPrivateLinkResourceTests
    {
        [Fact]
        public async Task PrivateLinkResourceGet()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'properties': {
                            'groupId': 'batchAccount',
                            'requiredMembers': [
                                'batchAccount'
                            ]
                        }
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = await client.PrivateLinkResource.GetAsync("rg", "myaccount", "privateLinkResource");

            // Validate result
            Assert.Equal("batchAccount", result.GroupId);
            Assert.Single(result.RequiredMembers, "batchAccount");
        }

        [Fact]
        public async Task PrivateEndpointConnectionList()
        {
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'value': [
                            {
                                'properties': {
                                    'groupId': 'batchAccount',
                                    'requiredMembers': [
                                        'batchAccount'
                                    ]
                                }
                            }
                        ]
                    }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var result = (await client.PrivateLinkResource.ListByBatchAccountAsync("rg", "myaccount")).ToList();

            // Validate result
            Assert.Equal("batchAccount", result.Single().GroupId);
            Assert.Single(result.Single().RequiredMembers, "batchAccount");
        }
    }
}
