// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    internal partial class TopologyImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ITopology> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ITopology>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.ITopology;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.INetworkWatcher;
            }
        }

        /// <summary>
        /// Gets GUID representing the id.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITopology.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets name of resource group this topology represents.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITopology.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets The resources in this topology.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.TopologyResource> Microsoft.Azure.Management.Network.Fluent.ITopology.Resources
        {
            get
            {
                return this.Resources() as System.Collections.Generic.IReadOnlyDictionary<string,Models.TopologyResource>;
            }
        }

        /// <summary>
        /// Gets the datetime when the topology was last modified.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.ITopology.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets the datetime when the topology was initially created for the resource
        /// group.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.ITopology.CreatedTime
        {
            get
            {
                return this.CreatedTime();
            }
        }
    }
}