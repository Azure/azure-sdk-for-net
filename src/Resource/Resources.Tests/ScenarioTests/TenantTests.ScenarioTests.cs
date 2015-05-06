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
using Hyak.Common.TransientFaultHandling;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveTenantTests : TestBase
    {
        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClient();
            client = client.WithHandler(handler);
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
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var tenants = client.Tenants.List();

                Assert.NotNull(tenants);
                Assert.Equal(HttpStatusCode.OK, tenants.StatusCode);
                Assert.NotNull(tenants.TenantIds);
                Assert.NotEqual(0, tenants.TenantIds.Count());
                Assert.NotNull(tenants.TenantIds[0].Id);
                Assert.NotNull(tenants.TenantIds[0].TenantId);
            }
        }
    }
}
