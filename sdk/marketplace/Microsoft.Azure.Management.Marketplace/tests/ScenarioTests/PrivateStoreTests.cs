// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Marketplace.Tests.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Marketplace.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class PrivateStoreTests
    {
        [Fact]
        public void PrivateStoresTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceManagementClient>())
                {
                    var privateStores = client.PrivateStore.List();
                    Assert.True(privateStores.Any());

                    var privateStore = privateStores.FirstOrDefault();
                    Assert.Equal("disabled", privateStore?.Availability);

                    var privateStoreUpdate = new PrivateStore
                    {

                        Availability = "enabled",
                        ETag = privateStore?.ETag
                    };

                    client.PrivateStore.CreateOrUpdate(privateStore?.PrivateStoreId, privateStoreUpdate);

                    privateStores = client.PrivateStore.List();
                    privateStore = privateStores.FirstOrDefault();
                    Assert.Equal("enabled", privateStore?.Availability);

                    privateStoreUpdate = new PrivateStore
                    {
                        Availability = "disabled",
                        ETag = privateStore?.ETag
                    };

                    client.PrivateStore.CreateOrUpdate(privateStore?.PrivateStoreId, privateStoreUpdate);
                }
            }
        }

        [Fact]
        public void PrivateStoreOffersTest()
        {
            var privateStoreId = "420c70be-a111-4152-8d48-640c069d441f";
            var offerId = "data3-limited-1019419.d3_azure_managed_services";
            var planId = "d3-azure-cost-management";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceManagementClient>())
                {
                    var offers = client.PrivateStoreOffers.List(privateStoreId);
                    Assert.True(offers.Count() == 3);

                    var offer = client.PrivateStoreOffer.Get(privateStoreId, offerId);
                    Assert.NotNull(offer);

                    client.PrivateStoreOffer.Delete(privateStoreId, offerId);

                    offers = client.PrivateStoreOffers.List(privateStoreId);
                    Assert.True(offers.Count() == 2);

                    var offerToUpdate = new Offer
                    {
                        ETag = offer.ETag,
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };

                    offer = client.PrivateStoreOffer.CreateOrUpdate(privateStoreId, offerId, offerToUpdate);
                    Assert.Equal(offer.UniqueOfferId, offerId);
                    Assert.True(offer.SpecificPlanIdsLimitation.Count == 1);

                    offers = client.PrivateStoreOffers.List(privateStoreId);
                    Assert.True(offers.Count() == 3);

                }
            }
        }

        [Fact]
        public void PrivateStorePrivateOffersTest()
        {
            var privateStoreId = "a70d384d-ec34-47dd-9d38-ec6df452cba1";
            var offerId = "test_test_pmc2pc1.test-managed-app-private-indirect-gov";
            var subscriptionId = "bc17bb69-1264-4f90-a9f6-0e51e29d5281";
            var planId = "test-managed-app";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceManagementClient>())
                {
                    var offers = client.PrivateStorePrivateOffers.List(subscriptionId, privateStoreId);
                    Assert.True(!offers.Any());


                    var offerToCreate = new Offer
                    {
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };

                    var offer = client.PrivateStorePrivateOffer.CreateOrUpdate(subscriptionId, privateStoreId, offerId, offerToCreate);
                    Assert.Equal(offer.UniqueOfferId, offerId);
                    Assert.True(offer.SpecificPlanIdsLimitation.Count == 1);

                    offers = client.PrivateStorePrivateOffers.List(subscriptionId, privateStoreId);
                    Assert.True(offers.Count() == 1);
                    var privateOffer = offers.FirstOrDefault();
                    if (privateOffer != null)
                    {
                        Assert.Equal(privateOffer.UniqueOfferId, offerId);
                    }
                    
                    client.PrivateStoreOffer.Delete(privateStoreId, offerId);

                    offers = client.PrivateStorePrivateOffers.List(subscriptionId, privateStoreId);
                    Assert.True(!offers.Any());
                }
            }
        }

    }
}
