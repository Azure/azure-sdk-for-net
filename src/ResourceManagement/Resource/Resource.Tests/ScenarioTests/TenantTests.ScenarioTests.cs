// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
