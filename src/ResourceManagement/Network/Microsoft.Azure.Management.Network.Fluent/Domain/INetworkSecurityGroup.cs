// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager,Models.NetworkSecurityGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<NetworkSecurityGroup.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IHasAssociatedSubnets
    {
        /// <summary>
        /// Gets default security rules associated with this network security group, indexed by their name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> DefaultSecurityRules { get; }

        /// <summary>
        /// Gets the IDs of the network interfaces associated with this network security group.
        /// </summary>
        System.Collections.Generic.ISet<string> NetworkInterfaceIds { get; }

        /// <summary>
        /// Gets security rules associated with this network security group, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> SecurityRules { get; }
    }
}