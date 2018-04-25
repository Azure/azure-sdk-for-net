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

        private void ValidateSubscription(Subscription subscription) {
            // Resource
            Assert.NotNull(subscription);
            Assert.NotNull(subscription.Id);

            // Subscription
            Assert.NotNull(subscription.Owner);
            Assert.NotNull(subscription.OfferId);
            Assert.NotNull(subscription.State);
            Assert.NotNull(subscription.TenantId);
            Assert.NotNull(subscription.RoutingResourceManagerType);
        }
        
        private void AssertSame(Subscription expected, Subscription given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);

            // Subscription
            Assert.Equal(expected.Owner, given.Owner);
            Assert.Equal(expected.OfferId, given.OfferId);
            Assert.Equal(expected.State, given.State);
            Assert.Equal(expected.TenantId, given.TenantId);
            Assert.Equal(expected.RoutingResourceManagerType, given.RoutingResourceManagerType);

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

        [Fact]
        public void CreateUpdateDeleteSubscription()
        {
            RunTest((client) =>
            {
                var subscriptionId = "4FDD5149-B7E6-46E1-AC30-4D7E3AF4B69B";
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
