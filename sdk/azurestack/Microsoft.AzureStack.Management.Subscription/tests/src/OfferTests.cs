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
    public class OfferTests : SubscriptionsTestBase
    {

        private void ValidateOffer(Offer offer) {
            // Subscription
            Assert.NotNull(offer);
            Assert.NotNull(offer.Id);
            Assert.NotNull(offer.Name);
            Assert.NotNull(offer.DisplayName);
        }
        
        private void AssertSame(Offer expected, Offer given) {
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.DisplayName, given.DisplayName);
            Assert.Equal(expected.Description, given.Description);
        }

        [Fact]
        public void TestListRootOffers()
        {
            RunTest((client) =>
            {
                client.Offers.List().ForEach(ValidateOffer);
            });
        }


        [Fact]
        public void TestListDelegatedProviderOffers()
        {
            RunTest((client) =>
            {
                client.DelegatedProviderOffers.List("default").ForEach(ValidateOffer);
            });
        }

        [Fact]
        public void TestGetDelegatedProviderOffers()
        {
            RunTest((client) =>
            {
                var offerFromList = client.DelegatedProviderOffers.List("default").GetFirst();

                var offerFromGet = client.DelegatedProviderOffers.Get("default", offerFromList.Name);
                ValidateOffer(offerFromGet);
                AssertSame(offerFromList, offerFromGet);
            });
        }
    }
}
