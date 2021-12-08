// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveSubscriptionTests : TestBase
    {
        private const string subscriptionId = "d17ad3ae-320e-42ff-b5a1-705389c6063a";

        public SubscriptionClient GetSubscriptionClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(context, handler);
            return client;
        }

        [Fact]
        public void GetAcceptSubscriptionOwnershipStatus()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.Subscription.AcceptOwnershipStatus(subscriptionId);
                
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                Assert.Equal(subscriptionId, result.SubscriptionId);
                Assert.Equal("Pending", result.AcceptOwnershipState);
                Assert.Equal("abc@test.com", result.BillingOwner);
                Assert.Equal("6c541ca7-1cab-4ea0-adde-6305e1d534e2", result.SubscriptionTenantId);
                Assert.Equal("Test Subscription", result.DisplayName);
            }
        }

        /*[Fact]
        public void ListSubscriptions()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptions = client.Subscriptions.List();

                Assert.NotNull(subscriptions);
                Assert.NotEmpty(subscriptions);
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
                const string subscriptionId = "11e23d44-5f84-4f2f-908f-e3bd3195243d";
                var client = GetSubscriptionClient(context, handler);
                //var rmclient = GetResourceManagementClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptionDetails = client.Subscriptions.Get(subscriptionId);

                Assert.NotNull(subscriptionDetails);
                Assert.NotNull(subscriptionDetails.Id);
                Assert.NotNull(subscriptionDetails.SubscriptionId);
                Assert.NotNull(subscriptionDetails.DisplayName);
                Assert.NotNull(subscriptionDetails.State);
            }
        }*/
    }
}
