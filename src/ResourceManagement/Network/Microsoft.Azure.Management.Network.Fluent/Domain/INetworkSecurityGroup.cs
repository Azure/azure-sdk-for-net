// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkSecurityGroup.Update;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup  :
        IGroupableResource<INetworkManager, NetworkSecurityGroupInner>,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        IUpdatable<NetworkSecurityGroup.Update.IUpdate>,
        IHasAssociatedSubnets
    {
        /// <summary>
        /// Gets default security rules associated with this network security group, indexed by their name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> DefaultSecurityRules { get; }

        /// <summary>
        /// Gets security rules associated with this network security group, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> SecurityRules { get; }

        /// <summary>
        /// Gets the ids of the network interfaces associated with this network security group.
        /// </summary>
        System.Collections.Generic.ISet<string> NetworkInterfaceIds { get; }
    }
}