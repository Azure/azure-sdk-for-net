// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Marketplace.Models
{
    public static partial class ArmMarketplaceModelFactory
    {
        /// <summary> Creates an approval request model for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource metadata. </param>
        /// <param name="offerId"> The offer identifier. </param>
        /// <param name="offerDisplayName"> The offer display name. </param>
        /// <param name="publisherId"> The publisher identifier. </param>
        /// <param name="plansDetails"> The plan details. </param>
        /// <param name="isClosed"> Whether the request is closed. </param>
        /// <param name="messageCode"> The request message code. </param>
        /// <returns> An approval request model. </returns>
        public static MarketplaceApprovalRequestData MarketplaceApprovalRequestData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string offerId = default, string offerDisplayName = default, string publisherId = default, IEnumerable<PrivateStorePlanDetails> plansDetails = default, bool? isClosed = default, long? messageCode = default)
        {
            var properties = offerId is null && offerDisplayName is null && publisherId is null && plansDetails is null && isClosed is null && messageCode is null
                ? null
                : new RequestApprovalProperties(offerId, offerDisplayName, publisherId, (plansDetails ?? new ChangeTrackingList<PrivateStorePlanDetails>()).ToList(), isClosed, messageCode, default);
            return new MarketplaceApprovalRequestData(id, name, resourceType, systemData, default, properties);
        }

        /// <summary> Creates an admin approval request model for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource metadata. </param>
        /// <param name="offerId"> The offer identifier. </param>
        /// <param name="displayName"> The offer display name. </param>
        /// <param name="publisherId"> The publisher identifier. </param>
        /// <param name="adminAction"> The administrator action. </param>
        /// <param name="approvedPlans"> The approved plan identifiers. </param>
        /// <param name="comment"> The administrator comment. </param>
        /// <param name="administrator"> The administrator. </param>
        /// <param name="plans"> The plan requesters. </param>
        /// <param name="collectionIds"> The associated collection identifiers. </param>
        /// <param name="iconUri"> The offer icon URI. </param>
        /// <returns> An admin approval request model. </returns>
        public static MarketplaceAdminApprovalRequestData MarketplaceAdminApprovalRequestData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string offerId = default, string displayName = default, string publisherId = default, MarketplaceAdminAction? adminAction = default, IEnumerable<string> approvedPlans = default, string comment = default, string administrator = default, IEnumerable<PlanRequesterDetails> plans = default, IEnumerable<Guid> collectionIds = default, Uri iconUri = default)
        {
            var properties = offerId is null && displayName is null && publisherId is null && adminAction is null && approvedPlans is null && comment is null && administrator is null && plans is null && collectionIds is null && iconUri is null
                ? null
                : new AdminRequestApprovalProperties(offerId, displayName, publisherId, adminAction, (approvedPlans ?? new ChangeTrackingList<string>()).ToList(), comment, administrator, (plans ?? new ChangeTrackingList<PlanRequesterDetails>()).ToList(), (collectionIds ?? new ChangeTrackingList<Guid>()).ToList(), iconUri, default);
            return new MarketplaceAdminApprovalRequestData(id, name, resourceType, systemData, default, properties);
        }
    }
}
