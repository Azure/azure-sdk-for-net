// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableAvsSubscriptionResource : ArmResource
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
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(AzureLocation location, CancellationToken cancellationToken)
        {
            return await CheckAvsTrialAvailabilityAsync(location, null, cancellationToken).ConfigureAwait(false);
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
        /// <param name="location"> Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(AzureLocation location, CancellationToken cancellationToken)
        {
            return CheckAvsTrialAvailability(location, null, cancellationToken);
        }
    }
}
