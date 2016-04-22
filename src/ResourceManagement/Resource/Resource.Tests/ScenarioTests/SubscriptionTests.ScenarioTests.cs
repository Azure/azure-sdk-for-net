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
    public class LiveSubscriptionTests : TestBase
    {
        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClientWithHandler(context, handler);
            return client;
        }

        public SubscriptionClient GetSubscriptionClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(context, handler);
            return client;
        }

        [Fact]
        public void ListSubscriptions()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptions = client.Subscriptions.List();

                Assert.NotNull(subscriptions);
                Assert.NotEqual(0, subscriptions.Count());
                Assert.NotNull(subscriptions.First().Id);
                Assert.NotNull(subscriptions.First().SubscriptionId);
                Assert.NotNull(subscriptions.First().DisplayName);
                Assert.NotNull(subscriptions.First().State);
            }
        }
        
        [Fact]
        public void GetSubscriptionDetails()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                var rmclient = GetResourceManagementClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptionDetails = client.Subscriptions.Get(rmclient.SubscriptionId);

                Assert.NotNull(subscriptionDetails);
                Assert.NotNull(subscriptionDetails.Id);
                Assert.NotNull(subscriptionDetails.SubscriptionId);
                Assert.NotNull(subscriptionDetails.DisplayName);
                Assert.NotNull(subscriptionDetails.State);
            }
        }
    }
}
