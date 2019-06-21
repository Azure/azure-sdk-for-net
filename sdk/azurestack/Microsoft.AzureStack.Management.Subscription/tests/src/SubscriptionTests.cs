// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscription;
using Microsoft.AzureStack.Management.Subscription.Models;
using System;
using Xunit;

namespace Subscriptions.Tests
{
    public class SubscriptionTests : SubscriptionsTestBase
    {

        private void ValidateSubscription(SubscriptionModel subscription) {
            // Subscription
            Assert.NotNull(subscription);
            Assert.NotNull(subscription.Id);
            Assert.NotNull(subscription.DisplayName);
            Assert.NotNull(subscription.SubscriptionId);
            Assert.NotNull(subscription.TenantId);
            Assert.NotNull(subscription.State);
            Assert.NotNull(subscription.OfferId);
        }

        private void AssertSame(SubscriptionModel expected, SubscriptionModel given)
        {
            // Subscription
            Assert.Same(expected.Id, given.Id);
            Assert.Same(expected.DisplayName, given.DisplayName);
            Assert.Same(expected.SubscriptionId, given.SubscriptionId);
            Assert.Same(expected.TenantId, given.TenantId);
            Assert.Same(expected.State, given.State);
            Assert.Same(expected.OfferId, given.OfferId);
        }

        [Fact]
        public void TestListSubscriptions()
        {
            RunTest((client) =>
            {
                var subscriptions = client.Subscriptions.List();

                subscriptions.ForEach(ValidateSubscription);
            });
        }

        [Fact]
        public void TestGetSubscription()
        {
            RunTest((client) =>
            {
                var subscriptions = client.Subscriptions.List();
                subscriptions.ForEach(subscription =>
                {
                    ValidateSubscription(subscription);
                    client.Subscriptions.Get(subscription.SubscriptionId);
                });
            });
        }


        [Fact(Skip ="true")]
        //The test would fail with the following as we try to create the subscription as ServicePrincipal Identity which is not allowed
        //The request identity does not contain valid name claim type and is not allowed to create new subscription.
        //The call has been validated with user identity manually
        public void TestCreateUpdateAndThenDeleteSubscription()
        {
            RunTest((client) =>
            {
                var subscriptionId = Guid.NewGuid().ToString();
                var offer = client.Offers.List().GetFirst();

                var result = client.Subscriptions.CreateOrUpdate(
                    subscriptionId,
                    new SubscriptionModel(
                        displayName: "Test Subscription",
                        offerId: offer.Id,
                        subscriptionId: subscriptionId,
                        state: SubscriptionState.Enabled));

                var createdSubscription = client.Subscriptions.Get(subscriptionId);

                AssertSame(result, createdSubscription);

                client.Subscriptions.Delete(subscriptionId);

                var deletedSubscription = client.Subscriptions.Get(subscriptionId);
                Assert.Null(deletedSubscription);
            });
        }
    }
}
