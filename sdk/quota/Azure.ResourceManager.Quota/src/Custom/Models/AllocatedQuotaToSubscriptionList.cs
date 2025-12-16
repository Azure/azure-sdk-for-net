// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Quota.Models
{
    /// <summary> Quota allocated to subscriptions. </summary>
    internal partial class AllocatedQuotaToSubscriptionList
    {
        /// <summary> List of Group Quota Limit allocated to subscriptions. </summary>
        [WirePath("value")]
        public IReadOnlyList<SubscriptionAllocatedQuota> Value { get; }
    }
}
