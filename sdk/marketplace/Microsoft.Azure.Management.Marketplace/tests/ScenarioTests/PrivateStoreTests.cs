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

        [Fact]
        public void PrivateStoreCollectionTest()
        {
            string privateStoreId = "3bc6b734-0508-42db-849e-7a60818a96fc";
            string testSubscription = "bc17bb69-1264-4f90-a9f6-0e51e29d5281";
            string TestCollectionName = "TestCollection";            
            string collectionId = "6408057d-3c16-4c09-bd4b-4aa0f2bb6a17";

            string TargetTestCollectionName = "TargetTestCollection";
            string TargetcollectionId = "1065c936-3533-4af5-b636-cc75136d696f";

            var offerId = "data3-limited-1019419.d3_azure_managed_services";
            var planId = "data3-managed-azure-plan";
    
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    // Check privateStore exist
                    var privateStore = client.PrivateStore.Get(privateStoreId);
                    Assert.NotNull(privateStore);

                    // Clean test collection if exist
                    try
                    {
                        client.PrivateStoreCollection.Delete(privateStoreId, collectionId);
                    }
                    catch (Exception ex) {
                        if (!ex.Message.Contains("NotFound")) {
                            throw;
                        }
                    }

                    try
                    { 
                        client.PrivateStoreCollection.Delete(privateStoreId, TargetcollectionId);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("NotFound"))
                        {
                            throw;
                        }
                    }
                    // Create Test Collections
                    Collection testCollection = new Collection {
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

                    client.PrivateStoreCollection.CreateOrUpdate(privateStoreId, collectionId, testCollection);
                    client.PrivateStoreCollection.CreateOrUpdate(privateStoreId, TargetcollectionId, targetTestCollection);
                    var collections = client.PrivateStoreCollection.List(privateStoreId);
                    Assert.NotNull(collections);
                    
                    // Enable collections
                    BulkCollectionsPayload bulkCollectionsPayload = new BulkCollectionsPayload {
                        Action = "EnableCollections",
                        CollectionIds = new List<string>() { collectionId, TargetcollectionId }
                    };
                    client.PrivateStore.BulkCollectionsAction(privateStoreId, bulkCollectionsPayload);

                    var TestCollection = client.PrivateStoreCollection.Get(privateStoreId, collectionId);
                    Assert.NotNull(TestCollection);
                    Assert.True(TestCollection.Enabled);

                    var TargetTestCollection = client.PrivateStoreCollection.Get(privateStoreId, TargetcollectionId);
                    Assert.NotNull(TargetTestCollection);
                    
                    // Check collection to subscription mapping
                    CollectionsToSubscriptionsMappingProperties collectionsToSubscriptionsMappingProperties = new CollectionsToSubscriptionsMappingProperties
                    {
                        SubscriptionIds = new List<string>() { testSubscription }
                    };
                    CollectionsToSubscriptionsMappingPayload collectionsToSubscriptionsMappingPayload = new CollectionsToSubscriptionsMappingPayload {
                        Properties = collectionsToSubscriptionsMappingProperties
                    };
                    var collectionToSubscriptionMapping = client.PrivateStore.CollectionsToSubscriptionsMapping(privateStoreId, collectionsToSubscriptionsMappingPayload);
                    Assert.Equal(testSubscription, collectionToSubscriptionMapping.Details[collectionId].Subscriptions.First() ); 

                    var testCollectionOffers = client.PrivateStoreCollectionOffer.List(privateStoreId, collectionId);
                    Assert.True(testCollectionOffers.Count() == 0);

                    // Create offer in the Test collection
                    var offerToUpdate = new Offer
                    {
                        ETag = "57002de5-0000-0300-0000-5eaee7e50000",
                        SpecificPlanIdsLimitation = new List<string> { planId }
                    };
                    var createCollectionOffer = client.PrivateStoreCollectionOffer.CreateOrUpdate(privateStoreId, offerId, collectionId, offerToUpdate);

                    // Check offer in collection
                    bool offerFound = false;
                    var privateStoreOffers = client.PrivateStore.QueryOffersMethod(privateStoreId);
                    foreach (OfferProperties offer in privateStoreOffers.Value) {
                        if (offer.UniqueOfferId == offerId) {
                            offerFound = true;
                            break;
                        }
                    }
                    Assert.True(offerFound);

                    // Transfer offer to target collection
                    TransferOffersProperties transferOffersProperties = new TransferOffersProperties {
                        TargetCollections = new List<string>() { TargetcollectionId },
                        Operation = "copy",
                        OfferIdsList = new List<string>() { offerId }
                    };
                    var transferOffersOperation = client.PrivateStoreCollection.TransferOffers(privateStoreId, collectionId, transferOffersProperties);

                    var transsferedOffer = client.PrivateStoreCollectionOffer.Get(privateStoreId, offerId, TargetcollectionId);
                    Assert.Equal(transsferedOffer.UniqueOfferId , offerId);

                    // Delete test offer from collection
                    client.PrivateStoreCollectionOffer.Delete(privateStoreId, offerId, TargetcollectionId);
                    var targetTestCollectionOffers = client.PrivateStoreCollectionOffer.List(privateStoreId, TargetcollectionId);
                    Assert.True(targetTestCollectionOffers.Count() == 0);
                   
                    // Deleting test collections
                    client.PrivateStoreCollection.Delete(privateStoreId, collectionId);
                    client.PrivateStoreCollection.Delete(privateStoreId, TargetcollectionId);
                }
            }
        }

        [Fact]
        public void PrivateStoreNotificationsTest()
        {
            string privateStoreId = "3bc6b734-0508-42db-849e-7a60818a96fc";
            string testSubscription = "bc17bb69-1264-4f90-a9f6-0e51e29d5281";
            string testSubscriptionName = "Renamed JEDI Sub";
            string requestAprrovalId = "data3-limited-1019419.d3_azure_managed_services";
            string publisherId = "data3-limited-1019419";
            string TestCollectionName = "TestCollection";
            string collectionId = "6408057d-3c16-4c09-bd4b-4aa0f2bb6a17";
            string planId = "d3-azure-health-check";
            string managedAzurePlanId = "data3-managed-azure-plan";
            string managedAzureOptimiser = "data3-azure-optimiser-plan";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    //clean test collection if exist
                    try
                    {
                        client.PrivateStoreCollection.Delete(privateStoreId, collectionId);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("NotFound"))
                        {
                            throw;
                        }
                    }
                    
                    // create Test Collections
                    Collection testCollection = new Collection
                    {
                        CollectionName = TestCollectionName,
                        AllSubscriptions = false,
                        SubscriptionsList = new List<string> { testSubscription }
                    };
                    client.PrivateStoreCollection.CreateOrUpdate(privateStoreId, collectionId, testCollection);

                    //create approval request
                    PlanDetails planDetails = new PlanDetails { 
                    PlanId = planId,
                    Justification = "because ...",
                    SubscriptionId = testSubscription,
                    SubscriptionName = testSubscriptionName
                    };

                    RequestApprovalResource requestApprovalResource = new RequestApprovalResource {
                        PublisherId = "data3-limited-1019419",
                        PlansDetails = new List<PlanDetails>() { planDetails }
                    };

                    try
                    {
                        var approvalRequest = client.PrivateStore.CreateApprovalRequest(privateStoreId, requestAprrovalId, requestApprovalResource);
                    }
                    catch (Exception ex) {
                        if (!ex.Message.Contains("BadRequest")) {
                            throw;
                        }  
                    }

                    // Assert notification arrived
                    var notificationState = client.PrivateStore.QueryNotificationsState(privateStoreId);
                    Assert.Contains(notificationState.ApprovalRequests, x => x.OfferId == requestAprrovalId);

                    var adminRequestApproval = client.PrivateStore.GetAdminRequestApproval(publisherId, privateStoreId, requestAprrovalId);
                    Assert.Equal("Pending", adminRequestApproval.AdminAction);

                    RequestDetails requestDetails = new RequestDetails {
                    PublisherId = publisherId,
                    PlanIds = new List<string> { planId, managedAzurePlanId, managedAzureOptimiser } ,
                    SubscriptionId = testSubscription
                    };
                    QueryRequestApprovalProperties queryRequestApprovalProperties = new QueryRequestApprovalProperties {
                        Properties = requestDetails
                    };
                    var requestApproval = client.PrivateStore.QueryRequestApprovalMethod(privateStoreId, requestAprrovalId, queryRequestApprovalProperties);
                    Assert.Equal("Pending", requestApproval.PlansDetails[planId].Status);

                    // Withdraw request
                    WithdrawProperties withdrawProperties = new WithdrawProperties {
                        PublisherId = publisherId,
                        PlanId = planId
                    };
                    client.PrivateStore.WithdrawPlan(privateStoreId,requestAprrovalId, withdrawProperties);
                    
                    notificationState = client.PrivateStore.QueryNotificationsState(privateStoreId);
                    Assert.DoesNotContain(notificationState.ApprovalRequests, x => x.OfferId == requestAprrovalId);

                    // Send request to add offer to collection again
                    try
                    {
                        var approvalRequest = client.PrivateStore.CreateApprovalRequest(privateStoreId, requestAprrovalId, requestApprovalResource);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("BadRequest"))
                        {
                            throw;
                        }
                    }
                    var notificationStateSecond = client.PrivateStore.QueryNotificationsState(privateStoreId);
                    bool requestFoundSecond = false;
                    foreach (var request in notificationStateSecond.ApprovalRequests)
                    {
                        if (request.OfferId == requestAprrovalId)
                        {
                            requestFoundSecond = true;
                            break;
                        }
                    }
                    Assert.True(requestFoundSecond);

                    // Approve request by admin
                    AdminRequestApprovalsResource adminRequestApprovalsResource = new AdminRequestApprovalsResource {
                        PublisherId = publisherId,
                        AdminAction = "Approved",
                        ApprovedPlans = new List<string>() { planId },
                        Comment = "I'm ok with that",
                        CollectionIds = new List<string>() { collectionId }
                    };
                    client.PrivateStore.UpdateAdminRequestApproval(privateStoreId, requestAprrovalId, adminRequestApprovalsResource);

                    var collectionOffers = client.PrivateStoreCollectionOffer.List(privateStoreId, collectionId);
                    Assert.Contains(collectionOffers, x => x.UniqueOfferId == requestAprrovalId);

                    client.PrivateStoreCollection.Delete(privateStoreId, collectionId);
                }
            }
        }

        [Fact]
        public void PrivateStoreBillingAccountTest()
        {
            string privateStoreId = "3bc6b734-0508-42db-849e-7a60818a96fc";
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MarketplaceRPServiceClient>())
                {
                    var billigAccount = client.PrivateStore.BillingAccounts(privateStoreId);
                    Assert.Equal("direct-TSZ", billigAccount.BillingAccounts.First());
                }
            }
        }
    }
}
