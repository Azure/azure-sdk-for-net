// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.ContainerServiceFleet.Mocking
{
    // Because of a breaking change, it was manually added back to ensure compatibility.
    public partial class MockableContainerServiceFleetSubscriptionResource
    {
        /// <summary>
        /// Lists fleets in the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/fleets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fleets_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ContainerServiceFleetResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerServiceFleetResource> GetContainerServiceFleetsAsync(CancellationToken cancellationToken = default)
        {
            return GetContainerServiceFleetsAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// Lists fleets in the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/fleets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fleets_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerServiceFleetResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerServiceFleetResource> GetContainerServiceFleets(CancellationToken cancellationToken = default)
        {
            return GetContainerServiceFleets(null, null, cancellationToken);
        }
    }
}
