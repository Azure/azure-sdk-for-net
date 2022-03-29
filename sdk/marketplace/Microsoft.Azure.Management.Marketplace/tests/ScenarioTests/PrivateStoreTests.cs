// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Marketplace.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Marketplace.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class PrivateStoreTests
    {
        readonly string PrivateStoreId = "3bc6b734-0508-42db-849e-7a60818a96fc";
        readonly string TestSubscriptionName = "Renamed JEDI Sub";
        readonly string testSubscription = "bc17bb69-1264-4f90-a9f6-0e51e29d5281";
        readonly string TestCollectionName = "TestCollection";
        readonly string collectionId = "6408057d-3c16-4c09-bd4b-4aa0f2bb6a17";

        readonly string TargetTestCollectionName = "TargetTestCollection";
        readonly string TargetcollectionId = "1065c936-3533-4af5-b636-cc75136d696f";

        readonly string offerId = "data3-limited-1019419.d3_azure_managed_services";     
        readonly string requestApprovalId = "data3-limited-1019419.d3_azure_managed_services";
        readonly string publisherId = "data3-limited-1019419";
        readonly string planId = "d3-azure-health-check";
        readonly string managedAzurePlanId = "data3-managed-azure-plan";
        readonly string managedAzureOptimiser = "data3-azure-optimiser-plan";

        [Fact]
        public void PrivateStoresTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
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

        // Upserts collections to privateStore
        private void SetUp(MarketplaceRPServiceClient client) {
            // Check privateStore exist
            var privateStore = client.PrivateStore.Get(PrivateStoreId);
            Assert.NotNull(privateStore);

            // Clean test collection if exist
            try
            {
                client.PrivateStoreCollection.Delete(PrivateStoreId, collectionId);
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("NotFound"))
                {
                    throw;
                }
            }

            try
            {
                client.PrivateStoreCollection.Delete(PrivateStoreId, TargetcollectionId);
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("NotFound"))
                {
                    throw;
                }
            }
            // Create Test Collections
            Collection testCollection = new Collection
            {
                CollectionName = TestCollectionName,
                AllSubscriptions = false,
                SubscriptionsList = new List<string> { testSubscription }
            };

            Collection targetTestCollection = new Collection
            {
                CollectionName = TargetTestCollectionName,
                AllSubscriptions = false,
                SubscriptionsList = new List<string> { testSubscription }
            };

            client.PrivateStoreCollection.CreateOrUpdate(PrivateStoreId, collectionId, testCollection);
            client.PrivateStoreCollection.CreateOrUpdate(PrivateStoreId, TargetcollectionId, targetTestCollection);
        }

        // Delete collections from private store
        private void CleanUp(MarketplaceRPServiceClient client) {
            // Deleting test collections
            client.PrivateStoreCollection.Delete(PrivateStoreId, collectionId);
            client.PrivateStoreCollection.Delete(PrivateStoreId, TargetcollectionId);
        }
        
        [Fact]
        public void UpsertCollectionTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);
                    // Assert collections exists
                    var TestCollection = client.PrivateStoreCollection.Get(PrivateStoreId, collectionId);
                    Assert.NotNull(TestCollection);
                    
                    var TargetTestCollection = client.PrivateStoreCollection.Get(PrivateStoreId, TargetcollectionId);
                    Assert.NotNull(TargetTestCollection);

                    var collections = client.PrivateStoreCollection.List(PrivateStoreId);
                    Assert.NotNull(collections);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void BulkCollectionActionTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);

                    // Enable collections
                    BulkCollectionsPayload bulkCollectionsPayload = new BulkCollectionsPayload
                    {
                        Action = "EnableCollections",
                        CollectionIds = new List<string>() { collectionId, TargetcollectionId }
                    };
                    client.PrivateStore.BulkCollectionsAction(PrivateStoreId, bulkCollectionsPayload);

                    var TestCollection = client.PrivateStoreCollection.Get(PrivateStoreId, collectionId);
                    Assert.NotNull(TestCollection);
                    Assert.True(TestCollection.Enabled);

                    var targetTestCollection = client.PrivateStoreCollection.Get(PrivateStoreId, TargetcollectionId);
                    Assert.NotNull(targetTestCollection);
                    Assert.True(targetTestCollection.Enabled);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void CollectionsToSubscriptionsMappingTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);

                    // Check collection to subscription mapping
                    CollectionsToSubscriptionsMappingProperties collectionsToSubscriptionsMappingProperties = new CollectionsToSubscriptionsMappingProperties
                    {
                        SubscriptionIds = new List<string>() { testSubscription }
                    };
                    CollectionsToSubscriptionsMappingPayload collectionsToSubscriptionsMappingPayload = new CollectionsToSubscriptionsMappingPayload
                    {
                        Properties = collectionsToSubscriptionsMappingProperties
                    };
                    var collectionToSubscriptionMapping = client.PrivateStore.CollectionsToSubscriptionsMapping(PrivateStoreId, collectionsToSubscriptionsMappingPayload);
                    Assert.Equal(testSubscription, collectionToSubscriptionMapping.Details[collectionId].Subscriptions.First());

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void UpsertCollectionOfferTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);
                    var testCollectionOffers = client.PrivateStoreCollectionOffer.List(PrivateStoreId, collectionId);
                    Assert.True(testCollectionOffers.Count() == 0);

                    BulkCollectionsPayload bulkCollectionsPayload = new BulkCollectionsPayload
                    {
                        Action = "EnableCollections",
                        CollectionIds = new List<string>() { collectionId, TargetcollectionId }
                    };
                    client.PrivateStore.BulkCollectionsAction(PrivateStoreId, bulkCollectionsPayload);

                    // Create offer in the Test collection
                    var offerToUpdate = new Offer
                    {
                        ETag = "57002de5-0000-0300-0000-5eaee7e50000",
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };
                    var createCollectionOffer = client.PrivateStoreCollectionOffer.CreateOrUpdate(PrivateStoreId, offerId, collectionId, offerToUpdate);
                    
                    // Check offer in collection                  
                    var privateStoreOffers = client.PrivateStore.QueryOffersMethod(PrivateStoreId);
                    Assert.Contains(privateStoreOffers.Value, x => x.UniqueOfferId == offerId);

                    client.PrivateStoreCollectionOffer.Delete(PrivateStoreId, offerId, collectionId);
                    var targetTestCollectionOffers = client.PrivateStoreCollectionOffer.List(PrivateStoreId, collectionId);
                    Assert.True(targetTestCollectionOffers.Count() == 0);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void TransferOffersTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);
                    // Create offer in the Test collection
                    var offerToUpdate = new Offer
                    {
                        ETag = "57002de5-0000-0300-0000-5eaee7e50000",
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };
                    var createCollectionOffer = client.PrivateStoreCollectionOffer.CreateOrUpdate(PrivateStoreId, offerId, collectionId, offerToUpdate);
                  
                    // Transfer offer to target collection
                    TransferOffersProperties transferOffersProperties = new TransferOffersProperties
                    {
                        TargetCollections = new List<string>() { TargetcollectionId },
                        Operation = "copy",
                        OfferIdsList = new List<string>() { offerId }
                    };
                    var transferOffersOperation = client.PrivateStoreCollection.TransferOffers(PrivateStoreId, collectionId, transferOffersProperties);

                    var transsferedOffer = client.PrivateStoreCollectionOffer.Get(PrivateStoreId, offerId, TargetcollectionId);
                    Assert.Equal(transsferedOffer.UniqueOfferId, offerId);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void CreateAndWithdrawApprovalRequestTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);

                    //create approval request
                    PlanDetails planDetails = new PlanDetails
                    {
                        PlanId = planId,
                        Justification = "because ...",
                        SubscriptionId = testSubscription,
                        SubscriptionName = TestSubscriptionName
                    };

                    RequestApprovalResource requestApprovalResource = new RequestApprovalResource
                    {
                        PublisherId = "data3-limited-1019419",
                        PlansDetails = new List<PlanDetails>() { planDetails }
                    };

                    try
                    {
                        var approvalRequest = client.PrivateStore.CreateApprovalRequest(PrivateStoreId, requestApprovalId, requestApprovalResource);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("BadRequest"))
                        {
                            throw;
                        }
                    }

                    // Assert notification arrived
                    var notificationState = client.PrivateStore.QueryNotificationsState(PrivateStoreId);
                    Assert.Contains(notificationState.ApprovalRequests, x => x.OfferId == requestApprovalId);

                    var adminRequestApproval = client.PrivateStore.GetAdminRequestApproval(publisherId, PrivateStoreId, requestApprovalId);
                    Assert.Equal("Pending", adminRequestApproval.AdminAction);

                    RequestDetails requestDetails = new RequestDetails
                    {
                        PublisherId = publisherId,
                        PlanIds = new List<string> { planId, managedAzurePlanId, managedAzureOptimiser },
                        SubscriptionId = testSubscription
                    };
                    QueryRequestApprovalProperties queryRequestApprovalProperties = new QueryRequestApprovalProperties
                    {
                        Properties = requestDetails
                    };
                    var requestApproval = client.PrivateStore.QueryRequestApprovalMethod(PrivateStoreId, requestApprovalId, queryRequestApprovalProperties);
                    Assert.Equal("Pending", requestApproval.PlansDetails[planId].Status);

                    // Withdraw request
                    WithdrawProperties withdrawProperties = new WithdrawProperties
                    {
                        PublisherId = publisherId,
                        PlanId = planId
                    };
                    client.PrivateStore.WithdrawPlan(PrivateStoreId, requestApprovalId, withdrawProperties);

                    notificationState = client.PrivateStore.QueryNotificationsState(PrivateStoreId);
                    Assert.DoesNotContain(notificationState.ApprovalRequests, x => x.OfferId == requestApprovalId);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void ApproveByAdminNotificationTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    SetUp(client);
                    //create approval request
                    PlanDetails planDetails = new PlanDetails
                    {
                        PlanId = planId,
                        Justification = "because ...",
                        SubscriptionId = testSubscription,
                        SubscriptionName = TestSubscriptionName
                    };
                    RequestApprovalResource requestApprovalResource = new RequestApprovalResource
                    {
                        PublisherId = "data3-limited-1019419",
                        PlansDetails = new List<PlanDetails>() { planDetails }
                    };

                    try
                    {
                        var approvalRequest = client.PrivateStore.CreateApprovalRequest(PrivateStoreId, requestApprovalId, requestApprovalResource);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("BadRequest"))
                        {
                            throw;
                        }
                    }
                    var notificationState = client.PrivateStore.QueryNotificationsState(PrivateStoreId);
                    Assert.Contains(notificationState.ApprovalRequests, x => x.OfferId == requestApprovalId);

                    // Approve request by admin
                    AdminRequestApprovalsResource adminRequestApprovalsResource = new AdminRequestApprovalsResource
                    {
                        PublisherId = publisherId,
                        AdminAction = "Approved",
                        ApprovedPlans = new List<string>() { planId },
                        Comment = "I'm ok with that",
                        CollectionIds = new List<string>() { collectionId }
                    };
                    client.PrivateStore.UpdateAdminRequestApproval(PrivateStoreId, requestApprovalId, adminRequestApprovalsResource);

                    var collectionOffers = client.PrivateStoreCollectionOffer.List(PrivateStoreId, collectionId);
                    Assert.Contains(collectionOffers, x => x.UniqueOfferId == requestApprovalId);

                    notificationState = client.PrivateStore.QueryNotificationsState(PrivateStoreId);
                    Assert.DoesNotContain(notificationState.ApprovalRequests, x => x.OfferId == requestApprovalId);

                    CleanUp(client);
                }
            }
        }

        [Fact]
        public void PrivateStoreBillingAccountTest()
        {           
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    var billigAccount = client.PrivateStore.BillingAccounts(PrivateStoreId);
                    Assert.Equal("direct-TSZ", billigAccount.BillingAccounts.First());
                }
            }
        }
    }
}
