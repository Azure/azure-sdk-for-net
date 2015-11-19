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

using Hyak.Common.TransientFaultHandling;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveSubscriptionTests : TestBase
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClient();
            client = client.WithHandler(handler);
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
        public void ListSubscriptions()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSubscriptionClient(handler);
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var subscription = client.Subscriptions.List();

                Assert.NotNull(subscription);
                Assert.Equal(HttpStatusCode.OK, subscription.StatusCode);
                Assert.NotNull(subscription.Subscriptions);
                Assert.NotEqual(0, subscription.Subscriptions.Count());
                Assert.NotNull(subscription.Subscriptions[0].Id);
                Assert.NotNull(subscription.Subscriptions[0].SubscriptionId);
                Assert.NotNull(subscription.Subscriptions[0].DisplayName);
                Assert.NotNull(subscription.Subscriptions[0].State);
            }
        }

        [Fact]
        public void ListSubscriptionLocations()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSubscriptionClient(handler);
                var rmclient = GetResourceManagementClient(handler);
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var locations = client.Subscriptions.ListLocations(rmclient.Credentials.SubscriptionId);

                Assert.NotNull(locations);
                Assert.Equal(HttpStatusCode.OK, locations.StatusCode);
                Assert.NotNull(locations.Locations[0].Id);
                Assert.NotNull(locations.Locations[0].Name);
                Assert.NotNull(locations.Locations[0].DisplayName);
                Assert.NotNull(locations.Locations[0].Latitude);
                Assert.NotNull(locations.Locations[0].Longitude);
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
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var subscriptionDetails = client.Subscriptions.Get(rmclient.Credentials.SubscriptionId);

                Assert.NotNull(subscriptionDetails);
                Assert.Equal(HttpStatusCode.OK, subscriptionDetails.StatusCode);
                Assert.NotNull(subscriptionDetails.Subscription.Id);
                Assert.NotNull(subscriptionDetails.Subscription.SubscriptionId);
                Assert.NotNull(subscriptionDetails.Subscription.DisplayName);
                Assert.NotNull(subscriptionDetails.Subscription.State);
            }
        }
    }
}
