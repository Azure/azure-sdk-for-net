// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Client-side representation of the configuration of flow log, associated with network watcher and an Azure resource.
    /// </summary>
    public interface IFlowLogSettings  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.FlowLogInformationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<FlowLogSettings.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings>
    {
        /// <summary>
        /// Gets the ID of the resource to configure for flow logging.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string TargetResourceId { get; }

        /// <summary>
        /// Gets the number of days to retain flow log records.
        /// </summary>
        int RetentionDays { get; }

        /// <summary>
        /// Gets true if retention policy enabled, false otherwise.
        /// </summary>
        bool IsRetentionEnabled { get; }

        /// <summary>
        /// Gets true if logging is enabled, false otherwise.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets network security group id these flow log settings apply to.
        /// </summary>
        string NetworkSecurityGroupId { get; }

        /// <summary>
        /// Gets the id of the storage account used to store the flow log.
        /// </summary>
        string StorageId { get; }
    }
}