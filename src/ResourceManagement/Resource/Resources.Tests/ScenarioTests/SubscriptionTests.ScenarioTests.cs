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

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System.Net;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveSubscriptionTests : TestBase
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClientWithHandler(handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClient(handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void ListSubscriptions()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSubscriptionClient(handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptions = client.Subscriptions.List();

                Assert.NotNull(subscriptions);
                Assert.NotEqual(0, subscriptions.Count);
                Assert.NotNull(subscriptions[0].Id);
                Assert.NotNull(subscriptions[0].SubscriptionId);
                Assert.NotNull(subscriptions[0].DisplayName);
                Assert.NotNull(subscriptions[0].State);
            }
        }
        
        [Fact]
        public void GetSubscriptionDetails()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSubscriptionClient(handler);
                var rmclient = GetResourceManagementClient(handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptionDetails = client.Subscriptions.Get(rmclient.Credentials.SubscriptionId);

                Assert.NotNull(subscriptionDetails);
                Assert.NotNull(subscriptionDetails.Id);
                Assert.NotNull(subscriptionDetails.SubscriptionId);
                Assert.NotNull(subscriptionDetails.DisplayName);
                Assert.NotNull(subscriptionDetails.State);
            }
        }
    }
}
