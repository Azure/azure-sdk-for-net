// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Update;
    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        IWrapper<Microsoft.Azure.Management.Network.Models.NetworkSecurityGroupInner>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Update.IUpdate>
    {
        /// <returns>security rules associated with this network security group, indexed by their names</returns>
        IDictionary<string,Microsoft.Azure.Management.Fluent.Network.INetworkSecurityRule> SecurityRules ();

        /// <returns>default security rules associated with this network security group, indexed by their name</returns>
        IDictionary<string,Microsoft.Azure.Management.Fluent.Network.INetworkSecurityRule> DefaultSecurityRules ();

        /// <returns>list of the ids of the network interfaces associated with this network security group</returns>
        List<string> NetworkInterfaceIds { get; }

        /// <returns>virtual networks associated with this security group,</returns>
        /// <returns>indexed by the names of the specific subnets referencing this security group</returns>
        List<Microsoft.Azure.Management.Fluent.Network.ISubnet> ListAssociatedSubnets ();

    }
}