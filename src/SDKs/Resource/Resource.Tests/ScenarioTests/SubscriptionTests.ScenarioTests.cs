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
