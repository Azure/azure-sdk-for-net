// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}/checkTrialAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Locations_CheckTrialAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            return await GetMockableAvsSubscriptionResource(subscriptionResource).CheckAvsTrialAvailabilityAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Return trial status for subscription by region
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}/checkTrialAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Locations_CheckTrialAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            return GetMockableAvsSubscriptionResource(subscriptionResource).CheckAvsTrialAvailability(location, cancellationToken);
        }
    }
}
