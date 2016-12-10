// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet :
        IWrapper<Models.SubnetInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetwork>
    {
        string AddressPrefix { get; }

        string RouteTableId { get; }

        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        string NetworkSecurityGroupId { get; }

        Microsoft.Azure.Management.Network.Fluent.IRouteTable GetRouteTable();
    }
}