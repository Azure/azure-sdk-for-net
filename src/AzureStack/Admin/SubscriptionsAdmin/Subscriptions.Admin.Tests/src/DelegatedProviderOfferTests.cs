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
    public class DelegatedProviderOfferTests : SubscriptionsTestBase
    {

        private void ValidateDelegatedProviderOffer(DelegatedProviderOffer offer) {
            Assert.NotNull(offer);
            Assert.NotNull(offer.Id);
            Assert.NotNull(offer.Location);
            Assert.NotNull(offer.Name);
            Assert.NotNull(offer.Type);
        }

        [Fact]
        public void TestListDelegatedProviderOffers() {
            RunTest((client) => {
                var providers = client.DelegatedProviders.List();
                providers.ForEach((provider) => {
                    var offers = client.DelegatedProviderOffers.List(provider.DelegatedProviderSubscriptionId);
                    offers.ForEach(offer => ValidateDelegatedProviderOffer(offer));
                });
            });
        }
    }
}
