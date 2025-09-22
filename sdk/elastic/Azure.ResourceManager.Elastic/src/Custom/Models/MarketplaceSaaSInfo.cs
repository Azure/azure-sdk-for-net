// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Elastic.Models
{
    // Added this custom code because the MarketplaceSaaSInfoMarketplaceSubscription model gained additional properties in API version 2025-06-01.
    public partial class MarketplaceSaaSInfo
    {
        /// <summary> Gets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier MarketplaceSubscriptionId
        {
            get => MarketplaceSubscription?.Id;
        }
    }
}
