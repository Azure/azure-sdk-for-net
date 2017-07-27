// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Update;
    using Microsoft.Azure.Management.Network.Fluent.NextHop.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Entry point for Network Watcher API in Azure.
    /// </summary>
    public interface INetworkWatcher  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager,Models.NetworkWatcherInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<NetworkWatcher.Update.IUpdate>
    {
        /// <summary>
        /// Gets First step specifying the parameters to get next hop for the VM.
        /// </summary>
        /// <summary>
        /// Gets a stage to specify target vm.
        /// </summary>
        NextHop.Definition.IWithTargetResource NextHop { get; }

        /// <summary>
        /// Gets entry point to manage packet captures associated with network watcher.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IPacketCaptures PacketCaptures { get; }

        /// <summary>
        /// Gets network topology of a given resource group asynchronously.
        /// </summary>
        /// <param name="targetResourceGroup">The name of the target resource group to perform getTopology on.</param>
        /// <return>Current network topology by resource group.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.ITopology> GetTopologyAsync(string targetResourceGroup, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets network topology of a given resource group.
        /// </summary>
        /// <param name="targetResourceGroup">The name of the target resource group to perform getTopology on.</param>
        /// <return>Current network topology by resource group.</return>
        Microsoft.Azure.Management.Network.Fluent.ITopology GetTopology(string targetResourceGroup);

        /// <summary>
        /// Gets the information on the configuration of flow log.
        /// </summary>
        /// <param name="nsgId">The name of the target resource group to get flow log status for.</param>
        /// <return>Information on the configuration of flow log.</return>
        Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings GetFlowLogSettings(string nsgId);

        /// <summary>
        /// Gets Verify IP flow from the specified VM to a location given the currently configured NSG rules.
        /// </summary>
        /// <summary>
        /// Gets a stage to specify target vm.
        /// </summary>
        VerificationIPFlow.Definition.IWithTargetResource VerifyIPFlow { get; }

        /// <summary>
        /// Gets the information on the configuration of flow log asynchronously.
        /// </summary>
        /// <param name="nsgId">The name of the target resource group to get flow log status for.</param>
        /// <return>Information on the configuration of flow log.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings> GetFlowLogSettingsAsync(string nsgId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the configured and effective security group rules on the specified VM.
        /// </summary>
        /// <param name="vmId">ID of the target VM.</param>
        /// <return>The configured and effective security group rules on the specified VM.</return>
        Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView GetSecurityGroupView(string vmId);

        /// <summary>
        /// Gets the configured and effective security group rules on the specified VM asynchronously.
        /// </summary>
        /// <param name="vmId">ID of the target VM.</param>
        /// <return>The configured and effective security group rules on the specified VM.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView> GetSecurityGroupViewAsync(string vmId, CancellationToken cancellationToken = default(CancellationToken));
    }
}