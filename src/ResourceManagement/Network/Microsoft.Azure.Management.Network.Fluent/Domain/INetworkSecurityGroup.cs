// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.NetworkSecurityGroupInner>,
        IUpdatable<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>
    {
        /// <returns>security rules associated with this network security group, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> SecurityRules { get; }

        /// <returns>default security rules associated with this network security group, indexed by their name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> DefaultSecurityRules { get; }

        /// <returns>list of the ids of the network interfaces associated with this network security group</returns>
        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }

        /// <returns>virtual networks associated with this security group,</returns>
        /// <returns>indexed by the names of the specific subnets referencing this security group</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet> ListAssociatedSubnets();

    }
}