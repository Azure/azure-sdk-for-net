// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Update;
    using Microsoft.Azure.Management.Network.Fluent.NextHop.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    internal partial class NetworkWatcherImpl 
    {
        /// <summary>
        /// Gets the information on the configuration of flow log.
        /// </summary>
        /// <param name="nsgId">The name of the target resource group to get flow log status for.</param>
        /// <return>Information on the configuration of flow log.</return>
        Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetFlowLogSettings(string nsgId)
        {
            return this.GetFlowLogSettings(nsgId) as Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings;
        }

        /// <summary>
        /// Gets First step specifying the parameters to get next hop for the VM.
        /// </summary>
        /// <summary>
        /// Gets a stage to specify target vm.
        /// </summary>
        NextHop.Definition.IWithTargetResource Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.NextHop
        {
            get
            {
                return this.NextHop() as NextHop.Definition.IWithTargetResource;
            }
        }

        /// <summary>
        /// Gets the configured and effective security group rules on the specified VM asynchronously.
        /// </summary>
        /// <param name="vmId">ID of the target VM.</param>
        /// <return>The configured and effective security group rules on the specified VM.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView> Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetSecurityGroupViewAsync(string vmId, CancellationToken cancellationToken)
        {
            return await this.GetSecurityGroupViewAsync(vmId, cancellationToken) as Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView;
        }

        /// <summary>
        /// Gets network topology of a given resource group asynchronously.
        /// </summary>
        /// <param name="targetResourceGroup">The name of the target resource group to perform getTopology on.</param>
        /// <return>Current network topology by resource group.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ITopology> Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetTopologyAsync(string targetResourceGroup, CancellationToken cancellationToken)
        {
            return await this.GetTopologyAsync(targetResourceGroup, cancellationToken) as Microsoft.Azure.Management.Network.Fluent.ITopology;
        }

        /// <summary>
        /// Gets network topology of a given resource group.
        /// </summary>
        /// <param name="targetResourceGroup">The name of the target resource group to perform getTopology on.</param>
        /// <return>Current network topology by resource group.</return>
        Microsoft.Azure.Management.Network.Fluent.ITopology Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetTopology(string targetResourceGroup)
        {
            return this.GetTopology(targetResourceGroup) as Microsoft.Azure.Management.Network.Fluent.ITopology;
        }

        /// <summary>
        /// Gets Verify IP flow from the specified VM to a location given the currently configured NSG rules.
        /// </summary>
        /// <summary>
        /// Gets a stage to specify target vm.
        /// </summary>
        VerificationIPFlow.Definition.IWithTargetResource Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.VerifyIPFlow
        {
            get
            {
                return this.VerifyIPFlow() as VerificationIPFlow.Definition.IWithTargetResource;
            }
        }

        /// <summary>
        /// Gets the configured and effective security group rules on the specified VM.
        /// </summary>
        /// <param name="vmId">ID of the target VM.</param>
        /// <return>The configured and effective security group rules on the specified VM.</return>
        Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetSecurityGroupView(string vmId)
        {
            return this.GetSecurityGroupView(vmId) as Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView;
        }

        /// <summary>
        /// Gets the information on the configuration of flow log asynchronously.
        /// </summary>
        /// <param name="nsgId">The name of the target resource group to get flow log status for.</param>
        /// <return>Information on the configuration of flow log.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings> Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.GetFlowLogSettingsAsync(string nsgId, CancellationToken cancellationToken)
        {
            return await this.GetFlowLogSettingsAsync(nsgId, cancellationToken) as Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings;
        }

        /// <summary>
        /// Gets entry point to manage packet captures associated with network watcher.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IPacketCaptures Microsoft.Azure.Management.Network.Fluent.INetworkWatcher.PacketCaptures
        {
            get
            {
                return this.PacketCaptures() as Microsoft.Azure.Management.Network.Fluent.IPacketCaptures;
            }
        }
    }
}