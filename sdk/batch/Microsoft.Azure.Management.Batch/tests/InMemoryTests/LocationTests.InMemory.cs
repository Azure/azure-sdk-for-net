// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Rest;
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
    }
}
