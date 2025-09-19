// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Elastic.Models
{
    // Added this custom code due to the change of MarketplaceSaaSInfoMarketplaceSubscription model in api version 2025-06-01 to have more properties
    public partial class MarketplaceSaaSInfo
    {
        /// <summary> Gets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier MarketplaceSubscriptionId
        {
            get => MarketplaceSubscription?.Id != null ? new ResourceIdentifier(MarketplaceSubscription.Id) : null;
        }
    }
}
