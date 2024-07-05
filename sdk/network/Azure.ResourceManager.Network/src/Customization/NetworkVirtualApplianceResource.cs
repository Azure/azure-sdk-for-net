// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A Class representing a NetworkVirtualAppliance along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NetworkVirtualApplianceResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNetworkVirtualApplianceResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNetworkVirtualAppliance method.
    /// </summary>
    public partial class NetworkVirtualApplianceResource : ArmResource
    {
        /// <summary>
        /// Restarts one or more VMs belonging to the specified Network Virtual Appliance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkVirtualAppliances_Restart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVirtualApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkVirtualApplianceInstanceIds"> Specifies a list of virtual machine instance IDs from the Network Virtual Appliance VM instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> RestartAsync(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds, CancellationToken cancellationToken)
        {
            ArmOperation<NetworkVirtualApplianceInstanceIds> result = await RestartAsync(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken).ConfigureAwait(false);
            return result.GetRawResponse();
        }

        /// <summary>
        /// Restarts one or more VMs belonging to the specified Network Virtual Appliance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkVirtualAppliances_Restart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVirtualApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkVirtualApplianceInstanceIds"> Specifies a list of virtual machine instance IDs from the Network Virtual Appliance VM instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Restart(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds, CancellationToken cancellationToken)
        {
            ArmOperation<NetworkVirtualApplianceInstanceIds> result = Restart(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken);
            return result.GetRawResponse();
        }
    }
}
