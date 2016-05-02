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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveTenantTests : TestBase
    {
        public SubscriptionClient GetSubscriptionClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(context, handler);

            return client;
        }

        [Fact]
        public void ListTenants()
        {
            // NEXT environment variables used to record the mock

            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var tenants = client.Tenants.ListWithHttpMessagesAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                Assert.NotNull(tenants);
                Assert.Equal(HttpStatusCode.OK, tenants.Response.StatusCode);
                Assert.NotNull(tenants.Body);
                Assert.NotEqual(0, tenants.Body.Count());
                Assert.NotNull(tenants.Body.First().Id);
                Assert.NotNull(tenants.Body.First().TenantId);
            }
        }
    }
}
