// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions;
using Microsoft.AzureStack.Management.Subscriptions.Models;
using System;
using Xunit;

namespace Subscriptions.Tests
{
    public class SubscriptionTests : SubscriptionsTestBase
    {

        private void ValidateSubscription(Subscription subscription) {
            // Subscription
            Assert.NotNull(subscription);
            Assert.NotNull(subscription.Id);
            Assert.NotNull(subscription.DisplayName);
            Assert.NotNull(subscription.SubscriptionId);
            Assert.NotNull(subscription.TenantId);
            Assert.NotNull(subscription.State);
            Assert.NotNull(subscription.OfferId);
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


        //[Fact]
        //public void TestCreateUpdateAndThenDeleteSubscription()
        //{
        //    RunTest((client) =>
        //    {
        //        var subscriptionId = Guid.NewGuid().ToString();
        //        var offer = client.Offers.List().GetFirst();

        //        var result = client.Subscriptions.CreateOrUpdate(
        //            subscriptionId,
        //            new Subscription(
        //                name: "TestSubscription",
        //                displayName: "Test Subscription",
        //                offerId: offer.Id,
        //                subscriptionId: subscriptionId,
        //                state: SubscriptionState.Enabled));

        //        var createdSubscription = client.Subscriptions.Get(subscriptionId);

        //        AssertSame(result, createdSubscription);

        //        client.Subscriptions.Delete(subscriptionId);

        //        var deletedSubscription = client.Subscriptions.Get(subscriptionId);
        //        Assert.Null(deletedSubscription);
        //    });
        //}
    }
}
