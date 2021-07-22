﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary> Subscription policies. </summary>
    public partial class SubscriptionPolicies
    {
        /// <summary> Initializes a new instance of SubscriptionPolicies. </summary>
        internal SubscriptionPolicies()
        {
        }

        /// <summary> Initializes a new instance of SubscriptionPolicies. </summary>
        /// <param name="locationPlacementId"> The subscription location placement ID. The ID indicates which regions are visible for a subscription. For example, a subscription with a location placement Id of Public_2014-09-01 has access to Azure public regions. </param>
        /// <param name="quotaId"> The subscription quota ID. </param>
        /// <param name="spendingLimit"> The subscription spending limit. </param>
        internal SubscriptionPolicies(string locationPlacementId, string quotaId, SpendingLimit? spendingLimit)
        {
            LocationPlacementId = locationPlacementId;
            QuotaId = quotaId;
            SpendingLimit = spendingLimit;
        }

        /// <summary> The subscription location placement ID. The ID indicates which regions are visible for a subscription. For example, a subscription with a location placement Id of Public_2014-09-01 has access to Azure public regions. </summary>
        public string LocationPlacementId { get; }
        /// <summary> The subscription quota ID. </summary>
        public string QuotaId { get; }
        /// <summary> The subscription spending limit. </summary>
        public SpendingLimit? SpendingLimit { get; }
    }
}
