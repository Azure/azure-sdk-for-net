// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using Subscriptions.Tests.src.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Subscriptions.Tests
{
    public class OfferTests : SubscriptionsTestBase
    {
 
        private void ValidateOffer(Offer offer) {
            // Resource
            Assert.NotNull(offer);
            Assert.NotNull(offer.Id);
            Assert.NotNull(offer.Location);
            Assert.NotNull(offer.Name);
            Assert.NotNull(offer.Type);

            // Offer
            Assert.NotNull(offer.DisplayName);
            Assert.NotNull(offer.State);
            Assert.NotNull(offer.BasePlanIds);
        }

        private void AssertSame(Offer expected, Offer given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Location, given.Location);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.Type, given.Type);

            // Offer
            Assert.Equal(expected.DisplayName, given.DisplayName);
            Assert.Equal(expected.State, given.State);
            Assert.Equal(expected.BasePlanIds, given.BasePlanIds);
        }

        [Fact]
        public void TestListAllOffers() {
            RunTest((client) => {
                var allOffers = client.Offers.ListAll();
                allOffers.ForEach(client.Offers.ListAllNext, ValidateOffer);
            });
            }

        [Fact]
        public void TestListOffers() {
            RunTest((client) => {
                var allOffers = client.Offers.ListAll();
                var resourceGroups = new System.Collections.Generic.HashSet<string>();

                allOffers.ForEach(client.Offers.ListAllNext, (offer) => {
                    resourceGroups.Add(Common.GetResourceGroupFromId(offer.Id));
                });

                resourceGroups.ForEach((rg) => {
                    var offers = client.Offers.List(rg);
                    offers.ForEach(client.Offers.ListNext, ValidateOffer);
                });
            });
        }

        [Fact]
        public void TestGetAllOffers() {
            RunTest((client) => {
                var allOffers = client.Offers.ListAll();
                var resourceGroups = new System.Collections.Generic.HashSet<string>();
                allOffers.ForEach(client.Offers.ListAllNext, (offer) => {
                    resourceGroups.Add(Common.GetResourceGroupFromId(offer.Id));
                });

                resourceGroups.ForEach((rg) => {
                    client.Offers.List(rg).ForEach(client.Offers.ListNext, (offer) => {
                        var result = client.Offers.Get(rg, offer.Name);
                        AssertSame(offer, result);
                    });
                });
            });
        }

        [Fact]
        public void TestGetOffer() {
            RunTest((client) => {
                var offer = client.Offers.ListAll().GetFirst();
                var rg = Common.GetResourceGroupFromId(offer.Id);
                var result = client.Offers.Get(rg, offer.Name);
                AssertSame(offer, result);
            });
        }

        [Fact]
        public void TestCreateUpdateThenDeleteOffer() {
            RunTest((client) => {
                var offerName = "o4";
                var plan = client.Plans.Get(TestContext.ResourceGroupName, TestContext.StoragePlanName);
                var offer = new Offer()
                {
                    Description = "This is a test Offer",
                    DisplayName = "Test Offer",
                    Location = TestContext.LocationName,
                    OfferName = offerName,
                    MaxSubscriptionsPerAccount = 100,
                    BasePlanIds = new List<string>() {plan.Id}
                };
                

                var result = client.Offers.CreateOrUpdate(TestContext.ResourceGroupName, offerName, offer);

                offer = client.Offers.Get(TestContext.ResourceGroupName, offerName);

                AssertSame(offer, result);

                client.Offers.Delete(TestContext.ResourceGroupName, offerName);
            });
        }
    }
}
