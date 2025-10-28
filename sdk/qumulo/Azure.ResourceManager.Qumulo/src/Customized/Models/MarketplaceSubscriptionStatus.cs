// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Qumulo.Models
{
    /// <summary> The MarketplaceSubscriptionStatus. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MarketplaceSubscriptionStatus
    {
        /// <summary> PendingFulfillmentStart. </summary>
        PendingFulfillmentStart,
        /// <summary> Subscribed. </summary>
        Subscribed,
        /// <summary> Suspended. </summary>
        Suspended,
        /// <summary> Unsubscribed. </summary>
        Unsubscribed
    }
}
