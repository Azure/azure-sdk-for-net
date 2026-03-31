// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated flatten produced property name "EdgeSubscriptionId",
// but baseline API had "SubscriptionId". This adds a backward-compatible alias property.

using Azure.Core;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class DataBoxEdgeDevicePatch
    {
        /// <summary> The Id of the default resource group to use for Edge Subscription. </summary>
        public ResourceIdentifier SubscriptionId
        {
            get => EdgeSubscriptionId;
            set => EdgeSubscriptionId = value;
        }
    }
}
