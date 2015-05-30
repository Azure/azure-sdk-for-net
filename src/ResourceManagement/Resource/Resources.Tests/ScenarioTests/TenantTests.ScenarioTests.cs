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

using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System.Net;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveTenantTests : TestBase
    {
        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void ListTenants()
        {
            // NEXT environment variables used to record the mock

            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSubscriptionClient(handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var tenants = client.Tenants.ListWithOperationResponseAsync().Result;

                Assert.NotNull(tenants);
                Assert.Equal(HttpStatusCode.OK, tenants.Response.StatusCode);
                Assert.NotNull(tenants.Body);
                Assert.NotEqual(0, tenants.Body.Count);
                Assert.NotNull(tenants.Body[0].ID);
                Assert.NotNull(tenants.Body[0].TenantId);
            }
        }
    }
}
