// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using System;
using Xunit;
using System.Linq;
using Subscriptions.Tests.src.Helpers;

namespace Subscriptions.Tests
{
    public class OfferDelegationTests : SubscriptionsTestBase
    {
        private void ValidateOfferDelegation(OfferDelegation item) {
            // Resource
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Location);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);

            // OfferDelegation
            Assert.NotNull(item.SubscriptionId);
        }

        private void AssertSame(OfferDelegation expected, OfferDelegation given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Location, given.Location);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.Type, given.Type);

            // OfferDelegation
            Assert.Equal(expected.SubscriptionId, given.SubscriptionId);
        }

        [Fact]
        public void TestListOfferDelegations() {
            RunTest((client) => {
                var offers = client.Offers.ListAll();
                Common.MapOverIPage(offers, client.Offers.ListAllNext, (offer) => {
                    var resourceGroup = Common.GetResourceGroupFromId(offer.Id);
                    var offerDelegations = client.OfferDelegations.List(resourceGroup, offer.Name);
                    offerDelegations.ForEach(client.OfferDelegations.ListNext, ValidateOfferDelegation);
                });
            });
        }

        [Fact]
        public void TestListAllOfferDelegations() {
            RunTest((client) => {
                var offers = client.Offers.ListAll();
                Common.MapOverIPage(offers, client.Offers.ListAllNext, (offer) => {
                    var resourceGroup = Common.GetResourceGroupFromId(offer.Id);
                    var offerDelegations = client.OfferDelegations.List(resourceGroup, offer.Name);
                    offerDelegations.ForEach(client.OfferDelegations.ListNext, (dOffer) => {
                        var result = client.OfferDelegations.Get(resourceGroup, offer.Name, dOffer.Name.Split(new[] { '/' })[1]);
                        AssertSame(dOffer, result);
                    });
                });
            });
        }

        [Fact]
        //Test asssumes that theres a offer delegation for the first offer
        public void TestGetOfferDelegation() {
            RunTest((client) => {
                var offer = client.Offers.ListAll().GetFirst();
                var resourceGroup = Common.GetResourceGroupFromId(offer.Id);
                var offerDelegation = client.OfferDelegations.List(resourceGroup, offer.Name).GetFirst();
                var offerDelegationName = (offerDelegation.Name.Split(new[] { '/' })[1]);
                var result = client.OfferDelegations.Get(resourceGroup, offer.Name, offerDelegationName);
                AssertSame(offerDelegation, result);
            });
        }

        [Fact]
        //Test assumes that there is a delegated provider(reseller) subscription
        public void TestCreateUpdateThenDeleteOfferDelegation() {
            RunTest((client) => {
                var offer = client.Offers.Get(TestContext.ResourceGroupName, TestContext.OfferToDelegateName);
                var subscription = client.Subscriptions.Get(TestContext.DelegatedProviderSubscriptionId);
                var resourceGroup = Common.GetResourceGroupFromId(offer.Id);
                var offerDelegationName = "testOfferDelegation";

                var offerDelegation = new OfferDelegation()
                {
                    SubscriptionId = subscription.SubscriptionId,
                    Location = TestContext.LocationName,
                };

                var result = client.OfferDelegations.CreateOrUpdate(resourceGroup, offer.Name, offerDelegationName, offerDelegation);

                var createdDelegation = client.OfferDelegations.Get(resourceGroup, offer.Name, offerDelegationName);

                AssertSame(createdDelegation, result);

                client.OfferDelegations.Delete(resourceGroup, offer.Name, offerDelegationName);
            });
        }

    }
}
