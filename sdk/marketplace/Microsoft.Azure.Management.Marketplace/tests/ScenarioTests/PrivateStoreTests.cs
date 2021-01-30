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

                    var originalAvailability = privateStore?.Availability;
                    var availability = privateStore?.Availability == "enabled" ? "disabled" : "enabled";

                    var privateStoreUpdate = new PrivateStore
                    {
                        Availability = availability,
                        ETag = privateStore?.ETag
                    };

                    client.PrivateStore.CreateOrUpdate(privateStore?.PrivateStoreId, privateStoreUpdate);

                    privateStores = client.PrivateStore.List();
                    privateStore = privateStores.FirstOrDefault();
                    Assert.Equal(availability, privateStore?.Availability);
                    
                    privateStoreUpdate = new PrivateStore
                    {
                        Availability = originalAvailability,
                        ETag = privateStore?.ETag
                    };

                    client.PrivateStore.CreateOrUpdate(privateStore?.PrivateStoreId, privateStoreUpdate);
                }
            }
        }

        [Fact]
        public void PrivateStoreOffersTest()
        {
            var privateStoreId = "a70d384d-ec34-47dd-9d38-ec6df452cba1";
            var offerId = "data3-limited-1019419.d3_azure_managed_services";
            var planId = "data3-managed-azure-plan";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceManagementClient>())
                {
                    //clean data before test
                    var offers = client.PrivateStoreOffers.List(privateStoreId);
                    foreach (var item in offers)
                    {
                        if (item.UniqueOfferId == offerId)
                        {
                            client.PrivateStoreOffer.Delete(privateStoreId, offerId);
                            var o = client.PrivateStoreOffer.Get(privateStoreId, offerId);
                            Assert.Null(o);
                            break;
                        }
                    }

                    //test
                    var offerToUpdate = new Offer
                    {
                        ETag = "57002de5-0000-0300-0000-5eaee7e50000",
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };

                    var offer = client.PrivateStoreOffer.CreateOrUpdate(privateStoreId, offerId, offerToUpdate);
                    Assert.Equal(offer.UniqueOfferId, offerId);
                    Assert.True(offer.SpecificPlanIdsLimitation.Count == 1);

                    offer = client.PrivateStoreOffer.Get(privateStoreId, offerId);
                    Assert.NotNull(offer);
                    
                    client.PrivateStoreOffer.Delete(privateStoreId, offerId);

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
