// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Topology info object, associated with network watcher.
    /// </summary>
    public interface ITopology  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.TopologyInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ITopology>
    {
        /// <summary>
        /// Gets name of resource group this topology represents.
        /// </summary>
        string ResourceGroupName { get; }

        /// <summary>
        /// Gets the datetime when the topology was last modified.
        /// </summary>
        System.DateTime LastModifiedTime { get; }

        /// <summary>
        /// Gets the datetime when the topology was initially created for the resource
        /// group.
        /// </summary>
        System.DateTime CreatedTime { get; }

        /// <summary>
        /// Gets The resources in this topology.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.TopologyResource> Resources { get; }

        /// <summary>
        /// Gets GUID representing the id.
        /// </summary>
        string Id { get; }
    }
}