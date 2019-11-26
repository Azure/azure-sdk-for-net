// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using System.Linq;
using Xunit;

namespace Subscriptions.Tests
{
    public class DelegatedProviderTests : SubscriptionsTestBase
    {

        private void ValidateSubscription(Subscription subscription) {
            // DelegatedProvider
            Assert.NotNull(subscription);
            Assert.NotNull(subscription.Id);

            Assert.NotNull(subscription.OfferId);
            Assert.NotNull(subscription.Owner);
            Assert.NotNull(subscription.RoutingResourceManagerType);
            Assert.NotNull(subscription.SubscriptionId);
            Assert.NotNull(subscription.DisplayName);
            Assert.NotNull(subscription.State);
            Assert.NotNull(subscription.TenantId);
        }

        private void AssertSame(Subscription expected, Subscription given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);

            // DelegatedProvider
            Assert.Equal(expected.DelegatedProviderSubscriptionId, given.DelegatedProviderSubscriptionId);
            Assert.Equal(expected.DisplayName, given.DisplayName);
            Assert.Equal(expected.ExternalReferenceId, given.ExternalReferenceId);
            Assert.Equal(expected.OfferId, given.OfferId);
            Assert.Equal(expected.Owner, given.Owner);
            Assert.Equal(expected.RoutingResourceManagerType, given.RoutingResourceManagerType);
            Assert.Equal(expected.State, given.State);
            Assert.Equal(expected.SubscriptionId, given.SubscriptionId);
            Assert.Equal(expected.TenantId, given.TenantId);
        }

        [Fact]
        public void TestListDelegatedProviders() {
            RunTest((client) => {
                var delegatedProviders = client.DelegatedProviders.List();
                delegatedProviders.ForEach(ValidateSubscription);
            });
        }

        [Fact]
        public void TestGetAllDelegatedProviders() {
            RunTest((client) => {
                var delegatedProviders = client.DelegatedProviders.List();
                delegatedProviders.ForEach((provider) => {
                    var result = client.DelegatedProviders.Get(provider.SubscriptionId);
                    AssertSame(provider, result);
                });
            });
        }

        [Fact]
        public void TestGetDelegatedProvider() {
            RunTest((client) => {
                var provider = client.DelegatedProviders.List().First();
                var result = client.DelegatedProviders.Get(provider.SubscriptionId);
                AssertSame(provider, result);
            });
        }
    }
}
