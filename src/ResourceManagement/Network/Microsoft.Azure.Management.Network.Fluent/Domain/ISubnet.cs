// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet  :
        IWrapper<Models.SubnetInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetwork>
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