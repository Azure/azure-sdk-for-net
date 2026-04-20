// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Marketplace.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Marketplace
{
    // Backward-compat overloads for ModelFactory methods with parameter count/type changes
    [CodeGenSuppress("PrivateStoreOfferResult", typeof(string), typeof(string), typeof(string), typeof(ETag?), typeof(Guid?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(bool?), typeof(IReadOnlyDictionary<string, Uri>), typeof(IEnumerable<PrivateStorePlan>))]
    [CodeGenSuppress("PrivateStorePlan", typeof(string), typeof(string), typeof(string), typeof(PrivateStorePlanAccessibility?), typeof(string), typeof(string))]
    [CodeGenSuppress("PrivateStoreOfferData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(string), typeof(ETag?), typeof(Guid?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(bool?), typeof(IDictionary<string, Uri>), typeof(IEnumerable<PrivateStorePlan>))]
    [CodeGenSuppress("PrivateStoreData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(PrivateStoreAvailability?), typeof(Guid?), typeof(ETag?), typeof(string), typeof(Guid?), typeof(bool?), typeof(IEnumerable<Guid>), typeof(IDictionary<string, string>), typeof(IEnumerable<NotificationRecipient>), typeof(bool?))]
    [CodeGenSuppress("PrivateStoreCollectionInfoData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(Guid?), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(bool?), typeof(long?), typeof(IEnumerable<MarketplaceRule>))]
    [CodeGenSuppress("MarketplaceAdminApprovalRequestData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(string), typeof(MarketplaceAdminAction?), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(IEnumerable<PlanRequesterDetails>), typeof(IEnumerable<Guid>), typeof(Uri))]
    [CodeGenSuppress("MarketplaceApprovalRequestData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<PrivateStorePlanDetails>), typeof(bool?), typeof(long?))]
    public static partial class ArmMarketplaceModelFactory
    {
        // PrivateStoreOfferResult: old 11-param → new 12-param (added isStopSell)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateStoreOfferResult PrivateStoreOfferResult(string uniqueOfferId, string offerDisplayName, string publisherDisplayName, ETag? eTag, Guid? privateStoreId, DateTimeOffset? createdOn, DateTimeOffset? modifiedOn, IEnumerable<string> specificPlanIdsLimitation, bool? isUpdateSuppressedDueToIdempotence, IReadOnlyDictionary<string, Uri> iconFileUris, IEnumerable<PrivateStorePlan> plans)
        {
            return PrivateStoreOfferResult(uniqueOfferId, offerDisplayName, publisherDisplayName, eTag, privateStoreId, createdOn, modifiedOn, specificPlanIdsLimitation, isUpdateSuppressedDueToIdempotence, iconFileUris, default(bool?), plans);
        }

        // Generator does not produce a factory method for QueryApprovalRequestResult
        public static QueryApprovalRequestResult QueryApprovalRequestResult(string uniqueOfferId = default, IReadOnlyDictionary<string, PrivateStorePlanDetails> plansDetails = default, ETag? eTag = default, long? messageCode = default)
        {
            return new QueryApprovalRequestResult(uniqueOfferId, plansDetails?.ToDictionary(kv => kv.Key, kv => kv.Value), eTag, messageCode, null);
        }

        // PrivateStorePlan: old 6-param → new 7-param (added isStopSell)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateStorePlan PrivateStorePlan(string skuId, string planId, string planDisplayName, PrivateStorePlanAccessibility? accessibility, string altStackReference, string stackType)
        {
            return PrivateStorePlan(skuId, planId, planDisplayName, accessibility, altStackReference, stackType, default(bool?));
        }

        // PrivateStoreOfferData: old used ResourceIdentifier id + IDictionary iconFileUris, no isStopSell
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateStoreOfferData PrivateStoreOfferData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string uniqueOfferId, string offerDisplayName, string publisherDisplayName, ETag? eTag, Guid? privateStoreId, DateTimeOffset? createdOn, DateTimeOffset? modifiedOn, IEnumerable<string> specificPlanIdsLimitation, bool? isUpdateSuppressedDueToIdempotence, IDictionary<string, Uri> iconFileUris, IEnumerable<PrivateStorePlan> plans)
        {
            return PrivateStoreOfferData(id?.ToString(), name, resourceType, systemData, uniqueOfferId, offerDisplayName, publisherDisplayName, eTag, privateStoreId, createdOn, modifiedOn, specificPlanIdsLimitation, isUpdateSuppressedDueToIdempotence, iconFileUris != null ? (IReadOnlyDictionary<string, Uri>)new Dictionary<string, Uri>(iconFileUris) : null, default(bool?), plans);
        }

        // PrivateStoreData: old used ResourceIdentifier id
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateStoreData PrivateStoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PrivateStoreAvailability? availability, Guid? privateStoreId, ETag? eTag, string privateStoreName, Guid? tenantId, bool? isGov, IEnumerable<Guid> collectionIds, IDictionary<string, string> branding, IEnumerable<NotificationRecipient> recipients, bool? sendToAllMarketplaceAdmins)
        {
            return PrivateStoreData(id?.ToString(), name, resourceType, systemData, availability, privateStoreId, eTag, privateStoreName, tenantId, isGov, collectionIds, branding, recipients, sendToAllMarketplaceAdmins);
        }

        // PrivateStoreCollectionInfoData: old used ResourceIdentifier id
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateStoreCollectionInfoData PrivateStoreCollectionInfoData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, Guid? collectionId, string collectionName, string claim, bool? areAllSubscriptionsSelected, bool? areAllItemsApproved, DateTimeOffset? approveAllItemsModifiedOn, IEnumerable<string> subscriptionsList, bool? isEnabled, long? numberOfOffers, IEnumerable<MarketplaceRule> appliedRules)
        {
            return PrivateStoreCollectionInfoData(id?.ToString(), name, resourceType, systemData, collectionId, collectionName, claim, areAllSubscriptionsSelected, areAllItemsApproved, approveAllItemsModifiedOn, subscriptionsList, isEnabled, numberOfOffers, appliedRules);
        }

        // MarketplaceAdminApprovalRequestData: old used ResourceIdentifier id
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MarketplaceAdminApprovalRequestData MarketplaceAdminApprovalRequestData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string offerId, string displayName, string publisherId, MarketplaceAdminAction? adminAction, IEnumerable<string> approvedPlans, string comment, string administrator, IEnumerable<PlanRequesterDetails> plans, IEnumerable<Guid> collectionIds, Uri iconUri)
        {
            return MarketplaceAdminApprovalRequestData(id?.ToString(), name, resourceType, systemData, offerId, displayName, publisherId, adminAction, approvedPlans, comment, administrator, plans, collectionIds, iconUri);
        }

        // MarketplaceApprovalRequestData: old used ResourceIdentifier id
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MarketplaceApprovalRequestData MarketplaceApprovalRequestData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string offerId, string offerDisplayName, string publisherId, IEnumerable<PrivateStorePlanDetails> plansDetails, bool? isClosed, long? messageCode)
        {
            return MarketplaceApprovalRequestData(id?.ToString(), name, resourceType, systemData, offerId, offerDisplayName, publisherId, plansDetails, isClosed, messageCode);
        }
    }
}
