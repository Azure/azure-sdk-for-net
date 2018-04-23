// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using System;
using Xunit;

namespace Subscriptions.Tests
{
    public class SubscriptionTests : SubscriptionsTestBase
    {

        private void ValidateSubscription(Subscription ua) {
            // Resource
            Assert.NotNull(ua);
            Assert.NotNull(ua.Id);

            // Subscription
        }
        
        private void AssertSame(Subscription expected, Subscription given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);

            // Subscription
        }

        [Fact]
        public void TestListSubscriptions() {
            RunTest((client) => {
                var subscriptions = client.Subscriptions.List();
                Assert.NotNull(subscriptions);
            });
        }

        [Fact]
        public void CheckNameAvailability()
        {
            RunTest((client) =>
            {
                var result = client.Subscriptions.CheckNameAvailability(new CheckNameAvailabilityDefinition(
                    name: "Test Sub", resourceType: "Microsoft.Subscriptions.Admin/plans"));
                Assert.NotNull(result);
            });
        }

        [Fact]
        public void ListAdminOperations() {
            RunTest((client) => {
                var adminOperations = client.Operations.List();
                Assert.NotNull(adminOperations);
                Assert.NotEmpty(adminOperations.Value);
            });
        }

      //  [Fact]
        public void CreateUpdateDeleteSubscription()
        {
            RunTest((client) =>
            {
                var subscriptionId = Guid.NewGuid().ToString();
                var delProviderSubId = Environment.GetEnvironmentVariable("SubscriptionId");
                var tenantId = Environment.GetEnvironmentVariable("AADTenant");
                var offer = client.Offers.ListAll().GetFirst();

                var subscription = new Subscription(
                    delegatedProviderSubscriptionId: delProviderSubId,
                    displayName: "Test Subscription",
                    offerId: offer.Id,
                    owner: "tenantadmin1@msazurestack.onmicrosoft.com",
                    subscriptionId: subscriptionId,
                    state: SubscriptionState.Enabled,
                    tenantId: tenantId);

                var result = client.Subscriptions.CreateOrUpdate(
                    subscription: subscriptionId,                    
                    newSubscription: subscription);

                ValidateSubscription(result);

                var createdSubscription = (client.Subscriptions.Get(subscriptionId));

                AssertSame(result, createdSubscription);

                client.Subscriptions.Delete(subscriptionId);

                var deletedSubscription = client.Subscriptions.Get(subscriptionId);

                if (deletedSubscription != null)
                {
                    Assert.Equal("Deleted", deletedSubscription.State);
                }

            });
        }
    }
}
