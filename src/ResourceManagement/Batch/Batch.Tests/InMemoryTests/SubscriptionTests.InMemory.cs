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
using Xunit;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Batch.Tests.Helpers;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemorySubscriptionTests
    {
        public BatchManagementClient GetBatchManagementClient(RecordedDelegatingHandler handler)
        {
            var certCreds = new CertificateCloudCredentials(Guid.NewGuid().ToString(), new System.Security.Cryptography.X509Certificates.X509Certificate2());
            handler.IsPassThrough = false;
            return new BatchManagementClient(certCreds).WithHandler(handler);
        }

        [Fact]
        public void GetSubscriptionQuotasThrowsException()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Subscriptions.GetSubscriptionQuotas(null));
        }

        [Fact]
        public void GetSubscriptionQuotasValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'accountQuota' : '5'
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            var result = client.Subscriptions.GetSubscriptionQuotas("westus");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(5, result.AccountQuota);
        }
    }
}
