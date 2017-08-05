// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SubnetInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.INetwork>
    {
        /// <summary>
        /// Gets the address space prefix, in CIDR notation, assigned to this subnet.
        /// </summary>
        string AddressPrefix { get; }

        /// <summary>
        /// Gets the resource ID of the route table associated with this subnet, if any.
        /// </summary>
        string RouteTableId { get; }

        /// <return>
        /// The network security group associated with this subnet, if any
        /// Note that this method will result in a call to Azure each time it is invoked.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        /// <return>
        /// Network interface IP configurations that are associated with this subnet
        /// Note that this call may result in multiple calls to Azure to fetch all the referenced interfaces each time it is invoked.
        /// </return>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration> GetNetworkInterfaceIPConfigurations();

        /// <summary>
        /// Gets the resource ID of the network security group associated with this subnet, if any.
        /// </summary>
        string NetworkSecurityGroupId { get; }

        /// <summary>
        /// Gets number of network interface IP configurations associated with this subnet.
        /// </summary>
        int NetworkInterfaceIPConfigurationCount { get; }

        /// <return>
        /// The route table associated with this subnet, if any
        /// Note that this method will result in a call to Azure each time it is invoked.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.IRouteTable GetRouteTable();
    }
}