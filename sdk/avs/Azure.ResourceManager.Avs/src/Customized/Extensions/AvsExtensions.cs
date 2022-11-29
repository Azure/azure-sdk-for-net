// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Avs
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Avs. </summary>
    public static partial class AvsExtensions
    {
        /// <summary>
        /// Return trial status for subscription by region
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}/checkTrialAvailability
        /// Operation Id: Locations_CheckTrialAvailability
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            AvsSku sku = null;
            return await GetExtensionClient(subscriptionResource).CheckAvsTrialAvailabilityAsync(location, sku, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Return trial status for subscription by region
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}/checkTrialAvailability
        /// Operation Id: Locations_CheckTrialAvailability
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            AvsSku sku = null;
            return GetExtensionClient(subscriptionResource).CheckAvsTrialAvailability(location, sku, cancellationToken);
        }
    }
}
