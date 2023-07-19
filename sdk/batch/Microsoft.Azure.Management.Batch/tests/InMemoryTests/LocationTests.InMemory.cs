// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Rest;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryLocationTests
    {
        [Fact]
        public void GetLocationQuotasThrowsException()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Location.GetQuotas(null));
        }

        [Fact]
        public void GetLocationQuotasValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'accountQuota' : '5'
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.Location.GetQuotas("westus");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(5, result.AccountQuota);
        }

        [Fact]
        public void ListSupportedCloudServiceSkusValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                        {
                          'name': 'Small',
                          'familyName': 'standardA0_A7Family',
                          'capabilities': [
                            {
                              'name': 'MaxResourceVolumeMB',
                              'value': '20480'
                            },
                            {
                              'name': 'vCPUs',
                              'value': '1'
                            },
                            {
                              'name': 'HyperVGenerations',
                              'value': 'V1'
                            },
                            {
                              'name': 'MemoryGB',
                              'value': '0.75'
                            },
                            {
                              'name': 'LowPriorityCapable',
                              'value': 'False'
                            },
                            {
                              'name': 'vCPUsAvailable',
                              'value': '1'
                            },
                            {
                              'name': 'EphemeralOSDiskSupported',
                              'value': 'False'
                            }
                          ]
                        }
                      ]
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.Location.ListSupportedCloudServiceSkus("westus");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.Equal("standardA0_A7Family", result.Single().FamilyName);
            Assert.Equal("Small", result.Single().Name);
            Assert.Equal(7, result.Single().Capabilities.Count());
        }
    }
}
