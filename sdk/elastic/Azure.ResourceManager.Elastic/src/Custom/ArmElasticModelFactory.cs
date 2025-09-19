// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Elastic.Models
{
    public static partial class ArmElasticModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MarketplaceSaaSInfo"/>. </summary>
        /// <param name="marketplaceSubscriptionId"> Marketplace Subscription. </param>
        /// <param name="marketplaceName"> Marketplace Subscription Details: SAAS Name. </param>
        /// <param name="marketplaceResourceId"> Marketplace Subscription Details: Resource URI. </param>
        /// <param name="marketplaceStatus"> Marketplace Subscription Details: SaaS Subscription Status. </param>
        /// <param name="billedAzureSubscriptionId"> The Azure Subscription ID to which the Marketplace Subscription belongs and gets billed into. </param>
        /// <param name="isSubscribed"> Flag specifying if the Marketplace status is subscribed or not. </param>
        /// <returns> A new <see cref="Models.MarketplaceSaaSInfo"/> instance for mocking. </returns>
        // Added this method due to the change of MarketplaceSaaSInfoMarketplaceSubscription model in api version 2025-06-01 to have more properties
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MarketplaceSaaSInfo MarketplaceSaaSInfo(ResourceIdentifier marketplaceSubscriptionId = null, string marketplaceName = null, string marketplaceResourceId = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, bool? isSubscribed = null)
        {
            return MarketplaceSaaSInfo(
                marketplaceSubscriptionId != null ? MarketplaceSaaSInfoMarketplaceSubscription(id: marketplaceSubscriptionId?.ToString()) : null,
                marketplaceName,
                marketplaceResourceId,
                marketplaceStatus,
                billedAzureSubscriptionId,
                isSubscribed);
        }
    }
}
