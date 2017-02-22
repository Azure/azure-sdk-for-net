// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet  :
        IHasInner<Models.SubnetInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetwork>
    {
        /// <summary>Gets the network interface IP configurations that are associated with this subnet.
        /// Note that this call may result in multiple calls to Azure to fetch all the referenced interfaces each time it is invoked.
        /// </summary>
        ISet<INicIPConfiguration> GetNetworkInterfaceIPConfigurations();

        /// <summary>
        /// Gets the number of network interface IP configurations associated with this subnet.
        /// </summary>
        int NetworkInterfaceIPConfigurationCount { get; }

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

        /// <summary>
        /// Gets the resource ID of the network security group associated with this subnet, if any.
        /// </summary>
        string NetworkSecurityGroupId { get; }

        /// <return>
        /// The route table associated with this subnet, if any
        /// Note that this method will result in a call to Azure each time it is invoked.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.IRouteTable GetRouteTable();
    }
}