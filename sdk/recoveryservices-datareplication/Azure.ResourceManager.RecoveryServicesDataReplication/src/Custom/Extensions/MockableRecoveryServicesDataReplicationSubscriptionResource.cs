// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesDataReplication.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Mocking
{
    /// <summary> A class to add extension methods to <see cref="SubscriptionResource"/>. </summary>
    public partial class MockableRecoveryServicesDataReplicationSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Checks the resource name availability.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataReplication/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> Resource details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use CheckDataReplicationNameAvailabilityAsync instead.", false)]
        public virtual async Task<Response<DataReplicationNameAvailabilityResult>> PostCheckNameAvailabilityAsync(AzureLocation location, DataReplicationNameAvailabilityContent content = null, CancellationToken cancellationToken = default)
            => await CheckDataReplicationNameAvailabilityAsync(location, content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Checks the resource name availability.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataReplication/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> Resource details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use CheckDataReplicationNameAvailability instead.", false)]
        public virtual Response<DataReplicationNameAvailabilityResult> PostCheckNameAvailability(AzureLocation location, DataReplicationNameAvailabilityContent content = null, CancellationToken cancellationToken = default)
            => CheckDataReplicationNameAvailability(location, content, cancellationToken);
    }
}
