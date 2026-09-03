// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Mocking
{
    public partial class MockableNetworkCloudSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(CancellationToken cancellationToken)
            => GetNetworkCloudBareMetalMachinesAsync(null, null, cancellationToken);

        /// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(CancellationToken cancellationToken)
            => GetNetworkCloudBareMetalMachines(null, null, cancellationToken);
    }
}
