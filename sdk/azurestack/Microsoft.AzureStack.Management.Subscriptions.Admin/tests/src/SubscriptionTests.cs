// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using Subscriptions.Tests.src.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                var subscriptionId = "a08052b9-4ba8-47d0-be93-4b72a3d672e9";
                var offer = client.Offers.ListAll().GetFirst();

                var subscription = new Subscription(
                    delegatedProviderSubscriptionId: TestContext.DefaultProviderSubscriptionId,
                    displayName: "Test Subscription",
                    offerId: offer.Id,
                    owner: TestContext.TenantUpn,
                    subscriptionId: subscriptionId,
                    state: SubscriptionState.Enabled,
                    tenantId: TestContext.DirectoryTenantId);

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

        [Fact]
        public void MoveSubscriptions()
        {
            RunTest((client) =>
            {
                var offer = client.Offers.Get(TestContext.ResourceGroupName, TestContext.MoveOfferName);

                var subsriptionIds = new[] {
                    "ce4c7fdb-5a38-46f5-8bbc-b8b328a87ab7",
                    "a0d1a71c-0b27-4e73-abfc-169512576f7e",
                    "85d57d7e-c8b4-4ab3-ba62-54b5984fa3c7" };
                var subscriptions = new Subscription[3];

                for (var i = 0; i < subscriptions.Length; i++)
                {
                    var subscriptionId = subsriptionIds[i];
                    subscriptions[i]= new Subscription(
                        delegatedProviderSubscriptionId: TestContext.DefaultProviderSubscriptionId,
                        displayName: nameof(MoveSubscriptions) + i,
                        offerId: offer.Id,
                        owner: TestContext.TenantUpn,
                        subscriptionId: subscriptionId,
                        state: SubscriptionState.Enabled,
                        tenantId: TestContext.DirectoryTenantId);

                    var result = client.Subscriptions.CreateOrUpdate(
                        subscription: subscriptionId,
                        newSubscription: subscriptions[i]);

                    ValidateSubscription(result);
                    subscriptions[i] = result;
                }

                var delegatedProviderOffer = client.DelegatedProviderOffers.Get(
                    TestContext.DelegatedProviderSubscriptionId,
                    TestContext.DelegatedProviderOfferName);

                var moveSubscriptionsDefinition = new MoveSubscriptionsDefinition()
                {
                    TargetDelegatedProviderOffer = delegatedProviderOffer.Id,
                    Resources = subscriptions.Select(s => s.Id).ToArray()
                };

                client.Subscriptions.MoveSubscriptions(moveSubscriptionsDefinition);

                var subscriptionIds = subscriptions.Select(s => s.SubscriptionId);
                subscriptions = client.Subscriptions.List()
                    .Where(s => subscriptionIds.Contains(s.SubscriptionId))
                    .ToArray();

                var expectedOfferId = string.Format(
                    provider: CultureInfo.InvariantCulture,
                    format: "/subscriptions/{0}/providers/Microsoft.Subscriptions.Admin/delegatedProviders/{1}/offers/{2}",
                    arg0: TestContext.DefaultProviderSubscriptionId,
                    arg1: TestContext.DelegatedProviderSubscriptionId,
                    arg2: TestContext.DelegatedProviderOfferName);

                foreach (var subscription in subscriptions)
                {
                    Assert.Equal(delegatedProviderOffer.Id, subscription.OfferId);
                    client.Subscriptions.Delete(subscription.SubscriptionId);
                }
            });
        }
    }
}
